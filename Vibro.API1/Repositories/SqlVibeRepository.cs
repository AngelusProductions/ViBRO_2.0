using Microsoft.EntityFrameworkCore;
using Vibro.API1.Data;
using Vibro.API1.Models;

namespace Vibro.API1.Repositories
{
    public class SqlVibeRepository(VibroDbContext db) : IVibeRepository
    {
        public async Task<List<Vibe>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var vibes = db.Vibes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    vibes = vibes.Where(v => v.Name.Contains(filterQuery));

            if (!string.IsNullOrWhiteSpace(sortBy))
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    vibes = isAscending ? vibes.OrderBy(v => v.Name) : vibes.OrderByDescending(v => v.Name);

            var skipResults = (pageNumber - 1) * pageSize;

            return await vibes.Skip(skipResults).Take(pageSize).ToListAsync();
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

            if (existingVibe == null) return null;

            existingVibe.Name = vibe.Name;
            existingVibe.Description = vibe.Description;
            existingVibe.ArtUrl = vibe.ArtUrl;

            await db.SaveChangesAsync();

            return existingVibe;
        }

        public async Task<Vibe?> DeleteAsync(Guid id)
        {
            var existingVibe = await db.Vibes.FirstOrDefaultAsync(v => v.Id == id);

            if (existingVibe == null) return null;

            db.Vibes.Remove(existingVibe);
            await db.SaveChangesAsync();

            return existingVibe;
        }
    }
}
