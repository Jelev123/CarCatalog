using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Core.ViewModels.Transmision;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.Car
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ITransmisionService transmisionService;
        private readonly IBodyTypeService bodyTypeService;

        public CarController(ICarService carService, ITransmisionService transmisionService, IBodyTypeService bodyTypeService)
        {
            this.carService = carService;
            this.transmisionService = transmisionService;
            this.bodyTypeService = bodyTypeService;
        }

        public IActionResult AddCar()
        {
            var transmisions = this.transmisionService.AllTransmisions<TransmisionViewModel>();
            var bodyTypes = this.bodyTypeService.AllBodyTypes<BodyTypeViewModel>();

            this.ViewData["transmisions"] = transmisions.Select(s => new CarViewModel
            {
               TransmisionType = s.TransmisionType,
               Gears = s.Gears,
            }).ToList();

            this.ViewData["bodyTypes"] = bodyTypes.Select(s => new CarViewModel
            {
                BodyTypeName = s.BodyTypeName,
                Doors = s.Doors,
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddCar(CarViewModel addCar)
        {
            this.carService.AddCars(addCar);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetCarById(int id)
        {
            this.carService.GetById(3);
            return this.View();
        }
    }
}
