using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ecommerce.Service.WebApi.Modules.Swagger
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ecommerce Technology API Market",
                    Description = "Simple ASP.NET Core API",
                    Contact = new OpenApiContact
                    {
                        Email = "latorre@gmail.com",
                        Name = "Test",
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var securityscheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityscheme.Reference.Id, securityscheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityscheme, new List<string>{ } }
                });
            });
            return services;
        }
    }
}
