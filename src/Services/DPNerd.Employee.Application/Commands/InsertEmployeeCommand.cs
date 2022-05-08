using DPNerd.Core.Messages;
using FluentValidation;

namespace DPNerd.Employees.Application.Commands;

public class InsertEmployeeCommand : Command
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }

    public InsertEmployeeCommand(Guid id, string name, string email, string cpf)
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
    }

    public override bool IsValid()
    {
        ValidationResult = new InsertEmployeeValidation().Validate(this);
        return ValidationResult.IsValid;
    }
    public class InsertEmployeeValidation : AbstractValidator<InsertEmployeeCommand>
    {
        public InsertEmployeeValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do colaborador inválido");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O nome do colaborador não foi informado");

            RuleFor(c => c.Cpf)
                .Must(CpfIsValid)
                .WithMessage("O CPF informado não é válido");

            RuleFor(c => c.Email)
                .Must(EmailIsValid)
                .WithMessage("O e-mail informado não é válido");
        }
        protected bool CpfIsValid(string cpf)
        {
            return Core.DomainObjects.ValueObjects.Cpf.IsValid(cpf);
        }

        protected static bool EmailIsValid(string email)
        {
            return Core.DomainObjects.ValueObjects.Email.IsValid(email);
        }
    }
}
