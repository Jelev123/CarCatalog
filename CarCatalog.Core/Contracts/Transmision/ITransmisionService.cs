namespace CarCatalog.Core.Contracts.Transmision
{
    using CarCatalog.Core.ViewModels.Transmision;

    public interface ITransmisionService
    {
        Task<IEnumerable<TransmisionViewModel>> AllTransmisionsAsync<T>();
    }
}
