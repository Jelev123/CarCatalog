namespace CarCatalog.Infrastructure.Data.Models
{
    public class BodyType
    {
        public int BodyTypeId { get; set; }

        public string BodyTypeName { get; set; }

        public ICollection<BodyTypesDoors> BodyTypesDoors { get; set; } = new HashSet<BodyTypesDoors>();
    }
}
