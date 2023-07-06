namespace CarCatalog.Infrastructure.Data.Models
{
    public class CarBodyType
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int BodyTypeId { get; set; }

        public BodyType BodyType { get; set; }
    }
}
