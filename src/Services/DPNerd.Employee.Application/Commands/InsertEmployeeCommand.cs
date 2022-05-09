using DPNerd.Core.Messages;
using DPNerd.Employees.Application.Enums;
using FluentValidation;

namespace DPNerd.Employees.Application.Commands;

public class InsertEmployeeCommand : Command
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Cpf { get; private set; }
    public string Pis { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Birthplace { get; private set; }
    public string Nationality { get; private set; }
    public Gender Gender { get; private set; }
    public MaritalStatus MaritalStatus { get; private set; }
    public string? SpouseName { get; private set; }
    public bool HasSpecialNeeds { get; private set; }
    public string? SpecialNeeds { get; private set; }
    public string NameMother { get; private set; }
    public string? NameFather { get; private set; }

    public InsertEmployeeCommand(string firstName, string lastName, string cpf,
    string pis, DateTime birthDate, string birthplace, string nationality,
    Gender gender, MaritalStatus maritalStatus, string? spouseName,
    bool hasSpecialNeeds, string? specialNeeds, string nameMother, string? nameFather)
    {
        FirstName = firstName;
        LastName = lastName;
        Cpf = cpf;
        Pis = pis;
        BirthDate = birthDate;
        Birthplace = birthplace;
        Nationality = nationality;
        Gender = gender;
        MaritalStatus = maritalStatus;
        SpouseName = spouseName;
        HasSpecialNeeds = hasSpecialNeeds;
        SpecialNeeds = specialNeeds;
        NameMother = nameMother;
        NameFather = nameFather;
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
                RuleFor(s => s.SpecialNeeds).NotEmpty().WithMessage("As necessidades especiais não foram informadas");
            });

            RuleFor(c => c.NameMother)
                .NotEmpty()
                .WithMessage("O nome da mãe não foi informado");
        }
        protected bool CpfIsValid(string cpf)
        {
            return Core.DomainObjects.ValueObjects.Cpf.IsValid(cpf);
        }
    }
}
