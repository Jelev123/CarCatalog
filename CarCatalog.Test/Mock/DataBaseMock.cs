namespace CarCatalog.Test.Mock
{
    using CarCatalog.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DataBaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

                return new ApplicationDbContext(dbContext);
            }
        }

    }
}
