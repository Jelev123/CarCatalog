using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.Api.Controllers.Image
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ImageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImages(List<IFormFile> images)
        {
            if (images == null || images.Count == 0)
            {
                return BadRequest("No images uploaded.");
            }

            var dropboxToken = _configuration["Dropbox:AccessToken"];
            var dropboxClient = new DropboxClient(dropboxToken);

            var imageUrls = new List<string>();

            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

                    using (var stream = image.OpenReadStream())
                    {
                        var uploadResult = await dropboxClient.Files.UploadAsync(
                            "/" + fileName,
                            WriteMode.Overwrite.Instance,
                            body: stream
                        );

                        var sharedLink = await dropboxClient.Sharing.CreateSharedLinkWithSettingsAsync(uploadResult.PathDisplay);

                        var imageUrl = sharedLink.Url;
                        imageUrls.Add(imageUrl);
                    }
                }
            }

            return Ok(imageUrls);
        }
    }
}
