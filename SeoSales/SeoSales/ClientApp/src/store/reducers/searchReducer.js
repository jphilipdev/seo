import { GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS } from '../actions/constants';

const initialState = {
  googleSearchKeywords: 'test',
  googleResults: ['a'],
  otherResults: [],
};

const searchReducer = (state = initialState, action) => {
  switch(action.type) {
    case GOOGLE_LOAD_SEARCH_RESULTS_SUCCESS: {
      return {
        ...state,
        googleResults: [...action.payload]
      };
    }

    default: 
      return state;
  }
};

export default searchReducer;