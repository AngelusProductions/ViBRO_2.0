using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
