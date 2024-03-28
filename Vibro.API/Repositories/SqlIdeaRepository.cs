using Microsoft.EntityFrameworkCore;
using Vibro.API.Data;
using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public class SqlIdeaRepository(VibroDbContext db) : IIdeaRepository
    {
        public async Task<List<Idea>> GetAllAsync()
        {
            return await db.Ideas.Include(i => i.Mix).ThenInclude(m => m.Vibe).ToListAsync();
        }

        public async Task<Idea?> GetByIdAsync(Guid id)
        {
            return await db.Ideas.Include(i => i.Mix).ThenInclude(m => m.Vibe).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Idea> CreateAsync(Idea idea)
        {
            await db.Ideas.AddAsync(idea);
            await db.SaveChangesAsync();

            idea.Mix = await db.Mixes.Include(m => m.Vibe).FirstOrDefaultAsync(v => v.Id == idea.MixId);

            return idea;
        }

        public async Task<Idea?> UpdateAsync(Guid id, Idea idea)
        {
            var existingIdea = await db.Ideas.Include(i => i.Mix).ThenInclude(m => m.Vibe).FirstOrDefaultAsync(m => m.Id == id);

            if (existingIdea == null) return null;

            existingIdea.Name = idea.Name;
            existingIdea.Description = idea.Description;
            existingIdea.Timestamp = idea.Timestamp;
            existingIdea.MixId = idea.MixId;

            await db.SaveChangesAsync();

            existingIdea.Mix = await db.Mixes.Include(m => m.Vibe).FirstOrDefaultAsync(v => v.Id == idea.MixId);

            return existingIdea;
        }

        public async Task<Idea?> DeleteAsync(Guid id)
        {
            var idea = await db.Ideas.Include(m => m.Mix).ThenInclude(m => m.Vibe).FirstOrDefaultAsync(m => m.Id == id);

            if (idea == null) return null;

            db.Ideas.Remove(idea);
            await db.SaveChangesAsync();

            idea.Mix = await db.Mixes.Include(m => m.Vibe).FirstOrDefaultAsync(v => v.Id == idea.MixId);

            return idea;
        }
    }
}
