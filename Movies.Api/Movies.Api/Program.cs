using Movies.Api.CustomMIddlewares;
using Movies.Api.Helpers;

var builder = WebApplication.CreateBuilder(args);

ApplicationSetupHelper.SetupLogger(builder);
ApplicationSetupHelper.AddBaseService(builder.Services);



// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();
ConfigureRequestPipeline(app);

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    ServiceCollectionExtension.AddCommonServices(services);
    ServiceCollectionExtension.AddCommonRepositories(services);
    ServiceCollectionExtension.BindApiSettings(services, configuration);

    ApplicationSetupHelper.RegisterSqlServer(services, configuration);
    ApplicationSetupHelper.RegisterAutomapper(services);

    // CORS
    //var corsSettings = configuration.GetSection("CorsSettings").Get<CorsSettings>();
    //services.AddDefaultCorsFromSettings(corsSettings);

    services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            var frontend_url = configuration.GetSection("frontend_url").Get<string>();
            builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
        });
    });

}

static void ConfigureRequestPipeline(WebApplication app)
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseCors();
    app.UseAuthorization();
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.MapControllers();
    app.Run();
}
