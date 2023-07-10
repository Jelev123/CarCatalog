using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.Transmision;
using CarCatalog.Infrastructure.Data;

namespace CarCatalog.Core.Services.Transmision
{
    public class TransmisionService : ITransmisionService
    {
        private readonly ApplicationDbContext data;

        public TransmisionService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<TransmisionViewModel> AllTransmisions<T>()
        {
            return this.data.Transmisions
                .Select(x => new TransmisionViewModel()
                {
                    TransmisionId = x.TransmisionId,
                    TransmisionType = x.TransmisionType,
                });
        }
    }
}
