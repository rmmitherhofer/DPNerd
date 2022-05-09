namespace DPNerd.Employees.Application.Queries.ViewModels;

public class EmployeeViewModel
{
    public Guid Id { get; set; }
    public long Registration { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Cpf { get;  set; }
    public string Pis { get;  set; }
    public DateTime BirthDate { get;  set; }
    public string Birthplace { get;  set; }
    public string Nationality { get;  set; }
    public string Gender { get;  set; }
    public string MaritalStatus { get;  set; }
    public string? SpouseName { get;  set; }
    public bool HasSpecialNeeds { get;  set; }
    public string? SpecialNeeds { get;  set; }
    public ParentsViewModel Parents { get;  set; }
}
