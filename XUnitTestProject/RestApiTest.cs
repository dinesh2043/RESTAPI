using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestApplication;
using TestApplication.Model;
using Xunit;

namespace XUnitTestProject
{
    public class RestApiTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public RestApiTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task ReturnJson()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:44381/api/deployments");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal("["+ createJson().ToUpper()+"]", responseString.ToUpper());
        }
        public String createJson()
        {
            List<String> catlist = new List<string> { "full" };
            Deployment deployment = new Deployment();
            deployment.Name = "ta104400ww_dev";
            deployment.Description = "ND1 TA-1044_00WW (dev-keys)";
            deployment.Categories = JsonConvert.SerializeObject(catlist);

            String json = JsonConvert.SerializeObject(deployment);
            return json;
        }
    }
}
