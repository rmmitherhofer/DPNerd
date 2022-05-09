using DPNerd.Core.DomainObjects;
using DPNerd.Core.DomainObjects.ValueObjects;
using DPNerd.Employees.Application.Enums;

namespace DPNerd.Employees.Application.Models;

public class Employee : Entity, IAggregateRoot
{
    public long Registration { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Cpf Cpf { get; private set; }
    public Pis Pis { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Birthplace { get; private set; }
    public string Nationality { get; private set; }
    public Gender Gender { get; private set; }
    public MaritalStatus MaritalStatus { get; private set; }
    public string? SpouseName { get; private set; }
    public bool HasSpecialNeeds { get; private set; }
    public string? SpecialNeeds { get; private set; }
    public Parents Parents { get; private set; }

    public List<Contact> Contacts { get; private set; }
    public WorkPassport WorkPassport { get; set; }
    public Address Address { get; private set; }
    public GeneralRecord GeneralRecord { get; private set; }
    public VoterTitle VoterTitle { get; private set; }
    public Reservist Reservist { get; private set; }

    public Employee() { }

    public Employee(string firstName, string lastName, string cpf, string pis, 
        DateTime birthDate, string birthplace, string nationality, Gender gender,
        MaritalStatus maritalStatus, string? spouseName, bool hasSpecialNeeds, string? 
        specialNeeds, Parents parents)
    {
        Registration = new Random().Next(10000, int.MaxValue);
        FirstName = firstName;
        LastName = lastName;
        Cpf = new Cpf(cpf);
        Pis = new Pis(pis);
        BirthDate = birthDate;
        Birthplace = birthplace;
        Nationality = nationality;
        Gender = gender;
        MaritalStatus = maritalStatus;
        SpouseName = spouseName;
        HasSpecialNeeds = hasSpecialNeeds;
        SpecialNeeds = specialNeeds;
        Parents = parents;
    }

    public void AddAddress(Address address)
    {
        Address = address;
    }
}
