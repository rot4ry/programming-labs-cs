using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndStats
{
    public static class Parser<T>
    {
        public static List<T> Parse(string JSON_input)
        {   
            List<T> parsingResultList = new List<T>();

            string[] responseArray = JSON_input.Split("},{");
            responseArray[0] = responseArray[0].TrimStart('[');
            responseArray[responseArray.Length - 1] = responseArray[responseArray.Length - 1].TrimEnd(']');
            
            for (int i = 0; i < responseArray.Length; i++)
            {
                if (i != 0)
                    responseArray[i] = responseArray[i].Insert(0, "{");
                if (i != responseArray.Length - 1)
                    responseArray[i] = responseArray[i].Insert(responseArray[i].Length, "}");

                parsingResultList.Add(JsonConvert.DeserializeObject<T>(responseArray[i]));
            }
            
            return parsingResultList;
        }
    }
}
