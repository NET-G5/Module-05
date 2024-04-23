using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LMS.Views
{
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEmployeeDialog();

            dialog.ShowDialog();

            var employees = _databaseManager.GetEmployees();

            EmployeesDataGrid.ItemsSource = null;
            EmployeesDataGrid.ItemsSource = employees;
        }

        private void EmployeesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var employee = EmployeesDataGrid.SelectedItem as Employee;

            if (employee != null)
            {
                var window = new AddEmployeeDialog(employee);
                window.ShowDialog();
            }
        }
    }
}
