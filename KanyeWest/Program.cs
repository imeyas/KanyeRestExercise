using Newtonsoft.Json.Linq;
using System;

namespace KanyeRest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"\nIt was a sunny Sunday afternoon. Kanye West was walking his dog in a beautiful neighborhood in Miami at the same tine as Ron Swanson" +
               $"on the same street. Their dogs noticed each other and caused both man to let their dogs do their doggy thing. And while they were at it ...\n");

            for (var i = 0; i <= 5; i++)
            {
                Thread.Sleep(7000);

                kanyeSays();

                Thread.Sleep(5000);

                ronSays();
            }


        }

        public static void kanyeSays()

        {
            //KanyeRest API setting and call
            var kanyeURL = "https://api.kanye.rest";

            var clientKanye = new HttpClient();

            var kanyeResponse = clientKanye.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

          

            Console.WriteLine($"\nKanye says:\n");

            Console.WriteLine($"{kanyeQuote}.\n");
        }

        public static void ronSays()

        {
            //RonSwanson API setting and call
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var clientRon = new HttpClient();

            var ronResponse = clientRon.GetStringAsync(ronURL).Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine($"\nRon responds:\n");

            Console.WriteLine($"{ronQuote}\n");
        }
    }
}
