using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeePosition;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Core.Repositories;

public interface IEmployeePositionRepository
{
    public Task<IEnumerable<EmployeePosition>> GetEmployeePositions(CancellationToken cancellationToken);
    public Task<Result<EmployeePosition>> GetEmployeePositionById(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeePosition>> CreateEmployeePosition(EmployeePosition employeePosition, CancellationToken cancellationToken);
    public Task<Result<EmployeePosition>> UpdateEmployeePosition(EmployeePosition employeePosition, CancellationToken cancellationToken);
    public Task<Result<EmployeePosition>> DeleteEmployeePosition(int id, CancellationToken cancellationToken);
}