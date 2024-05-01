using Vibro.API1.Models;

namespace Vibro.API1.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
