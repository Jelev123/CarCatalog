using CarCatalog.Core.ViewModels.BodyType;

namespace CarCatalog.Core.Contracts.BodyType
{
    public interface IBodyTypeService
    {
        IEnumerable<BodyTypeViewModel> AllBodyTypes<T>();
    }
}
