using IncidentsDecisionMicroservices.EmployeeLogic.Application.DTO.EmployeePositionDtos;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeePosition;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Application.Interfaces;

public interface IEmployeePositionService
{
    public Task<IEnumerable<EmployeePositionDto>> GetEmployeePositions(CancellationToken cancellationToken);
    public Task<Result<EmployeePositionDto>> GetEmployeePositionById(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeePositionDto>> CreateEmployeePosition(EmployeePositionCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeePositionDto>> UpdateEmployeePosition(EmployeePositionUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeePosition>> DeleteEmployeePosition(int id, CancellationToken cancellationToken);
}