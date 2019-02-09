import { googleResultsLoaded } from '../actions/searchActions';

export const searchGoogle = (targetSearchEngineUrl, keywords, urlToMatch) => dispatch => {
  fetch('api/searchresultsanalysis', {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({targetSearchEngineUrl, keywords, urlToMatch}),
  })
  .then(response => response.json())
  .then(data => {
    dispatch(googleResultsLoaded(data));
  });
};