using LMS.Data;
using LMS.Models;
using System.Windows;
using System.Windows.Input;

namespace LMS.Views;

/// <summary>
/// Interaction logic for EmployeesWindow.xaml
/// </summary>
public partial class EmployeesWindow : Window
{
    private readonly EmployeeManagement _databaseManager;

    public EmployeesWindow()
    {
        InitializeComponent();

        _databaseManager = new EmployeeManagement();

        var employees = _databaseManager.GetEmployees();

        EmployeesDataGrid.ItemsSource = employees;
    }

    private void AddEmployee_Clicked(object sender, RoutedEventArgs e)
    {
        var dialog = new AddEmployeeDialog();
        dialog.ShowDialog();

        var employees = _databaseManager.GetEmployees();

        EmployeesDataGrid.ItemsSource = null;
        EmployeesDataGrid.ItemsSource = employees;
    }

    private void DeleteEmployee_Clicked(object sender, RoutedEventArgs e)
    {
        if (EmployeesDataGrid.SelectedItem is not Employee selectedEmployee)
        {
            MessageBox.Show(
                "Please, select an employee to delete",
                "Error",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
            return;
        }

        var isConfirm = MessageBox.Show(
            $"Are you sure you want to delete: {selectedEmployee.Name}?",
            "Confirm your action.",
            MessageBoxButton.YesNoCancel,
            MessageBoxImage.Question);

        if (isConfirm != MessageBoxResult.Yes)
        {
            return;
        }

        var result = _databaseManager.DeleteEmployee(selectedEmployee.Number);

        if (result)
        {
            var employees = _databaseManager.GetEmployees();

            EmployeesDataGrid.ItemsSource = null;
            EmployeesDataGrid.ItemsSource = employees;
        }
    }

    private void EmployeesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var employee = EmployeesDataGrid.SelectedItem as Employee;

        if (employee != null)
        {
            var window = new AddEmployeeDialog(employee);
            window.ShowDialog();

            var employees = _databaseManager.GetEmployees();

            EmployeesDataGrid.ItemsSource = null;
            EmployeesDataGrid.ItemsSource = employees;
        }
    }

    private void EmployeesDataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
    {

    }
}
