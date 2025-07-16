using Microsoft.EntityFrameworkCore;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeeHealthGroup;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.EmployeePosition;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Position;
using IncidentsDecisionMicroservices.EmployeeLogic.Core.Models.Employee;
using IncidentsDecisionMicroservices.EmployeeLogic.Persistence.Configurations;

namespace IncidentsDecisionMicroservices.EmployeeLogic.Persistence
{
    public class IncidentDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HealthGroup> HealthGroups { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeeHealthGroup> EmployeeHealthGroups { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeHealthGroupConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePositionConfiguration());
            modelBuilder.ApplyConfiguration(new HealthGroupConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
