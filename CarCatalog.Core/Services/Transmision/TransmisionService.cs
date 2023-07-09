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

        public void AddTransmisions(TransmisionViewModel transmisionViewModel)
        {
            //var transmision = new Infrastructure.Data.Models.Transmision
            //{
            //    TransmisionType = transmisionViewModel.TransmisionType,
            //    Gears = transmisionViewModel.Gears,
            //};

            //this.data.Transmisions.Add(transmision);
            //this.data.SaveChanges();
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
