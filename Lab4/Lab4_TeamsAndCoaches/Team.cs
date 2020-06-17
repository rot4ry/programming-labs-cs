using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndCoaches
{
    public class Team
    { 
        #nullable enable
        public int id { get; set; }
        public string? school { get; set; }
        public string? mascot { get; set; }
        public string? abbreviation { get; set; }
        public string? division { get; set; }
        public string? color { get; set; }
        public string? conference { get; set; }
        public string? alt_name1 { get; set; }
        public string? alt_name2 { get; set; }
        public string? alt_name3 { get; set; }
        public string? alt_color { get; set; }
        
        public void PrintDetails()
        {
            Console.WriteLine($"ID:                 {id}");
            Console.WriteLine($"School:             {school}");
            Console.WriteLine($"Mascot:             {mascot}");
            Console.WriteLine($"Abbreviation:       {abbreviation}");
            Console.WriteLine($"Alt_name1:          {alt_name1}");
            Console.WriteLine($"Alt_name2:          {alt_name2}");
            Console.WriteLine($"Alt_name3:          {alt_name3}");
            Console.WriteLine($"Conference:         {conference}");
            Console.WriteLine($"Color:              {color}");
            Console.WriteLine($"Alt_color:          {alt_color}\n");
        
        }
    }
}

