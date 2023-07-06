namespace CarCatalog.Infrastructure.Data.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public string FuelType { get; set; }

        public ICollection<Images> Images { get; set; } = new HashSet<Images>();

        public ICollection<CarTransmision> CarTransmisions { get; set; } = new HashSet<CarTransmision>();

        public ICollection<CarBodyType> CarBodyTypes { get; set; } = new HashSet<CarBodyType>();

    }
}
