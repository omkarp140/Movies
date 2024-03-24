using Microsoft.EntityFrameworkCore;
using Movies.Models.Generic.Requests;
using Movies.Models.Other;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Movies.DAL.Repositories
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDbEntity">Request model of Entity with which the repository works</typeparam>
    /// <typeparam name="TFilter">Filtering On Service Level, not passed by client</typeparam>
    /// <typeparam name="TRequest">Filtering passed by client (request DTO)</typeparam>
    public interface IBaseRepository<TDbEntity, in TFilter, in TRequest>
        where TDbEntity: class, IIdEntity
        where TFilter: class
        where TRequest: class, IPaging, ISortable
    {
        Task<PagedResultFromDb<TDbEntity>> SelectAsync(TFilter basicFilter, TRequest requestFilter);

        PagedResultFromDb<TDbEntity> Select(TFilter basicFilter, TRequest requestFilter);

        /// <summary>
        /// Allows to make select with applying extra LINQ to IQueryable
        /// </summary>
        /// <param name="basicFilter"></param>
        /// <param name="requestFilter"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<PagedResultFromDb<TDbEntity>> SelectWithCustomQueryableAsync(TFilter basicFilter, TRequest requestFilter, Func<IQueryable<TDbEntity>, IQueryable<TDbEntity>> func);
        PagedResultFromDb<TDbEntity> SelectWithCustomQueryable(TFilter basicFilter, TRequest requestFilter, Func<IQueryable<TDbEntity>, IQueryable<TDbEntity>> func);

        Task<TDbEntity> SelectSingleAsync(int entityId);

        Task<TDbEntity> CreateAsync(TDbEntity entity);

        Task<TDbEntity> UpdateAsync(TDbEntity entity);
        Task DeleteAsync(int entityId);
    }

    public abstract class BaseRepository<TDbContext, TDbEntity, TFilter, TRequest> : IBaseRepository<TDbEntity, TFilter, TRequest>, IDisposable
        where TDbContext: DbContext
        where TDbEntity : class, IIdEntity
        where TFilter : class
        where TRequest : class, IPaging, ISortable
    {
        protected readonly TDbContext Context;

        protected virtual string[] AllowedOrderByColumns { get; set; } = new string[] { };

        protected BaseRepository(TDbContext context)
        {
            Context = context;
        }

        public virtual async Task<PagedResultFromDb<TDbEntity>> SelectAsync(TFilter basicFilter, TRequest requestFilter)
        {
            var queryableEntities = ApplyFiltering(basicFilter, requestFilter);
            return await GetPagedResponseAsync(queryableEntities, requestFilter);
        }

        public virtual PagedResultFromDb<TDbEntity> Select(TFilter basicFilter, TRequest requestFilter)
        {
            var queryableEntities = ApplyFiltering(basicFilter, requestFilter);
            return GetPagedResponseGeneric(queryableEntities, requestFilter);
        }

        public virtual async Task<PagedResultFromDb<TDbEntity>> SelectWithCustomQueryableAsync(TFilter basicFilter, TRequest requestFilter, Func<IQueryable<TDbEntity>, IQueryable<TDbEntity>> func)
        {
            var queryableEntities = ApplyFiltering(basicFilter, requestFilter);
            queryableEntities = func(queryableEntities);
            return await GetPagedResponseAsync(queryableEntities, requestFilter);
        }

        public virtual PagedResultFromDb<TDbEntity> SelectWithCustomQueryable(TFilter basicFilter, TRequest requestFilter,
             Func<IQueryable<TDbEntity>, IQueryable<TDbEntity>> func)
        {
            var queryableEntities = ApplyFiltering(basicFilter, requestFilter);
            queryableEntities = func(queryableEntities);
            return GetPagedResponseGeneric(queryableEntities, requestFilter);
        }

        public virtual async Task<TDbEntity> SelectSingleAsync(int entityId)
        {
            var records = Context.Set<TDbEntity>().AsNoTracking();
            records = ApplyPermanentIncludes(records);
            return await records.FirstOrDefaultAsync(e => e.Id == entityId);
        }
        
        public virtual async Task<TDbEntity> CreateAsync(TDbEntity entity)
        {
            try
            {
                //if (entity.Id == Guid.Empty)
                //    entity.Id = Guid.NewGuid();

                Context.Add(entity);
                await Context.SaveChangesAsync();
            }
            finally
            {
                Context.Entry(entity).State = EntityState.Detached;
            }

            return await SelectSingleAsync(entity.Id);
        }

        public virtual async Task<TDbEntity> UpdateAsync(TDbEntity entity)
        {
            try
            {
                Context.Update(entity);
                await Context.SaveChangesAsync();
            }
            finally
            {
                // Update() causes entity to start being tracked causing issues if same entity is fetched again
                // in different section of code, so detaching it
                Context.Entry(entity).State = EntityState.Detached;
            }
            return await SelectSingleAsync(entity.Id);
        }

        public virtual async Task DeleteAsync(int entityId)
        {
            var entity = await Context.FindAsync<TDbEntity>(entityId);
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }


        #region Helpers

        private IQueryable<TDbEntity> ApplyFiltering(TFilter basicFilter, TRequest requestFilter)
        {
            IQueryable<TDbEntity> queryableEntities = Context.Set<TDbEntity>().AsQueryable().AsNoTracking();

            queryableEntities = ApplyPermanentIncludes(queryableEntities);

            if(!(basicFilter is NoBasicFilter))
                queryableEntities = ApplyBasicFiltering(queryableEntities, basicFilter);

            queryableEntities = ApplyRequestFiltering(queryableEntities, requestFilter);
            queryableEntities = Order(queryableEntities, requestFilter);

            return queryableEntities;
        }

        protected virtual IQueryable<TDbEntity> ApplyBasicFiltering(IQueryable<TDbEntity> records, TFilter filter)
        {
            return records;
        }

        protected virtual IQueryable<TDbEntity> ApplyRequestFiltering(IQueryable<TDbEntity> records, TRequest filter)
        {
            return records;
        }

        protected virtual IQueryable<TDbEntity> ApplyPermanentIncludes(IQueryable<TDbEntity> records)
        {
            return records;
        }

        protected virtual PagedResultFromDb<TDbEntitySpecific> GetPagedResponseGeneric<TDbEntitySpecific>(IQueryable<TDbEntitySpecific> records, TRequest request)
          where TDbEntitySpecific : class
        {
            var count = records.Count();
            records = records.AsNoTracking()
                .Skip((request.PageNumber - 1) * request.PageSize) // Offset
                .Take(request.PageSize); // Takes records per page
            return new PagedResultFromDb<TDbEntitySpecific>(records.ToList(), count);
        }

        /// <summary>
        /// Produces paged response
        /// </summary>
        /// <param name="records">Accepts IQueryable object to fetch data from database</param>
        /// <param name="request">Request inherited from BasePagingRequestDto</param>
        /// <typeparam name="TDbEntity"></typeparam>
        /// <returns></returns>
        protected virtual async Task<PagedResultFromDb<TDbEntity>> GetPagedResponseAsync(IQueryable<TDbEntity> records, TRequest request)
        {
            return await GetPagedResponseGenericAsync(records, request);
            // var count = await records.CountAsync();
            // records = records.AsNoTracking()
            //     .Skip((request.PageNumber - 1) * request.PageSize) // Offset
            //     .Take(request.PageSize); // Takes records per page
            // return new PagedResultFromDb<TDbEntity>(await records.ToListAsync(), count);
        }

        /// <summary>
        /// Produces paged response
        /// </summary>
        /// <param name="records">Accepts IQueryable object to fetch data from database</param>
        /// <param name="request">Request inherited from BasePagingRequestDto</param>
        /// <typeparam name="TDbEntitySpecific"></typeparam>
        /// <returns></returns>
        protected virtual async Task<PagedResultFromDb<TDbEntitySpecific>> GetPagedResponseGenericAsync<TDbEntitySpecific>(IQueryable<TDbEntitySpecific> records, TRequest request)
            where TDbEntitySpecific : class
        {
            var count = await records.CountAsync();
            records = records.AsNoTracking()
                .Skip((request.PageNumber - 1) * request.PageSize) // Offset
                .Take(request.PageSize); // Takes records per page
            return new PagedResultFromDb<TDbEntitySpecific>(await records.ToListAsync(), count);
        }

        protected virtual IQueryable<TDbEntity> Order(IQueryable<TDbEntity> records, TRequest request)
        {
            if(request == null || string.IsNullOrEmpty(request.Sort))
                return records;

            // Example: name, name asc, name desc
            var sortQuery = request.Sort.ToLower();
            IOrderedQueryable<TDbEntity> orderedQuery = null;

            // Parse
            var sortPairs = sortQuery.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in sortPairs)
            {
                var pair = item.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                // Validate amount of elements
                if (pair.Length < 1 || pair.Length > 2) continue;

                // Validate order direction
                if (pair.Length == 2 && (pair[1] != "asc" && pair[1] != "desc"))
                    continue;

                // Validate if order by value is allowed. If AllowedOrderByColumns empty it means that all
                // fields are allowed
                if(AllowedOrderByColumns.Length > 0 && !AllowedOrderByColumns.Select(_ => _.ToLower()).Contains(pair[0]))
                    continue;

                var orderByProp = pair[0];
                var orderByDirc = pair.Length == 2 ? pair[1] : "asc";

                var property = typeof(TDbEntity).GetProperty(orderByProp, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if(property != null)
                {
                    orderedQuery = orderedQuery == null ?
                                                   records.OrderByCustom(property.Name, orderByDirc == "asc") :
                                                   orderedQuery.OrderByCustom(property.Name, orderByDirc == "asc");

                }
            }
            return orderedQuery ?? records;
        }
       
        #endregion
    }

    public class PagedResultFromDb<T>
    {
        public PagedResultFromDb(IEnumerable<T> records,int count)
        {
            RecordsFromDb = records;
            Count = count;
        }
        public IEnumerable<T> RecordsFromDb { get; }
        public int Count { get; set; }
    }

    public sealed class NoBasicFilter
    {

    }

    public sealed class NoRequestFilter : BasePagingWithOrderByRequestDto, IPaging, ISortable
    {
        public string Sort { get; set; }
    }

    public static class CustomQueryableExtensions
    {
        public static IOrderedQueryable<TEntity> OrderByCustom<TEntity>(this IQueryable<TEntity> source, string orderByProp, bool asc)
        {
            string command = asc ? "OrderBy" : "OrderByDescending";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProp);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType }, 
                                                   source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
        }

        public static IOrderedQueryable<TEntity> OrderByCustom<TEntity>(this IOrderedQueryable<TEntity> source, string orderByProperty,
            bool asc)
        {
            string command = asc ? "ThenBy" : "ThenByDescending";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
