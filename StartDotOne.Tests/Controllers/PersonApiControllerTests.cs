using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarDotOne.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Formatting;
using StarDotOne.Models;
namespace StarDotOne.Controllers.Tests
{
    [TestClass()]
    public class PersonApiControllerTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void TestInitialize()
        {
            _client = new HttpClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
        }

        [TestMethod()]
        public async Task GetPeopleJsonTest()
        {
            int iterations = 100;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var result = await _client.GetAsync("http://localhost:29108/api/PersonApi");
                MediaTypeFormatter[] formatters = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };

                var person = await result.Content.ReadAsAsync<Person>(formatters);
                result.EnsureSuccessStatusCode();
            }

            Console.WriteLine("JSON: " + watch.ElapsedMilliseconds);
        }

        [TestMethod()]
        public async Task GetPeopleBsonTest()
        {
            int iterations = 100;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/bson"));

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var result = await _client.GetAsync("http://localhost:29108/api/PersonApi");
                MediaTypeFormatter[] formatters = new MediaTypeFormatter[] { new BsonMediaTypeFormatter() };

                var person = await result.Content.ReadAsAsync<Person>(formatters);
                result.EnsureSuccessStatusCode();
            }

            Console.WriteLine("BSON: " + watch.ElapsedMilliseconds);
        }
    }
}
