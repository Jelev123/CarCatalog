namespace CarCatalog.Infrastructure.Data.Models
{
    public class BodyTypesDoors
    {
        public int Id { get; set; }

        public int BodyTypeId { get; set; }

        public BodyType BodyType { get; set; }

        public int DoorId { get; set; }

        public Door Door { get; set; }
    }
}
