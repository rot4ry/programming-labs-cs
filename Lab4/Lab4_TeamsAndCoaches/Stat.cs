using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndStats
{
    public class Stat
    {
        public int STAT_ID { get; set; }
        public string team { get; set; }

        public int season { get; set; }
        public string conference { get; set; }
        public Offense offense { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"season:         {season}");
            Console.WriteLine($"team:           {team}");
            Console.WriteLine($"conference:     {conference}");
            Console.WriteLine("Offense: ");
            offense.PrintDetails();
        }
    }
}
