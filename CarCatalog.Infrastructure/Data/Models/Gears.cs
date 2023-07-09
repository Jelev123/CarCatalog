using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Infrastructure.Data.Models
{
    public class Gears
    {
        [Key]
        public int GearId { get; set; }

        public int Value { get; set; }

        public ICollection<TransmisionsGears> Transmisions { get; set; }
    }
}
