using DPNerd.Employees.Application.Enums;

namespace DPNerd.Employees.Application.DTO;

public class EmployeeDTO
{
    public long Registration { get;  set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Cpf { get;  set; }
    public string Pis { get;  set; }
    public DateTime BirthDate { get;  set; }
    public string Birthplace { get;  set; }
    public string Nationality { get;  set; }
    public Gender Gender { get;  set; }
    public MaritalStatus MaritalStatus { get;  set; }
    public string? SpouseName { get;  set; }
    public bool HasSpecialNeeds { get;  set; }
    public string? SpecialNeeds { get;  set; }
}
