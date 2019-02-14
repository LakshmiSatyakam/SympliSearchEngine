import React from 'react';
import expect from 'expect';
import {mount, shallow} from 'enzyme';
import { SearchCountPage } from './SearchCountPage';

describe('Sympli Search Page', () => {
  it('sets error message when trying to search empty text', () => {
    const props = {
      text: "",
      domain: "",
      actions: { searchCount: () => { return Promise.resolve(); } },
      errors: {},
      searchResults:"",
      searching: false
    };

    const wrapper = mount(<SearchCountPage {...props}/>);
    const searchButton = wrapper.find('input').last();
    expect(searchButton.prop('type')).toBe('submit');
    searchButton.simulate('click');
    alert(wrapper.state().errors.text);
    expect(wrapper.state().errors.text).toBe('Text must be at least 1 character.');
    expect(wrapper.state().errors.domain).toBe('Domain must be at least 1 character.');

  });
});
