using API.Data.Configurations;
using API.Data.Entities;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
