namespace CarCatalog.Infrastructure.Data.Models
{
    public class Door
    {
        public int DoorId { get; set; }

        public int DoorCount { get; set; }

        public ICollection<BodyTypesDoors> BodyTypesDoors { get; set; } = new HashSet<BodyTypesDoors>();

    }
}
