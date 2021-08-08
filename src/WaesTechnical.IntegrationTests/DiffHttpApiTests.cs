using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Domain.Const;
using WaesTechnical.Domain.Models;
using WaesTechnical.IntegrationTests.Infrastructure.Utils;
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

        #region Post Success

        [Fact(DisplayName = "Post Right - Must return status 200")]
        public async Task PostRightAsync()
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(new BaseBuilder().DataInputRight()));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/diff/v1/1/Right", httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Post Left - Must return status 200")]
        public async Task PostLeftAsync()
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(new BaseBuilder().DataInputLeft()));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/diff/v1/1/Left", httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        #endregion

        #region Post With Errors
        [Fact(DisplayName = "Post Right - Must return Bad Request")]
        public async Task PostRightBadRequestAsync()
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(new BaseBuilder().DataInputWrong()));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/diff/v1/2/Right", httpContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Post Left - Must return Bad Request")]
        public async Task PostLeftBadRequestAsync()
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(new BaseBuilder().DataInputWrong()));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/diff/v1/2/Left", httpContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        #endregion

        #region Get Success

        [Fact(DisplayName = "Get - Not Same Length")]
        public async Task GetAsync()
        {
            var httpContentRight = new StringContent(JsonConvert.SerializeObject(new BaseBuilder().DataInputRight()));
            httpContentRight.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _client.PostAsync("/diff/v1/1/Right", httpContentRight);

            var httpContentLeft = new StringContent(JsonConvert.SerializeObject(new BaseBuilder().DataInputLeft()));
            httpContentLeft.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await _client.PostAsync("/diff/v1/1/Left", httpContentLeft);

            var response = await _client.GetAsync("/diff/v1/1");

            var apiresponse = await response.Content.ReadAsStringAsync();
            var message = JsonConvert.DeserializeObject<GetResponse>(apiresponse);

            Assert.Equal(MessagesConsts.DATA_NOT_EQUAL_LENGTH_MESSAGE, message.Message);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Get Errors
        [Fact(DisplayName = "Get - Must return Not Found")]
        public async Task GetNotFoundAsync()
        {
            var response = await _client.GetAsync("/diff/v1/2");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        #endregion
    }
}
