using CarCatalog.Core.ViewModels.Transmision;

namespace CarCatalog.Core.Contracts.Transmision
{
    public interface ITransmisionService
    {
       void AddTransmisions(TransmisionViewModel transmisionViewModel);

        IEnumerable<TransmisionViewModel> AllTransmisions<T>();
    }
}
