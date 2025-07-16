using IncidentsDecisionMicroservices.Incidents.Application.DTO.ResolvedIncidentDtos;
using IncidentsDecisionMicroservices.Incidents.Core.Helpers;
using IncidentsDecisionMicroservices.Incidents.Core.Models.ResolvedIncident;

namespace IncidentsDecisionMicroservices.Incidents.Application.Interfaces;

public interface IResolvedIncidentService
{
    public Task<IEnumerable<ResolvedIncidentDto>> GetResolvedIncidents(CancellationToken cancellationToken);
    public Task<Result<ResolvedIncidentDto>> GetResolvedIncidentById(int id, CancellationToken cancellationToken);
    public Task<Result<ResolvedIncidentDto>> CreateResolvedIncident(ResolvedIncidentCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<ResolvedIncidentDto>> UpdateResolvedIncident(ResolvedIncidentUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<ResolvedIncident>> DeleteResolvedIncident(int id, CancellationToken cancellationToken);
}