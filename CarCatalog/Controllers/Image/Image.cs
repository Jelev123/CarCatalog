namespace CarCatalog.Controllers.Image
{
    using CarCatalog.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class Image : Controller
    {
        private readonly IImageService imageService;

        public Image(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<IActionResult> DeleteImageAsync(string id, int carId)
        {
            await this.imageService.DeleteImageAsync(id);
            return this.RedirectToAction("Edit", "Car", new { id = carId });
        }
    }
}
