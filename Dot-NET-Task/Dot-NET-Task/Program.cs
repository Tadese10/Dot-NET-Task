using DotNETTask.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Serilog;

public class Startup
{
    private readonly IConfigurationRoot configRoot;
    private AppSettings AppSettings { get; set; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        Configuration = configuration;

        IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.{env.EnvironmentName}.json");
        configRoot = builder.Build();

        AppSettings = new AppSettings();
        Configuration.Bind(AppSettings);
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
        })
        .AddNewtonsoftJson();

        services.AddInfrastructureServices(Configuration);

        services.AddCoreServices();

        services.AddSwaggerOpenAPI();

        services.AddVersion();

        services.AddHealthCheck(AppSettings, Configuration);

        services.AddFeatureManagement();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(options =>
             options.WithOrigins("http://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod());

        app.ConfigureCustomExceptionMiddleware();

        log.AddSerilog();

        //app.ConfigureHealthCheck();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.ConfigureSwagger();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}