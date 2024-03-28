using Microsoft.EntityFrameworkCore;
using Vibro.API.Data;
using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public class SqlVibeRepository(VibroDbContext db) : IVibeRepository
    {
        public async Task<List<Vibe>> GetAllAsync()
        {
            return await db.Vibes.ToListAsync();
        }

        public async Task<Vibe?> GetByIdAsync(Guid id)
        {
            return await db.Vibes.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vibe> CreateAsync(Vibe vibe)
        {
            await db.Vibes.AddAsync(vibe);
            await db.SaveChangesAsync();

            return vibe;
        }

        public async Task<Vibe?> UpdateAsync(Guid id, Vibe vibe)
        {
            var existingVibe = await db.Vibes.FirstOrDefaultAsync(v => v.Id == id);

            if(existingVibe == null) return null;

            existingVibe.Name = vibe.Name;
            existingVibe.Description = vibe.Description;
            existingVibe.ArtUrl = vibe.ArtUrl;

            await db.SaveChangesAsync();

            return existingVibe;
        }

        public async Task<Vibe?> DeleteAsync(Guid id)
        {
            var existingVibe = await db.Vibes.FirstOrDefaultAsync(v => v.Id == id);

            if(existingVibe == null) return null;

            db.Vibes.Remove(existingVibe);
            await db.SaveChangesAsync();

            return existingVibe;
        }
    }
}
