using System;

namespace SearchResultsAnalysis.Exceptions
{
    public class KeywordsNotSuppliedException : Exception
    {
        public KeywordsNotSuppliedException()
            : base("Keywords must be supplied")
        {

        }
    }
}
