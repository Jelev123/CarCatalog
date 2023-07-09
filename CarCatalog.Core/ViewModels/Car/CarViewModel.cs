using CarCatalog.Core.ViewModels.Door;
using CarCatalog.Core.ViewModels.Gear;
using Microsoft.AspNetCore.Http;

namespace CarCatalog.Core.ViewModels.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public int Year { get; set; }

        public IFormFileCollection GalleryFiles { get; set; }

        public List<CarGalleryModel> Gallery { get; set; }

        public string CoverPhoto { get; set; }

        public string TransmisionType { get; set; }

        public int TransmisionId { get; set; }

        public List<GearViewModel> Gears { get; set; }

        public int GearId { get; set; }

        public int DoorId { get; set; }

        public int DoorCount { get; set; }

        public int GearCount { get; set; }

        public string BodyTypeName { get; set; }

        public int BodyTypeId { get; set; }

        public List<DoorViewModel> Doors { get; set; }

        public int HorsePower { get; set; }

        public string FuelType { get; set; }

    }
}
