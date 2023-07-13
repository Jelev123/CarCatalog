using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.ViewModels.Home;
using CarCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;
        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var randomCars = new HomeViewModel()
            {
                RandomCars = await this.carService.RandomCarsAsync(6)
            };

            return View(randomCars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}