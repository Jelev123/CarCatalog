namespace CarCatalog.Core.Contracts.Door
{
    using CarCatalog.Core.ViewModels.Door;

    public interface IDoorService
    {
        Task<List<DoorViewModel>> GetDoorsByBodyTypeIdAsync(int bodyTypeId);
    }
}
