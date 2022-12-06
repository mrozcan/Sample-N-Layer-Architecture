using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace App.Infrastructure.Contexts;

public class DatabaseContext : DbContext
{
    private protected string SqliteDbPath { get; set; }

    public DatabaseContext() => SqliteDbPath = System.IO.Path.Join(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Sample.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={SqliteDbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    [AllowNull]
    public virtual DbSet<SampleEntity> SampleEntities { get; set; }
}
