using IncidentsDecisionMicroservices.Incidents.Application.DTO.NotResolvedIncidentDtos;
using IncidentsDecisionMicroservices.Incidents.Core.Helpers;
using IncidentsDecisionMicroservices.Incidents.Core.Models.NotResolvedIncident;

namespace IncidentsDecisionMicroservices.Incidents.Application.Interfaces;

public interface INotResolvedIncidentService
{
    public Task<IEnumerable<NotResolvedIncidentDto>> GetNotResolvedIncidents(CancellationToken cancellationToken);
    public Task<Result<NotResolvedIncidentDto>> GetNotResolvedIncidentById(int id, CancellationToken cancellationToken);
    public Task<Result<NotResolvedIncidentDto>> CreateNotResolvedIncident(NotResolvedIncidentCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<NotResolvedIncidentDto>> UpdateNotResolvedIncident(NotResolvedIncidentUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<NotResolvedIncident>> DeleteNotResolvedIncident(int id, CancellationToken cancellationToken);
}