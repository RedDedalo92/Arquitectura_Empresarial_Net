using Ecommerce.Transversal.Mapper;
using AutoMapper;

namespace Ecommerce.Service.WebApi.Modules.Mapper
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
