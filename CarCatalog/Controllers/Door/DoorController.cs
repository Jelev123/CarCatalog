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
        public IActionResult GetDoorsByBodyTypeId(int bodyTypeId) => Json(doorService.GetDoorsByBodyTypeId(bodyTypeId));
    }
}
