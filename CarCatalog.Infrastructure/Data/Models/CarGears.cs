namespace CarCatalog.Infrastructure.Data.Models
{
    public class CarGears
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int GearId { get; set; }

        public Gears Gear { get; set; }
    }
}
