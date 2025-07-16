using IncidentsDecisionMicroservices.TechSupportLogic.Core.Helpers;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;

namespace IncidentsDecisionMicroservices.TechSupportLogic.Core.Repositories;

public interface ITechSupportRepository
{
    public Task<IEnumerable<TechSupport>> GetTechSupports(CancellationToken cancellationToken);
    public Task<Result<TechSupport>> GetTechSupportById(int id, CancellationToken cancellationToken);
    public Task<Result<TechSupport>> CreateTechSupport(TechSupport techSupport, CancellationToken cancellationToken);
    public Task<Result<TechSupport>> UpdateTechSupport(TechSupport techSupport, CancellationToken cancellationToken);
    public Task<Result<TechSupport>> DeleteTechSupport(int id, CancellationToken cancellationToken);
}