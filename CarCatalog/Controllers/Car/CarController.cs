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

        public IActionResult Edit(int id)
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

            var car = this.carService.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(CarViewModel car ,int id)
        {
            this.carService.EditCar(car , id);
            return this.RedirectToAction("GetCarById","Car", new { id = id });
        }

        public IActionResult GetCarById(int id) => this.View(carService.GetById(id));

        public IActionResult GetAllCars(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 1;

            var viewModel = new CarListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                CarsCount = this.carService.GetCarCount(),
                Cars = carService.GetAll(id, ItemsPerPage)
            };

            return View(viewModel); 
        }
    }
}
