using CarCatalog.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;



namespace CarCatalog.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Gears> Gears { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Transmision> Transmisions { get; set; }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }
        public DbSet<CarTransmision> CarTransmisions { get; set; }
        public DbSet<TransmisionsGears> TransmisionsGears { get; set; }
        public DbSet<BodyTypesDoors> BodyTypesDoors { get; set; }
        public DbSet<CarDoors> CarDoors { get; set; }
        public DbSet<CarGears> CarGears { get; set; }
    }
}
