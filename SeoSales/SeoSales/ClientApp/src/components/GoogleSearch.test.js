import React from 'react';
import { shallow } from 'enzyme';
import GoogleSearch, { Error, ResultsContainer } from './GoogleSearch';

const setup = propsOverrides => {
  const props = {
    ...propsOverrides
  };

  const wrapper = shallow(<GoogleSearch {...props} />);

  return {
    props,
    wrapper
  };
}

describe('GoogleSearch', () => {
  it('should not display error when there is no error', () => {
    const { wrapper } = setup();

    expect(wrapper.find(Error).exists()).toBeFalsy();
  });

  it('should display error when there is an error', () => {
    const { wrapper } = setup({googleSearchError: 'error'});

    expect(wrapper.find(Error).exists()).toBeTruthy();
  });

  it('should not display analysis results when there are no analysis results', () => {
    const { wrapper } = setup();

    expect(wrapper.find(ResultsContainer).exists()).toBeFalsy();
  });

  it('should display analysis results when there are analysis results', () => {
    const { wrapper } = setup({googleResults: 'results'});

    expect(wrapper.find(ResultsContainer).exists()).toBeTruthy();
  });

  it('should call google search when search button clicked', () => {
    const searchGoogle = jest.fn();
    const { wrapper } = setup({searchGoogle});

    wrapper.find('.btn').simulate('click');

    expect(searchGoogle).toHaveBeenCalled();
  });
});