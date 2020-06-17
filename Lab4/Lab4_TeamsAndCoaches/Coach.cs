using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndCoaches
{
    public class Coach
    {
        public int coach_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        #nullable enable
        public List<TeamSeason>? seasons { get; set; } = new List<TeamSeason>();
        

        public void PrintDetails()
        {
            Console.WriteLine($"First name:         { first_name}");
            Console.WriteLine($"Last name:          { last_name}");

            if (seasons != null)
            {
                foreach (var item in seasons)
                {
                    item.PrintSeason();
                }
            }
        }
    }
}
