using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Infrastructure.Data;

namespace CarCatalog.Core.Services.BodyType
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly ApplicationDbContext data;

        public BodyTypeService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void AddBodyTypes(BodyTypeViewModel bodyTypeViewModel)
        {
            var bodyType = new Infrastructure.Data.Models.BodyType()
            {
                BodyTypeId = bodyTypeViewModel.BodyTypeId,
                BodyTypeName = bodyTypeViewModel.BodyTypeName,
            };

            data.BodyTypes.Add(bodyType);
            data.SaveChanges();
        }

        public IEnumerable<BodyTypeViewModel> AllBodyTypes<T>()
        {
            return this.data.BodyTypes
                .Select(s => new BodyTypeViewModel
                {
                    BodyTypeId= s.BodyTypeId,
                    BodyTypeName = s.BodyTypeName,
                });
        }
    }
}
