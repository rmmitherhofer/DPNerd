using DPNerd.Core.Messages;
using DPNerd.Employees.Application.Enums;
using FluentValidation;

namespace DPNerd.Employees.Application.Commands;

public class InsertContactCommand : Command
{
    public Guid EmployeeId { get; private set; }
    public ContactType Type { get; private set; }
    public string Description { get; private set; }
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
    public string? Others { get; private set; }
    public InsertContactCommand() { }

    public InsertContactCommand(Guid employeeId, ContactType type, string description, string? email, string? phone, string? others)
    {
        EmployeeId = employeeId;
        Type = type;
        Description = description;
        switch (Type)
        {
            case ContactType.Email:
                Email = email;
                break;
            case ContactType.Phone:
                Phone = phone;
                break;
            case ContactType.Others:
                Others = others;
                break;
        }
    }

    public override bool IsValid()
    {
        ValidationResult = new InsertContactValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class InsertContactValidation : AbstractValidator<InsertContactCommand>
    {
        public InsertContactValidation()
        {
            RuleFor(c => c.EmployeeId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("Informe o id do colaborador.");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Informe a descrição do contato.");

            When(t => t.Type == ContactType.Email, () =>
            {
                RuleFor(c => c.Email)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Informe o e-mail de contato.");
            });

            When(t => t.Type == ContactType.Phone, () =>
            {
                RuleFor(c => c.Email)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Informe o telefone de contato.");
            });

            When(t => t.Type == ContactType.Others, () =>
            {
                RuleFor(c => c.Email)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Informe o contato.");
            });
        }
    }
}