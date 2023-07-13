namespace CarCatalog.Core.Contracts
{
    using CarCatalog.Core.ViewModels.Car;
    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {
        Task DeleteImageAsync(string imageId);

        Task CheckGalleryAsync(CarViewModel model);

        Task<string> UploadImageAsync(string folderPath, IFormFile file);
    }
}
