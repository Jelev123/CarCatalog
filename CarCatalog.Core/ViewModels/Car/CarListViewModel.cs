namespace CarCatalog.Core.ViewModels.Car
{
    using CarCatalog.Core.ViewModels.Paging;

    public class CarListViewModel : PagingViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
