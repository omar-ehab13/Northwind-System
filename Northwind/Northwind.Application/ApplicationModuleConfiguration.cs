using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Northwind.Application.Behaviors;
using Northwind.Application.Services;
using Northwind.Application.Services.Contracts;
using Northwind.Core.Helpers.Auth;
using System.Reflection;
using System.Text;

namespace Northwind.Application
{
    public static class ApplicationModuleConfiguration
    {
        public static IServiceCollection AddApplicationModuleConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServicesDependencyInjectionConfiguration();

            services.ConfigureJWT(configuration);

            services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPiplineBehavior<,>));

            return services;
        }

        private static IServiceCollection AddServicesDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();

            configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);

            services.AddSingleton(jwtOptions);

            //var secret = Encoding.UTF8.GetBytes(configuration["JWT:Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = jwtOptions.ValidateIssuer,
                   ValidIssuers = new[] { jwtOptions.Issuer },
                   ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                   ValidAudience = jwtOptions.Audience,
                   ValidateAudience = jwtOptions.ValidateAudience,
                   ValidateLifetime = jwtOptions.ValidateLifeTime,
               };
           });
        }
    }
}