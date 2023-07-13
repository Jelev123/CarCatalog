using CarCatalog.Core;
using CarCatalog.Core.Contracts;
using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.Services.BodyType;
using CarCatalog.Core.Services.Car;
using CarCatalog.Core.Services.Image;
using CarCatalog.Core.Services.Transmision;
using CarCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using static Dropbox.Api.TeamLog.EventCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Transient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ITransmisionService, TransmisionService>();
builder.Services.AddScoped<IBodyTypeService, BodyTypeService>();

var app = builder.Build();


app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// In the Configure method
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
