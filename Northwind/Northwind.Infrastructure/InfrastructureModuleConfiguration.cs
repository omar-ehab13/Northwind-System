using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Entities.Identity;
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

            services.AddIdentity<NorthwindUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
              .AddEntityFrameworkStores<NorthwindContext>()
              .AddDefaultUI()
              .AddDefaultTokenProviders();


            services.AddScoped<IRepositoryManager, RepositoryManager.RepositoryManager>();

            return services;
        }
    }
}