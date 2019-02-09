import { LOAD_SEARCH_RESULTS_SUCCESS } from './constants';

export const resultsLoaded = results => ({
  type: LOAD_SEARCH_RESULTS_SUCCESS,
  payload: {
    ...results
  }
});