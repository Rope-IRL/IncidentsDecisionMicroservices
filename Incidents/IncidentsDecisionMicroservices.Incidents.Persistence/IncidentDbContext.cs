using IncidentsDecisionMicroservices.Incidents.Core.Models.NotResolvedIncident;
using IncidentsDecisionMicroservices.Incidents.Core.Models.ResolvedIncident;
using IncidentsDecisionMicroservices.Incidents.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentsDecisionMicroservices.Incidents.Persistence
{
    public class IncidentDbContext : DbContext
    {
        public DbSet<NotResolvedIncident> NotResolvedIncidents { get; set; }
        public DbSet<ResolvedIncident> ResolvedIncidents { get; set; }
        public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotResolvedIncidentConfiguration());
            modelBuilder.ApplyConfiguration(new ResolvedIncidentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
