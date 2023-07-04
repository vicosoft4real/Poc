using Application.Abstraction;
using Core.Entity;
using Core.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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

public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=School;Username=postgres;Password=12345678");
        return new AppDbContext(optionsBuilder.Options);

        
    }
}