namespace CarCatalog.Infrastructure.Data.Models
{
    public class TransmisionsGears
    {
        public int Id { get; set; }

        public int TransmisionId { get; set; }

        public Transmision Transmision { get; set; }

        public int GearId { get; set; }

        public Gears Gear { get; set; }
    }
}
