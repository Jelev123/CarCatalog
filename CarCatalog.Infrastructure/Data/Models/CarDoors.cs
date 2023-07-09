namespace CarCatalog.Infrastructure.Data.Models
{
    public class CarDoors
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int DoorId { get; set; }

        public Door Door { get; set; }
    }
}
