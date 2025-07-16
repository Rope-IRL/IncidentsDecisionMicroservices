using IncidentsDecisionMicroservices.Auth.Core.Models.EmployeeLogin;
using IncidentsDecisionMicroservices.Auth.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

public class IncidentDbContext : DbContext
{
    public DbSet<EmployeeLogin> EmployeeLogins { get; set; }
    public DbSet<TechSupportLogin> TechSupportLogins { get; set; }
    public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeLoginConfiguration());
        modelBuilder.ApplyConfiguration(new TechSupportLoginConfiguration());
        base.OnModelCreating(modelBuilder);
    }

}