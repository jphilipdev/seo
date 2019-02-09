import { GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS } from './constants';

export const googleResultsLoaded = data => ({
  type: GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS,
  payload: data
});