namespace DPNerd.Employees.Application.Models;

public class VoterTitle
{
    public long Number { get; private set; }
    public int Zone { get; private set; }
    public int Section { get; private set; }

    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; private set; }

    protected VoterTitle() { }
}