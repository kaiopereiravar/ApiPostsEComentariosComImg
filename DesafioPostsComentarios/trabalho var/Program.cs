using System;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;

namespace VideoDurationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> urls = new List<string>
            {
                "https://www.youtube.com/watch?v=1H-vSHVOxoU"

            };

            foreach (string url in urls)
            {
                int durationInSeconds = GetVideoDurationInSeconds(url);
                Console.WriteLine($"URL: {url} | Duration: {durationInSeconds} seconds");
            }

            Console.ReadLine();
        }

        static int GetVideoDurationInSeconds(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = client.GetStringAsync(url).Result;

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                HtmlNode durationNode = document.DocumentNode.SelectSingleNode("//span[@class='duration']");
                if (durationNode != null)
                {
                    string durationText = durationNode.InnerText;
                    TimeSpan duration = TimeSpan.Parse(durationText);
                    return (int)duration.TotalSeconds;
                }
                else
                {
                    // Elemento de duração não encontrado
                    return 0; // Ou qualquer valor de tratamento adequado
                }
            }
        }
    }
}
