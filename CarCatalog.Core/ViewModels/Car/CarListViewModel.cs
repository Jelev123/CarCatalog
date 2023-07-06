using CarCatalog.Core.ViewModels.Paging;

namespace CarCatalog.Core.ViewModels.Car
{
    public class CarListViewModel : PagingViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
