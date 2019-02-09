import { createSelector } from 'reselect';

const search = state => state.search;

export const googleResults = createSelector(
  search,
  search => search.googleResults
);

export const googleSearchError = createSelector(
  search,
  search => search.googleSearchError
);

export const otherResults = createSelector(
  search,
  search => search.otherResults
);

export const otherSearchError = createSelector(
  search,
  search => search.otherSearchError
);