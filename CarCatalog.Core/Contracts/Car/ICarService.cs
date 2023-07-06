using CarCatalog.Core.ViewModels.Car;

namespace CarCatalog.Core.Contracts.Car
{
    public interface ICarService
    {
        void AddCars(CarViewModel addCar);

        void DeleteCar(int id);

        void EditCar(CarViewModel editCar, int id);

        CarViewModel GetById(int id);

    }
}
