using System;

namespace SearchResultsAnalysis.Exceptions
{
    public class TargetSearchEngineUrlNotSuppliedException : Exception
    {
        public TargetSearchEngineUrlNotSuppliedException()
            : base("TargetSearchEngineUrl must be supplied")
        {

        }
    }
}
