using LMS.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string a = "hello";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new StackWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new GridWindow();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new DataGridWindow();
            
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = new InputWindow();

            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var window = new EmployeesWindow();

            window.Show();
        }
    }
}
