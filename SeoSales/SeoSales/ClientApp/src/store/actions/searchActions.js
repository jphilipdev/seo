import { GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS } from './constants';

export const googleResultsLoaded = results => ({
  type: GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS,
  payload: [...results]  
});