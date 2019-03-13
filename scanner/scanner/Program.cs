using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using scanner.Generics;

namespace scanner
{
    internal static class Program
    {
        // Keywords to scan for URIs
        private static IEnumerable<string> Keywords => new[]
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
            Scanner scan  = new Scanner();
            Links   links = new Links();

            foreach (string keyword in Keywords)
            {
                string source = scan.Scrape("http://google.com?q=" + keyword);

                links.Extract(source);
            }
        }
    }
}