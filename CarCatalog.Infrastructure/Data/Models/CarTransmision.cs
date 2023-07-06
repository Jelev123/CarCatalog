namespace CarCatalog.Infrastructure.Data.Models
{
    public class CarTransmision
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int TransmisionId { get; set; }

        public Transmision Transmision { get; set; }
    }
}
