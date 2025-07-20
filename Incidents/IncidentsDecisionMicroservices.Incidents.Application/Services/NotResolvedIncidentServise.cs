using IncidentsDecisionMicroservices.Incidents.Application.DTO.NotResolvedIncidentDtos;
using IncidentsDecisionMicroservices.Incidents.Application.Interfaces;
using IncidentsDecisionMicroservices.Incidents.Application.Mappers;
using IncidentsDecisionMicroservices.Incidents.Application.RabbitMqService;
using IncidentsDecisionMicroservices.Incidents.Application.RabbitMqService.NotResolvedIncidentService;
using IncidentsDecisionMicroservices.Incidents.Core.Helpers;
using IncidentsDecisionMicroservices.Incidents.Core.Models.NotResolvedIncident;

namespace IncidentsDecisionMicroservices.Incidents.Application.Services;

public class NotResolvedIncidentService(INotResolvedIncidentRepository repo,
    INotResolvedIncidentNotifier notifier) : INotResolvedIncidentService
{
    public async Task<IEnumerable<NotResolvedIncidentDto>> GetNotResolvedIncidents(
        CancellationToken cancellationToken)
    {
        var NotResolvedIncidents = await repo.GetNotResolvedIncidents(cancellationToken);
        var NotResolvedIncidentDtos = new List<NotResolvedIncidentDto>();
        foreach (var NotResolvedIncident in NotResolvedIncidents)
        {
            NotResolvedIncidentDtos.Add(NotResolvedIncidentMapper.FromDomainToDto(NotResolvedIncident));
        }

        return NotResolvedIncidentDtos;
    }

    public async Task<Result<NotResolvedIncidentDto>> GetNotResolvedIncidentById(int id, 
        CancellationToken cancellationToken)
    {
        var NotResolvedIncidentResult = await repo.GetNotResolvedIncidentById(id, cancellationToken);

        if (NotResolvedIncidentResult.IsSuccess == false)
        {
            return Result<NotResolvedIncidentDto>.Failure(NotResolvedIncidentResult.Error);
        }

        var NotResolvedIncident = NotResolvedIncidentMapper.FromDomainToDto(
            NotResolvedIncidentResult.Value);

        return Result<NotResolvedIncidentDto>.Success(NotResolvedIncident);
    }

    public async Task<Result<NotResolvedIncidentDto>> CreateNotResolvedIncident(
        NotResolvedIncidentCreateDto dto, 
        CancellationToken cancellationToken)
    {
        var NotResolvedIncidentResult = NotResolvedIncidentMapper.FromCreateDtoToDomain(dto);

        if (NotResolvedIncidentResult.IsSuccess == false)
        {
            return Result<NotResolvedIncidentDto>.Failure(NotResolvedIncidentResult.Error);
        }

        var createRes = await repo.CreateNotResolvedIncident(NotResolvedIncidentResult.Value, 
            cancellationToken);

        if (createRes.IsSuccess == false)
        {
            return Result<NotResolvedIncidentDto>.Failure(createRes.Error);
        }


        var res = Result<NotResolvedIncidentDto>.Success(NotResolvedIncidentMapper.FromDomainToDto(createRes.Value));
        notifier.SendMessageToQueue(createRes.Value);

        return res;
    }

    public async Task<Result<NotResolvedIncidentDto>> UpdateNotResolvedIncident(NotResolvedIncidentUpdateDto dto, CancellationToken cancellationToken)
    {
        var NotResolvedIncidentRes = NotResolvedIncidentMapper.FromUpdateDtoToDomain(dto);

        if (NotResolvedIncidentRes.IsSuccess == false)
        {
            return Result<NotResolvedIncidentDto>.Failure(NotResolvedIncidentRes.Error);
        }

        var updateRes = await repo.UpdateNotResolvedIncident(NotResolvedIncidentRes.Value, cancellationToken);

        if (updateRes.IsSuccess == false)
        {
            return Result<NotResolvedIncidentDto>.Failure(updateRes.Error);
        }

        var res = Result<NotResolvedIncidentDto>.Success(NotResolvedIncidentMapper.FromDomainToDto(updateRes.Value));

        return res;
    }

    public async Task<Result<NotResolvedIncident>> DeleteNotResolvedIncident(int id, 
        CancellationToken cancellationToken)
    {
        var NotResolvedIncidentRes = await repo.DeleteNotResolvedIncident(id, cancellationToken);

        if (NotResolvedIncidentRes.IsSuccess == false)
        {
            return Result<NotResolvedIncident>.Failure(NotResolvedIncidentRes.Error);
        }

        return Result<NotResolvedIncident>.Success(NotResolvedIncidentRes.Value);
    }
}