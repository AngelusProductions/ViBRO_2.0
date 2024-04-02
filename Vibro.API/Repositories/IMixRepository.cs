using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public interface IMixRepository
    {
        Task<List<Mix>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000, Guid? vibeId = null);

        Task<Mix?> GetByIdAsync(Guid id);

        Task<Mix> CreateAsync(Mix mix);

        Task<Mix?> UpdateAsync(Guid id, Mix mix);

        Task<Mix?> DeleteAsync(Guid id);
    }
}
