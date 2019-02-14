import delay from './delay';

// This file mocks a web API by working with the hard-coded data below.
// It uses setTimeout to simulate the delay of an AJAX call.
// All calls return promises.

const customHeader = {
  'Content-Type': 'application/json',
  'Accept': 'application/json'
};

class SearchCountApi {

  static getFromApi(resolve, reject, text, domain, engine) {
    fetch("https://localhost:44369/api/search/searchResults?searchText=" + text + "&searchUrl=" + domain + "&searchEngine=" + engine, { method: 'GET', headers: customHeader })
      .then(res => res.json())
      .then(
        (response) => { resolve(Object.assign(response)); },
        (error) => { reject(error); }
      );
   }

  static getSearchCount(text, domain, engine) {
     return new Promise((resolve, reject) => {
       setTimeout(() => { SearchCountApi.getFromApi(resolve, reject, text, domain, engine); }, delay);
    });
  }
}

export default SearchCountApi;
