using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vibro.API.Models.DTO
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadRequestDto : ControllerBase
    {
        public required IFormFile File { get; set; }

        public required string FileName { get; set; }

        public string? FileDescription { get; set; }
    }
}
