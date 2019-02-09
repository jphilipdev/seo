import { createSelector } from 'reselect';

const search = state => state.search;

export const google = createSelector(
  search,
  search => search.googleResults
);