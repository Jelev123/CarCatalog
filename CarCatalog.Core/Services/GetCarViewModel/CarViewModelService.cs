using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.Contracts.Door;
using CarCatalog.Core.Contracts.Gear;
using CarCatalog.Core.Contracts.GetCarViewModel;
using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Core.ViewModels.Door;
using CarCatalog.Core.ViewModels.Gear;
using CarCatalog.Core.ViewModels.Transmision;

namespace CarCatalog.Core.Services.GetCarViewModel
{
    public class CarViewModelService : ICarViewModel
    {
        private readonly ITransmisionService transmisionService;
        private readonly IBodyTypeService bodyTypeService;
        private readonly IDoorService doorService;
        private readonly IGearService gearService;

        public CarViewModelService(ITransmisionService transmisionService, IBodyTypeService bodyTypeService, IDoorService doorService, IGearService gearService)
        {
            this.transmisionService = transmisionService;
            this.bodyTypeService = bodyTypeService;
            this.doorService = doorService;
            this.gearService = gearService;
        }

        public async Task<List<CarViewModel>> GetCarViewModelsAsync()
        {
            var transmisions = await this.transmisionService.AllTransmisionsAsync<TransmisionViewModel>();
            var bodyTypes = await this.bodyTypeService.AllBodyTypesAsync<BodyTypeViewModel>();

            var carViewModels = new List<CarViewModel>();

            foreach (var transmision in transmisions)
            {
                var gears = await this.gearService.GetGearsForTransmissionIdAsync(transmision.TransmisionId);
                var transmission = new CarViewModel
                {
                    TransmisionId = transmision.TransmisionId,
                    TransmisionType = transmision.TransmisionType,
                    Gears = gears.Select(gear => new GearViewModel { GearId = gear.GearId, Value = gear.Value }).ToList()
                };
                carViewModels.Add(transmission);
            }

            foreach (var body in bodyTypes)
            {
                var doors = await this.doorService.GetDoorsByBodyTypeIdAsync(body.BodyTypeId);
                var bodyType = new CarViewModel
                {
                    BodyTypeId = body.BodyTypeId,
                    BodyTypeName = body.BodyTypeName,
                    Doors = doors.Select(door => new DoorViewModel { DoorId = door.DoorId, DoorsCount = door.DoorsCount }).ToList()
                };
                carViewModels.Add(bodyType);
            }

            return carViewModels;
        }
    }
}
