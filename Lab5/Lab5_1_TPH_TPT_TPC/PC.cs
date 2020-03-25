using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class PC : Computer
    {
        public PC(string description, decimal price, string coolingType) : base(description, price)
        {
            CoolingType = coolingType;
            Description = description;
        }
        public string CoolingType { get; set; }
    }
}
