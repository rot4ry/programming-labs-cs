using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public abstract class Computer
    {
        protected Computer(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
        
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
