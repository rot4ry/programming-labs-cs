using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Table Splitting - jedna tabela => dwa typy
namespace Lab5_B_TSES
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            var es = new ESContext();
            es.Computers.Add(new ESComputer() { Description = "ESComputer", CoolingType = "?", Price = 1500 });
            es.SaveChanges();
            */
            var ts = new TSContext();
            ts.Computers.Add(new TSComputer() { Description = "SAS", CoolingType = "Vodka", Price = 420 ,
                Server = new Server() { Bandwidth = 1500 } } );
            ts.SaveChanges();
        }
    }
}
