using DPNerd.Core.Data;
using DPNerd.Employees.Business.Models;

namespace DPNerd.Employees.Business.Interface.Repository;

public interface IEmployeeRepository : IRepository<Employee>
{
    void Insert(Employee employee);
    void Update(Employee employee);
    Task<IEnumerable<Employee>> GetAll();
    Task<Employee> GetByCpf(string cpf);
    Task<Employee> GetByRegistration(int registration);

    Task<Address> GetAddressById(Guid id);
    void InsertAddress(Address address);
    void UpdateAddress(Address address);
}
