using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_B_TSES
{
    public class Server
    {
        public int ServerId { get; set; }
        public int Bandwidth { get; set; }
        public decimal Price { get; set; }
        public string CoolingType { get; set; }
        public virtual TSComputer Computer { get; set; }
    }
}
