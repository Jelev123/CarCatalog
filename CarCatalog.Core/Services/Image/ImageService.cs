using CarCatalog.Core.Constants.Car;
using CarCatalog.Core.Contracts;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace CarCatalog.Core.Services.Image
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment environment;


        public ImageService(ApplicationDbContext data, IWebHostEnvironment environment)
        {
            this.data = data;
            this.environment = environment;
        }

        public async Task CheckGallery(CarViewModel model)
        {
            if (model.GalleryFiles != null)
            {
                model.Gallery = new List<CarGalleryModel>();

                foreach (var file in model.GalleryFiles)
                {
                    var gallery = new CarGalleryModel()
                    {
                        Name = file.FileName,
                        URL = await UploadImage(CarConstants.CarImagesFolder, file)
                    };
                    model.Gallery.Add(gallery);
                }
            }
        }


        public async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(environment.WebRootPath, folderPath);

            file.CopyTo(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public void DeleteImage(string imageId)
        {
            var image = data.Images.FirstOrDefault(x => x.ImageId == imageId);

            string filePath = Path.Combine(environment.WebRootPath, image.URL.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            data.Remove(image);
            data.SaveChanges();
        }
    }
}
