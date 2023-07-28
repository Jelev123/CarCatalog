namespace CarCatalog.Test.Services
{
    using CarCatalog.Core.Services.Car;
    using CarCatalog.Infrastructure.Data.Models;
    using CarCatalog.Test.Mock;

    public class CarServiceTest
    {
        private const int CarId = 1;
        private const int InvalidCarId = 100;

        [Fact]
        public async Task ShouldReturnCarById()
        {
            var carService = await this.GetCarService();
            var result = await carService.GetByIdAsync(CarId);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldReturnNullIfItNotValidId()
        {
            var carService = await this.GetCarService();
            var result = await carService.GetByIdAsync(InvalidCarId);
            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldReturnAllCars()
        {
            var carService = await this.GetCarService();
            var result = await carService.GetAllAsync(1, 2);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldReturnZeroIfDoesntHaveCars()
        {
            using var data = DataBaseMock.Instance;
            var carService = new CarService(data, null);
            var result = await carService.GetAllAsync(1, 2);
            Assert.Empty(result);
        }

        [Fact]
        public async Task ShouldDeleteTheCarWithThisId()
        {
            using var data = DataBaseMock.Instance;
            var carService = await this.GetCarService();
            await carService.DeleteCarAsync(CarId);
            var deletedCar = await data.Cars.FindAsync(CarId);
            Assert.Null(deletedCar);

        }

        [Fact]
        public async Task ShouldReturnCarCount()
        {
            var carService = await this.GetCarService();
            var result = await carService.GetCarCountAsync();
            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetCarCountAsync_ReturnsZeroWhenNoCarsInDatabase()
        {
            using var data = DataBaseMock.Instance;
            var carService = new CarService(data, null);
            var result = await carService.GetCarCountAsync();
            Assert.Equal(0, result);
        }

        private async Task<CarService> GetCarService()
        {
            var data = DataBaseMock.Instance;
            var cars = new List<Car>();

            var car1 = new Car()
            {
                CarId = 1,
                CarBrand = "Porche",
                CarModel = "911",
                FuelType = "Gasoline",
            };

            var car2 = new Car()
            {
                CarId = 2,
                CarBrand = "McLaren",
                CarModel = "Artura",
                FuelType = "Gasoline",
            };

            cars.AddRange(new[] { car1, car2 });
            data.Cars.AddRange(cars);
            data.SaveChanges();
            return new CarService(data, null);
        }
    }
}
