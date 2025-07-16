using IncidentsDecisionMicroservices.EmployeeLogic.Application.DTO.PositionDtos;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Position;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Application.Interfaces;

public interface IPositionService
{
    public Task<IEnumerable<PositionDto>> GetPositions(CancellationToken cancellationToken);
    public Task<Result<PositionDto>> GetPositionById(int id, CancellationToken cancellationToken);
    public Task<Result<PositionDto>> CreatePosition(PositionCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<PositionDto>> UpdatePosition(PositionUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<Position>> DeletePosition(int id, CancellationToken cancellationToken);
}