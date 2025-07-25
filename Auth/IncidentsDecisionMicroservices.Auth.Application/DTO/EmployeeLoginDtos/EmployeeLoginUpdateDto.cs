namespace IncidentsDecisionMicroservices.Auth.Application.DTO.EmployeeLoginDtos;

public class EmployeeLoginUpdateDto
{
    public int Id { get; set; } = 0;
    public string Login { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty; 
}