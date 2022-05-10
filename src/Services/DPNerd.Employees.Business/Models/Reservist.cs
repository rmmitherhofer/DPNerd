using DPNerd.Core.DomainObjects;

namespace DPNerd.Employees.Application.Models;

public class Reservist : Entity
{
    public int Number { get; set; }
    public long EnlistmentRegistration { get; set; }
    public string Serie { get; set; }

    public Guid EmployeeId { get; private set; }
    public  Employee Employee { get; private set; }
    protected Reservist() { }

    public Reservist(int number, long enlistmentRegistration, string serie, Guid employeeId)
    {
        Number = number;
        EnlistmentRegistration = enlistmentRegistration;
        Serie = serie;
        EmployeeId = employeeId;
    }

    internal void BindEmployeed(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}