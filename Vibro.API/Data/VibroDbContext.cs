using Microsoft.EntityFrameworkCore;
using Vibro.API.Models;

namespace Vibro.API.Data
{
    public class VibroDbContext : DbContext
    {
        public VibroDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Vibe> Vibes { get; set; }

        public DbSet<Mix> Mixes { get; set; }

        public DbSet<Idea> Ideas { get; set; }
    }
}
