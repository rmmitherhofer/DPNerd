using DPNerd.Employees.Infra.Data;
using DPNerd.Notifications.Configurations;
using DPNerd.Swagger.Core.Configurations;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

namespace DPNerd.Employees.API.Configurations;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmployeeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EmployeeConnection")));

        services.AddControllers();

        services.RegisterServices();

        services.AddNotificationConfiguration();

        services.AddSwaggerConfiguration(false);

        services.AddMediatR(typeof(Program));

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseSwaggerConfiguration(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

        //app.UseHttpsRedirection();

        app.UseRouting();

        //app.UseAuthConfiguration();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}
