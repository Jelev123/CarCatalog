namespace CarCatalog.Test.Controllers
{
    using CarCatalog.Controllers.Car;
    using CarCatalog.Core.Services.BodyType;
    using CarCatalog.Core.Services.Car;
    using CarCatalog.Core.Services.Door;
    using CarCatalog.Core.Services.Gear;
    using CarCatalog.Core.Services.GetCarViewModel;
    using CarCatalog.Core.Services.Transmision;
    using CarCatalog.Core.ViewModels.Car;
    using CarCatalog.Infrastructure.Data.Models;
    using CarCatalog.Test.Mock;
    using Microsoft.AspNetCore.Mvc;

    public class CarControllerTest
    {

        [Fact]

        public async Task GetAllCarAsyncShouldReturnViewWithCorrectModel()
        {
            var data = DataBaseMock.Instance;
            var transmisionService = new TransmisionService(data);
            var doorService = new DoorService(data);
            var bodytypeServuce = new BodyTypeService(data);
            var gearService = new GearService(data);

           var cars = 
                Enumerable
                .Range(0, 10)
                .Select(c => new Car()
                {
                    CarBrand = "Porche",
                    CarModel = "911",
                    FuelType = "Gasoline"
                });

            await data.Cars.AddRangeAsync(cars);
            await data.SaveChangesAsync();

            var carService = new CarService(data, null);
            var carViewModelService = new CarViewModelService(transmisionService, bodytypeServuce, doorService, gearService);

            var carController = new CarController(carService, carViewModelService);

            var result = await carController.GetAllCarsAsync();

            var viewResult = Assert.IsAssignableFrom<IActionResult>(result);

            var viewModel = (viewResult as ViewResult)?.Model;

            var carViewModel = Assert.IsType<CarListViewModel>(viewModel);

            Assert.Equal(1, carViewModel.Cars.Count());
            Assert.NotNull(viewModel);
            Assert.NotNull(result);
        }
    }
}
