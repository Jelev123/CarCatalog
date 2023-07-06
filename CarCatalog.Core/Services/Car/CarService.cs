using CarCatalog.Core.Contracts;
using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Infrastructure.Data;
using CarCatalog.Infrastructure.Data.Models;

namespace CarCatalog.Core.Services.Car
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext data;
        private readonly IImageService imageService;

        public CarService(ApplicationDbContext data, IImageService imageService)
        {
            this.data = data;
            this.imageService = imageService;
        }

        public void AddCars(CarViewModel addCar)
        {
            this.imageService.CheckGallery(addCar);
            var car = new Infrastructure.Data.Models.Car()
            {
                CarBrand = addCar.CarBrand,
                CarModel = addCar.CarModel,
                Year = addCar.Year,
                FuelType = addCar.FuelType,
                HorsePower = addCar.HorsePower,
                Images = addCar.Gallery.Select(file => new Images
                {
                    ImageId = Guid.NewGuid().ToString(),
                    ImageName = file.Name,
                    URL = file.URL,
                }).ToList()
            };

            var transmision = new Infrastructure.Data.Models.Transmision { TransmisionType = addCar.TransmisionType, Gears = addCar.Gears };

            car.CarTransmisions.Add(new CarTransmision
            {
                Transmision = transmision,
                Car = car,
                CarId = car.CarId,
                TransmisionId = transmision.TransmisionId,
            });

            var bodyType = new Infrastructure.Data.Models.BodyType { BodyTypeName = addCar.BodyTypeName, Doors = addCar.Doors };

            car.CarBodyTypes.Add(new CarBodyType
            {
                BodyType = bodyType,
                BodyTypeId = bodyType.BodyTypeId,
                Car = car,
                CarId = car.CarId,
            });

            this.data.Cars.Add(car);
            this.data.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = this.data.Cars.FirstOrDefault(x => x.CarId == id);
            data.Remove(car);
        }

        public void EditCar(CarViewModel editCar, int id)
        {
            imageService.CheckGallery(editCar);
            var car = this.data.Cars.FirstOrDefault(x => x.CarId == id);
            var transmision = this.data.Transmisions.FirstOrDefault(s => s.TransmisionType == editCar.TransmisionType);
            var bodyType = this.data.BodyTypes.FirstOrDefault(s => s.BodyTypeName == editCar.BodyTypeName);

            if (car != null)
            {
                car.CarBrand = editCar.CarBrand;
                car.CarModel = editCar.CarModel;
                car.Year = editCar.Year;
                car.HorsePower = editCar.HorsePower;
                car.FuelType = editCar.FuelType;
                bodyType.BodyTypeName = editCar.BodyTypeName;
                bodyType.Doors = editCar.Doors;
                transmision.TransmisionType = editCar.TransmisionType;
                transmision.Gears = editCar.Gears;

                if (editCar.GalleryFiles != null)
                {
                    car.Images.Clear();

                    foreach (var file in editCar.Gallery)
                    {
                        car.Images.Add(new Images()
                        {
                            ImageId = Guid.NewGuid().ToString(),
                            ImageName = file.Name,
                            URL = file.URL,
                            CarId = car.CarId
                        });
                    }
                }
                data.Update(car);
                data.SaveChanges();
            }
        }

        public IEnumerable<CarViewModel> GetAll(int page, int itemsPerPage)
        {
            return this.data.Cars
                .Select(car => new CarViewModel()
                {
                    Id = car.CarId,
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    Year = car.Year,
                    HorsePower = car.HorsePower,
                    FuelType = car.FuelType,
                    BodyTypeName = car.CarBodyTypes.FirstOrDefault().BodyType.BodyTypeName,
                    Doors = car.CarBodyTypes.FirstOrDefault().BodyType.Doors,
                    TransmisionType = car.CarTransmisions.FirstOrDefault().Transmision.TransmisionType,
                    Gears = car.CarTransmisions.FirstOrDefault().Transmision.Gears,
                    CoverPhoto = car.Images.FirstOrDefault().URL,
                }).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
        }

        public CarViewModel GetById(int id)
        {
            return this.data.Cars
                .Where(car => car.CarId == id)
                .Select(car => new CarViewModel()
                {
                    Id = car.CarId,
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    Year = car.Year,
                    HorsePower = car.HorsePower,
                    FuelType = car.FuelType,
                    BodyTypeName = car.CarBodyTypes.FirstOrDefault().BodyType.BodyTypeName,
                    Doors = car.CarBodyTypes.FirstOrDefault().BodyType.Doors,
                    TransmisionType = car.CarTransmisions.FirstOrDefault().Transmision.TransmisionType,
                    Gears = car.CarTransmisions.FirstOrDefault().Transmision.Gears,
                    Gallery = car.Images.Select(img => new CarGalleryModel
                    {
                        ImageId = img.ImageId,
                        Name = img.ImageName,
                        URL = img.URL,
                        CarId = car.CarId,
                    }).ToList(),
                }).FirstOrDefault();

        }

        public int GetCarCount()
        {
            return this.data.Cars.Count();
        }

        public IEnumerable<RandomCars> RandomCars(int count)
        {
            return this.data.Cars
               .OrderBy(s => Guid.NewGuid())
               .Select(car => new RandomCars()
               {
                   Id = car.CarId,
                   CarBrand = car.CarBrand,
                   CarModel = car.CarModel,
                   Year = car.Year,
                   CoverPhoto = car.Images.FirstOrDefault().URL,
               }).ToList()
               .Take(count);
        }
    }
}
