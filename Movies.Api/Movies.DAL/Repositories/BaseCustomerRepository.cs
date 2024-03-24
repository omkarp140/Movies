using Movies.DAL.EF;
using Movies.Models.Other;

namespace Movies.DAL.Repositories
{
    /// <summary>
    /// Base customer repository that sets CustomerDbContext as Context
    /// </summary>
    public interface IBaseCustomerRepository<TDbEntity, in TFilter, in TRequest>
        : IBaseRepository<TDbEntity, TFilter, TRequest>
        where TDbEntity : class, IIdEntity
        where TFilter : class
        where TRequest : class, IPaging, ISortable

    {
    }

    public abstract class BaseCustomerRepositoty<TDbEntity, TFilter, TRequest>
        : BaseRepository<CustomerDbContext, TDbEntity, TFilter, TRequest>,
            IBaseCustomerRepository<TDbEntity, TFilter, TRequest>
        where TDbEntity : class, IIdEntity
        where TFilter : class
        where TRequest : class, IPaging, ISortable
    {
        protected BaseCustomerRepositoty(CustomerDbContext context) : base(context) { }
    }
}
