using CarCatalog.Core.ViewModels.BodyType;

namespace CarCatalog.Core.Contracts.BodyType
{
    public interface IBodyTypeService
    {
        Task<IEnumerable<BodyTypeViewModel>> AllBodyTypesAsync<T>();
    }
}
