using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Zombie : Human
    {
        private double strength;
        public double Strength {
            get { return strength; }
            set
            {
                if (value < 0)
                    strength = 0;
                else
                    strength = value;
            }
                 }

        private int virusLeft;
        public bool isCured { get; set; } = false;

        public int VirusLeft {
            get 
            {
                return virusLeft;
            }
            
            private set
            {
                if (value <= 0)
                    virusLeft = 0;
                else virusLeft = value;
            }
        }

        public Zombie(double money, Point coords, double str, int vLeft = 3) : base(money, coords, "zombie")
        {
            Strength = str;
            VirusLeft = vLeft;
        }

        public void VirusDecrease()
        {
            this.VirusLeft--;
        }
    }
}
