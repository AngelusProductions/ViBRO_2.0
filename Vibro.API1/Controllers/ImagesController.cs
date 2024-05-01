using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Vibro.API1.Models;
using Vibro.API1.Models.DTO;
using Vibro.API1.Repositories;

namespace Vibro.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController() : ControllerBase
    {
        private readonly IImageRepository? _imageRepository;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(IImageRepository? imageRepository, ILogger<ImagesController> logger) : this()
        {
            _imageRepository = imageRepository;
            _logger = logger;
        }

        // POST: api/Images
       //[HttpPost]
       // public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
       // {
       //     ValidateFileUpload(request);

       //     if (!ModelState.IsValid) return BadRequest(ModelState);

       //     _logger.LogInformation("Uploading image");

       //     var image = new Image
       //     {
       //         File = request.File,
       //         FileExtension = Path.GetExtension(request.File.FileName),
       //         FileSize = request.File.Length,
       //         FileName = request.FileName,
       //         FileDescription = request.FileDescription
       //     };

       //     await _imageRepository?.Upload(image)!;

       //     _logger.LogInformation($"Uploaded image with data: {JsonSerializer.Serialize(image)}");

       //     return Ok(image);
       // }

        private void ValidateFileUpload(ImageUploadRequestDto request) 
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
                ModelState.AddModelError("file", "Unsupported file extension");

            if (request.File.Length > 10485760)
                ModelState.AddModelError("file", "File size exceeds 10MB");
        }
    }
}
