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
    /// Interaction logic for AddEmployeeDialog.xaml
    /// </summary>
    public partial class AddEmployeeDialog : Window
    {
        private readonly EmployeeManagement _databaseManager;
        private readonly bool isEditingMode;

        public AddEmployeeDialog()
        {
            InitializeComponent();

            hiredateInput.SelectedDate = DateTime.Now;
            _databaseManager = new EmployeeManagement();
        }

        public AddEmployeeDialog(Employee employee)
            : this()
        {
            isEditingMode = true;
            empnoInput.IsEnabled = false;

            empnoInput.Text = employee.Empno.ToString();
            enameInput.Text = employee.Ename.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var empno = decimal.Parse(empnoInput.Text);
            var ename = enameInput.Text;
            var job = jobInput.Text;
            decimal? mgr = string.IsNullOrEmpty(mgrInput.Text) ? null : decimal.Parse(mgrInput.Text);
            var hiredate = hiredateInput.SelectedDate ?? DateTime.Now;
            var sal = decimal.Parse(salInput.Text);
            decimal? comm = string.IsNullOrEmpty(commInput.Text) ? null : decimal.Parse(commInput.Text);
            var deptno = decimal.Parse(deptnoInput.Text);

            var newEmployee = new Employee(empno, ename, job, mgr, hiredate, sal, comm, deptno);
            
            bool isSuccess;

            if (isEditingMode)
            {
                isSuccess = _databaseManager.UpdateEmployee(employee);
            }
            else
            {
                isSuccess = _databaseManager.CreateEmployee(newEmployee);
            }

            if (isSuccess)
                Close();
        }
    }
}
