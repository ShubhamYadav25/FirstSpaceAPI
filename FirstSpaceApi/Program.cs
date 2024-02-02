using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Services.Service;
using FirstSpaceApi.Shared.Database;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Database.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer("Data Source = SHUBHAM_YADAV; Initial Catalog = firstSpaceDb; Integrated Security = True; Encrypt = True; Trust Server Certificate=True"));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITokenServices, TokenServices>();
builder.Services.AddTransient<ISharedService, SharedService>();
builder.Services.AddTransient<IGenericServices, GenericServices>(); 
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
