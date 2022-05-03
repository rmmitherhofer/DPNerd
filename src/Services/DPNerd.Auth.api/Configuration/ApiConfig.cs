using DPNerd.WebAPI.Core.Identity;

namespace DPNerd.Auth.api.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddIdentityConfiguration(configuration);

        services.AddSwaggerConfiguration();

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwaggerConfiguration();

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
