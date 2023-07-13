using CarCatalog.Core.Contracts.Gear;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.Gear
{
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
