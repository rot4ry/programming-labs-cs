using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Laptop : Computer
    {
        public Laptop(string description, decimal price, double weight, string manufacturer):base(description, price)
        {
            Weight = weight;
            Manufacturer = manufacturer;
        }

        public double Weight { get; set; }
        public string Manufacturer { get; set; }
    }
}
