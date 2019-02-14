import * as types from './actionTypes';
import searchCountApi from '../api/searchCountApi';
import {beginAjaxCall, ajaxCallError} from './ajaxStatusActions';

export function loadSearchResultsSuccess(searchResults) {
  return { type: types.LOAD_SEARCH_RESULTS_SUCCESS, searchResults };
}

export function searchCountSuccess(searchResults) {
  return { type: types.SEARCH_COUNT_SUCCESS, searchResults};
}

export function loadSearchResults(searchResults) {
  return function (dispatch) {
    dispatch(loadSearchResultsSuccess(searchResults));
  };
}

export function searchCount(text, domain, engine) {
  return function (dispatch, getState) {
    dispatch(beginAjaxCall());
    return searchCountApi.getSearchCount(text, domain, engine).then(searchResults => {
      dispatch(searchCountSuccess(searchResults));
      dispatch(loadSearchResultsSuccess(searchResults));
    }).catch(error => {
      dispatch(ajaxCallError(error));
      throw(error);
    });
  };
}
