using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ArcadeScore.Api.Configurations
{
    /// <summary>
    /// Provides extension methods to configure and enable Swagger/OpenAPI documentation for the API.
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Configures Swagger services for API documentation.
        /// </summary>
        /// <param name="services">Collection of services to add Swagger configuration to.</param>
        /// <returns>The collection of services updated with the Swagger configuration.</returns>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ArcadeScore API",
                    Version = "v1",
                    Description = "API for recording scores and statistics of arcade players.",
                    Contact = new OpenApiContact
                    {
                        Name = "William Luiz",
                        Url = new Uri("https://github.com/williamgluiz"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Configures Swagger middleware and Swagger UI for the application.
        /// </summary>
        /// <param name="app">The application builder to configure the request pipeline.</param>
        /// <returns>The application builder with Swagger middleware configured.</returns>
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ArcadeScore API v1");
                options.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
