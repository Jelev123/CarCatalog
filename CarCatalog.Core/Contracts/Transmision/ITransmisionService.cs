using CarCatalog.Core.ViewModels.Transmision;

namespace CarCatalog.Core.Contracts.Transmision
{
    public interface ITransmisionService
    {
        Task<IEnumerable<TransmisionViewModel>> AllTransmisionsAsync<T>();
    }
}
