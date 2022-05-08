using DPNerd.Swagger.Core.Configurations;
using DPNerd.WebAPI.Core.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DPNerd.Auth.api.Configurations;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddIdentityConfiguration(configuration);

        services.AddSwaggerConfiguration(false);

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwaggerConfiguration(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthConfiguration();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}
