using System.Windows;

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

            string text = "hello World!";
            int number = 12;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new StackWindow();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new GridWindow();
            window.Show();
        }
    }
}
