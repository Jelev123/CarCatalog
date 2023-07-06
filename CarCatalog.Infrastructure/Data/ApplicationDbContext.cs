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
        public DbSet<Images> Images { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Transmision> Transmisions { get; set; }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }
        public DbSet<CarTransmision> CarTransmisions { get; set; }
    }
}
