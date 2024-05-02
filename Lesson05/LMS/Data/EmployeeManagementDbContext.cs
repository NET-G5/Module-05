using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class EmployeeManagementDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salgrade> Salgrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management_ef;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}