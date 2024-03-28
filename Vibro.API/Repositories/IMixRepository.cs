using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public interface IMixRepository
    {
        Task<List<Mix>> GetAllAsync();

        Task<Mix?> GetMixById(Guid id);

        Task<Mix> CreateAsync(Mix mix);

        Task<Mix?> UpdateAsync(Guid id, Mix mix);

        Task<Mix?> DeleteAsync(Guid id);
    }
}
