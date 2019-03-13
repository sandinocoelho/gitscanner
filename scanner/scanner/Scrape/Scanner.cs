using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using scanner.Contracts;
using scanner.Generics;

namespace scanner
{
    public class Scanner : IScanner
    {
        /// <summary>
        /// Navigate to our search engine
        /// </summary>
        /// <returns></returns>
        public string Scrape(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(uri).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        return content.ReadAsStringAsync().Result;
                    }
                }
            }
        }

        public string Results()
        {
            throw new NotImplementedException();
        }
    }
}