using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var sw = new Stopwatch();
            //var google = new RestClient("http://google.pl");
            //var ath = new RestClient("http://ath.bielsko.pl");
            //var otomoto = new RestClient("http://otomoto.pl");
            //var stackoverflow = new RestClient("https://stackoverflow.com");

            sw.Start();
            List <Task> tasks  = new List<Task>();
            //ExecuteAsync nie czeka na odpowiedź na żądanie
            //  await - nie zawsze


            tasks.Add(Website.Download("http://google.pl", "/"));
            Console.WriteLine(sw.Elapsed);
            tasks.Add(Website.Download("http://otomoto.pl", "/"));
            Console.WriteLine(sw.Elapsed);
            tasks.Add(Website.Download("https://stackoverflow.com", "/"));
            Console.WriteLine(sw.Elapsed);
         
            Console.WriteLine("___________");
         
            await Task.WhenAny(tasks);
            Console.WriteLine(sw.Elapsed);
            await Task.WhenAll(tasks);
            Console.WriteLine(sw.Elapsed);
            sw.Stop();
        }
    }
}
