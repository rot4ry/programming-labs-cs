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

namespace Lab10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student exampleStudent = new Student()
        {
            Id = 100,
            FirstName = "Janek",
            LastName = "Kowalskyyyy",
            EnlistingDate = new DateTime(2015, 10, 3)

        };

        List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 0,
                FirstName = "Maciej",
                LastName = "Kowalski",
                EnlistingDate = new DateTime(2014,9,28)
            },
            new Student()
            {
                Id = 1,
                FirstName = "Janusz",
                LastName = "Tomasz",
                EnlistingDate = new DateTime(2016,2,15)
            },
          
            new Student()
            {
                Id = 2,
                FirstName = "Tomasz",
                LastName = "Hołowczyc",
                EnlistingDate = new DateTime(2017,10,3)
            },

            new Student()
            {
                Id = 3,
                FirstName = "Grzegorz",
                LastName = "Nowak",
                EnlistingDate = new DateTime(2018,5,13)
            },

            new Student()
            {
                Id=4,
                FirstName = "karol",
                LastName = "krawczyk",
                EnlistingDate = new DateTime(2020, 10, 25)
            }
        };


        public MainWindow()
        {
            InitializeComponent();
            SingleBinding.DataContext = exampleStudent;

            idBox.SetBinding(TextBox.TextProperty, new Binding("Id"));
            fNameBox.SetBinding(TextBox.TextProperty, new Binding("FirstName"));
            lNameBox.SetBinding(TextBox.TextProperty, new Binding("LastName"));
            eDateBox.SetBinding(TextBox.TextProperty, new Binding("EnlistingDate"));
            
            StudentListView.ItemsSource = students;
            StudentListBox.ItemsSource = students;
        }


    }
}
