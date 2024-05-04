using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LMS.Data;

internal class DepartmentsService
{
    private readonly EmployeeManagementDbContext _context;

    public DepartmentsService()
    {
        _context = new EmployeeManagementDbContext();
    }

    public List<Department> GetDepartments() => _context.Departments.ToList();

    public bool Create(Department department)
    {
        _context.Departments.Add(department);
        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool Update(Department department)
    {
        _context.Departments.Update(department);
        // _context.Entry(department).State = EntityState.Modified;

        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool Delete(decimal deptno)
    {
        var department = _context.Departments.FirstOrDefault(x => x.Number == deptno);

        if (department is null)
        {
            return false;
        }

        _context.Departments.Remove(department);
        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }
}
