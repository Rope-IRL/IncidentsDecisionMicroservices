using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Position;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Core.Repositories;

public interface IPositionRepository
{
    public Task<IEnumerable<Position>> GetPositions(CancellationToken cancellationToken);
    public Task<Result<Position>> GetPositionById(int id, CancellationToken cancellationToken);
    public Task<Result<Position>> CreatePosition(Position position, CancellationToken cancellationToken);
    public Task<Result<Position>> UpdatePosition(Position position, CancellationToken cancellationToken);
    public Task<Result<Position>> DeletePosition(int id, CancellationToken cancellationToken);
}