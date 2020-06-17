using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndCoaches
{
    public class TeamSeason
    {
        public int season_id { get; set; }
        
        #nullable enable
        public string? school { get; set; }
        public string? year { get; set; }
        public int? games { get; set; }
        public int? wins { get; set; }
        public int? losses { get; set; }
        public int? ties { get; set; }
        public int? preseason_rank { get; set; }
        public int? postseason_rank { get; set; }

        public void PrintSeason()
        {
            Console.WriteLine("_____");
            Console.WriteLine($"School:             {school}");
            Console.WriteLine($"Year:               {year}");
            Console.WriteLine($"Games:              {games}");
            Console.WriteLine($"Wins:               {wins}");
            Console.WriteLine($"Losses:             {losses}");
            Console.WriteLine($"Ties:               {ties}");
            Console.WriteLine($"Preseason rank:     {preseason_rank}");
            Console.WriteLine($"Postseason rank:    {postseason_rank}");
        }

    }
}

