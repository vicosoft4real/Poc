using Application.Abstraction;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration.GetSection("UseInMemoryDatabase").Value == "true")
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDb>(provider => provider.GetRequiredService<AppDbContext>());
        
        return services;

    }
}