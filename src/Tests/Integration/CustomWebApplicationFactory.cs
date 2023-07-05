using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;


namespace Tests.Integration;


public class CustomWebApplicationFactory <TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<AppDbContext>));
            if (descriptor != null) services.Remove(descriptor);
            // use test database 
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Services.GetRequiredService<IConfiguration>().GetConnectionString("TestConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            
            
            
            
            
            
        });
    }
    
}