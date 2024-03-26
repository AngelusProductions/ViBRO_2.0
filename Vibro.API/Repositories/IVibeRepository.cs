using Vibro.API.Models;
using Vibro.API.Models.DTO;

namespace Vibro.API.Repositories
{
    public interface IVibeRepository
    {
        Task<List<Vibe>> GetAllAsync();

        Task<Vibe?> GetByIdAsync(Guid id);

        Task<Vibe> CreateAsync(Vibe vibe);

        Task<Vibe?> UpdateAsync(Guid id, Vibe vibe);

        Task<Vibe?> DeleteAsync(Guid id);
    }
}
