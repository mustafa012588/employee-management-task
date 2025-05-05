using EmployeeApi.DAL;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(EmployeeContext).Assembly
    );
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
