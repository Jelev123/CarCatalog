using CarCatalog.Core.ViewModels.Gear;

namespace CarCatalog.Core.Contracts.Gear
{
    public interface IGearService
    {
        Task<List<GearViewModel>> GetGearsForTransmissionIdAsync(int transmisionId);
    }
}
