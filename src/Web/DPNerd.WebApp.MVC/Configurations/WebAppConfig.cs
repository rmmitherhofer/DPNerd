namespace DPNerd.WebApp.MVC.Configurations;

public static class WebAppConfig
{
    public static IServiceCollection AddWebAppConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();

        //services.RegistrarServices(configuration);

        return services;
    }

    public static IApplicationBuilder UserWebAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); ;

        app.UseAuthorization();

        return app;
    }
}
