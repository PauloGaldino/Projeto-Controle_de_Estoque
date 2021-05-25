using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Service.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Store Control Project",
                    Description = "Store Control API Swagger surface",
                    Contact = new OpenApiContact { Name = "José Paulo", Email = "dnadeveloper@gmail.com", Url = new Uri("https://mail.google.com/mail/u/2/?ogbl#inbox") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/EduardoPires/EquinoxProject/blob/master/LICENSE") }
                });
            });
        }
    }
}
