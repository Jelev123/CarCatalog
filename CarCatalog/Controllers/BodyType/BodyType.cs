using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.ViewModels.BodyType;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.BodyType
{
    public class BodyType : Controller
    {
        private readonly IBodyTypeService bodyTypeService;

        public BodyType(IBodyTypeService bodyTypeService)
        {
            this.bodyTypeService = bodyTypeService;
        }

        public IActionResult AddBodyType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBodyType(BodyTypeViewModel bodyTypeViewModel)
        {
            this.bodyTypeService.AddBodyTypes(bodyTypeViewModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
