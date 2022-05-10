using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ValidationResult> Handle(InsertEmployeeCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var employee = MapEmployee(message);

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

    private Employee MapEmployee(InsertEmployeeCommand message)
    {
        var contacts = _mapper.Map<List<Contact>>(message.Contacts);

        var employee = new Employee(message.FirstName, message.LastName, message.Cpf, message.Pis, message.BirthDate, message.Birthplace,
            message.Nationality, message.Gender, message.MaritalStatus, message.SpouseName, message.HasSpecialNeeds, message.SpecialNeeds, contacts);

        var reservist = _mapper.Map<Reservist>(message.Reservist);
        var voterTitle = _mapper.Map<VoterTitle>(message.VoterTitle);
        var workPassport = _mapper.Map<WorkPassport>(message.WorkPassport);
        var address = _mapper.Map<Address>(message.Address);
        var generalRecord = _mapper.Map<GeneralRecord>(message.GeneralRecord);

        employee.AddParents(new Parents(message.NameMother, message.NameFather));
        employee.AddReservist(reservist);
        employee.AddVoterTitle(voterTitle);
        employee.AddWorkPassport(workPassport);
        employee.AddAddress(address);
        employee.AddGeneralRecord(generalRecord);
        return employee;
    }
}
