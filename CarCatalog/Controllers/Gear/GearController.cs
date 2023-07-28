namespace CarCatalog.Controllers.Gear
{
    using CarCatalog.Core.Contracts.Gear;
    using Microsoft.AspNetCore.Mvc;

    public class GearController : Controller
    {
        private readonly IGearService gearService;

        public GearController(IGearService gearService)
        {
            this.gearService = gearService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGearsForTransmissionIdAsync(int transmisionId) => Json(await this.gearService.GetGearsForTransmissionIdAsync(transmisionId));
    }
}
