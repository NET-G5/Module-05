using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class EmployeeManagementDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salgrade> Salgrades { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Country { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management_ef;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<Street>(s => s.ToTable(nameof(Street)));
            modelBuilder.Entity<Street>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .HasDefaultValue("Oybek street")
                .IsRequired();
            modelBuilder.Entity<Street>()
                .HasOne(x => x.City)
                .WithMany(c => c.Streets)
                .HasForeignKey(x => x.CityId)
                .HasConstraintName("Street_City_FK");

            base.OnModelCreating(modelBuilder);
        }
    }
}