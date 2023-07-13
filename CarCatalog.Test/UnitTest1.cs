using CarCatalog.Controllers.Image;
using CarCatalog.Core.Services.Car;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Infrastructure.Data.Models;

namespace CarCatalog.Test
{
    public class UnitTest1
    {
        [Fact]
       
          using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
    public class CarServiceTests
    {
        [TestMethod]
        public void GetById_WithValidId_ReturnsCarViewModel()
        {
            // Arrange
            int carId = 1;

            var mockData = new Mock<IDataContext>();

            var carService = new CarService(mockData.Object);

            // Mock data for CarDoors
            var mockCarDoors = new List<CarDoors>
        {
            new CarDoors { CarId = carId, DoorId = 1 },
            new CarDoors { CarId = carId, DoorId = 2 },
            new CarDoors { CarId = carId, DoorId = 3 }
        }.AsQueryable();

            mockData.Setup(d => d.CarDoors).Returns(mockCarDoors);

            // Mock data for Doors
            var mockDoors = new List<Door>
        {
            new Door { DoorId = 1, DoorCount = 2 },
            new Door { DoorId = 2, DoorCount = 4 },
            new Door { DoorId = 3, DoorCount = 4 }
        }.AsQueryable();

            mockData.Setup(d => d.Doors).Returns(mockDoors);

            // Mock data for CarGears
            var mockCarGears = new List<CarGears>
        {
            new CarGears { CarId = carId, GearId = 1 },
            new CarGears { CarId = carId, GearId = 2 },
            new CarGears { CarId = carId, GearId = 3 }
        }.AsQueryable();

            mockData.Setup(d => d.CarGears).Returns(mockCarGears);

            // Mock data for Gears
            var mockGears = new List<Gear>
        {
            new Gear { GearId = 1, Value = 5 },
            new Gear { GearId = 2, Value = 6 },
            new Gear { GearId = 3, Value = 6 }
        }.AsQueryable();

            mockData.Setup(d => d.Gears).Returns(mockGears);

            // Mock data for Cars
            var mockCars = new List<Car>
        {
            new Car
            {
                CarId = carId,
                CarBrand = "Toyota",
                CarModel = "Camry",
                Year = 2022,
                HorsePower = 200,
                FuelType = "Gasoline",
                CarBodyTypes = new List<CarBodyType>
                {
                    new CarBodyType
                    {
                        BodyType = new BodyType { BodyTypeName = "Sedan" }
                    }
                },
                CarTransmisions = new List<CarTransmision>
                {
                    new CarTransmision
                    {
                        Transmision = new Transmision { TransmisionType = "Automatic" }
                    }
                },
                Images = new List<Images>
                {
                    new Images { ImageId = "1", ImageName = "car1.jpg", URL = "https://example.com/car1.jpg" },
                    new Images { ImageId = "2", ImageName = "car2.jpg", URL = "https://example.com/car2.jpg" }
                }
            }
        }.AsQueryable();

            mockData.Setup(d => d.Cars).Returns(mockCars);

            // Act
            var result = carService.GetById(carId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(carId, result.Id);
            Assert.AreEqual("Toyota", result.CarBrand);
            Assert.AreEqual("Camry", result.CarModel);
            Assert.AreEqual(2022, result.Year);
            Assert.AreEqual(200, result.HorsePower);
            Assert.AreEqual("Gasoline", result.FuelType);
            Assert.AreEqual("Sedan", result.BodyTypeName);
            Assert.AreEqual(2, result.DoorCount);
            Assert.AreEqual("Automatic", result.TransmisionType);
            Assert.AreEqual(5, result.GearCount);
            Assert.AreEqual(2, result.Gallery.Count);
            Assert.AreEqual("1", result.Gallery[0].ImageId);
            Assert.AreEqual("car1.jpg", result.Gallery[0].Name);
            Assert.AreEqual("https://example.com/car1.jpg", result.Gallery[0].URL);
            Assert.AreEqual(carId, result.Gallery[0].CarId);
        }
    }


}
}