using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.Transmision;
using CarCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Core.Services.Transmision
{
    public class TransmisionService : ITransmisionService
    {
        private readonly ApplicationDbContext data;

        public TransmisionService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<TransmisionViewModel>> AllTransmisionsAsync<T>()
        {
            return await this.data.Transmisions
                .Select(x => new TransmisionViewModel()
                {
                    TransmisionId = x.TransmisionId,
                    TransmisionType = x.TransmisionType,
                }).ToListAsync();
        }
    }
}
