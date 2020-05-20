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
using System.Runtime.InteropServices;
using System.Security;

namespace Lab12
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Window _Parent;
        private class User
        {
            public  string Name { get; set; }
            public string Password { get; set; }
        }

        private List<User> Users = new List<User>()
        {
            new User(){Name = "JankoMuzykant", Password = "TaniecToJestZyci3" },
            new User(){Name = "WiesiekElektryk", Password = "qwerty"},
            new User(){Name = "Karolina", Password = "Kucyki1234"}
        };

        public LoginWindow(Window parent)
        {
            InitializeComponent();
            _Parent = parent;    
        }

        private bool CheckLogin(string login, List<User> users, SecureString password)
        {
            var pwd = default(string);
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                pwd = Marshal.PtrToStringUni(unmanagedString);
            }catch(Exception ex) { return false; }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            foreach(User user in users)
            {
                if(login == user.Name)
                {
                    if (user.Password == pwd) return true;
                    else continue;
                }
                
            }
            return false;
        }
        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            this._Parent.Close();
            string login = UsernameTextbox.Text;
            if (CheckLogin(login, Users, PasswordTextBox.SecurePassword))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.WelcomeTextbox.Visibility = Visibility.Visible;
                mainWindow.UsernameTextbox.Visibility = Visibility.Visible;
                mainWindow.UsernameTextbox.Text = login;
                mainWindow.loginButton.Content = "Log out";
                this.Close();
                mainWindow.Show();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
