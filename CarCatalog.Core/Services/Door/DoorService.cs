using CarCatalog.Core.Contracts.Door;
using CarCatalog.Core.ViewModels.Door;
using CarCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Core.Services.Door
{
    public class DoorService : IDoorService
    {
        private readonly ApplicationDbContext data;

        public DoorService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<List<DoorViewModel>> GetDoorsByBodyTypeIdAsync(int bodyTypeId)
        {
            return await this.data.BodyTypesDoors
                .Where(d => d.BodyTypeId == bodyTypeId)
                .Select(d => new DoorViewModel 
                {
                    DoorId = d.DoorId,
                    DoorsCount = d.Door.DoorCount,
                }).ToListAsync();
        }
    }
}
