using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi;

// Servicios
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<Datos.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection2")));

builder.Services.AddTransient<ServicioTransient>();
builder.Services.AddScoped<ServicioScope>();
builder.Services.AddSingleton<ServicioSingleton>();
builder.Services.AddSingleton<IRepositorioValores, RepositorioValoresOracle>();



var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

// Middlewares
app.UseLogueaPeticion();
app.UseBloqueaPeticion();
app.MapControllers();
app.Run();
