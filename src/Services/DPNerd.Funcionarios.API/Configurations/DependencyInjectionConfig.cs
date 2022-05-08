using DPNerd.Core.Mediator;
using DPNerd.Employees.Application.Commands;
using DPNerd.Employees.Application.Commands.Handler;
using DPNerd.Employees.Business.Interface.Repository;
using DPNerd.Employees.Infra.Data;
using DPNerd.Employees.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;

namespace DPNerd.Employees.API.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IRequestHandler<InsertEmployeeCommand, ValidationResult>, EmployeeCommandHandler>();

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<EmployeeContext>();

        return services;
    }
}
