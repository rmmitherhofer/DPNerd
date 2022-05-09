namespace DPNerd.Employees.Application.Models;

public class WorkPassport
{
    public int Number { get; private set; }
    public int Serie { get; private set; }
    public string State { get; private set; }
    public DateTime DispatchDate { get; private set; }
    public Guid EmployeeId { get; private set; }

    public Employee Employee { get; protected set; }

    protected WorkPassport() { }

    public WorkPassport(int number, int serie, string state, DateTime dispatchDate, Guid employeeId)
    {
        Number = number;
        Serie = serie;
        State = state;
        DispatchDate = dispatchDate;
        EmployeeId = employeeId;
    }
}