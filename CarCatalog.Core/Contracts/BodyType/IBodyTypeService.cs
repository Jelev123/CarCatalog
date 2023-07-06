using CarCatalog.Core.ViewModels.BodyType;

namespace CarCatalog.Core.Contracts.BodyType
{
    public interface IBodyTypeService
    {
        void AddBodyTypes(BodyTypeViewModel bodyTypeViewModel);

        IEnumerable<BodyTypeViewModel> AllBodyTypes<T>();
    }
}
