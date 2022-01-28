using System.Text.Json;
using ConfigurationManager.Core.Contract.Configurations;
using ConfigurationManager.Core.Contract.Database;
using ConfigurationManager.Core.Contract.Projects;
using ConfigurationManager.Core.Contract.Users;
using ConfigurationManager.Core.Db;
using ConfigurationManager.Tests.Users;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Tests.Db;

public sealed class TestContext : DatabaseContext
{
    public TestContext()
    {
        Database.EnsureCreated();
    }

    public override DbSet<User> Users { get; set; }
    public override DbSet<Project> Projects { get; set; }
    public override DbSet<Configuration> Configurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseInMemoryDatabase("Test");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Configuration>()
            .Property(p => p.Json)
            .HasConversion(c => c.ToString(), c => JsonDocument.Parse(c ?? "{}", default));
        modelBuilder.Entity<User>().HasData(UsersTestData.ExistUserDocument, UsersTestData.DeletionUserDocument);
    } 
}