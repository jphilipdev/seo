import { post } from '../../util/api';
import { googleResultsSuccess, googleResultsFailure, otherResultsSuccess, otherResultsFailure } from '../actions/searchActions';

export const searchGoogle = (keywords, urlToMatch) => dispatch => {
  post('api/searchresultsanalysis', {
    targetSearchEngineUrl: 'http://www.google.com', 
    keywords, 
    urlToMatch}
  )
  .then(data => {
    dispatch(googleResultsSuccess(data));
  }).catch(({body}) => {
    body.then(error => dispatch(googleResultsFailure(error)));
  });
};

export const searchOther = (targetSearchEngineUrl, keywords, urlToMatch) => dispatch => {
  post('api/searchresultsanalysis', {
    targetSearchEngineUrl, 
    keywords, 
    urlToMatch}
  )
  .then(data => {
    dispatch(otherResultsSuccess(data));
  }).catch(({body}) => {
    body.then(error => dispatch(otherResultsFailure(error)));
  });
};