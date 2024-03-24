using Movies.BLL.Interfaces;
using Movies.BLL.Services;
using Movies.DAL.Repositories.Genre;
using Movies.Models.Settings;

namespace Movies.Api.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
        }

        public static void AddCommonRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static void BindApiSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MovieAppSettings>(options => configuration.GetSection("MovieAppSettings").Bind(options));
        }
    }
}
