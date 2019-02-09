using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SearchEngineParsing.Dtos;
using SearchResultsAnalysis.Dtos;
using SearchResultsAnalysis.Proxies;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchResultsAnalysis.Tests
{
    [TestClass]
    public class SearchResultsAnalysisSuccessTests
    {
        private const string Url = "/api/SearchResultsAnalysis";

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_ThenResponseStatusCodeIs200Ok()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "b", "c");

            var response = await client.PostAsJsonAsync(Url, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_ThenBodyContainsResults()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "b", "c");

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<SearchResultsAnalysisResponse>();

            body.Results.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_ThenBodyContainsCommaSeparatedListOfPositionsOfMatchingResults()
        {
            var urlToMatch = "urlToMatch";
            var request = new SearchResultsAnalysisRequest("a", "b", urlToMatch);
            var results = new List<SearchEngineResult>() { new SearchEngineResult(1, urlToMatch), new SearchEngineResult(28, urlToMatch), new SearchEngineResult(89, "") };
            var proxyResponse = new SearchEngineParsingResponse(results);
            var expectedResponse = "1, 28";
            var client = CreateClientWithMockProxy(proxyResponse);

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<SearchResultsAnalysisResponse>();

            body.Results.Should().Be(expectedResponse);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_MatchingResultsWithPositionGreaterThan100AreFilteredOut()
        {
            var urlToMatch = "urlToMatch";
            var request = new SearchResultsAnalysisRequest("a", "b", urlToMatch);
            var results = new List<SearchEngineResult>() { new SearchEngineResult(99, urlToMatch), new SearchEngineResult(100, urlToMatch), new SearchEngineResult(101, urlToMatch) };
            var proxyResponse = new SearchEngineParsingResponse(results);
            var expectedResponse = "99, 100";
            var client = CreateClientWithMockProxy(proxyResponse);

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<SearchResultsAnalysisResponse>();

            body.Results.Should().Be(expectedResponse);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndRequestIsWithinCachingPeriod_ThenBodyContainsCachedResults()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "b", "c");

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<SearchResultsAnalysisResponse>();
            var response2 = await client.PostAsJsonAsync(Url, request);
            var body2 = await response2.Content.ReadAsAsync<SearchResultsAnalysisResponse>();

            body.Results.Should().Be(body2.Results);
        }

        private HttpClient CreateClientWithMockProxy(SearchEngineParsingResponse proxyResponse)
        {
            var mockProxy = new Mock<ISearchEngineParsingServiceProxy>();
            mockProxy.Setup(p => p.GetSearchResults(It.IsAny<SearchResultsAnalysisRequest>())).Returns(proxyResponse);
            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => builder.ConfigureTestServices(p => p.AddSingleton(mockProxy.Object)));
            var client = factory.CreateClient();
            return client;
        }
    }
}
