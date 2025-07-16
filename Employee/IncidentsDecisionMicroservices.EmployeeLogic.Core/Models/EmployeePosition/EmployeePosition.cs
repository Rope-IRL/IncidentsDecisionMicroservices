using System.Runtime.InteropServices;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeePosition;

public class EmployeePosition
{
    public int? Id { get; }

    public int EmployeeId { get; private set; }

    public int PositionId { get; private set; }

    private EmployeePosition(int? id, int employeeId, int positionId)
    {
        Id = id;
        EmployeeId = employeeId;
        PositionId = positionId;
    }

    public static Result<EmployeePosition> Create(int? id, int employeeId, int positionId)
    {
        if (employeeId == 0 || positionId == 0)
        {
            return Result<EmployeePosition>.Failure("Employee Id and Position Id must be not empty");
        }

        var employeePosition = new EmployeePosition(id, employeeId, positionId);

        return Result<EmployeePosition>.Success(employeePosition);
    }

    public void UpdateEmployeeId(int employeeId)
    {
        EmployeeId = employeeId;
    }

    public void UpdatePositionId(int positionId)
    {
        PositionId = positionId;
    }
}