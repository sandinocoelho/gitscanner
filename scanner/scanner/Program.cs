using System;
using System.Collections.Generic;
using System.Net.Http;

namespace scanner
{
    internal static class Program
    {
        // URI to get results
        private const string Url = "https://www.google.com/search?q=";

        // Keywords to scan for URIs
        private static IEnumerable<string> Keywords => new []
        {
            "Bitcoin",
            "Exchange",
            "Bank"
        };

        /// <summary>
        /// Run the main program
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            foreach (var keyword in Keywords)
            {
                Console.Write(Results(keyword));
            }
        }

        /// <summary>
        /// Get the source of our search engine
        /// </summary>
        /// <returns></returns>
        private static string Results(string keyword)
        {
            var url = Url + keyword;
            
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url).Result)
                {
                    using (var content = response.Content)
                    {
                        return content.ReadAsStringAsync().Result;
                    }
                }
            }
        }
    }
}