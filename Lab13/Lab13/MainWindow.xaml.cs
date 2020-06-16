using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();   
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["Title"] = "DYNAMIC TITLE";
            this.Resources["Color"] = new SolidColorBrush(Colors.Yellow);
            MyRectangle.Fill = new SolidColorBrush(Colors.Blue);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();

            string filePath = dialog.FileName;

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                var reader = (ResourceDictionary)XamlReader.Load(stream);
                this.Resources.MergedDictionaries.Add(reader);
            }
        }
    }
}
