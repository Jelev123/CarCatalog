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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Transient);
var serviceCollection = new ServiceCollection();

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ITransmisionService, TransmisionService>();
builder.Services.AddTransient<IBodyTypeService, BodyTypeService>();
builder.Services.AddTransient<IImageService, ImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
