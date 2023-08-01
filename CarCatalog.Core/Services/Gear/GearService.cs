namespace CarCatalog.Core.Services.Gear
{
    using CarCatalog.Core.Contracts.Gear;
    using CarCatalog.Core.ViewModels.Gear;
    using CarCatalog.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class GearService : IGearService
    {
        private readonly ApplicationDbContext data;

        public GearService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<List<GearViewModel>> GetGearsForTransmissionIdAsync(int transmisionId)
            => await this.data.TransmisionsGears
                .Where(tg => tg.TransmisionId == transmisionId)
                .Select(tg => new GearViewModel
                {
                    GearId = tg.GearId,
                    Value = tg.Gear.Value,
                })
                .ToListAsync();
    }
}
