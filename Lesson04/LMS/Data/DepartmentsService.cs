using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace LMS.Data;

internal class DepartmentsService
{
    private readonly DatabaseService _databaseService;

    public DepartmentsService()
    {
        _databaseService = new DatabaseService();
    }

    public List<Department> GetDepartments()
    {
        var command = new SqlCommand();
        command.CommandText = "SELECT * FROM Dept\n" +
            "ORDER BY Dname, Loc";

        var departments = _databaseService.ExecuteQuery(command, DataConverter);

        return departments;
    }

    public bool Create(Department department)
    {
        var command = new SqlCommand();
        command.CommandText = "INSERT INTO Dept\n" +
            "VALUES (@deptno, @dname, @loc)";
        command.Parameters.AddWithValue("@deptno", department.Deptno);
        command.Parameters.AddWithValue("@dname", department.Dname);
        command.Parameters.AddWithValue("@loc", department.Loc);

        int affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    public bool Update(Department department)
    {
        var command = new SqlCommand();
        command.CommandText = "UPDATE Dept\n" +
            $"SET DName = @dname, Loc = @loc\n" +
            $"WHERE Deptno = @deptno";
        command.Parameters.AddWithValue("@dname", department.Dname);
        command.Parameters.AddWithValue("@loc", department.Loc);
        command.Parameters.AddWithValue("@deptno", department.Deptno);

        int affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    public bool Delete(decimal deptno)
    {
        var command = new SqlCommand();
        command.CommandText = $"DELETE FROM Dept\n" +
            $"WHERE Deptno = @deptno";
        command.Parameters.AddWithValue("@deptno", deptno);
        
        int affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    private List<Department> DataConverter(SqlDataReader reader)
    {
        List<Department> departments = new();

        while (reader.Read())
        {
            var deptno = reader.GetDecimal(0);
            var dname = reader.GetString(1);
            var loc = reader.GetString(2);

            var department = new Department(deptno, dname, loc);
            departments.Add(department);
        }

        return departments;
    }
}
