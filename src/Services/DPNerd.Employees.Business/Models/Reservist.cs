namespace DPNerd.Employees.Application.Models;

public class Reservist
{
    public int Number { get; set; }
    public long EnlistmentRegistration { get; set; }
    public string Serie { get; set; }

    public Guid EmployeeId { get; private set; }
    public  Employee Employee { get; private set; }
    protected Reservist() { }
}