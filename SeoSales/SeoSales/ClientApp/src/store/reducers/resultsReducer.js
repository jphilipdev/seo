import { LOAD_SEARCH_RESULTS_SUCCESS } from '../actions/constants';

const initialState = {
  results: []
};

const resultsReducer = (state = initialState, action) => {
  switch(action.type) {
    case LOAD_SEARCH_RESULTS_SUCCESS: {
      return {
        ...state,
        results: [...action.results]
      }
    }

    default: 
      return state;
  }
};

export default resultsReducer;