import { 
  GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS, 
  GOOGLE_LOAD_SEARCH_RESULTS_FAILURE, 
  OTHER_LOAD_SEARCH_RESULTS_SUCCESS, 
  OTHER_LOAD_SEARCH_RESULTS_FAILURE 
} from '../actions/constants';

const initialState = {
  googleResults: null,
  googleSearchError: null,
  otherResults: null,
  otherSearchError: null
};

const searchReducer = (state = initialState, action) => {
  switch(action.type) {
    case GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS: {
      return {
        ...state,
        googleResults: action.payload.results,
        googleSearchError: null
      };
    }

    case GOOGLE_LOAD_SEARCH_RESULTS_FAILURE: {
      return {
        ...state,
        googleResults: null,
        googleSearchError: action.payload.ErrorMessage
      };
    }

    case OTHER_LOAD_SEARCH_RESULTS_SUCCESS: {
      return {
        ...state,
        otherResults: action.payload.results,
        otherSearchError: null
      };
    }

    case OTHER_LOAD_SEARCH_RESULTS_FAILURE: {
      return {
        ...state,
        otherResults: null,
        otherSearchError: action.payload.ErrorMessage
      };
    }

    default: 
      return state;
  }
};

export default searchReducer;