using LMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Data;

class EmployeeManagement
{
    private readonly EmployeeManagementDbContext _context;

    public EmployeeManagement()
    {
        _context = new EmployeeManagementDbContext();
    }

    public List<Employee> GetEmployees() => _context.Employees.ToList();

    public bool CreateEmployee(Employee employee)
    {
        _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool UpdateEmployee(Employee employee)
    {
        _context.ChangeTracker.Clear();

        _context.Employees.Update(employee);

        //var employeeToUpdate = _context.Employees.FirstOrDefault(x => x.Number == employee.Number);

        //if (employeeToUpdate != null)
        //{
        //    _context.Entry(employeeToUpdate).CurrentValues.SetValues(employee);
        //}

        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool DeleteEmployee(decimal empno)
    {
        var employee = _context.Employees.FirstOrDefault(x => x.Number == empno);

        if (employee is null)
        {
            return false;
        }

        _context.Employees.Remove(employee);
        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }
}
