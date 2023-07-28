namespace CarCatalog.Core.Contracts.BodyType
{
    using CarCatalog.Core.ViewModels.BodyType;

    public interface IBodyTypeService
    {
        Task<IEnumerable<BodyTypeViewModel>> AllBodyTypesAsync<T>();
    }
}
