namespace IncidentsDecisionMicroservices.Notifications.Core.Models
{
    public class NotResolvedIncident
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public NotResolvedIncident(int? id, string name, string description, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"Name of the cur incident is {Name} Description is {Description} Date is {CreatedAt}";
        }
    }
}
