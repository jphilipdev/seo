using System;
using System.Collections.Generic;

namespace SearchEngineParsing.Dtos
{
    public class SearchEngineParsingResponse
    {
        public SearchEngineParsingResponse(IReadOnlyList<SearchEngineResult> results)
        {
            Results = results;
        }

        public IReadOnlyList<SearchEngineResult> Results { get; }
    }

    public class SearchEngineResult
    {
        public SearchEngineResult(int position, string result)
        {
            Position = position;
            Result = result;
        }

        public int Position { get; }
        public string Result { get; }
    }
}
