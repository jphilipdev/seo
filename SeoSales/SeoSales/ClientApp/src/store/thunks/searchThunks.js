import { googleResultsLoaded } from '../actions/searchActions';


export const search = (targetSearchEngineUrl, keywords, urlToMatch) => dispatch => {
    dispatch(googleResultsLoaded(["1", "15", "37"]));
};