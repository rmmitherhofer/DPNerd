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

    private readonly List<Contact> _contacts;
    public IReadOnlyCollection<Contact> Contacts => _contacts;

    public WorkPassport WorkPassport { get; set; }
    public Address Address { get; private set; }
    public GeneralRecord GeneralRecord { get; private set; }
    public VoterTitle VoterTitle { get; private set; }
    public Reservist Reservist { get; private set; }
    public DateTime DateRegister { get; private set; }
    public EmployeeStatus EmployeeStatus { get; private set; }

    protected Employee() { }

    public Employee(string firstName, string lastName, string cpf, string pis,
        DateTime birthDate, string birthplace, string nationality, Gender gender,
        MaritalStatus maritalStatus, string? spouseName, bool hasSpecialNeeds, string?
        specialNeeds, List<Contact> contacts)
    {
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
        EmployeeStatus = EmployeeStatus.Created;

        contacts.ForEach(c => c.BindEmployeed(Id));
        _contacts = contacts;
    }

    public void AddParents(Parents parents)
    {
        Parents = parents;
    }
    public void AddWorkPassport(WorkPassport workPassport)
    {
        workPassport.BindEmployeed(Id);
        WorkPassport = workPassport;
    }
    public void AddAddress(Address address)
    {
        address.BindEmployeed(Id);
        Address = address;
    }
    public void AddGeneralRecord(GeneralRecord generalRecord)
    {
        generalRecord.BindEmployeed(Id);
        GeneralRecord = generalRecord;
    }
    public void AddVoterTitle(VoterTitle voterTitle)
    {
        voterTitle.BindEmployeed(Id);
        VoterTitle = voterTitle;
    }
    public void AddReservist(Reservist reservist)
    {
        reservist.BindEmployeed(Id);
        Reservist = reservist;
    }
}
