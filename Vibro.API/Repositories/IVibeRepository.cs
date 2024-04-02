using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public interface IVibeRepository
    {
        Task<List<Vibe>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Vibe?> GetByIdAsync(Guid id);

        Task<Vibe> CreateAsync(Vibe vibe);

        Task<Vibe?> UpdateAsync(Guid id, Vibe vibe);

        Task<Vibe?> DeleteAsync(Guid id);
    }
}
