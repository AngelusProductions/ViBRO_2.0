using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public interface IIdeaRepository
    {
        Task<List<Idea>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000, Guid? mixId = null);

        Task<Idea?> GetByIdAsync(Guid id);

        Task<Idea> CreateAsync(Idea idea);

        Task<Idea?> UpdateAsync(Guid id, Idea idea);

        Task<Idea?> DeleteAsync(Guid id);
    }
}
