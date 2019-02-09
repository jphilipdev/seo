import { LOAD_SEARCH_RESULTS_SUCCESS } from '../actions/constants';

const initialState = {
  googleSearchKeywords: 'test',
  googleResults: [],
  otherResults: [],
};

const searchReducer = (state = initialState, action) => {
  switch(action.type) {
    case LOAD_SEARCH_RESULTS_SUCCESS: {
      return {
        ...state,
        googleResults: [...action.results]
      }
    }

    default: 
      return state;
  }
};

export default searchReducer;