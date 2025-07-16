using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Employee;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeeHealthGroup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Persistence.Configurations;

public class EmployeeHealthGroupConfiguration : IEntityTypeConfiguration<EmployeeHealthGroup>
{
    public void Configure(EntityTypeBuilder<EmployeeHealthGroup> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne<Employee>()
            .WithOne()
            .HasForeignKey<EmployeeHealthGroup>(e => e.EmployeeId);

        builder.HasOne<HealthGroup>()
            .WithOne()
            .HasForeignKey<EmployeeHealthGroup>(e => e.HealthGroupId); 
    }
}