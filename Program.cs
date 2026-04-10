using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi;

// Servicios
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<Datos.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

// Middlewares

app.MapControllers();
app.Run();
