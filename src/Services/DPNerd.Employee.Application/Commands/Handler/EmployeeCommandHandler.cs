using DPNerd.Core.Messages;
using DPNerd.Employees.Application.Events;
using DPNerd.Employees.Application.Interface.Repository;
using DPNerd.Employees.Application.Models;
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

        var employee = new Employee(
            message.FirstName,
            message.LastName,
            message.Cpf,
            message.Pis,
            message.BirthDate,
            message.Birthplace,
            message.Nationality,
            message.Gender,
            message.MaritalStatus,
            message.SpouseName,
            message.HasSpecialNeeds,
            message.SpecialNeeds,
            new Parents(message.NameMother, message.NameFather)
            );

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
