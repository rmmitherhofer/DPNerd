using DPNerd.WebApp.MVC.Services;
using Microsoft.Extensions.Options;

namespace DPNerd.WebApp.MVC.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegistarServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IAuthService, AuthService>(options => 
            options.BaseAddress = new Uri("https://localhost:7048"));

        return services;
    }
}
