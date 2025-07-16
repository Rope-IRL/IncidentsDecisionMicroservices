using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;
using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentsDecisionMicroservices.TechSupportLogic.Persistence.Configurations;

public class TechSupportConfiguration : IEntityTypeConfiguration<TechSupport>
{
    public void Configure(EntityTypeBuilder<TechSupport> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(30);

        builder.Property(e => e.Surname)
            .HasMaxLength(40);

        builder.Property(e => e.Telephone)
            .HasConversion(telephone => telephone.Number,
                value => Telephone.Create(value).Value);
    }
}