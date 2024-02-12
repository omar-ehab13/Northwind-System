using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Infrastructure.Data;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Infrastructure
{
    public static class InfrastructureModuleConfiguration
    {
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("northwindContext"));
            });

            services.AddScoped<IRepositoryManager, RepositoryManager.RepositoryManager>();

            return services;
        }
    }
}