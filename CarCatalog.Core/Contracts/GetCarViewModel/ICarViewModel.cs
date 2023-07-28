namespace CarCatalog.Core.Contracts.GetCarViewModel;
using CarCatalog.Core.ViewModels.Car;

public interface ICarViewModel
{
    Task<List<CarViewModel>> GetCarViewModelsAsync();
}
