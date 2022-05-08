using DPNerd.Core.Mediator;
using DPNerd.Employees.API.Configurations;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);



var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.Run();

public partial class Program { }
