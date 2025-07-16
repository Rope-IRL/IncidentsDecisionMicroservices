using IncidentsDecisionMicroservices.TechSupportLogic.Core.Helpers;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport.ValueObjects;

namespace IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;

public class TechSupport
{
    public int? Id { get; }

    public string Name { get; private set; }

    public string Surname { get; private set; }

    public Telephone Telephone { get; private set; }

    private TechSupport(int? id, string name, string surname, Telephone telephone)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Telephone = telephone;
    }

    public static Result<TechSupport> Create(int? id, string name, string surname, string telephone)
    {
        var telephoneResult = Telephone.Create(telephone);
        if (telephoneResult.IsSuccess == false)
        {
            return Result<TechSupport>.Failure(telephoneResult.Error);
        }

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
        {
            return Result<TechSupport>.Failure("Name and surname must be not empty");
        }

        var techSupport = new TechSupport(id, name, surname, telephoneResult.Value);

        return Result<TechSupport>.Success(techSupport);
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateSurname(string surname)
    {
        Surname = surname;
    }

    public void UpdateTelephone(Telephone telephone)
    {
        Telephone = telephone;
    }
}