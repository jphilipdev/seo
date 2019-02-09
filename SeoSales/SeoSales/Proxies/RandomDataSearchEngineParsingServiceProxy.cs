using SearchEngineParsing.Dtos;
using SearchResultsAnalysis.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchResultsAnalysis.Proxies
{
    public class RandomDataSearchEngineParsingServiceProxy : ISearchEngineParsingServiceProxy
    {
        public SearchEngineParsingResponse GetSearchResults(SearchResultsAnalysisRequest request)
        {
            var random = new Random();
            var numberOfResults = random.Next(50);

            if (numberOfResults == 0)
            {
                return new SearchEngineParsingResponse(new List<SearchEngineResult>());
            }

            return GenerateRandomResults(request, random, numberOfResults);
        }               

        private SearchEngineParsingResponse GenerateRandomResults(SearchResultsAnalysisRequest request, Random random, int numberOfResults)
        {
            var matchingPositions = GenerateMatchingPositionsBetween1And1000(random, numberOfResults);

            var results = Generate1000Results(request, matchingPositions);

            return new SearchEngineParsingResponse(results);
        }

        private IReadOnlyList<int> GenerateMatchingPositionsBetween1And1000(Random random, int numberOfResults)
        {
            return Enumerable.Range(1, numberOfResults).Select(p => random.Next(1, 1000)).ToList();
        }

        private List<SearchEngineResult> Generate1000Results(SearchResultsAnalysisRequest request, IReadOnlyList<int> matchingPositions)
        {
            return Enumerable.Range(1, 1000).Select(p => new SearchEngineResult(p, matchingPositions.Contains(p) ? request.UrlToMatch : "http://www.someotherurl.com")).ToList();
        }
    }
}
