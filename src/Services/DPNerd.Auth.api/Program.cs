using DPNerd.Auth.api.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApiConfiguration(builder.Configuration);

var app = builder.Build();


app.UseApiConfiguration(app.Environment);

app.Run();
