using AutoMapper;
using DPNerd.Employees.Application.Queries.ViewModels;
using DPNerd.Employees.Application.Interface.Repository;

namespace DPNerd.Employees.Application.Queries;


public interface IEmployeeQueries
{
    Task<IEnumerable<EmployeeViewModel>> GetAll();
    Task<EmployeeViewModel> GetByRegistration(int registration);
    Task<EmployeeViewModel> GetByCpf(string cpf);
}
public class EmployeeQueries : IEmployeeQueries
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeQueries(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeViewModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.GetAll());
    }

    public async Task<EmployeeViewModel> GetByCpf(string cpf)
    {
        return _mapper.Map<EmployeeViewModel>(await _employeeRepository.GetByCpf(cpf));
    }

    public async Task<EmployeeViewModel> GetByRegistration(int registration)
    {
        return _mapper.Map<EmployeeViewModel>(await _employeeRepository.GetByRegistration(registration));
    }
}
