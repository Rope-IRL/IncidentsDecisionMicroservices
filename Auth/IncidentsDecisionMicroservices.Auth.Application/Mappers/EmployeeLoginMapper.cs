using IncidentsDecisionMicroservices.Auth.Application.DTO.EmployeeLoginDtos;
using IncidentsDecisionMicroservices.Auth.Core.Helpers;
using IncidentsDecisionMicroservices.Auth.Core.Models.EmployeeLogin;

namespace IncidentsDecisionMicroservices.Auth.Application.Mappers;

public class EmployeeLoginMapper
{
    public static Result<EmployeeLogin> FromCreateDtoToDomain(EmployeeLoginCreateDto dto)
    {
        int? id = null;
        int? employeeId = null;
        var employeeLoginResult = EmployeeLogin.Create(id, dto.Login, dto.HashedPassword, employeeId);

        if (employeeLoginResult.IsSuccess == false)
        {
            return Result<EmployeeLogin>.Failure(employeeLoginResult.Error);
        }

        return Result<EmployeeLogin>.Success(employeeLoginResult.Value);
    }
    public static Result<EmployeeLogin> FromUpdateDtoToDomain(EmployeeLoginUpdateDto dto)
    {
        int? loginId = null;
        var employeeLoginResult = EmployeeLogin.Create(dto.Id, dto.Login, dto.HashedPassword, loginId);

        if (employeeLoginResult.IsSuccess == false)
        {
            return Result<EmployeeLogin>.Failure(employeeLoginResult.Error);
        }

        return Result<EmployeeLogin>.Success(employeeLoginResult.Value);
    }

    public static EmployeeLoginDto FromDomainToDto(EmployeeLogin employeeLogin)
    {
        var employeeLoginDto = new EmployeeLoginDto()
        {
            Id = (int)employeeLogin.Id,
            Login = employeeLogin.Login,
            HashedPassword = employeeLogin.HashedPassword
        };

        return employeeLoginDto;
    }
}