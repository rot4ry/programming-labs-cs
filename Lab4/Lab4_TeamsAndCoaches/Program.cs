using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace Lab4_TeamsAndStats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<IRestResponse> teamsResponse = Downloader.GetTeams();
            Task<IRestResponse> statsResponse = Downloader.GetStats();

            string teams_JSON_String = teamsResponse.Result.Content;
            string stats_JSON_String = statsResponse.Result.Content;
            
            List<Team> teams = new List<Team>();
            List<Stat> stats = new List<Stat>();
            
            teams = Parser<Team>.Parse(teams_JSON_String);
            if(teams.Count > 0)
                Console.WriteLine("Parsed: Teams");

            stats = Parser<Stat>.Parse(stats_JSON_String);
            if (stats.Count > 0)
                Console.WriteLine("Parsed: Stats");

            Console.WriteLine("Inserting into the database.");


            
            //foreach (var item in teams)
            //{
            //    item.PrintDetails();
            //    Console.WriteLine();
            //}
            //foreach (var item in stats)
            //{
            //    item.PrintDetails();
            //}
            
            using (Context databaseContext = new Context())
            {
                bool wasCreated = databaseContext.Database.EnsureCreated();
                Console.WriteLine($"Database created: {wasCreated}");

                foreach (Team team in teams)
                {
                    databaseContext.Teams.Add(team);

                    foreach (Stat stat in (stats.Where(x => x.team == team.school))) 
                    {
                        databaseContext.Stats.Add(stat);
                    }
                }

                databaseContext.SaveChanges();
            }
        }
    }
}


