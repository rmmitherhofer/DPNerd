namespace DPNerd.Employees.Application.Models;

public class GeneralRecord
{
    public string Number { get; private set; }
    public string IssuingAgency { get; private set; }
    public string State { get; private set; }
    public DateTime DispatchDate { get; private set; }

    public Guid EmployeeId { get; private set; }
    public  Employee Employee { get; private set; }
    protected GeneralRecord() { }
}