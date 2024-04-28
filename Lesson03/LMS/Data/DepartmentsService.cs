using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace LMS.Data;

internal class DepartmentsService
{
    public List<Department> GetDepartments()
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHIRJON-LAPTOP;Initial Catalog=employee_management;Integrated Security=True");
        List<Department> departments = new List<Department>();

        try
        {
            sqlConnection.Open();

            var command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Dept\n" +
                "ORDER BY Dname, Loc";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var deptno = reader.GetDecimal(0);
                var dname = reader.GetString(1);
                var loc = reader.GetString(2);

                var department = new Department(deptno, dname, loc);
                departments.Add(department);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Error fetching departments. Please, try again later.\nDetails: {ex.Message}",
                "Database error.",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            sqlConnection.Close();
        }

        return departments;
    }
}
