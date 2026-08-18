using Microsoft.OpenApi.Models;

namespace Inter_seller_task.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer(); services.AddSwaggerGen(options => {

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                { Name = "Authorization", 
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", 
                    BearerFormat = "JWT", 
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT token.\n\n" + "Example: Bearer {your-token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement 
                { 
                    { 
                        new OpenApiSecurityScheme
                        { 
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" 
                            } },
                        Array.Empty<string>() 
                    }
                });
            }); 
            return services;
        }
    }
    
}
