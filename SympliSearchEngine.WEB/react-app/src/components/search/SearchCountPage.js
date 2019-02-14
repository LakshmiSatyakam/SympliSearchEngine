import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as searchCountActions from '../../actions/searchCountActions';
import SearchCountForm from './SearchCountForm';
import SearchList from './SearchList';
import toastr from 'toastr';
import moment from 'moment';

export class SearchCountPage extends React.Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      text: "",
      domain: "",
      engine: "",
      errors: {},
      searching: false,
      lastAPICallTime: null
    };

    this.updateSearchFormState = this.updateSearchFormState.bind(this);
    this.searchCount = this.searchCount.bind(this);
  }

  updateSearchFormState(event) {
    const field = event.target.name;
    let value = event.target.value;

    if (field == "text") {
      return this.setState({ text: value });
    }

    if (field == "domain") {
      return this.setState({ domain: value });
    }

    if (field == "engine") {
      return this.setState({ engine: value });
    }

    return this.setState({ field: value });
  }

  searchCountFormIsValid() {
    let formIsValid = true;
    let errors = {};

    if (this.state.text.length <= 0) {
      errors.text = 'Text must be at least 1 character.';
      formIsValid = false;
    }

    if (this.state.domain.length <= 0) {
      errors.domain = 'Domain must be at least 1 character.';
      formIsValid = false;
    }

    this.setState({errors: errors});
    return formIsValid;
  }

  searchCount(event) {
    event.preventDefault();

    if (!this.searchCountFormIsValid()) {
      return;
    }    

    let callAPI = true;
    if (this.state.lastAPICallTime !== null) {
      let ms = moment(moment(), "DD/MM/YYYY HH:mm:ss").diff(moment(this.state.lastAPICallTime, "DD/MM/YYYY HH:mm:ss"));
      let d = moment.duration(ms);
      if (d.asHours() < 1) {
        callAPI = false;
        this.loadSearchResults();
      }
    }

    if (callAPI) {
      this.setState({ searching: true });
      this.props.actions.searchCount(this.state.text, this.state.domain, this.state.engine)
        .then(() => this.loadSearchResults(), this.setState({ lastAPICallTime: moment() }))
        .catch(error => {
          toastr.error(error);
          this.setState({ searching: false });
        });
    }
  }

  loadSearchResults() {
    this.setState({ searching: false });
    toastr.success('Search completed.');
  }

  render() {
    const {searchResults} = this.props;

    return (
      <div>
        <SearchCountForm
          onChange={this.updateSearchFormState}
          onSearch={this.searchCount}
          text={this.state.text}
          domain={this.state.domain}
          engine={this.state.engine}
          errors={this.state.errors}
          searching={this.state.searching}
        />
        <h1>Search Results</h1>
        <SearchList searchResults={searchResults} />
      </div>
    );
  }
}

SearchCountPage.propTypes = {
  text: PropTypes.string,
  domain: PropTypes.string,
  engine: PropTypes.string,
  searchResults: PropTypes.string,
  actions: PropTypes.object.isRequired,
  lastAPICallTime: PropTypes.Datetime
};

function mapStateToProps(state, ownProps) {
   return {
     text: state.text,
     domain: state.domain,
     engine: state.engine,
     searchResults: state.searchResults,
     lastAPICallTime: state.lastAPICallTime
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(searchCountActions, dispatch)
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(SearchCountPage);
