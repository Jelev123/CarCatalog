using CarCatalog.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Controllers.Image
{
    public class Image : Controller
    {
        private readonly IImageService imageService;

        public Image(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public IActionResult DeleteImage(string id, int productId)
        {
            this.imageService.DeleteImage(id);
            return this.RedirectToAction("Edit", "Car", new { id = productId });
        }
    }
}
