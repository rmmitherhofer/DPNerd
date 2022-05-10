using DPNerd.Core.Messages;
using DPNerd.Employees.Application.DTO;
using DPNerd.Employees.Application.Enums;
using FluentValidation;

namespace DPNerd.Employees.Application.Commands;

public class InsertEmployeeCommand : Command
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Cpf { get; set; }
    public string Pis { get; set; }
    public DateTime BirthDate { get; set; }
    public string Birthplace { get; set; }
    public string Nationality { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string? SpouseName { get; set; }
    public bool HasSpecialNeeds { get; set; }
    public string? SpecialNeeds { get; set; }
    public string NameMother { get; set; }
    public string? NameFather { get; set; }
    public ReservistDTO Reservist { get; set; }
    public VoterTitleDTO VoterTitle { get; set; }
    public WorkPassportDTO WorkPassport { get; set; }
    public AddressDTO Address { get; set; }
    public GeneralRecordDTO GeneralRecord { get; set; }
    public List<ContactDTO> Contacts { get; set; }       

    public override bool IsValid()
    {
        ValidationResult = new InsertEmployeeValidation().Validate(this);
        return ValidationResult.IsValid;
    }
    public class InsertEmployeeValidation : AbstractValidator<InsertEmployeeCommand>
    {
        public InsertEmployeeValidation()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("O nome não foi informado");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("O sobrenome não foi informado");

            RuleFor(c => c.Cpf)
                .Must(CpfIsValid)
                .WithMessage("O CPF informado não é válido");

            RuleFor(c => c.Pis)
                .NotEmpty()
                .WithMessage("O PIS informado não é válido");

            RuleFor(c => c.BirthDate)
                .Must(c => DateTime.Now.AddYears(-15) > c)
                .WithMessage("A data de nascimento informado não é válido");

            RuleFor(c => c.Birthplace)
                .NotEmpty()
                .WithMessage("A naturalidade não foi informada");

            RuleFor(c => c.Nationality)
                .NotEmpty()
                .WithMessage("A nacionalidade não foi informada");

            RuleFor(c => c.Gender)
                .NotEmpty()
                .WithMessage("O gênero não foi informado");

            RuleFor(c => c.MaritalStatus)
                .NotEmpty()
                .WithMessage("O estado civil não foi informado");

            When(c => c.MaritalStatus == MaritalStatus.Married || c.MaritalStatus == MaritalStatus.Concubinage, () =>
            {
                RuleFor(c => c.SpouseName)
                    .NotEmpty()
                    .WithMessage("O nome do(a) conjugê não foi informada");
            });

            When(c => c.HasSpecialNeeds, () =>
            {
                RuleFor(s => s.SpecialNeeds)
                    .NotEmpty()
                    .WithMessage("As necessidades especiais não foram informadas");
            });

            RuleFor(c => c.NameMother)
                .NotEmpty()
                .WithMessage("O nome da mãe não foi informado");

            When(c => c.Gender == Gender.Masculine && c.BirthDate > DateTime.Now.AddYears(-18), () =>
            {
                RuleFor(s => s.Reservist)
                    .NotNull()
                    .WithMessage("Os dados do serviço militar obrigatório não foram informados");
            });;

            RuleFor(c => c.VoterTitle)
                .NotNull()
                .WithMessage("Os dados do título de eleitor não foram informados");

            RuleFor(c => c.WorkPassport)
                .NotNull()
                .WithMessage("Os dados da carteira de trabalho não foram informados");

            RuleFor(c => c.Address)
                .NotNull()
                .WithMessage("Os dados do endereço não foram informados");

            RuleFor(c => c.GeneralRecord)
                .NotNull()
                .WithMessage("Os dados do registro geral (RG) não foram informados");

            RuleFor(c => c.Contacts.Count())
                .GreaterThan(0)
                .WithMessage("O colaborador precisa ter no mínimo 1 meio de contato.");
        }
        protected bool CpfIsValid(string cpf)
        {
            return Core.DomainObjects.ValueObjects.Cpf.IsValid(cpf);
        }
    }
}
