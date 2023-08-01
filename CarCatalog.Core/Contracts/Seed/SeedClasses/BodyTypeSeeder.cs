namespace CarCatalog.Core.Contracts.Seed.SeedClasses
{
    using CarCatalog.Core.Models;
    using CarCatalog.Infrastructure.Data;
    using CarCatalog.Infrastructure.Data.Models;

    public class BodyTypeSeeder : ISeeder
    {  
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BodyTypes.Any() && dbContext.Doors.Any())
            {
                return;
            }

            var bodyTypes = new List<BodyType>
            {
                new BodyType { BodyTypeName = "Sedan" },
                new BodyType { BodyTypeName = "Coupe" },
                new BodyType { BodyTypeName = "Hetch" },
                new BodyType { BodyTypeName = "Combi" },
                new BodyType { BodyTypeName = "Pickup truck" },
            };

            dbContext.BodyTypes.AddRange(bodyTypes);
            await dbContext.SaveChangesAsync();

            var doors = new List<Door>
            {
                new Door { DoorCount = 3 },
                new Door { DoorCount = 5 }
            };

            dbContext.Doors.AddRange(doors);
            await dbContext.SaveChangesAsync();

            var bodyTypeDoors = new List<BodyTypesDoors>();

            var sedan = bodyTypes.First(bt => bt.BodyTypeName == "Sedan");
            var sedanDoor = doors.First(d => d.DoorCount == 5);
            bodyTypeDoors.Add(new BodyTypesDoors { BodyTypeId = sedan.BodyTypeId, DoorId = sedanDoor.DoorId });

            var coupe = bodyTypes.First(bt => bt.BodyTypeName == "Coupe");
            var coupeDoor = doors.First(d => d.DoorCount == 3);
            bodyTypeDoors.Add(new BodyTypesDoors { BodyTypeId = coupe.BodyTypeId, DoorId = coupeDoor.DoorId });

            var combi = bodyTypes.First(bt => bt.BodyTypeName == "Combi");
            var combiDoor = doors.First(d => d.DoorCount == 5);
            bodyTypeDoors.Add(new BodyTypesDoors { BodyTypeId = combi.BodyTypeId, DoorId = combiDoor.DoorId });

            var pickupTruck = bodyTypes.First(bt => bt.BodyTypeName == "Pickup truck");
            var pickupTruckDoor = doors.First(d => d.DoorCount == 5);
            bodyTypeDoors.Add(new BodyTypesDoors { BodyTypeId = pickupTruck.BodyTypeId, DoorId = pickupTruckDoor.DoorId });

            var hetch = bodyTypes.First(bt => bt.BodyTypeName == "Hetch");

            var hetchDoors = doors.Where(d => d.DoorCount == 3 || d.DoorCount == 5).ToList();
            foreach (var door in hetchDoors)
            {
                bodyTypeDoors.Add(new BodyTypesDoors { BodyTypeId = hetch.BodyTypeId, DoorId = door.DoorId });
            }

            dbContext.BodyTypesDoors.AddRange(bodyTypeDoors);
            await dbContext.SaveChangesAsync();

        }
    }
}
