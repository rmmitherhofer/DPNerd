using DPNerd.Core.Data;
using DPNerd.Employees.Business.Interface.Repository;
using DPNerd.Employees.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DPNerd.Employees.Infra.Data.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeContext _context;

    public EmployeeRepository(EmployeeContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;
    public async Task<IEnumerable<Employee>> GetAll()
        => await _context.Employees.AsNoTracking().ToListAsync();
    public async Task<Employee> GetByCpf(string cpf)
        => await _context.Employees.FirstOrDefaultAsync(e => e.Cpf.Number.Equals(cpf));
    public async Task<Employee> GetByRegistration(int registration)
        => await _context.Employees.FirstOrDefaultAsync(e => e.Registration == registration);
    public async Task<Address> GetAddressById(Guid id)
        => await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);

    public void Insert(Employee employee)
        => _context.Employees.Add(employee);
    public void Update(Employee employee)
        => _context.Employees.Update(employee);

    public void InsertAddress(Address address)
        => _context.Addresses.Add(address);
    public void UpdateAddress(Address address)
        => _context.Addresses.Update(address);

    public void Dispose()
        => _context?.Dispose();
}
