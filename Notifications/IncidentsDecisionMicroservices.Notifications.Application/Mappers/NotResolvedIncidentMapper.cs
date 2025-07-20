using IncidentsDecisionMicroservices.Notifications.Application.DTO.NotResolvedIncidentsDtos;
using IncidentsDecisionMicroservices.Notifications.Core.Helpers;
using IncidentsDecisionMicroservices.Notifications.Core.Models;

namespace IncidentsDecisionMicroservices.Notifications.Application.Mappers;

public class NotResolvedIncidentMapper
{
    public static NotResolvedIncidentDto FromDomainToDto(NotResolvedIncident notResolvedIncident)
    {
        var notResolvedIncidentDto = new NotResolvedIncidentDto()
        {
            Id = (int)notResolvedIncident.Id,
            Name = notResolvedIncident.Name,
            Description = notResolvedIncident.Description,
            CreatedAt = notResolvedIncident.CreatedAt
        };

        return notResolvedIncidentDto;
    }
}