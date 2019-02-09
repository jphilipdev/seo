import { GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS, GOOGLE_LOAD_SEARCH_RESULTS_FAILURE } from './constants';

export const googleResultsSuccess = data => ({
  type: GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS,
  payload: data
});

export const googleResultsFailure = data => ({
  type: GOOGLE_LOAD_SEARCH_RESULTS_FAILURE,
  payload: data
});