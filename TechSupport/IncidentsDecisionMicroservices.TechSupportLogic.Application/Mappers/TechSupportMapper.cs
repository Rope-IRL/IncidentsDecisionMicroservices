using IncidentsDecisionMicroservices.TechSupportLogic.Application.DTO.TechSupportDtos;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Helpers;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;

namespace IncidentsDecisionMicroservices.TechSupportLogic.Application.Mappers;

public class TechSupportMapper
{
    public static Result<TechSupport> FromCreateDtoToDomain(TechSupportCreateDto dto)
    {
        int? id = null;
        var techSupportResult = TechSupport.Create(id, dto.Name, dto.Surname, dto.Telephone);

        if (techSupportResult.IsSuccess == false)
        {
            return Result<TechSupport>.Failure(techSupportResult.Error);
        }

        return Result<TechSupport>.Success(techSupportResult.Value);
    }

    public static Result<TechSupport> FromUpdateDtoToDomain(TechSupportUpdateDto dto)
    {
        int? loginId = null;
        var techSupportResult = TechSupport.Create(dto.Id, dto.Name, dto.Surname, dto.Telephone);

        if (techSupportResult.IsSuccess == false)
        {
            return Result<TechSupport>.Failure(techSupportResult.Error);
        }

        return Result<TechSupport>.Success(techSupportResult.Value);
    }

    public static TechSupportDto FromDomainToDto(TechSupport TechSupport)
    {
        var TechSupportDto = new TechSupportDto()
        {
            Id = (int)TechSupport.Id,
            Name = TechSupport.Name,
            Surname = TechSupport.Surname,
            Telephone = TechSupport.Telephone.Number,
        };

        return TechSupportDto;
    }
}