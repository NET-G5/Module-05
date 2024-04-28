using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LMS.Data;

class EmployeeManagement
{
    public List<Employee> GetEmployees()
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management;Integrated Security=True");
        List<Employee> employees = new List<Employee>();

        try
        {
            sqlConnection.Open();

            // SqlCommand command = sqlConnection.CreateCommand();
            // SqlCommand command = new SqlCommand("SELECT * FROM EMP;", sqlConnection);
            
            SqlCommand command = new()
            {
                CommandText = "SELECT * FROM EMP;",
                Connection = sqlConnection
            };

            SqlDataReader reader = command.ExecuteReader();

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
        }
        catch(Exception ex)
        { 
            MessageBox.Show($"There was error loading data from database: {ex.Message}", 
                "Error", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }
        finally
        {
            sqlConnection.Close();
        }

        return employees;
    }

    public bool CreateEmployee(Employee employee)
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management;Integrated Security=True");

        try
        {
            sqlConnection.Open();

            SqlCommand command = sqlConnection.CreateCommand();
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

            int affectedRows = command.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                MessageBox.Show(
                    $"{employee.Ename} was successfully saved.",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return true;
            }

            MessageBox.Show(
                    $"Something went wrong while saving new employee.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

        }
        catch (Exception ex)
        {
            MessageBox.Show(
                    $"Something went wrong while saving new employee: {ex.Message}.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }
        finally
        {
            sqlConnection.Close();
        }

        return false;
    }

    public bool UpdateEmployee(Employee employee)
    {
        SqlConnection connection = new SqlConnection("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management;Integrated Security=True;");
        int affectedRows = 0;

        try
        {
            connection.Open();

            var command = connection.CreateCommand();
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

             affectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"There was an error updating employee: {employee.Ename}. Please, try again. Details: {ex.Message}",
                "Error updating employee!",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            connection.Close();
        }

        return affectedRows > 0;
    }

    /// <summary>
    /// Deletes given employee from database. Uses Empno as an identifier.
    /// If operation is not successfull display an error message using <see cref="MessageBox"/>.
    /// 
    /// </summary>
    /// <param name="empno"></param>
    /// <returns></returns>
    public bool DeleteEmployee(decimal empno)
    {
        SqlConnection connection = new SqlConnection("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management;Integrated Security=True;");
        int affectedRows = 0;

        try
        {
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = "DELETE FROM Emp\n" +
                "WHERE Empno = @empno";

            command.Parameters.AddWithValue("@empno", empno);

            affectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"There was an error deleting employee with number: {empno}. Please, try again.\nDetails: {ex.Message}",
                "Database error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally 
        { 
            connection.Close(); 
        }

        return affectedRows > 0;
    }
}
