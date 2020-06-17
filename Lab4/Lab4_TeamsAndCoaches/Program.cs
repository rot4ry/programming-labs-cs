using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lab4_TeamsAndCoaches
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<IRestResponse> teamsResponse = Downloader.GetTeams();
            Task<IRestResponse> coachesResponse = Downloader.GetCoaches();

            string teams_JSON_String = teamsResponse.Result.Content;
            string coaches_JSON_String = coachesResponse.Result.Content;
            Console.WriteLine(coaches_JSON_String);

            List<Team> teams = new List<Team>();
            List<Coach> coaches = new List<Coach>();

            teams = Parser<Team>.Parse(teams_JSON_String);
            if(teams.Count>0)
                Console.WriteLine("Parsed: Teams");

            if (coaches.Count > 0)
                coaches = Parser<Coach>.Parse(coaches_JSON_String);
            Console.WriteLine("Parsed: Coaches");
            
            Console.WriteLine("Inserting into the database.");
           
            /*
            foreach (var item in teams)
            {
                item.PrintDetails();
                Console.WriteLine();
            }
            foreach (var item in coaches)
            {
                item.PrintDetails();
                Console.WriteLine();
            }
            */
            using (Context databaseContext = new Context())
            {
                bool wasCreated = databaseContext.Database.EnsureCreated();
                Console.WriteLine($"Database created: {wasCreated}");

                foreach (var item in teams)
                {
                    databaseContext.Teams.Add(item);
                }

                foreach (Coach coach in coaches)
                {                    
                    databaseContext.Coaches.Add(new Coach() 
                    { 
                        first_name = coach.first_name, 
                        last_name = coach.last_name 
                    });

                    foreach(TeamSeason ts in coach.seasons)
                    {
                        databaseContext.Seasons.Add(
                            new TeamSeason()
                            {
                                school = ts.school,
                                year = ts.year,
                                games = ts.games,
                                wins = ts.wins,
                                losses = ts.losses,
                                ties = ts.ties,
                                preseason_rank = ts.preseason_rank,
                                postseason_rank = ts.postseason_rank
                            });
                    }
                }

                databaseContext.SaveChanges();
            }
        }
    }
}

