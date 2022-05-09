using DPNerd.Core.DomainObjects;

namespace DPNerd.Employees.Application.Models;

public class Address
{
    public string PublicPlace { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string District { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public Guid EmployeeId { get; private set; }

    public Employee Employee { get; protected set; }

    public Address() { }

    public Address(string publicPlace, string number, string complement, string district, string zipCode, string city, string state, Guid employeeId)
    {
        PublicPlace = publicPlace;
        Number = number;
        Complement = complement;
        District = district;
        ZipCode = zipCode;
        City = city;
        State = state;
        EmployeeId = employeeId;
    }
}

