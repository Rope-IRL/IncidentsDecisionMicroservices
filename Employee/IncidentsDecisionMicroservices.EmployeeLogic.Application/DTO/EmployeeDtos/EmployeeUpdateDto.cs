using System.ComponentModel.DataAnnotations;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Application.DTO.EmployeeDtos;

public class EmployeeUpdateDto
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

}