using CarCatalog.Core.ViewModels.Gear;
using CarCatalog.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Api.Controllers.Gear
{
    [Route("api/transmissions")]
    [ApiController]
    public class GearController : ControllerBase
    {
        private readonly ApplicationDbContext data;

        public GearController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [HttpGet("{transmissionId}/gears")]
        [Produces("application/json")]
        public IActionResult GetGearsForTransmission(int transmissionId)
        {
            var gears = data.TransmisionsGears
                 .Where(tg => tg.TransmisionId == transmissionId)
                 .Select(tg => new GearViewModel
                 {
                     GearId = tg.GearId,
                     Value = tg.Gear.Value,
                 })
                 .ToList();

            return new JsonResult(gears);
        }
    }
}
