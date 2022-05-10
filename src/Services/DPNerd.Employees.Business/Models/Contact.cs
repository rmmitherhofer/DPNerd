using DPNerd.Core.DomainObjects;
using DPNerd.Core.DomainObjects.ValueObjects;
using DPNerd.Employees.Application.Enums;

namespace DPNerd.Employees.Application.Models;

public class Contact : Entity
{
    public ContactType Type { get; private set; }
    public string Description { get; private set; }
    public Email? Email { get; private set; }
    public string? Phone { get; private set; }

    public Guid EmployeeId { get; private set; }

    public Employee Employee { get; protected set; }
    protected Contact() { }

    public Contact(ContactType type, string description, string value, Guid employeeId)
    {
        Type = type;
        Description = description;
        EmployeeId = employeeId;
        switch (Type)
        {
            case ContactType.Email:
                if (string.IsNullOrEmpty(value))
                    throw new DomainException("e-mail não informado");
                Email = new Email(value);
                return;
            case ContactType.Phone:
                if (string.IsNullOrEmpty(value))
                    throw new DomainException("telefone não informado");
                Phone = value;
                return;
        }
    }

    internal void BindEmployeed(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}