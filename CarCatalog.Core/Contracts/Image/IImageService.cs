namespace CarCatalog.Core.Contracts
{
    using CarCatalog.Core.ViewModels.Car;
    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {
        void DeleteImage(string imageId);

        Task CheckGallery(CarViewModel model);

        Task<string> UploadImage(string folderPath, IFormFile file);
    }
}
