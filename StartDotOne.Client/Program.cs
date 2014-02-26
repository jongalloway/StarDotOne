using StarDotOne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace StarDotOne.Client
{
    class Program
    {
        private HttpClient _client = new HttpClient();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hit ENTER to begin...");
                RunAsync().Wait();
            }
            finally
            {
                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            }
        }

        private async static Task RunAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                await RunTimedTest<BoringData>(client, new JsonMediaTypeFormatter(), "http://localhost:29108/api/BoringDataApi", "application/json");
                await RunTimedTest<BoringData>(client, new BsonMediaTypeFormatter(), "http://localhost:29108/api/BoringDataApi", "application/bson");
                await RunTimedTest<Person>(client, new JsonMediaTypeFormatter(), "http://localhost:29108/api/PersonApi", "application/json");
                await RunTimedTest<Person>(client, new BsonMediaTypeFormatter(), "http://localhost:29108/api/PersonApi", "application/bson");
            }
        }

        public static async Task RunTimedTest<T>(HttpClient _client, MediaTypeFormatter formatter, string Uri, string mediaHeader)
        {
            int iterations = 500;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(mediaHeader));
            MediaTypeFormatter[] formatters = new MediaTypeFormatter[] { formatter };

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var result = await _client.GetAsync(Uri);
                var value = await result.Content.ReadAsAsync<T[]>(formatters);
            }

            Console.WriteLine("Format: {0,-20} Type: {1,-15}\t Time (s):{2,10:ss\\.fff}", mediaHeader, typeof(T).Name, watch.Elapsed);
        }
    }
}
