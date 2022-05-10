using DPNerd.Employees.Application.Enums;

namespace DPNerd.Employees.Application.Queries.ViewModels;

public class EmployeeViewModel
{
    public Guid Id { get; set; }
    public long Registration { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Cpf { get;  set; }
    public string Pis { get;  set; }
    public DateTime BirthDate { get;  set; }
    public string Birthplace { get;  set; }
    public string Nationality { get;  set; }
    public string Gender { get;  set; }
    public string MaritalStatus { get;  set; }
    public string? SpouseName { get;  set; }
    public bool HasSpecialNeeds { get;  set; }
    public string? SpecialNeeds { get;  set; }
    public ParentsViewModel Parents { get;  set; }
    public ReservistViewModel Reservist { get; set; }
    public VoterTitleViewModel VoterTitle { get; set; }
    public WorkPassportViewModel WorkPassport { get; set; }
    public AddressViewModel Address { get; set; }
    public GeneralRecordViewModel GeneralRecord { get; set; }
    public List<ContactViewModel> Contacts { get; set; }
    public DateTime DateRegister { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; }
}
public class AddressViewModel
{
    public string PublicPlace { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}
public class ContactViewModel
{
    public ContactType Type { get; set; }
    public string Description { get; set; }
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
}
public class GeneralRecordViewModel
{
    public string Number { get; set; }
    public string IssuingAgency { get; set; }
    public string State { get; set; }
    public DateTime DispatchDate { get; set; }
}
public class ReservistViewModel
{
    public int Number { get; set; }
    public long EnlistmentRegistration { get; set; }
    public string Serie { get; set; }
}
public class VoterTitleViewModel
{
    public long Number { get; set; }
    public int Zone { get; set; }
    public int Section { get; set; }
}
public class WorkPassportViewModel
{
    public int Number { get; set; }
    public int Serie { get; set; }
    public string State { get; set; }
    public DateTime DispatchDate { get; set; }
}
