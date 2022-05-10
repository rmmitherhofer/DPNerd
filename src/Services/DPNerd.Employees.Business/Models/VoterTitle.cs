using DPNerd.Core.DomainObjects;

namespace DPNerd.Employees.Application.Models;

public class VoterTitle : Entity
{
    public long Number { get; private set; }
    public int Zone { get; private set; }
    public int Section { get; private set; }

    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; private set; }

    protected VoterTitle() { }

    public VoterTitle(long number, int zone, int section, Guid employeeId)
    {
        Number = number;
        Zone = zone;
        Section = section;
        EmployeeId = employeeId;
    }
    internal void BindEmployeed(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}