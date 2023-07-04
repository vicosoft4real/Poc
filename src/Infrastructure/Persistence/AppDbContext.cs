using Application.Abstraction;
using Core.Entity;
using Core.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext , IApplicationDb
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Teacher> Teachers  => Set<Teacher>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Title> Titles  => Set<Title>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Teacher>().OwnsOne<Money>(x=>x.Salary).WithOwner();
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new("Mr"),
            new("Mrs"),
            new ("Miss"),
            new ("Dr"),
            new ("Prof")
        });
        base.OnModelCreating(modelBuilder);
    }
}