using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Infrastructure.Data.Models
{
    public class Images
    {
        [Key]
        public string ImageId { get; set; }

        public string ImageName { get; set; }

        public string? URL { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
