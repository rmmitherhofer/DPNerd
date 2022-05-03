using Microsoft.OpenApi.Models;

namespace DPNerd.Auth.api.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DPNerd Auth API",
                Description = "Esta API é responsavel pela autenticação e criação de usuários.",
                Contact = new OpenApiContact() { Name = "Renato Mitherhofer", Email = "renato.matos1@hotmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensourse.org/license/MIT") }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

        return app;
    }
}
