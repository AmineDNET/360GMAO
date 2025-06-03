using GMAO.API;
using GMAO.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GMAO.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<GMAODbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<GMAODbContext>(options =>
                options.UseInMemoryDatabase("InMemoryTest"));
        });
    }
}
