import {combineReducers} from 'redux';
import searchResults from './searchReducer';
import ajaxCallsInProgress from './ajaxStatusReducer';

const rootReducer = combineReducers({
  searchResults,
  ajaxCallsInProgress
});

export default rootReducer;
