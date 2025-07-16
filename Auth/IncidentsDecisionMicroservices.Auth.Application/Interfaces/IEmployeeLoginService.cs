using IncidentsDecisionMicroservices.Auth.Application.DTO.EmployeeLoginDtos;
using IncidentsDecisionMicroservices.Auth.Core.Helpers;
using IncidentsDecisionMicroservices.Auth.Core.Models.EmployeeLogin;

namespace IncidentsDecisionMicroservices.Auth.Application.Interfaces;

public interface IEmployeeLoginService
{
    public Task<IEnumerable<EmployeeLoginDto>> GetEmployeeLogins(CancellationToken cancellationToken);
    public Task<Result<EmployeeLoginDto>> GetEmployeeLoginById(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeeLoginDto>> CreateEmployeeLogin(EmployeeLoginCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeeLoginDto>> UpdateEmployeeLogin(EmployeeLoginUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeeLogin>> DeleteEmployeeLogin(int id, CancellationToken cancellationToken);
    public Task<Result<string>> LoginEmployee(string login, string password, CancellationToken cancellationToken);
}