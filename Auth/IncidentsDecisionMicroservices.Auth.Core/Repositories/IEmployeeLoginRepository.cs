using IncidentsDecisionMicroservices.Auth.Core.Helpers;
using IncidentsDecisionMicroservices.Auth.Core.Models.EmployeeLogin;

namespace IncidentsDecisionMicroservices.Auth.Core.Repositories;

public interface IEmployeeLoginRepository
{
    public Task<IEnumerable<EmployeeLogin>> GetEmployeeLogins(CancellationToken cancellationToken);
    public Task<Result<EmployeeLogin>> GetEmployeeLoginById(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeeLogin>> CreateEmployeeLogin(EmployeeLogin employeeLogin, CancellationToken cancellationToken);
    public Task<Result<EmployeeLogin>> UpdateEmployeeLogin(EmployeeLogin employeeLogin, CancellationToken cancellationToken);
    public Task<Result<EmployeeLogin>> DeleteEmployeeLogin(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeeLogin>> GetEmployeeByLogin(string login, CancellationToken cancellationToken);
}