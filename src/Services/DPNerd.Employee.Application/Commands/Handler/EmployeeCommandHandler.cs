using DPNerd.Core.Messages;
using DPNerd.Employees.Application.Events;
using DPNerd.Employees.Business.Interface.Repository;
using DPNerd.Employees.Business.Models;
using FluentValidation.Results;
using MediatR;

namespace DPNerd.Employees.Application.Commands.Handler;

public class EmployeeCommandHandler : CommandHandler,
    IRequestHandler<InsertEmployeeCommand, ValidationResult>
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ValidationResult> Handle(InsertEmployeeCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var employee = new Employee(message.Id, message.Name, message.Email, message.Cpf);

        var employeeExist = await _employeeRepository.GetByCpf(employee.Cpf.Number);

        if (employeeExist is not null)
        {
            AddError("Colaborador já cadastrado");
            return ValidationResult;
        }
        _employeeRepository.Insert(employee);

        employee.AddEvent(new RegisteredEmployeeEvent());

        return await Commit(_employeeRepository.UnitOfWork);
    }
}
