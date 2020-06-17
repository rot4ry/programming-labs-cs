using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


namespace Lab4_TeamsAndStats
{
    public class Downloader
    {
        //API connection strings
        private static string _SRC = @"https://api.collegefootballdata.com";
        private static Method _METHOD = Method.GET;
        private static RestClient client = new RestClient(_SRC);

        private static string _TEAMPATH = @"/teams/fbs?year=";
        private static string _STATPATH = @"/stats/season/advanced?year=";
        
        /*
        year has a fixed default value BUT 
        the result can be changed when the method 
        is called with a different argument 
        */
        public static async Task<IRestResponse> GetTeams(string year = @"2019")
        {
            return await client.ExecuteAsync(new RestRequest(_TEAMPATH + year), _METHOD);
        }

        public static async Task<IRestResponse> GetStats(string year = @"2019")
        {
            return await client.ExecuteAsync(new RestRequest(_STATPATH + year), _METHOD);
        }
    }
}
