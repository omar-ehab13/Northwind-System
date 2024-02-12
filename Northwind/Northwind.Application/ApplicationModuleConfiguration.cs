using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Northwind.Application
{
    public static class ApplicationModuleConfiguration
    {
        public static IServiceCollection AddApplicationModuleConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}