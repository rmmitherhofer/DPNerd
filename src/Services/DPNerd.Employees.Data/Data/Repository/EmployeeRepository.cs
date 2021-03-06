using DPNerd.Core.Data;
using DPNerd.Employees.Application.Interface.Repository;
using DPNerd.Employees.Application.Models;
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
    {
        return await _context.Employees
            .Include(e => e.WorkPassport)
            .Include(e => e.VoterTitle)
            .Include(e=> e.Address)
            .Include(e=>e.GeneralRecord)
            .Include(e=> e.Reservist)
            .Include(e => e.Contacts)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Cpf.Number.Equals(cpf));
    }

    public async Task<Employee> GetByRegistration(int registration)
        => await _context.Employees
        .FirstOrDefaultAsync(e => e.Registration == registration);
    public async Task<Address> GetAddressById(Guid id)
        => await _context.Addresses
        .FirstOrDefaultAsync(a => a.EmployeeId == id);

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
