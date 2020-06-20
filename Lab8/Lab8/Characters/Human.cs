using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public class Human : PictureBox
    {
        public double Money { get; set; }
        public Point Coords { get; set; }
        public bool isInfected { get; set; } = false;
        public bool isSoldier { get; set; } = false;
        public bool isCheckedThisRound { get; set; } = false;


        private Image image = Lab8.Properties.Resources.human;
        public Human(double money, Point coords, string charType = "human")
        {
            Money = money;
            Coords = coords;

            switch (charType)
            {
                case "human":
                    break;

                case "soldier":
                    image = Lab8.Properties.Resources.soldier;
                    break;

                case "zombie":
                    image = Lab8.Properties.Resources.zombie;
                    break;
            }

            this.Image = image;
            this.Location = Coords;
            this.Size = new Size(40, 40);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void MoveTo(Point point)
        {
            this.Coords = point;
            this.Location = Coords;
        }
            
    }
}


