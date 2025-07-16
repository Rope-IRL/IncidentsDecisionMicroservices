using IncidentsDecisionMicroservices.EmployeeLogic.Application.DTO.EmployeeHealthGroupDtos;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeeHealthGroup;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Application.Interfaces;

public interface IEmployeeHealthGroupService
{
    public Task<IEnumerable<EmployeeHealthGroupDto>> GetEmployeeHealthGroups(CancellationToken cancellationToken);
    public Task<Result<EmployeeHealthGroupDto>> GetEmployeeHealthGroupById(int id, CancellationToken cancellationToken);
    public Task<Result<EmployeeHealthGroupDto>> CreateEmployeeHealthGroup(EmployeeHealthGroupCreateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeeHealthGroupDto>> UpdateEmployeeHealthGroup(EmployeeHealthGroupUpdateDto dto, CancellationToken cancellationToken);
    public Task<Result<EmployeeHealthGroup>> DeleteEmployeeHealthGroup(int id, CancellationToken cancellationToken);
}