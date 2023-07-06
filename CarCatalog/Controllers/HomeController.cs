using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.ViewModels.Home;
using CarCatalog.Infrastructure.Data;
using CarCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;
        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            this.carService = carService;
        }

        public IActionResult Index()
        {
            var randomCars = new HomeViewModel()
            {
                RandomCars = this.carService.RandomCars(6)
            };

            return View(randomCars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}