using CarCatalog.Core.ViewModels.Door;

namespace CarCatalog.Core.Contracts.Door
{
    public interface IDoorService
    {
        Task<List<DoorViewModel>> GetDoorsByBodyTypeIdAsync(int bodyTypeId);
    }
}
