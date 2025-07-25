using IncidentsDecisionMicroservices.Auth.Application.DTO.EmployeeLoginDtos;
using IncidentsDecisionMicroservices.Auth.Application.Interfaces;
using IncidentsDecisionMicroservices.Auth.Application.Mappers;
using IncidentsDecisionMicroservices.Auth.Core.Helpers;
using IncidentsDecisionMicroservices.Auth.Core.Models.EmployeeLogin;
using IncidentsDecisionMicroservices.Auth.Core.Repositories;

namespace IncidentsDecisionMicroservices.Auth.Application.Services;

public class EmployeeLoginService(IEmployeeLoginRepository repo,
     ITokenProvider provider) : IEmployeeLoginService
{
    public async Task<IEnumerable<EmployeeLoginDto>> GetEmployeeLogins(CancellationToken cancellationToken)
    {
        var employeeLogins = await repo.GetEmployeeLogins(cancellationToken);
        var employeeLoginDtos = new List<EmployeeLoginDto>();
        foreach (var employeeLogin in employeeLogins)
        {
            employeeLoginDtos.Add(EmployeeLoginMapper.FromDomainToDto(employeeLogin));
        }

        return employeeLoginDtos;
    }

    public async Task<Result<EmployeeLoginDto>> GetEmployeeLoginById(int id, CancellationToken cancellationToken)
    {
        var employeeLoginResult = await repo.GetEmployeeLoginById(id, cancellationToken);

        if (employeeLoginResult.IsSuccess == false)
        {
            return Result<EmployeeLoginDto>.Failure(employeeLoginResult.Error);
        }

        var employeeLogin = EmployeeLoginMapper.FromDomainToDto(employeeLoginResult.Value);

        return Result<EmployeeLoginDto>.Success(employeeLogin);
    }

    public async Task<Result<EmployeeLoginDto>> CreateEmployeeLogin(EmployeeLoginCreateDto dto, CancellationToken cancellationToken)
    {
        var employeeLoginResult = EmployeeLoginMapper.FromCreateDtoToDomain(dto);

        if (employeeLoginResult.IsSuccess == false)
        {
            return Result<EmployeeLoginDto>.Failure(employeeLoginResult.Error);
        }

        var createRes = await repo.CreateEmployeeLogin(employeeLoginResult.Value, cancellationToken);

        if (createRes.IsSuccess == false)
        {
            return Result<EmployeeLoginDto>.Failure(createRes.Error);
        }

        var res = Result<EmployeeLoginDto>.Success(EmployeeLoginMapper.FromDomainToDto(createRes.Value));

        return res;
    }

    public async Task<Result<EmployeeLoginDto>> UpdateEmployeeLogin(EmployeeLoginUpdateDto dto, CancellationToken cancellationToken)
    {
        var employeeLoginRes = EmployeeLoginMapper.FromUpdateDtoToDomain(dto);

        if (employeeLoginRes.IsSuccess == false)
        {
            return Result<EmployeeLoginDto>.Failure(employeeLoginRes.Error);
        }

        var updateRes = await repo.UpdateEmployeeLogin(employeeLoginRes.Value, cancellationToken);

        if (updateRes.IsSuccess == false)
        {
            return Result<EmployeeLoginDto>.Failure(updateRes.Error);
        }

        var res = Result<EmployeeLoginDto>.Success(EmployeeLoginMapper.FromDomainToDto(updateRes.Value));

        return res;
    }

    public async Task<Result<EmployeeLogin>> DeleteEmployeeLogin(int id, CancellationToken cancellationToken)
    {
        var employeeLoginRes = await repo.DeleteEmployeeLogin(id, cancellationToken);

        if (employeeLoginRes.IsSuccess == false)
        {
            return Result<EmployeeLogin>.Failure(employeeLoginRes.Error);
        }

        return Result<EmployeeLogin>.Success(employeeLoginRes.Value);
    }

    public async Task<Result<string>> LoginEmployee(string login, string password, CancellationToken cancellationToken)
    {
        var employeeLoginResult = await repo.GetEmployeeByLogin(login, cancellationToken);

        if (employeeLoginResult.IsSuccess == false)
        {
            return Result<string>.Failure(employeeLoginResult.Error);
        }

        if (employeeLoginResult.Value.HashedPassword != password)
        {
            return Result<string>.Failure("Failed to login with such password");
        }

        if (employeeLoginResult.Value.EmployeeId == null)
        {
            return Result<string>.Failure("Failed to find employee with such credentials");
        }

        var token = provider.Create((int)employeeLoginResult.Value.Id);

        return Result<string>.Success(token); 

    }
}