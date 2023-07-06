using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.ViewModels.Transmision;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.Transmision
{
    public class Transmision : Controller
    {
        private readonly ITransmisionService transmisionService;

        public Transmision(ITransmisionService transmisionService)
        {
            this.transmisionService = transmisionService;
        }

        public IActionResult AddTransmision()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTransmision(TransmisionViewModel transmisionViewModel)
        {
            this.transmisionService.AddTransmisions(transmisionViewModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
