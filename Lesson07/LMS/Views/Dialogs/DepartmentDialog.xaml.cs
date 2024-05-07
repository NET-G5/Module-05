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

namespace LMS.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DepartmentsDialog.xaml
    /// </summary>
    public partial class DepartmentDialog : Window
    {
        private readonly DepartmentsService _departmentsService;
        private readonly bool isEditingMode;

        public DepartmentDialog()
        {
            InitializeComponent();

            Title = "Add Department";

            _departmentsService = new DepartmentsService();
        }

        public DepartmentDialog(Department department)
            : this()
        {
            Title = $"Update {department.Name}";
            isEditingMode = true;
            deptnoInput.IsEnabled = false;

            PopulateData(department);
        }

        private void PopulateData(Department department)
        {
            deptnoInput.Text = department.Number.ToString();
            dnameInput.Text = department.Name;
            locInput.Text = department.Location;
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            var deptno = decimal.Parse(deptnoInput.Text);
            var dname = dnameInput.Text;
            var loc = locInput.Text;

            var department = new Department(deptno, dname, loc);
            
            if (isEditingMode)
            {
                _departmentsService.Update(department);
            }
            else
            {
                _departmentsService.Create(department);
            }
            
            Close();
        }
    }
}
