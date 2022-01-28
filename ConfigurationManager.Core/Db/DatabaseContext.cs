using System.Linq;
using ConfigurationManager.Core.Contract.Configurations;
using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Core.Contract.Projects;
using ConfigurationManager.Core.Contract.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConfigurationManager.Core.Db;

public class DatabaseContext : DbContext, IContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Configuration> Configurations { get; set; }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _ = ChangeTracker
            .Entries()
            .Where(x => x.State is EntityState.Added or EntityState.Modified)
            .Select(EnrichEntry);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected EntityEntry EnrichEntry(EntityEntry entry)
    {
        var entity = (BaseModel) entry.Entity;

        if (entry.State is EntityState.Added)
        {
            entity.CreatedAt = DateTime.UtcNow;
        }
        entity.UpdatedAt = DateTime.UtcNow;
        return entry;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>().HasData(new User { Id = 2 });
    }
}