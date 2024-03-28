using Microsoft.EntityFrameworkCore;
using Vibro.API.Data;
using Vibro.API.Models;

namespace Vibro.API.Repositories
{
    public class SqlMixRepository(VibroDbContext db) : IMixRepository
    {
        public async Task<List<Mix>> GetAllAsync()
        {
            return await db.Mixes.Include(m => m.Vibe).ToListAsync();
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
