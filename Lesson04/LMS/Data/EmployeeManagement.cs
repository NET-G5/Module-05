using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LMS.Data;

class EmployeeManagement
{
    private readonly DatabaseService _databaseService;

    public EmployeeManagement()
    {
        _databaseService = new DatabaseService();
    }

    public List<Employee> GetEmployees()
    {
        var command = new SqlCommand("SELECT * FROM EMP;");

        List<Employee> employees = _databaseService.ExecuteQuery(command, DataConverter);

        return employees;
    }

    public bool CreateEmployee(Employee employee)
    {
        var command = new SqlCommand();
        command.CommandText = $"INSERT INTO EMP (Empno, Ename, Job, Mgr, Hiredate, Sal, Comm, Deptno) " +
            $" VALUES (@empno, @ename, @job, @mgr, @hiredate, @sal, @comm, @deptno)";

        command.Parameters.AddWithValue("@empno", employee.Empno);
        command.Parameters.AddWithValue("@ename", employee.Ename);
        command.Parameters.AddWithValue("@job", employee.Job);
        command.Parameters.AddWithValue("@mgr", employee.Mgr == null ? DBNull.Value : employee.Mgr);
        command.Parameters.AddWithValue("@hiredate", employee.Hiredate.ToString("MM/dd/yyyy"));
        command.Parameters.AddWithValue("@sal", employee.Salary);
        command.Parameters.AddWithValue("@comm", employee.Comm == null ? DBNull.Value : employee.Comm);
        command.Parameters.AddWithValue("@deptno", employee.Deptno);

        int affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    public bool UpdateEmployee(Employee employee)
    {
        var command = new SqlCommand();
        command.CommandText = "UPDATE Emp SET\n" +
            $"Ename = @ename, Job = @job, Mgr = @mgr, Hiredate = @hiredate, Sal = @sal, Comm = @comm, Deptno = @deptno\n" +
            $"WHERE Empno = @empno";

        command.Parameters.AddWithValue("@empno", employee.Empno);
        command.Parameters.AddWithValue("@ename", employee.Ename);
        command.Parameters.AddWithValue("@Job", employee.Job);
        command.Parameters.AddWithValue("@mgr", employee.Mgr == null ? DBNull.Value : employee.Mgr);
        command.Parameters.AddWithValue("@hiredate", employee.Hiredate.ToString("MM/dd/yyyy"));
        command.Parameters.AddWithValue("@sal", employee.Salary);
        command.Parameters.AddWithValue("@comm", employee.Comm == null ? DBNull.Value : employee.Comm);
        command.Parameters.AddWithValue("@deptno", employee.Deptno);

        int affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    public bool DeleteEmployee(decimal empno)
    {
        var command = new SqlCommand();
        command.CommandText = "DELETE FROM Emp\n" +
            "WHERE Empno = @empno";

        command.Parameters.AddWithValue("@empno", empno);

        int affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    private List<Employee> DataConverter(SqlDataReader reader)
    {
        List<Employee> employees = new();

        while (reader.Read())
        {
            decimal empno = reader.GetDecimal(0);
            string ename = reader.GetString(1);
            string job = reader.GetString(2);
            decimal? mgr = reader.IsDBNull(3) ? null : reader.GetDecimal(3);
            DateTime hiredate = reader.GetDateTime(4);
            decimal sal = reader.GetDecimal(5);
            decimal? comm = reader.IsDBNull(6) ? null : reader.GetDecimal(6);
            decimal deptno = reader.GetDecimal(7);

            var employee = new Employee(empno, ename, job, mgr, hiredate, sal, comm, deptno);

            employees.Add(employee);
        }

        return employees;
    }
}
