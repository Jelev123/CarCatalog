namespace CarCatalog.Core.Contracts.Seed.SeedClasses
{
    using CarCatalog.Core.Models;
    using CarCatalog.Infrastructure.Data;
    using CarCatalog.Infrastructure.Data.Models;

    public class TransmisionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Transmisions.Any())
            {
                return;
            }

            var gears = new List<Gears>
            {
                new Gears { Value = 3 },
                new Gears { Value = 4 },
                new Gears { Value = 5 },
                new Gears { Value = 6 },
                new Gears { Value = 7 },
                new Gears { Value = 8 },
                new Gears { Value = 9 },
                new Gears { Value = 10 }
            };

            dbContext.Gears.AddRange(gears);
            await dbContext.SaveChangesAsync();

            var transmissions = new List<Infrastructure.Data.Models.Transmision>
            {
                new Infrastructure.Data.Models.Transmision { TransmisionType = "Manual" },
                new Infrastructure.Data.Models.Transmision { TransmisionType = "Automatic" }
            };

            dbContext.Transmisions.AddRange(transmissions);
            await dbContext.SaveChangesAsync();

            var transmisionGears = new List<TransmisionsGears>();

            foreach (var transmission in transmissions)
            {
                var gearsForTransmission = new List<Gears>();

                if (transmission.TransmisionType == "Manual")
                {
                    gearsForTransmission = gears.Where(g => g.Value >= 4 && g.Value <= 6).ToList();
                }
                else if (transmission.TransmisionType == "Automatic")
                {
                    gearsForTransmission = gears.Where(g => g.Value >= 3 && g.Value <= 10).ToList();
                }

                foreach (var gear in gearsForTransmission)
                {
                    transmisionGears.Add(new TransmisionsGears { TransmisionId = transmission.TransmisionId, GearId = gear.GearId });
                }
            }

            dbContext.TransmisionsGears.AddRange(transmisionGears);
            await dbContext.SaveChangesAsync();
        }
    }
}
