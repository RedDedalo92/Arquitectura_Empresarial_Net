namespace Ecommerce.Service.WebApi.Modules.Feature
{
    public static class FeatureExtension
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            var myPolicy = "policyEcommerce";
            var originCors = configuration["Config:OriginCors"];
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(originCors).AllowAnyHeader().AllowAnyMethod()));

            services.AddMvc();
            return services;
        }
    }
}
