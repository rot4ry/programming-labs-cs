using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _voteCounter = 0;

        private Dictionary<string, int> _OPTIONS = new Dictionary<string, int>
        {
            {"A", 0 },
            {"B", 0 },
            {"C", 0 },
            {"D", 0 }
        };

        public MainWindow()
        {
            InitializeComponent();
            textBlock.Text = "Którą literę wolisz: A, B, C, D?";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            string optionChosen = clickedButton.Content.ToString();
            _OPTIONS[optionChosen]++;
            _voteCounter++;

            double canvasHeight = Canvas.ActualHeight;

            double percA = (double)_OPTIONS["A"] / _voteCounter;
            double percB = (double)_OPTIONS["B"] / _voteCounter;
            double percC = (double)_OPTIONS["C"] / _voteCounter;
            double percD = (double)_OPTIONS["D"] / _voteCounter;

            Rectangle_A.Height = Math.Pow(percA, (double)2/3) * canvasHeight + 1;
            Rectangle_B.Height = Math.Pow(percB, (double)2/3) * canvasHeight + 1;
            Rectangle_C.Height = Math.Pow(percC, (double)2/3) * canvasHeight + 1;
            Rectangle_D.Height = Math.Pow(percD, (double)2/3) * canvasHeight + 1;

            percent_A.Content = (percA * 100).ToString("F2") + "%";
            percent_B.Content = (percB * 100).ToString("F2") + "%";
            percent_C.Content = (percC * 100).ToString("F2") + "%";
            percent_D.Content = (percD * 100).ToString("F2") + "%";

            amountOfVotesTB.Text = _voteCounter.ToString();
            topVotes.Text = _OPTIONS.Max(x => x.Value).ToString();
        }
        private void RefreshView(object sender, RoutedEventArgs e)
        {
            _voteCounter = 0;

            _OPTIONS["A"] = 0;
            _OPTIONS["B"] = 0;
            _OPTIONS["C"] = 0;
            _OPTIONS["D"] = 0;

            Rectangle_A.Height = 1;
            Rectangle_B.Height = 1;
            Rectangle_C.Height = 1;
            Rectangle_D.Height = 1;

            percent_A.Content = 0.00.ToString("F2") + "%";
            percent_B.Content = 0.00.ToString("F2") + "%";
            percent_C.Content = 0.00.ToString("F2") + "%";
            percent_D.Content = 0.00.ToString("F2") + "%";

            amountOfVotesTB.Text = _voteCounter.ToString();
            topVotes.Text = _OPTIONS.Max(x => x.Value).ToString();
        }
    }
}

