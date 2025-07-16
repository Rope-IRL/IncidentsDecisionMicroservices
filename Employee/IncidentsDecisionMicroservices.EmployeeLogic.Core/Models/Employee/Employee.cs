using IncidentsDecisionMicroservices.EmployeeLogic.Core.Helpers;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Employee.ValueObjects;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Employee;

public class Employee
{
    public int? Id { get; private set; }
    public string Name { get; private set; }

    public string Surname { get; private set; }

    public Telephone Telephone { get; private set; }

    public Gender Gender { get; private set; }

    public int? LoginId { get; private set; }

    private Employee(int? id, string name, string surname, Telephone telephone, Gender gender, int? loginId)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Telephone = telephone;
        Gender = gender;
        LoginId = loginId;
    }

    public static Result<Employee> Create(int? id, string name, string surname, string telephone, 
        string gender, int? loginId)
    {
        var telephoneResult = Telephone.Create(telephone);
        if (telephoneResult.IsSuccess == false)
        {
            return Result<Employee>.Failure(telephoneResult.Error);
        }

        var genderResult = Gender.Create(gender);
        if (genderResult.IsSuccess == false)
        {
            return Result<Employee>.Failure(genderResult.Error);
        }

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
        {
            return Result<Employee>.Failure("Name and Surname must be not empty");
        }

        var employee = new Employee(id, name, surname, telephoneResult.Value, genderResult.Value, loginId);

        return Result<Employee>.Success(employee);
    }

    public void UpdateTelephone(Telephone telephone)
    {
        Telephone = telephone; 
    }

    public void UpdateGender(Gender gender)
    {
        Gender = gender;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name) == false)
        {
            Name = name;
        }
    }
    public void UpdateSurname(string surname)
    {
        if (string.IsNullOrEmpty(surname) == false)
        {
            Surname = surname;
        }
    }
    public override string ToString()
    {
        return $"Id is {Id} Name is {Name} Surname is {Surname} Telephone is {Telephone.Number} Gender is {Gender.Value}";
    }
}