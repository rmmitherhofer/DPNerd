using DPNerd.WebApp.MVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebAppConfiguration(builder.Configuration);

var app = builder.Build();

app.UserWebAppConfiguration(app.Environment);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program { }
