using LMS.Data;
using LMS.Extensions;
using LMS.Models;
using LMS.Views.Dialogs;
using System;
using System.Windows;
using System.Windows.Input;

using MessageBox = LMS.Extensions.MessageBoxExtensions;

namespace LMS.Views
{
    /// <summary>
    /// Interaction logic for DepartmentsWindow.xaml
    /// </summary>
    public partial class DepartmentsWindow : Window
    {
        private readonly DepartmentsService _departmentsService;

        public DepartmentsWindow()
        {
            InitializeComponent();

            _departmentsService = new DepartmentsService();

            RefreshData();
        }

        private void AddDepartment_Clicked(object sender, RoutedEventArgs e)
        {
            var dialog = new DepartmentDialog();
            dialog.ShowDialog();

            RefreshData();
        }

        private void DeleteDepartment_Clicked(object sender, RoutedEventArgs e)
        {
            if (DepartmentsDataGrid.SelectedItem is not Department selectedDepartment)
            {
                MessageBox.ShowError("Please, select an Department to delete.");

                return;
            }

            var isConfirm = MessageBox.ShowConfirmation("Are you sure you want to delete department?");
            if (isConfirm != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                var result = _departmentsService.Delete(selectedDepartment.Deptno);

                if (result)
                {
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.ShowError($"There was an error deleting department.\nDetails: {ex.Message}");
            }
        }

        private void DepartmentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DepartmentsDataGrid.SelectedItem is not Department department)
            {
                return;
            }

            var dialog = new DepartmentDialog(department);
            dialog.ShowDialog();

            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                var departments = _departmentsService.GetDepartments();

                DepartmentsDataGrid.ItemsSource = null;
                DepartmentsDataGrid.ItemsSource = departments;
            }
            catch(Exception ex)
            {
                MessageBox.ShowError($"There was an error fetching data.\nDetails: {ex.Message}");
            }
        }
    }
}
