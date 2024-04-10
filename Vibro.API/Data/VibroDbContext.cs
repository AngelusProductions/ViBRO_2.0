using Microsoft.EntityFrameworkCore;
using Vibro.API.Data.Seeds;
using Vibro.API.Models;

namespace Vibro.API.Data
{
    public class VibroDbContext : DbContext
    {
        public VibroDbContext(DbContextOptions<VibroDbContext> dbContextOptions) : base(dbContextOptions) {}

        public DbSet<Vibe> Vibes { get; set; }

        public DbSet<Mix> Mixes { get; set; }

        public DbSet<Idea> Ideas { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vibe>().HasData(VibeSeed.Data);
            modelBuilder.Entity<Mix>().HasData(MixSeed.Data);
            modelBuilder.Entity<Idea>().HasData(IdeaSeed.Data);
        }
    }
}
