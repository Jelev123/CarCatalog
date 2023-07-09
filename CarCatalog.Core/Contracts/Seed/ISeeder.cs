namespace CarCatalog.Core.Models
{
    using CarCatalog.Infrastructure.Data;
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
