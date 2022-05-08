using Microsoft.Extensions.DependencyInjection;

namespace DPNerd.Notifications.Configurations;

public static class NotificationConfig
{
    public static IServiceCollection AddNotificationConfiguration(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();

        return services;
    }
}
