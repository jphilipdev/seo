import { post } from '../../util/api';
import { googleResultsSuccess, googleResultsFailure } from '../actions/searchActions';

export const searchGoogle = (targetSearchEngineUrl, keywords, urlToMatch) => dispatch => {
  post('api/searchresultsanalysis', {
    targetSearchEngineUrl, 
    keywords, 
    urlToMatch}
  )
  .then(data => {
    dispatch(googleResultsSuccess(data));
  }).catch(({body}) => {
    body.then(error => dispatch(googleResultsFailure(error)));
  });
};