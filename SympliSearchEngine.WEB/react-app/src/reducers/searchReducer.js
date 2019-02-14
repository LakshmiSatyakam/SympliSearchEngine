import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function searchReducer(state = initialState.searchResults, action) {
  switch (action.type) {
    case types.SEARCH_COUNT_SUCCESS:
      return action.searchResults;

    default:
      return state;
  }
}
