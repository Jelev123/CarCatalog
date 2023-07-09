namespace CarCatalog.Infrastructure.Data.Models
{
    public class Transmision
    {
        public int TransmisionId { get; set; }

        public string TransmisionType { get; set; }

        public ICollection<TransmisionsGears> TransmisionsGears { get; set; }
    }
}
