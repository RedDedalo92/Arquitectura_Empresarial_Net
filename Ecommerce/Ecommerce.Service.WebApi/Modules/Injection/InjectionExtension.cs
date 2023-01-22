using Ecommerce.Application.Interface;
using Ecommerce.Application.Main;
using Ecommerce.Domain.Core;
using Ecommerce.Domain.Interface;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Interface;
using Ecommerce.Infraestructure.Repository;
using Ecommerce.Transversal.Common;
using Ecommerce.Transversal.Loggin;

namespace Ecommerce.Service.WebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
