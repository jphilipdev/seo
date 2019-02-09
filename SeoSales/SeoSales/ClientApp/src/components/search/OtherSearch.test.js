import React from 'react';
import { shallow } from 'enzyme';
import OtherSearch from './OtherSearch';
import Error from './shared/Error';
import ResultsContainer from './shared/ResultsContainer';

const setup = propsOverrides => {
  const props = {
    ...propsOverrides
  };

  const wrapper = shallow(<OtherSearch {...props} />);

  return {
    props,
    wrapper
  };
}

describe('OtherSearch', () => {
  it('should not display error when there is no error', () => {
    const { wrapper } = setup();

    expect(wrapper.find(Error).exists()).toBeFalsy();
  });

  it('should display error when there is an error', () => {
    const { wrapper } = setup({otherSearchError: 'error'});

    expect(wrapper.find(Error).exists()).toBeTruthy();
  });

  it('should not display analysis results when there are no analysis results', () => {
    const { wrapper } = setup();

    expect(wrapper.find(ResultsContainer).exists()).toBeFalsy();
  });

  it('should display analysis results when there are analysis results', () => {
    const { wrapper } = setup({otherResults: 'results'});

    expect(wrapper.find(ResultsContainer).exists()).toBeTruthy();
  });

  it('should call other search when search button clicked', () => {
    const searchOther = jest.fn();
    const { wrapper } = setup({searchOther});

    wrapper.find('.btn').simulate('click');

    expect(searchOther).toHaveBeenCalled();
  });
});