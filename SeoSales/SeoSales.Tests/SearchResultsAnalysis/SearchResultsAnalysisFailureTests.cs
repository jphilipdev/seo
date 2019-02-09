using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchResultsAnalysis.Dtos;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchResultsAnalysis.Tests
{
    [TestClass]
    public class SearchResultsAnalysisTests
    {
        private const string Url = "/api/SearchResultsAnalysis";

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndTargetSearchEngineUrlIsNotSupplied_ThenResponseStatusCodeIs400BadRequest()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("", "b", "c");

            var response = await client.PostAsJsonAsync(Url, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndTargetSearchEngineUrlIsNotSupplied_ThenBodyContainsError()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("", "b", "c");
            var expectedError = new ErrorResponse("TargetSearchEngineUrl must be supplied", "TargetSearchEngineUrlNotSupplied");

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<ErrorResponse>();

            body.Should().BeEquivalentTo(expectedError);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndKeywordsNotSupplied_ThenResponseStatusCodeIs400BadRequest()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "", "c");

            var response = await client.PostAsJsonAsync(Url, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndKeywordsNotSupplied_ThenBodyContainsError()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "", "c");
            var expectedError = new ErrorResponse("Keywords must be supplied", "KeywordsNotSupplied");

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<ErrorResponse>();

            body.Should().BeEquivalentTo(expectedError);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndUrlToMatchNotSupplied_ThenResponseStatusCodeIs400BadRequest()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "b", "");

            var response = await client.PostAsJsonAsync(Url, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task WhenSearchResultsAnalysisRequested_AndUrlToMatchNotSupplied_ThenBodyContainsError()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var request = new SearchResultsAnalysisRequest("a", "b", "");
            var expectedError = new ErrorResponse("UrlToMatch must be supplied", "UrlToMatchNotSupplied");

            var response = await client.PostAsJsonAsync(Url, request);
            var body = await response.Content.ReadAsAsync<ErrorResponse>();

            body.Should().BeEquivalentTo(expectedError);
        }
    }
}
