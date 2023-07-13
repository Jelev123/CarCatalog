using CarCatalog.Core.ViewModels.Door;
using CarCatalog.Core.ViewModels.Gear;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Core.ViewModels.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the car brand.")]
        public string CarBrand { get; set; }

        [Required(ErrorMessage = "Please enter the car model.")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Please enter year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter image.")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<CarGalleryModel> Gallery { get; set; }

        public string CoverPhoto { get; set; }

        [Required(ErrorMessage = "Please enter the transmision.")]
        public string TransmisionType { get; set; }

        public int TransmisionId { get; set; }

        [Required(ErrorMessage = "Please enter the gear.")]
        public List<GearViewModel> Gears { get; set; }

        public int GearId { get; set; }

        public int DoorId { get; set; }

        public int DoorCount { get; set; }

        public int GearCount { get; set; }

        [Required(ErrorMessage = "Please enter the body type.")]
        public string BodyTypeName { get; set; }

        public int BodyTypeId { get; set; }

        [Required(ErrorMessage = "Please enter the door.")]
        public List<DoorViewModel> Doors { get; set; }

        public int HorsePower { get; set; }

        public string FuelType { get; set; }
    }
}
