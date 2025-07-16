using IncidentsDecisionMicroservices.TechSupportLogic.Core.Models.TechSupport;
using IncidentsDecisionMicroservices.TechSupportLogic.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

public class IncidentDbContext : DbContext
{
    public DbSet<TechSupport> TechSupports { get; set; }
    public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TechSupportConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}