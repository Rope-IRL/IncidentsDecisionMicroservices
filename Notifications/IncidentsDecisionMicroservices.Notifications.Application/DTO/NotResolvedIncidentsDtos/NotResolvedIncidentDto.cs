﻿namespace IncidentsDecisionMicroservices.Notifications.Application.DTO.NotResolvedIncidentsDtos
{
    public class NotResolvedIncidentDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
