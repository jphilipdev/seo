import React, { Component } from 'react';
import SearchForm from './shared/SearchForm';
import TextInput from './shared/TextInput';
import Error from './shared/Error';
import ResultsContainer from './shared/ResultsContainer';

export default class GoogleSearch extends Component {

  constructor(props) {
    super(props);

    this.state = {
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
    const { keywords, urlToMatch } = this.state;
    this.props.searchGoogle(keywords, urlToMatch);
  }

  render() {
    const { googleResults, googleSearchError } = this.props;
    const { keywords, urlToMatch } = this.state;

    return (
      <div>
        <h1>Google Search</h1>

        <p>Enter search keywords and the URL to match</p>

        <SearchForm>
          <div>
            <label htmlFor='keywords'>Keywords</label>
            <TextInput type='text' name='keywords' value={keywords} onChange={this.onChange} />
          </div>
          <div>
            <label htmlFor='urlToMatch'>URL to Match</label>
            <TextInput type='text' name='urlToMatch' value={urlToMatch} onChange={this.onChange} />
          </div>
          <button className="btn btn-primary" onClick={this.getSearchResults}>Search</button>

          {googleSearchError &&
            <Error>{googleSearchError}</Error>
          }

        </SearchForm>

        {googleResults &&
          <ResultsContainer>
            <h2>Analysis Results</h2>
            <p>Matching results found at the following search result positions:</p>
            <p>{googleResults}</p>
          </ResultsContainer>
        }
      </div>
    );
  }
}
