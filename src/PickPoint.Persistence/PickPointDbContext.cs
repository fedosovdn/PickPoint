using Microsoft.EntityFrameworkCore;

namespace PickPoint.Persistence;

public sealed class PickPointDbContext : DbContext
{
    public PickPointDbContext()
    {
    }
    
    public PickPointDbContext(DbContextOptions<PickPointDbContext> options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    internal void Migrate()
    {
        this.Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PickPointDbContext).Assembly);
    }
}