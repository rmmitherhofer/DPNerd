namespace DPNerd.Employees.Application.Models;

public class Parents
{
    public string NameMother { get; private set; }
    public string? NameFather { get; private set; }

    protected Parents() { }
    public Parents(string nameMother, string? nameFather)
    {
        NameMother = nameMother;
        NameFather = nameFather;
    }
}