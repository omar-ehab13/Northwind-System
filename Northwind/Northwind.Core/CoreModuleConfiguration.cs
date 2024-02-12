using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Helpers.Logger;

namespace Northwind.Core
{
    public static class CoreModuleConfiguration
    {
        public static IServiceCollection AddCoreModuleConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }
    }
}
