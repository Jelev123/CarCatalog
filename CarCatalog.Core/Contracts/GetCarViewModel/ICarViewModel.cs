using CarCatalog.Core.ViewModels.Car;

namespace CarCatalog.Core.Contracts.GetCarViewModel;

public interface ICarViewModel
{
    Task<List<CarViewModel>> GetCarViewModelsAsync();
}
