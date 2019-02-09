import { 
  GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS, 
  GOOGLE_LOAD_SEARCH_RESULTS_FAILURE, 
  OTHER_LOAD_SEARCH_RESULTS_SUCCESS, 
  OTHER_LOAD_SEARCH_RESULTS_FAILURE 
} from './constants';

export const googleResultsSuccess = data => ({
  type: GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS,
  payload: data
});

export const googleResultsFailure = data => ({
  type: GOOGLE_LOAD_SEARCH_RESULTS_FAILURE,
  payload: data
});

export const otherResultsSuccess = data => ({
  type: OTHER_LOAD_SEARCH_RESULTS_SUCCESS,
  payload: data
});

export const otherResultsFailure = data => ({
  type: OTHER_LOAD_SEARCH_RESULTS_FAILURE,
  payload: data
});