using CarCatalog.Core.ViewModels.Transmision;

namespace CarCatalog.Core.Contracts.Transmision
{
    public interface ITransmisionService
    {
        IEnumerable<TransmisionViewModel> AllTransmisions<T>();
    }
}
