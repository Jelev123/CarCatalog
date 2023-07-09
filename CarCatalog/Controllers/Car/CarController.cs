using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.Contracts.Door;
using CarCatalog.Core.Contracts.Gear;
using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Core.ViewModels.Door;
using CarCatalog.Core.ViewModels.Gear;
using CarCatalog.Core.ViewModels.Transmision;
using CarCatalog.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.Car
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ITransmisionService transmisionService;
        private readonly IBodyTypeService bodyTypeService;
        private readonly IGearService gearService;
        private readonly IDoorService doorService;

        public CarController(ICarService carService, ITransmisionService transmisionService, IBodyTypeService bodyTypeService, IGearService gearService, IDoorService doorService)
        {
            this.carService = carService;
            this.transmisionService = transmisionService;
            this.bodyTypeService = bodyTypeService;
            this.gearService = gearService;
            this.doorService = doorService;
        }

        public IActionResult AddCar()
        {
            var transmisions = this.transmisionService.AllTransmisions<TransmisionViewModel>();
            var bodyTypes = this.bodyTypeService.AllBodyTypes<BodyTypeViewModel>();

            var carViewModels = new List<CarViewModel>();

            foreach (var transmision in transmisions)
            {
                var gears = this.gearService.GetGearsForTransmissionId(transmision.TransmisionId);
                var transmission = new CarViewModel
                {
                    TransmisionId = transmision.TransmisionId,
                    TransmisionType = transmision.TransmisionType,
                    Gears = gears.Select(gear => new GearViewModel { GearId = gear.GearId, Value = gear.Value }).ToList()
                };
                carViewModels.Add(transmission);
            }

            foreach (var body in bodyTypes)
            {
                var doors = this.doorService.GetDoorsByBodyTypeId(body.BodyTypeId);
                var bodyType = new CarViewModel
                {
                    BodyTypeId = body.BodyTypeId,
                    BodyTypeName = body.BodyTypeName,
                    Doors = doors.Select(door => new DoorViewModel { DoorId = door.DoorId, DoorsCount = door.DoorsCount }).ToList()
                };
                carViewModels.Add(bodyType);
            }

            ViewData["transmisions"] = carViewModels.Where(c => c.Gears != null);
            ViewData["bodyTypes"] = carViewModels.Where(c => c.Doors != null);

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

            var carViewModels = new List<CarViewModel>();

            foreach (var transmision in transmisions)
            {
                var gears = this.gearService.GetGearsForTransmissionId(transmision.TransmisionId);
                var transmission = new CarViewModel
                {
                    TransmisionId = transmision.TransmisionId,
                    TransmisionType = transmision.TransmisionType,
                    Gears = gears.Select(gear => new GearViewModel { GearId = gear.GearId, Value = gear.Value }).ToList()
                };
                carViewModels.Add(transmission);
            }

            foreach (var body in bodyTypes)
            {
                var doors = this.doorService.GetDoorsByBodyTypeId(body.BodyTypeId);
                var bodyType = new CarViewModel
                {
                    BodyTypeId = body.BodyTypeId,
                    BodyTypeName = body.BodyTypeName,
                    Doors = doors.Select(door => new DoorViewModel { DoorId = door.DoorId, DoorsCount = door.DoorsCount }).ToList()
                };
                carViewModels.Add(bodyType);
            }

            ViewData["transmisions"] = carViewModels.Where(c => c.Gears != null);
            ViewData["bodyTypes"] = carViewModels.Where(c => c.Doors != null);
            ViewData["gears"] = carViewModels;
            ViewData["doors"] = carViewModels;

            var car = this.carService.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(CarViewModel car ,int id)
        {
            this.carService.EditCar(car , id);
            return this.RedirectToAction("GetCarById","Car", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            this.carService.DeleteCar(id);
            return this.RedirectToAction("Index", "Home");
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
