using IncidentsDecisionMicroservices.Auth.Core.Models.EmployeeLogin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentsDecisionMicroservices.Auth.Persistence.Configurations;

public class EmployeeLoginConfiguration : IEntityTypeConfiguration<EmployeeLogin>
{
    public void Configure(EntityTypeBuilder<EmployeeLogin> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Login)
            .HasMaxLength(100);

        builder.Property(e => e.HashedPassword)
            .HasMaxLength(200);

    }
}