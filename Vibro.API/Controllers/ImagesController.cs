using Microsoft.AspNetCore.Mvc;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;

namespace Vibro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController() : ControllerBase
    {
        private readonly IImageRepository? _imageRepository;

        public ImagesController(IImageRepository? imageRepository) : this()
        {
            _imageRepository = imageRepository;
        }

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var image = new Image
            {
                File = request.File,
                FileExtension = Path.GetExtension(request.File.FileName),
                FileSize = request.File.Length,
                FileName = request.FileName,
                FileDescription = request.FileDescription
            };

            await _imageRepository?.Upload(image)!;

            return Ok(image);
        }

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
