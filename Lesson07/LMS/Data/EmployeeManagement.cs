using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LMS.Data;

class EmployeeManagement
{
    private readonly EmployeeManagementDbContext _context;

    public EmployeeManagement()
    {
        _context = new EmployeeManagementDbContext();
    }

    public List<Employee> GetEmployeesEnumerable(string? searchString = "",
        decimal? minSalary = null,
        decimal? maxSalary = null)
    {
        var query = _context.Employees.Where(x => x.Salary > 100).ToList();

        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(x => x.Name.Contains(searchString) || x.Job.Contains(searchString)).ToList();
        }

        if (minSalary is not null && maxSalary is not null)
        {
            query = query.Where(x => x.Salary > minSalary && x.Salary < maxSalary).ToList();
        }

        return query;
    }

    // Eager loading
    public List<Employee> GetEmployees(string? searchString = "", 
        decimal? minSalary = null, 
        decimal? maxSalary = null)
    {
        var query = _context.Employees.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(x => x.Name.Contains(searchString) || x.Job.Contains(searchString));
        }

        if (minSalary is not null && maxSalary is not null)
        {
            query = query.Where(x => x.Salary > minSalary && x.Salary < maxSalary);
        }

        return query.ToList();
    }

    // Lazy loading
    public List<Employee> GetEmployeesLazy()
    {
        var employees = _context.Employees.ToList(); // 100

        // 100 x 4 = 400 + (100 users) -> 40.000
        foreach (var employee in employees)
        {
            MessageBox.Show(employee.Name);
            MessageBox.Show(employee.Department.Name); // Loads only department
            MessageBox.Show(employee.Department.City.Name); // Loads only city
            MessageBox.Show(employee.Department.City.Country.Name); // Loads country only in this line
        }

        return employees;
    }

    // Explicit
    public List<Employee> GetEmployeesExplicit()
    {
        var employees = _context.Employees.ToList(); // 100

        // 100 x 4 = 400 + (100 users) -> 40.000
        foreach (var employee in employees)
        {
            MessageBox.Show(employee.Name);

            if (employee.Salary > 2000)
            {
                _context.Entry(employee)
                    .Reference("Department")
                    .Load();
                _context.Entry(employee.Department)
                    .Reference("City")
                    .Load();

                MessageBox.Show(employee.Department.Name); // Loads only department
                MessageBox.Show(employee.Department.City.Name); // Loads only city
                MessageBox.Show(employee.Department.City.Country.Name); // Loads country only in this line
            }
        }

        return employees;
    }

    public bool CreateEmployee(Employee employee)
    {
        _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool UpdateEmployee(Employee employee)
    {
        //_context.ChangeTracker.Clear();

        //_context.Employees.Update(employee);

        var employeeToUpdate = _context.Employees.FirstOrDefault(x => x.Number == employee.Number);

        if (employeeToUpdate != null)
        {
            _context.Entry(employeeToUpdate).CurrentValues.SetValues(employee);
        }

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

public record Test(int Property);
