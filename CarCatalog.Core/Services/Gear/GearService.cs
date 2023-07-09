using CarCatalog.Core.Contracts.Gear;
using CarCatalog.Core.ViewModels.Gear;
using CarCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Core.Services.Gear
{
    public class GearService : IGearService
    {
        private readonly ApplicationDbContext data;

        public GearService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public List<GearViewModel> GetGearsForTransmissionId(int transmisionId)
        {
            return this.data.TransmisionsGears
                .Where(tg => tg.TransmisionId == transmisionId)
                .Select(tg => new GearViewModel
                {
                    GearId = tg.GearId,
                    Value = tg.Gear.Value,
                })
                .ToList();
        }
    }
}
