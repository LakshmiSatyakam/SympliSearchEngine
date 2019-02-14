import React, { PropTypes } from 'react';

const SearchList = ({ searchResults }) => {
  console.log(searchResults);
  return (
    <table className="table">
      <tbody>
        <tr>
          <td>{searchResults}</td>
        </tr>
      </tbody>
    </table>
  );
};

SearchList.propTypes = {
  searchResults: PropTypes.string
};

export default SearchList;
