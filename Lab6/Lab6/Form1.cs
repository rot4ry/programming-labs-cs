using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private int _counter = 0;
        private BindingList<Number> numberList = new BindingList<Number>();
        private List<int> availableNumbersList = Enumerable.Range(1, 100).ToList();
        private Random randomizer = new Random();
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = numberList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _counter = 0;
            timer1.Start();
            dataGridView1.Rows.Clear();
        }

        private TextBox GenerateTextBox(string text)
        {
            return new TextBox()
            {
                Text = text,
                Width = 100,
                ReadOnly = true
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int randomNumber = availableNumbersList[randomizer.Next(availableNumbersList.Count())];

            textBox1.Text = randomNumber.ToString();
            _counter++;

            if(_counter%10 == 0)
            {
                numberList.Add(
                    new Number
                    {
                        Value = randomNumber.ToString()
                    });
                availableNumbersList.Remove(randomNumber);
            }

            if(_counter == 60)
            {
                timer1.Stop();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string filePath = openFileDialog1.FileName;
            string fileContent = File.ReadAllText(filePath);

            var formattedFileContent = fileContent.Split(new[] { "\r", "\n", " ", "\t" },
                                        StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in formattedFileContent)
            {
                flowLayoutPanel1.Controls.Add(GenerateTextBox(item.ToString()));
            }
            textBox1.Visible = true;
            button2.Visible = true;
        }
    }
}
