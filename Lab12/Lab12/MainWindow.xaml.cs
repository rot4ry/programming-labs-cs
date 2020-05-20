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

namespace Lab12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginButton.Content.ToString() == "Login")
            {
                LoginWindow loginWindow = new LoginWindow(this);
                loginWindow.ShowDialog();
            }
            else if(loginButton.Content.ToString() == "Log out")
            {
                this.WelcomeTextbox.Visibility = Visibility.Hidden;
                this.UsernameTextbox.Visibility = Visibility.Hidden;
                this.loginButton.Content = "Login";
            }
        }
    }
}
