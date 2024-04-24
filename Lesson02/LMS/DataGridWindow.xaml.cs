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

namespace LMS
{
    /// <summary>
    /// Interaction logic for DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        private List<Person> people;
        public DataGridWindow()
        {
            InitializeComponent();

            people = new List<Person>()
            {
                new Person(1, "John", "123512"),
                new Person(2, "Robert", "123512"),
                new Person(3, "Steve", "123512"),
                new Person(4, "Anna", "123512"),
            };

            peopleGrid.ItemsSource = people;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Person(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
