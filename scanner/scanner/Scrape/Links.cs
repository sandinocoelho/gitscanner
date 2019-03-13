using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using scanner.Generics;

namespace scanner
{
    public class Links
    {
        /// <summary>
        /// Add link to our collection
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public IEnumerable<ScrapedLink> Collect(ScrapedLink link)
        {
            var list = new List<ScrapedLink> { link };

            return list;
        }

        /// <summary>
        /// Extract the link from the source code
        /// </summary>
        /// <param name="source"></param>
        public void Extract(string source)
        {
            MatchCollection matched = Regex.Matches(
                source,
                @"(<a.*?>.*?</a>)",
                RegexOptions.Singleline
            );
            
            foreach (Match match in matched)
            {
                string      value = match.Groups[1].Value;
                ScrapedLink link  = new ScrapedLink();

                Match href = Regex.Match(
                    value,
                    @"href=\""(.*?)\""",
                    RegexOptions.Singleline
                );


                if (href.Success)
                {
                    link.Href = href.Groups[1].Value;
                }

                string anchor = Regex.Replace(
                    value, 
                    @"\s*<.*?>\s*", "",
                    RegexOptions.Singleline
                );
                
                link.Text = anchor;

                Console.Write(link);
            }   
            
        }
    }
}