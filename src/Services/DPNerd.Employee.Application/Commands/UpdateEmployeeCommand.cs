using DPNerd.Core.Messages;
using FluentValidation;

namespace DPNerd.Employees.Application.Commands;

public class UpdateEmployeeCommand : Command
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public UpdateEmployeeCommand(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    public override bool IsValid()
    {
        ValidationResult = new UpdateEmployeeValidation().Validate(this);
        return ValidationResult.IsValid;
    }
    public class UpdateEmployeeValidation : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do colaborador inválido");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O nome do colaborador não foi informado");

            RuleFor(c => c.Email)
                .Must(EmailIsValid)
                .WithMessage("O e-mail informado não é válido");
        }

        protected static bool EmailIsValid(string email)
        {
            return Core.DomainObjects.ValueObjects.Email.IsValid(email);
        }
    }
}