using DPNerd.Core.DomainObjects;
using DPNerd.Core.DomainObjects.ValueObjects;

namespace DPNerd.Employees.Business.Models;

public class Employee : Entity, IAggregateRoot
{
    public long Registration { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Cpf Cpf { get; private set; }
    public Address Address { get; private set; }
    public bool Active { get; set; }

    public Employee() { }

    public Employee(Guid id, string name, string email, string cpf)
    {
        Registration = 1234;
        Id = id;
        Name = name;
        Email = new Email(email);
        Cpf = new Cpf(cpf);
        Active = true;
    }

    public void UpdateEmail(string email)
    {
        Email = new Email(email);
    }

    public void AddAddress(Address address)
    {
        Address = address;
    }
}
