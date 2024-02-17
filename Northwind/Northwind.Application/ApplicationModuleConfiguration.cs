using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Behaviors;
using Northwind.Application.Services;
using Northwind.Application.Services.Contracts;
using System.Reflection;

namespace Northwind.Application
{
    public static class ApplicationModuleConfiguration
    {
        public static IServiceCollection AddApplicationModuleConfiguration(this IServiceCollection services)
        {
            services.AddServicesDependencyInjectionConfiguration();

            services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPiplineBehavior<,>));

            return services;
        }

        private static IServiceCollection AddServicesDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISupplierService, SupplierService>();

            return services;
        }
    }
}