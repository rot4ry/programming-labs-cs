using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndStats
{
    public class Offense
    {
        public int OFF_ID { get; set; }
        public int plays { get; set; }
        public int drives { get; set; }
        public double ppa { get; set; }
        public double explosiveness { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"plays:              {plays}");
            Console.WriteLine($"drives:             {drives}");
            Console.WriteLine($"ppa:                {ppa}");
            Console.WriteLine($"explosiveness:      {explosiveness}");
            Console.WriteLine();
        }
    }
}
