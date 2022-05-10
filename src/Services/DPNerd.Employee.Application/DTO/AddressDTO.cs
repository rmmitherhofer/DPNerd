using DPNerd.Employees.Application.Enums;

namespace DPNerd.Employees.Application.DTO;

public class AddressDTO
{
    public string PublicPlace { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

public class ContactDTO
{
    public ContactType Type { get; set; }
    public string Description { get; set; }
    public string Value { get; set; }
}

public class GeneralRecordDTO
{
    public string Number { get; set; }
    public string IssuingAgency { get; set; }
    public string State { get; set; }
    public DateTime DispatchDate { get; set; }
}

public class ParentsDTO
{
    public string NameMother { get; set; }
    public string? NameFather { get; set; }
}

public class ReservistDTO
{
    public int Number { get; set; }
    public long EnlistmentRegistration { get; set; }
    public string Serie { get; set; }
}
public class VoterTitleDTO
{
    public long Number { get; set; }
    public int Zone { get; set; }
    public int Section { get; set; }
}

public class WorkPassportDTO
{
    public int Number { get; set; }
    public int Serie { get; set; }
    public string State { get; set; }
    public DateTime DispatchDate { get; set; }
}
