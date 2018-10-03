using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Xunit;

namespace GiftApi.IntegrationTests
{
    public class StartupTests
    {
        private readonly TestServer _testServer;

        public StartupTests()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            _testServer = new TestServer(builder);
        }

        [Fact]
        public async Task ContentEncodingWillUseGZipCompression()
        {
            // Arrange
            var client = _testServer.CreateClient();
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            // Act
            var response = await client.GetAsync("/api/gift/a82aa4b1-45bb-4ecb-a5aa-50de618f2e1d");

            // Assert
            response.Content.Headers.ContentEncoding.Should().Contain("gzip");
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange
            var client = _testServer.CreateClient();

            // Act
            var response = await client.GetAsync("/api/gift/a82aa4b1-45bb-4ecb-a5aa-50de618f2e1d");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("{\"id\":\"a82aa4b1-45bb-4ecb-a5aa-50de618f2e1d\",\"name\":\"Amazon.co.uk Gift Card\",\"slug\":\"amazon-uk\"}", await response.Content.ReadAsStringAsync());
        }
    }
}
