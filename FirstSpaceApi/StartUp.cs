using FirstSpaceApi.Middlewares;
using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Services.Service;
using FirstSpaceApi.Shared.Database;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Database.Repository;
using Microsoft.EntityFrameworkCore;
using NLog;
using FSServiceProvider = FirstSpaceApi.Services.IService;

public class Startup
{
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "log.config.txt"));

        // Add services to the container.
        services.AddDbContext<DatabaseContext>
            (options => options.UseSqlServer("Data Source = SHUBHAM_YADAV; Initial Catalog = firstSpaceDb; Integrated Security = True; Encrypt = True; Trust Server Certificate=True"));

        // Logger
        services.AddSingleton<IFSLoggerServices, IFSLoggerServices>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<ITokenServices, TokenServices>();
        services.AddTransient<ISharedService, SharedService>();
        services.AddScoped<IUserService,  UserService>();
        services.AddTransient<IGenericServices, GenericServices>();

        // Service provider
        services.AddScoped<FSServiceProvider.IServiceProvider, FirstSpaceApi.Services.Service.ServiceProvider>();


        // Repository Manager 
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {

        // Add error exception handler
        app.UseMiddleware<ErrorExceptionHandler>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}