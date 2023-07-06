using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Core.ViewModels.Transmision;
using Microsoft.AspNetCore.Http;

namespace CarCatalog.Core.ViewModels.Car
{
    public class CarViewModel
    {
        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public int Year { get; set; }

        public IFormFileCollection GalleryFiles { get; set; }

        public List<CarGalleryModel> Gallery { get; set; }
   
        public string TransmisionType { get; set; }

        public int Gears { get; set; }

        public string BodyTypeName { get; set; }

        public int Doors { get; set; }

        public int HorsePower { get; set; }

        public string FuelType { get; set; }

    }
}
