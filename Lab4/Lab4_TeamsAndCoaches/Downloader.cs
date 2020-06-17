using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


namespace Lab4_TeamsAndCoaches
{
    public class Downloader
    {
        //API connection strings
        private static string _SRC = @"https://api.collegefootballdata.com";
        private static Method _METHOD = Method.GET;
        private static RestClient client = new RestClient(_SRC);

        private static string _TEAMPATH = @"/teams/fbs?year=";
        private static string _COACHPATH = @"/coaches?year=";
        
        /*
        year has a fixed default value BUT 
        the result can be changed when the method 
        is called with a different argument 
        */
        public static async Task<IRestResponse> GetTeams(string year = @"2019")
        {
            return await client.ExecuteAsync(new RestRequest(_TEAMPATH + year), _METHOD);
        }

        public static async Task<IRestResponse> GetCoaches(string year = @"2019")
        {
            return await client.ExecuteAsync(new RestRequest(_COACHPATH + year), _METHOD);
        }
    }
}
