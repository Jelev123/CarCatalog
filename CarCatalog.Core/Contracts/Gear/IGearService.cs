namespace CarCatalog.Core.Contracts.Gear
{
    using CarCatalog.Core.ViewModels.Gear;

    public interface IGearService
    {
        Task<List<GearViewModel>> GetGearsForTransmissionIdAsync(int transmisionId);
    }
}
