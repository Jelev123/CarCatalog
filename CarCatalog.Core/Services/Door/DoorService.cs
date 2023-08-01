namespace CarCatalog.Core.Services.Door
{
    using CarCatalog.Core.Contracts.Door;
    using CarCatalog.Core.ViewModels.Door;
    using CarCatalog.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class DoorService : IDoorService
    {
        private readonly ApplicationDbContext data;

        public DoorService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<List<DoorViewModel>> GetDoorsByBodyTypeIdAsync(int bodyTypeId)
            => await this.data.BodyTypesDoors
                .Where(d => d.BodyTypeId == bodyTypeId)
                .Select(d => new DoorViewModel 
                {
                    DoorId = d.DoorId,
                    DoorsCount = d.Door.DoorCount,
                }).ToListAsync();
    }
}
