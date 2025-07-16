using IncidentsDecisionMicroservices.Incidents.Core.Models.ResolvedIncident;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentsDecisionMicroservices.Incidents.Persistence.Configurations
{
    public class ResolvedIncidentConfiguration : IEntityTypeConfiguration<ResolvedIncident>
    {
        public void Configure(EntityTypeBuilder<ResolvedIncident> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.CreatedAt);
        }
    }
}
