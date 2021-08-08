using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WaesTechnical.IntegrationTests
{
    public class DiffHttpApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _client;

        public DiffHttpApiTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get()
        {
            //var response = await _client.GetAsync("/diff/v1/1"); 

            //response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
