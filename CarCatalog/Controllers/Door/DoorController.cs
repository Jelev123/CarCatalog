using CarCatalog.Core.Contracts.Door;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.Door
{
    public class DoorController : Controller
    {
        private readonly IDoorService doorService;

        public DoorController(IDoorService doorService)
        {
            this.doorService = doorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoorsByBodyTypeIdAsync(int bodyTypeId) => Json(await this.doorService.GetDoorsByBodyTypeIdAsync(bodyTypeId));
    }
}
