using DPNerd.Core.DomainObjects;

namespace DPNerd.Employees.Application.Models;

public class GeneralRecord : Entity
{
    public string Number { get; private set; }
    public string IssuingAgency { get; private set; }
    public string State { get; private set; }
    public DateTime DispatchDate { get; private set; }

    public Guid EmployeeId { get; private set; }
    public  Employee Employee { get; private set; }
    protected GeneralRecord() { }

    public GeneralRecord(string number, string issuingAgency, string state, DateTime dispatchDate, Guid employeeId)
    {
        Number = number;
        IssuingAgency = issuingAgency;
        State = state;
        DispatchDate = dispatchDate;
        EmployeeId = employeeId;
    }
    internal void BindEmployeed(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}