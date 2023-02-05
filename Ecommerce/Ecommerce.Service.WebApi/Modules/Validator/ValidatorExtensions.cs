using Ecommerce.Application.Validator;

namespace Ecommerce.Service.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDTOValidator>();
            return services;
        }
    }
}
