import React, { Component } from 'react';
import styled from 'styled-components';
import { baseline, colours } from '../styles/constants';

const SearchForm = styled.div`
  margin-bottom: ${baseline(8)};
`;

const TextInput = styled.input`
  margin-left: ${baseline(1)};
`;

const Error = styled.div`
  margin-top: ${baseline(1)};
  color: ${colours.errorRed};
`;

export default class OtherSearch extends Component {

  constructor(props) {
    super(props);

    this.state = {
      targetSearchEngineUrl: 'http://www.bing.com',
      keywords: 'e-settlements',
      urlToMatch: 'http://www.sympli.com.au'
    }
  }

  onChange = event => (
    this.setState({
      [event.target.name]: event.target.value
    })
  );

  getSearchResults = () => {
    const { targetSearchEngineUrl, keywords, urlToMatch } = this.state;
    this.props.searchOther(targetSearchEngineUrl, keywords, urlToMatch);
  }

  render() {
    const { otherResults, otherSearchError } = this.props;
    const { targetSearchEngineUrl, keywords, urlToMatch } = this.state;

    return (
      <div>
        <h1>Other Search Engines</h1>

        <p>Enter search keywords and the URL to match</p>

        <SearchForm>
          <div>
            <label for='targetSearchEngineUrl'>Search Engine</label>
            <TextInput type='text' name='targetSearchEngineUrl' value={targetSearchEngineUrl} onChange={this.onChange} />
          </div>
          <div>
            <label for='keywords'>Keywords</label>
            <TextInput type='text' name='keywords' value={keywords} onChange={this.onChange} />
          </div>
          <div>
            <label for='urlToMatch'>URL to Match</label>
            <TextInput type='text' name='urlToMatch' value={urlToMatch} onChange={this.onChange} />
          </div>
          <button onClick={this.getSearchResults}>Search</button>

          {otherSearchError &&
            <Error>{otherSearchError}</Error>
          }

        </SearchForm>

        {otherResults &&
          <div>
            <h2>Analysis Results</h2>
            <p>Matching results found at the following search result positions:</p>
            <p>{otherResults}</p>
          </div>
        }
      </div>
    );
  }
}
