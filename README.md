# seo

This is a react app (16.3) with a .net core 2.1 backend.

The initial plan for the backend was two microservices, SearchResultsAnalysis and SearchEngineParsing.  
SearchEngineParsing would fake the retrieval of search results and return randomly generated data and the logic to be implemented would be in SearchResultsAnalysis.  
Due to time constraints I switched to mocking the SearchingEngineParsingServiceProxy, so it now returns the random results data.