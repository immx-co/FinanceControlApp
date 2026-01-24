using finance.control.core.Models;
using Microsoft.EntityFrameworkCore;

namespace finance.control.persistance;

public class ApplicationContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(e =>
        {
            e.ToTable("Categories");
            e.Property(e => e.Name).HasMaxLength(20);
        });
    }
}
