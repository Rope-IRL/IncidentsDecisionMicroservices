using IncidentsDecisionMicroservices.TechSupportLogic.Application.DTO.TechSupportDtos;
using IncidentsDecisionMicroservices.TechSupportLogic.Application.Interfaces;
using IncidentsDecisionMicroservices.TechSupportLogic.Application.Mappers;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Helpers;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Repositories;

namespace IncidentsDecisionMicroservices.TechSupportLogic.Application.Services;

public class TechSupportService(ITechSupportRepository repo): ITechSupportService 
{
    public async Task<IEnumerable<TechSupportDto>> GetTechSupports(CancellationToken cancellationToken)
    {
        var techSupports = await repo.GetTechSupports(cancellationToken);
        var techSupportDtos = new List<TechSupportDto>();
        foreach (var techSupport in techSupports)
        {
            techSupportDtos.Add(TechSupportMapper.FromDomainToDto(techSupport));
        }

        return techSupportDtos;
    }

    public async Task<Result<TechSupportDto>> GetTechSupportById(int id, CancellationToken cancellationToken)
    {
        var techSupportResult = await repo.GetTechSupportById(id, cancellationToken);

        if (techSupportResult.IsSuccess == false)
        {
            return Result<TechSupportDto>.Failure(techSupportResult.Error);
        }

        var techSupport = TechSupportMapper.FromDomainToDto(techSupportResult.Value);

        return Result<TechSupportDto>.Success(techSupport);
    }

    public async Task<Result<TechSupportDto>> CreateTechSupport(TechSupportCreateDto dto, CancellationToken cancellationToken)
    {
        var techSupportResult = TechSupportMapper.FromCreateDtoToDomain(dto);

        if (techSupportResult.IsSuccess == false)
        {
            return Result<TechSupportDto>.Failure(techSupportResult.Error);
        }

        var createRes = await repo.CreateTechSupport(techSupportResult.Value, cancellationToken);

        if (createRes.IsSuccess == false)
        {
            return Result<TechSupportDto>.Failure(createRes.Error);
        }

        var res = Result<TechSupportDto>.Success(TechSupportMapper.FromDomainToDto(createRes.Value));

        return res;
    }

    public async Task<Result<TechSupportDto>> UpdateTechSupport(TechSupportUpdateDto dto, CancellationToken cancellationToken)
    {
        var techSupportRes = TechSupportMapper.FromUpdateDtoToDomain(dto);

        if (techSupportRes.IsSuccess == false)
        {
            return Result<TechSupportDto>.Failure(techSupportRes.Error);
        }

        var updateRes = await repo.UpdateTechSupport(techSupportRes.Value, cancellationToken);

        if (updateRes.IsSuccess == false)
        {
            return Result<TechSupportDto>.Failure(updateRes.Error);
        }

        var res = Result<TechSupportDto>.Success(TechSupportMapper.FromDomainToDto(updateRes.Value));

        return res;
    }

    public async Task<Result<TechSupport>> DeleteTechSupport(int id, CancellationToken cancellationToken)
    {
        var techSupportRes = await repo.DeleteTechSupport(id, cancellationToken);

        if (techSupportRes.IsSuccess == false)
        {
            return Result<TechSupport>.Failure(techSupportRes.Error);
        }

        return Result<TechSupport>.Success(techSupportRes.Value);
    }
}