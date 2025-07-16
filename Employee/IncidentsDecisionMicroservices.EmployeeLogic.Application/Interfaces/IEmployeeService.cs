using IncidentsDecisionMicroservices.EmployeeLogic.Application.DTO.EmployeeDtos;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Employee;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Application.Interfaces;

public interface IEmployeeService
{
    public Task<IEnumerable<EmployeeDto>> GetEmployees(CancellationToken cancellationToken);
    public Task<Result<EmployeeDto>> GetEmployeeById(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeeDto>> CreateEmployee(EmployeeCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeeDto>> UpdateEmployee(EmployeeUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<Employee>> DeleteEmployee(int id, CancellationToken cancellationToken);
}