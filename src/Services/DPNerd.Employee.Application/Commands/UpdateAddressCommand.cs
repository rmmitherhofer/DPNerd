using DPNerd.Core.Messages;
using FluentValidation;

namespace DPNerd.Employees.Application.Commands;

public class UpdateAddressCommand : Command
{
    public Guid EmployeeId { get; private set; }
    public string PublicPlace { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string District { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public UpdateAddressCommand() { }

    public UpdateAddressCommand(Guid employeeId, string publicPlace, string number, string complement, string district, string zipCode, string city, string state)
    {
        EmployeeId = employeeId;
        PublicPlace = publicPlace;
        Number = number;
        Complement = complement;
        District = district;
        ZipCode = zipCode;
        City = city;
        State = state;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateAddressValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class UpdateAddressValidation : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressValidation()
        {
            RuleFor(c => c.PublicPlace)
                   .NotEmpty()
                   .WithMessage("Informe o Logradouro");

            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("Informe o Número");

            RuleFor(c => c.ZipCode)
                .NotEmpty()
                .WithMessage("Informe o CEP");

            RuleFor(c => c.District)
                .NotEmpty()
                .WithMessage("Informe o Bairro");

            RuleFor(c => c.City)
                .NotEmpty()
                .WithMessage("Informe a Cidade");

            RuleFor(c => c.State)
                .NotEmpty()
                .WithMessage("Informe o Estado");
        }
    }
}
