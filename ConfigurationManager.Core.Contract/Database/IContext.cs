using ConfigurationManager.Core.Contract.Configurations;
using ConfigurationManager.Core.Contract.Projects;
using ConfigurationManager.Core.Contract.Users;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Core.Contract.Database;

public interface IContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Configuration> Configurations { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}