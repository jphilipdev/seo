import { GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS } from '../actions/constants';

const initialState = {
  googleSearchKeywords: 'test',
  googleResults: null,
  otherResults: null,
};

const searchReducer = (state = initialState, action) => {
  switch(action.type) {
    case GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS: {
      return {
        ...state,
        googleResults: action.payload.results
      };
    }

    default: 
      return state;
  }
};

export default searchReducer;