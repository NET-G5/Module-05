using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace LMS.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeDialog.xaml
    /// </summary>
    public partial class AddEmployeeDialog : Window
    {
        private readonly EmployeeManagement _databaseManager;
        private readonly DepartmentsService _departmentsService;
        private readonly bool isEditingMode;

        public AddEmployeeDialog()
        {
            InitializeComponent();

            _databaseManager = new EmployeeManagement();
            _departmentsService = new DepartmentsService();

            hiredateInput.SelectedDate = DateTime.Now;

            var departments = _departmentsService.GetDepartments();
            departmentsCombobox.ItemsSource = departments;
            departmentsCombobox.SelectedIndex = 0;

            var managers = _databaseManager.GetEmployees();
            managersCombobox.ItemsSource = managers;
            managersCombobox.SelectedIndex = 0;

        }

        public AddEmployeeDialog(Employee employee)
            : this()
        {
            isEditingMode = true;
            empnoInput.IsEnabled = false;

            empnoInput.Text = employee.Empno.ToString();
            enameInput.Text = employee.Ename.ToString();
            jobInput.Text = employee.Job.ToString();
            hiredateInput.SelectedDate = employee.Hiredate;
            salInput.Text = employee.Salary.ToString();
            commInput.Text = employee.Comm.ToString();

            var departments = departmentsCombobox.ItemsSource as List<Department>;
            if (departments is null)
            {
                return;
            }

            var department = departments.Find(x => x.Deptno == employee.Deptno);
            departmentsCombobox.SelectedItem = department;

            var managers = managersCombobox.ItemsSource as List<Employee>;
            if (managers is null)
            {
                return;
            }

            var manager = managers.Find(x => x.Empno == employee.Mgr);
            managersCombobox.SelectedItem = manager;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var empno = decimal.Parse(empnoInput.Text);
            var ename = enameInput.Text;
            var job = jobInput.Text;
            var hiredate = hiredateInput.SelectedDate ?? DateTime.Now;
            var sal = decimal.Parse(salInput.Text);
            decimal? comm = string.IsNullOrEmpty(commInput.Text) ? null : decimal.Parse(commInput.Text);

            var selectedDepartment = departmentsCombobox.SelectedItem as Department;
            if (selectedDepartment is null)
            {
                MessageBox.Show("Please, select department.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedManager = managersCombobox.SelectedItem as Employee;

            var deptno = selectedDepartment.Deptno;
            var mgr = selectedManager?.Empno;

            var employee = new Employee(empno, ename, job, mgr, hiredate, sal, comm, deptno);
            
            bool isSuccess;

            if (isEditingMode)
            {
                isSuccess = _databaseManager.UpdateEmployee(employee);
            }
            else
            {
                isSuccess = _databaseManager.CreateEmployee(employee);
            }

            if (isSuccess)
                Close();
        }
    }
}
