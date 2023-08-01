namespace CarCatalog.Core.Services.Car
{
    using CarCatalog.Core.Contracts;
    using CarCatalog.Core.Contracts.Car;
    using CarCatalog.Core.ViewModels.Car;
    using CarCatalog.Infrastructure.Data;
    using CarCatalog.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext data;
        private readonly IImageService imageService;

        public CarService(ApplicationDbContext data, IImageService imageService)
        {
            this.data = data;
            this.imageService = imageService;
        }

        public async Task AddCarsAsync(CarViewModel addCar)
        {
            await this.imageService.CheckGalleryAsync(addCar);
            var car = new Car()
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

            var transmision = this.data.TransmisionsGears.FirstOrDefault(t => t.GearId == addCar.GearId);

            if (transmision != null)
            {
                car.CarTransmisions.Add(new CarTransmision
                {
                    Transmision = transmision.Transmision,
                    CarId = car.CarId,
                    TransmisionId = addCar.TransmisionId,
                });
            }

            var bodyType = this.data.BodyTypesDoors.FirstOrDefault(b => b.BodyTypeId == addCar.BodyTypeId);

            if (bodyType != null)
            {
                car.CarBodyTypes.Add(new CarBodyType
                {
                    BodyType = bodyType.BodyType,
                    CarId = car.CarId,
                    BodyTypeId = addCar.BodyTypeId,
                });
            }

            var carDoors = this.data.Doors.FirstOrDefault(d => d.DoorId == addCar.DoorId);

            if (carDoors != null)
            {
                if (carDoors != null)
                {
                    car.CarDoors.Add(new CarDoors
                    {
                        CarId = car.CarId,
                        DoorId = addCar.DoorId,
                        Door = carDoors
                    });
                }
            }

            var carGears = this.data.Gears.FirstOrDefault(g => g.GearId == addCar.GearId);

            if (carGears != null)
            {
                car.CarGears.Add(new CarGears
                {
                    CarId = car.CarId,
                    GearId = addCar.GearId,
                    Gear = carGears
                });
            }

            await this.data.Cars.AddAsync(car);
            await this.data.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = this.data.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            data.Remove(car);
            await data.SaveChangesAsync();
        }

        public async Task EditCarAsync(CarViewModel editCar, int id)
        {
            await imageService.CheckGalleryAsync(editCar);

            var car = this.data.Cars
                 .Include(c => c.CarTransmisions)
                     .ThenInclude(ct => ct.Transmision)
                 .Include(c => c.CarBodyTypes)
                     .ThenInclude(cb => cb.BodyType)
                 .Include(c => c.CarGears)
                     .ThenInclude(cg => cg.Gear)
                 .Include(c => c.CarDoors)
                     .ThenInclude(cd => cd.Door)
                 .FirstOrDefault(x => x.CarId == id);


            if (car != null)
            {
                car.CarBrand = editCar.CarBrand;
                car.CarModel = editCar.CarModel;
                car.Year = editCar.Year;
                car.HorsePower = editCar.HorsePower;
                car.FuelType = editCar.FuelType;


                var transmision = car.CarTransmisions.FirstOrDefault();
                if (transmision != null)
                {
                    if (editCar.TransmisionId != 0)
                    {
                        car.CarTransmisions.Remove(transmision);

                        var newTransmision = new CarTransmision
                        {
                            TransmisionId = editCar.TransmisionId,
                            CarId = car.CarId
                        };

                        car.CarTransmisions.Add(newTransmision);
                    }
                }

                var bodyType = car.CarBodyTypes.FirstOrDefault();
                if (bodyType != null)
                {
                    if (editCar.BodyTypeId != 0)
                    {
                        car.CarBodyTypes.Remove(bodyType);

                        var newBodyType = new CarBodyType
                        {
                            BodyTypeId = editCar.BodyTypeId,
                            CarId = car.CarId
                        };

                        car.CarBodyTypes.Add(newBodyType);
                    }
                }

                var door = car.CarDoors.FirstOrDefault();
                if (door != null)
                {
                    if (editCar.DoorId != 0)
                    {
                        car.CarDoors.Remove(door);

                        var newDoor = new CarDoors
                        {
                            DoorId = editCar.DoorId,
                            CarId = car.CarId
                        };

                        car.CarDoors.Add(newDoor);
                    }
                }

                var gear = car.CarGears.FirstOrDefault();
                if (gear != null)
                {

                    if (editCar.GearId != 0)
                    {
                        car.CarGears.Remove(gear);
                        var newGear = new CarGears
                        {
                            GearId = editCar.GearId,
                            CarId = car.CarId
                        };

                        car.CarGears.Add(newGear);
                    }
                }

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
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync(int page, int itemsPerPage)
            => await this.data.Cars
                .Select(car => new CarViewModel()
                {
                    Id = car.CarId,
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    Year = car.Year,
                    CoverPhoto = car.Images.FirstOrDefault().URL,
                })
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

        public async Task<CarViewModel> GetByIdAsync(int id)
        {
            var doorCount = (from carDoor in this.data.CarDoors
                             join door in this.data.Doors on carDoor.DoorId equals door.DoorId
                             where carDoor.CarId == id
                             select door.DoorCount)
                            .FirstOrDefault();

            var gearCount = (from carGear in this.data.CarGears
                             join gear in this.data.Gears on carGear.GearId equals gear.GearId
                             where carGear.CarId == id
                             select gear.Value)
                            .FirstOrDefault();

            return await this.data.Cars
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
                    DoorCount = doorCount,
                    TransmisionType = car.CarTransmisions.FirstOrDefault().Transmision.TransmisionType,
                    GearCount = gearCount,
                    Gallery = car.Images.Select(img => new CarGalleryModel
                    {
                        ImageId = img.ImageId,
                        Name = img.ImageName,
                        URL = img.URL,
                        CarId = car.CarId,
                    }).ToList(),
                }).FirstOrDefaultAsync();

        }

        public async Task<int> GetCarCountAsync()
            => await this.data.Cars.CountAsync();
        

        public async Task<IEnumerable<RandomCars>> RandomCarsAsync(int count)
            => await this.data.Cars
               .OrderBy(s => Guid.NewGuid())
               .Select(car => new RandomCars()
               {
                   Id = car.CarId,
                   CarBrand = car.CarBrand,
                   CarModel = car.CarModel,
                   Year = car.Year,
                   CoverPhoto = car.Images.FirstOrDefault().URL,
               })
               .Take(count)
               .ToListAsync();
    }
}
