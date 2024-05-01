using Microsoft.EntityFrameworkCore;
using Vibro.API2.Entities;

namespace Vibro.API2.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
