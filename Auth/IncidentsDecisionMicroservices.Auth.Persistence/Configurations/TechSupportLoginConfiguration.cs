using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentsDecisionMicroservices.Auth.Persistence.Configurations;

public class TechSupportLoginConfiguration : IEntityTypeConfiguration<TechSupportLogin>
{
    public void Configure(EntityTypeBuilder<TechSupportLogin> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Login)
            .HasMaxLength(100);

        builder.Property(e => e.HashedPassword)
            .HasMaxLength(200);
    }
}