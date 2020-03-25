using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var tph = new TPHContext();
            tph.Computers.Add(new PC("Standard PC", 1000, "Air"));
            tph.SaveChanges();

            var tpt = new TPTContext();
            tpt.Computers.Add(new PC("PC", 1500, "Air x2"));
            tpt.SaveChanges();

            var tpc = new TPCContext();
            tpc.Computers.Add(new PC("PC 100000GT", 15000, "Water"));
            tpc.SaveChanges();
        }
    }
}
