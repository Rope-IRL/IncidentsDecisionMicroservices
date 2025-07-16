using IncidentsDecisionMicroservices.EmployeeLogic.Application.DTO.EmployeePositionDtos;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeePosition;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Application.Mappers;

public class EmployeePositionMapper
{
    public static Result<EmployeePosition> FromCreateDtoToDomain(EmployeePositionCreateDto dto)
    {
        int? id = null;
        var employeePositionResult = EmployeePosition.Create(id, dto.EmployeeId, dto.PositionId);

        if (employeePositionResult.IsSuccess == false)
        {
            return Result<EmployeePosition>.Failure(employeePositionResult.Error);
        }

        return Result<EmployeePosition>.Success(employeePositionResult.Value);
    }
    public static Result<EmployeePosition> FromUpdateDtoToDomain(EmployeePositionUpdateDto dto)
    {
        var employeePositionResult = EmployeePosition.Create(dto.Id, dto.EmployeeId, dto.PositionId);

        if (employeePositionResult.IsSuccess == false)
        {
            return Result<EmployeePosition>.Failure(employeePositionResult.Error);
        }

        return Result<EmployeePosition>.Success(employeePositionResult.Value);
    }

    public static EmployeePositionDto FromDomainToDto(EmployeePosition employeePosition)
    {
        var employeePositionDto = new EmployeePositionDto()
        {
            Id = (int)employeePosition.Id,
            EmployeeId = employeePosition.EmployeeId,
            PositionId = employeePosition.PositionId
        };

        return employeePositionDto;
    }
}