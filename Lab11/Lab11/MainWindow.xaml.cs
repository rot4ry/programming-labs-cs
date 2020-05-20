using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<User> Users = new BindingList<User>()
        {
            new User(1, "test", 0),
            new User(2, "test2", 0),
            new User(3, "test3", 0)
        };
        public MainWindow()
        {
            InitializeComponent();
            MyListView.ItemsSource = Users;
            MyListBox.ItemsSource = Users;
        }

        //Dodaj
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users.Add(new User(0, "newTest", 0));
        }

        //Usun
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Users.Any()) Users.RemoveAt(0);
        }

        //Edytuj
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Users[0].Points += 100;
            
        }
    }
}
