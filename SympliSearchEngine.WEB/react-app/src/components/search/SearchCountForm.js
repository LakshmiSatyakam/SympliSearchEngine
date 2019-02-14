import React from 'react';
import TextInput from '../common/TextInput';

const SearchCountForm = ({ text, domain, engine, onSearch, onChange, searching, errors}) => {
  return (
    <form>
      <h1>Sympli Search Page</h1>
      <TextInput
        name="text"
        label="Text"
        value={text}
        onChange={onChange}
        error={errors.text} />

      <TextInput
        name="domain"
        label="Domain"
        value={domain}
        onChange={onChange}
        error={errors.domain} />

      <TextInput
        name="engine"
        label="Engine"
        value={engine}
        onChange={onChange} />

      <input
        type="submit"
        disabled={searching}
        value={searching ? 'Searching...' : 'Search'}
        className="btn btn-primary"
        onClick={onSearch}/>
        <br/><br/>
        <hr/>
    </form>
  );
};

SearchCountForm.propTypes = {
  text: React.PropTypes.string,
  domain: React.PropTypes.string,
  engine: React.PropTypes.string,
  onSearch: React.PropTypes.func.isRequired,
  onChange: React.PropTypes.func.isRequired,
  searching: React.PropTypes.bool,
  errors: React.PropTypes.object
};

export default SearchCountForm;
