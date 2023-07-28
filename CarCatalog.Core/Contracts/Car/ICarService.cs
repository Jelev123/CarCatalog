namespace CarCatalog.Core.Contracts.Car
{
    using CarCatalog.Core.ViewModels.Car;

    public interface ICarService
    {
        Task AddCarsAsync(CarViewModel addCar);

        Task DeleteCarAsync(int id);

        Task EditCarAsync(CarViewModel editCar, int id);

        Task<CarViewModel> GetByIdAsync(int id);

        Task<IEnumerable<CarViewModel>> GetAllAsync(int page, int itemsPerPage);

        Task<IEnumerable<RandomCars>> RandomCarsAsync(int count);

        Task<int> GetCarCountAsync();
    }
}
