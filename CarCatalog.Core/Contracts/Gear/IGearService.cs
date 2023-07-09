using CarCatalog.Core.ViewModels.Gear;

namespace CarCatalog.Core.Contracts.Gear
{
    public interface IGearService
    {
        List<GearViewModel> GetGearsForTransmissionId(int transmisionId);
    }
}
