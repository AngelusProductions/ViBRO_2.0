using Microsoft.EntityFrameworkCore;
using Vibro.API1.Data;
using Vibro.API1.Models;

namespace Vibro.API1.Repositories
{
    public class SqlMixRepository(VibroDbContext db) : IMixRepository
    {
        public async Task<List<Mix>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000, Guid? vibeId = null)
        {
            var mixes = db.Mixes.Include(m => m.Vibe).AsQueryable();

            if (vibeId != null)
                mixes = mixes.Where(m => m.VibeId == vibeId);

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    mixes = mixes.Where(m => m.Name.Contains(filterQuery));
                if (filterOn.Equals("Number", StringComparison.OrdinalIgnoreCase))
                    mixes = mixes.Where(m => m.Number == int.Parse(filterQuery));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    mixes = isAscending ? mixes.OrderBy(m => m.Name) : mixes.OrderByDescending(m => m.Name);
                if (sortBy.Equals("Number", StringComparison.OrdinalIgnoreCase))
                    mixes = isAscending ? mixes.OrderBy(m => m.Number) : mixes.OrderByDescending(m => m.Number);
                if (sortBy.Equals("Runtime", StringComparison.OrdinalIgnoreCase))
                    mixes = isAscending ? mixes.OrderBy(m => m.Runtime) : mixes.OrderByDescending(m => m.Runtime);
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await mixes.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Mix?> GetByIdAsync(Guid id)
        {
            return await db.Mixes.Include(m => m.Vibe).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Mix> CreateAsync(Mix mix)
        {
            await db.Mixes.AddAsync(mix);
            await db.SaveChangesAsync();

            mix.Vibe = await db.Vibes.FirstOrDefaultAsync(v => v.Id == mix.VibeId);

            return mix;
        }

        public async Task<Mix?> UpdateAsync(Guid id, Mix mix)
        {
            var existingMix = await db.Mixes.Include(m => m.Vibe).FirstOrDefaultAsync(m => m.Id == id);

            if (existingMix == null) return null;

            existingMix.Name = mix.Name;
            existingMix.Description = mix.Description;
            existingMix.Url = mix.Url;
            existingMix.Number = mix.Number;
            existingMix.Runtime = mix.Runtime;
            existingMix.VibeId = mix.VibeId;

            await db.SaveChangesAsync();

            existingMix.Vibe = await db.Vibes.FirstOrDefaultAsync(v => v.Id == mix.VibeId);

            return existingMix;
        }

        public async Task<Mix?> DeleteAsync(Guid id)
        {
            var mix = await db.Mixes.Include(m => m.Vibe).FirstOrDefaultAsync(m => m.Id == id);

            if (mix == null) return null;

            db.Mixes.Remove(mix);
            await db.SaveChangesAsync();

            mix.Vibe = await db.Vibes.FirstOrDefaultAsync(v => v.Id == mix.VibeId);

            return mix;
        }
    }
}
