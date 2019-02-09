using SearchResultsAnalysis.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchResultsAnalysis.Proxies
{
    public class RandomDataSearchEngineParsingServiceProxy : ISearchEngineParsingServiceProxy
    {
        public SearchResultsAnalysisResponse GetSearchResults(SearchResultsAnalysisRequest request)
        {
            var random = new Random();
            var numberOfResults = random.Next(15);

            if (numberOfResults == 0)
            {
                return new SearchResultsAnalysisResponse("0");
            }

            var results = GenerateResultsBetween1And1000(random, numberOfResults);
            return new SearchResultsAnalysisResponse(string.Join(", ", results));
        }

        private static IEnumerable<int> GenerateResultsBetween1And1000(Random random, int numberOfResults)
        {
            return Enumerable.Range(1, numberOfResults).Select(p => random.Next(1, 1000));
        }
    }
}
