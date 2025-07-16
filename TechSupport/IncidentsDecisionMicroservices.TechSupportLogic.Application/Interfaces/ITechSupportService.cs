using IncidentsDecisionMicroservices.TechSupportLogic.Application.DTO.TechSupportDtos;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Helpers;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;

namespace IncidentsDecisionMicroservices.TechSupportLogic.Application.Interfaces;

public interface ITechSupportService
{
    public Task<IEnumerable<TechSupportDto>> GetTechSupports(CancellationToken cancellationToken);
    public Task<Result<TechSupportDto>> GetTechSupportById(int id, CancellationToken cancellationToken);
    public Task<Result<TechSupportDto>> CreateTechSupport(TechSupportCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<TechSupportDto>> UpdateTechSupport(TechSupportUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<TechSupport>> DeleteTechSupport(int id, CancellationToken cancellationToken);
}