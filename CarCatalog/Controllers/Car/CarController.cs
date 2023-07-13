using CarCatalog.Core.Constants.Car;
using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.Contracts.Door;
using CarCatalog.Core.Contracts.Gear;
using CarCatalog.Core.Contracts.GetCarViewModel;
using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Core.ViewModels.Door;
using CarCatalog.Core.ViewModels.Gear;
using CarCatalog.Core.ViewModels.Transmision;
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
        private readonly ICarViewModel carViewModelService;

        public CarController(ICarService carService, ITransmisionService transmisionService, IBodyTypeService bodyTypeService, IGearService gearService, IDoorService doorService, ICarViewModel carViewModelService)
        {
            this.carService = carService;
            this.transmisionService = transmisionService;
            this.bodyTypeService = bodyTypeService;
            this.gearService = gearService;
            this.doorService = doorService;
            this.carViewModelService = carViewModelService;
        }

        public async Task<IActionResult> AddCarAsync()
        {
            var carViewModels = await carViewModelService.GetCarViewModelsAsync();

            ViewData["transmisions"] = carViewModels.Where(c => c.Gears != null);
            ViewData["bodyTypes"] = carViewModels.Where(c => c.Doors != null);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCarAsync(CarViewModel addCar)
        {
            var carViewModels = await carViewModelService.GetCarViewModelsAsync();

            ViewData["transmisions"] = carViewModels.Where(c => c.Gears != null);
            ViewData["bodyTypes"] = carViewModels.Where(c => c.Doors != null);

            if (string.IsNullOrEmpty(addCar.CarBrand) || string.IsNullOrEmpty(addCar.CarModel) || string.IsNullOrEmpty(addCar.FuelType))
            {
                return View(addCar);
            }

            if (addCar.HorsePower <= 0 || addCar.TransmisionId <= 0 || addCar.BodyTypeId <= 0 || addCar.GearId <= 0 || addCar.DoorId <= 0)
            {
                return View(addCar);
            }

            if (addCar.GalleryFiles == null)
            {
                return View(addCar);
            }

            await this.carService.AddCarsAsync(addCar);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var carViewModels = await carViewModelService.GetCarViewModelsAsync();

            ViewData["transmisions"] = carViewModels.Where(c => c.Gears != null);
            ViewData["bodyTypes"] = carViewModels.Where(c => c.Doors != null);

            var car = await this.carService.GetByIdAsync(id);
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(CarViewModel car, int id)
        {
            await this.carService.EditCarAsync(car, id);
            return this.RedirectToAction("GetCarById", "Car", new { id = id });
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            await this.carService.DeleteCarAsync(id);
            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetCarByIdAsync(int id) => this.View(await this.carService.GetByIdAsync(id));

        public async Task<IActionResult> GetAllCarsAsync(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new CarListViewModel()
            {
                ItemsPerPage = CarConstants.ItemsPerPage,
                PageNumber = id,
                CarsCount = await this.carService.GetCarCountAsync(),
                Cars = await carService.GetAllAsync(id, CarConstants.ItemsPerPage)
            };

            return View(viewModel);
        }
    }
}
