namespace CarCatalog.Core.ViewModels.Home
{
    using CarCatalog.Core.ViewModels.Car;

    public class HomeViewModel
    {
        public IEnumerable<RandomCars> RandomCars { get; set; }
    }
}
