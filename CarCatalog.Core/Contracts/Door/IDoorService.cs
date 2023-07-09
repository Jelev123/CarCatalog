using CarCatalog.Core.ViewModels.Door;

namespace CarCatalog.Core.Contracts.Door
{
    public interface IDoorService
    {
        List<DoorViewModel> GetDoorsByBodyTypeId(int bodyTypeId);
    }
}
