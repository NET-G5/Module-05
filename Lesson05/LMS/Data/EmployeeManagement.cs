using LMS.Migrations;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LMS.Data;

class EmployeeManagement
{
    private readonly EmployeeManagementDbContext _context;

    public EmployeeManagement()
    {
        _context = new EmployeeManagementDbContext();
    }

    public List<Employee> GetEmployees() => _context.Employees.Include(x => x.Department).ToList();

    public bool CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
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
