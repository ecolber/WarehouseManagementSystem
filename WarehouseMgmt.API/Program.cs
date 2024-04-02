using WarehouseMgmt.Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Repositories;
using WarehouseMgmt.Application.Services.Interfaces;
using WarehouseMgmt.Application.Services;
using Serilog.Events;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File("logs\\log.txt")
    .WriteTo.Console()
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddScoped(typeof(IProductTypeRepository), typeof(ProductTypeRepository));
builder.Services.AddScoped(typeof(IMetricUnitRepository), typeof(MetricUnitRepository));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductServices));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryServices));
builder.Services.AddScoped(typeof(IProductTypeService), typeof(ProductTypeServices));
builder.Services.AddScoped(typeof(IMetricUnitService), typeof(MetricUnitServices));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IJWTService), typeof(JWTService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));



//HttpClient client = new();
//client.BaseAddress = new("http://localhost:7001");
//builder.Services.AddSingleton<HttpClient>(client);
//builder.Services.AddHttpClient<CategoryServices>(client =>
//{
//    client.BaseAddress = new Uri("http://localhost:7001");
//});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//Add AutoMapper
//obtiene todos los ensamblados cargados en el dominio de la aplicación actual. 
//Esto significa que AutoMapper buscará en todos estos ensamblados cualquier perfil de mapeo que hayas definido
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
