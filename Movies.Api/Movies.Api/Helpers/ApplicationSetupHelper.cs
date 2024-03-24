using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Movies.BLL.Automapper;
using Movies.DAL.EF;
using Movies.Models.Generic.Settings;
using Serilog;
using Serilog.Events;
using System.Reflection;

namespace Movies.Api.Helpers
{
    public static class ApplicationSetupHelper
    {
        public static void SetupLogger(WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Assembly", Assembly.GetExecutingAssembly().GetName().Name)
                .WriteTo.File(path: @"logs/msg.log", fileSizeLimitBytes: 1_000_000,
                                                     flushToDiskInterval: TimeSpan.FromSeconds(5),
                                                     shared: true,
                                                     restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
            builder.Host.UseSerilog();
        }

        public static void AddBaseService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddResponseCaching();
            services.AddEndpointsApiExplorer();
            services.AddHttpClient();
            services.AddSwaggerGen();            
        }

        public static void RegisterAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperEfProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static IServiceCollection AddDefaultCorsFromSettings(this IServiceCollection services, CorsSettings settings)
        {
            services.AddCors(delegate (CorsOptions options)
            {
                options.AddPolicy("default", delegate (CorsPolicyBuilder policy)
                {
                    if (settings.AllowedOrigins != null && settings.AllowedOrigins.Length != 0)
                    {
                        bool flag = settings.AllowedHeaders != null && settings.AllowedHeaders.Length != 0;
                        bool flag2 = settings.AllowedMethods != null && settings.AllowedMethods.Length != 0;
                        policy.WithOrigins(settings.AllowedOrigins).WithHeaders(flag ? settings.AllowedHeaders : new string[1] { "*" }).WithMethods(flag2 ? settings.AllowedMethods : new string[1] { "*" });
                        return;
                    }

                    throw new ArgumentException("AllowedOrigins were not provided");
                });
            });
            return services;
        }

        public static void RegisterSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
