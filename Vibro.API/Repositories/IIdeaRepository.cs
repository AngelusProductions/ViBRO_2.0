using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public interface IIdeaRepository
    {
        Task<List<Idea>> GetAllAsync();

        Task<Idea?> GetByIdAsync(Guid id);

        Task<Idea> CreateAsync(Idea idea);

        Task<Idea?> UpdateAsync(Guid id, Idea idea);

        Task<Idea?> DeleteAsync(Guid id);
    }
}
