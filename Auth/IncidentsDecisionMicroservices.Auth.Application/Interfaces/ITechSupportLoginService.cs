using IncidentsDecisionMicroservices.Auth.Application.DTO.TechSupportLoginDtos;
using IncidentsDecisionMicroservices.Auth.Core.Helpers;

namespace IncidentsDecisionMicroservices.Auth.Application.Interfaces;

public interface ITechSupportLoginService
{
    public Task<IEnumerable<TechSupportLoginDto>> GetTechSupportLogins(CancellationToken cancellationToken);
    public Task<Result<TechSupportLoginDto>> GetTechSupportLoginById(int id, CancellationToken cancellationToken);
    public Task<Result<TechSupportLoginDto>> CreateTechSupportLogin(TechSupportLoginCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<TechSupportLoginDto>> UpdateTechSupportLogin(TechSupportLoginUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<TechSupportLogin>> DeleteTechSupportLogin(int id, CancellationToken cancellationToken);
    public Task<Result<string>> LoginTechSupport(string login, string password, CancellationToken cancellationToken);
}