namespace CarCatalog.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

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
