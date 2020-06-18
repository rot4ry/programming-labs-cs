using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Soldier : Human
    {
        public double Endurance { get; set; }

        public Soldier(double money, Point coords, double endurance) : base(money, coords, "soldier")
        {
            Endurance = endurance;
        }
    }
}
