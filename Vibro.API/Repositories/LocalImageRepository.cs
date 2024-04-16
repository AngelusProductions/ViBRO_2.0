using Vibro.API.Data;
using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public class LocalImageRepository(
        IHostEnvironment webHostEnvironment,
        IHttpContextAccessor httpContextAccessor,
        VibroDbContext dbContext
    ) : IImageRepository
    {
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", 
                image.FileName, image.FileExtension);

            await using var fileStream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(fileStream);

            // https://localhost:7279/images/imageName.jpg
            var request = httpContextAccessor.HttpContext?.Request;
            var urlFilePath = $"{request?.Scheme}://{request?.Host}{request?.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
