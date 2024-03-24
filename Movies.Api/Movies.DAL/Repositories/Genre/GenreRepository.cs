using Movies.DAL.EF;

namespace Movies.DAL.Repositories.Genre
{
    public interface IGenreRepository : IBaseRepository<Models.EF.Customer.Genre, NoBasicFilter, NoRequestFilter>
    {
    }

    public class GenreRepository : BaseCustomerRepositoty<Models.EF.Customer.Genre, NoBasicFilter, NoRequestFilter>, IGenreRepository
    {
        public GenreRepository(CustomerDbContext context) : base(context)
        {
        }
    }
}
