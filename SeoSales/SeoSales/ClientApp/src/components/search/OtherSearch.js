import React, { Component } from 'react';
import SearchForm from './shared/SearchForm';
import TextInput from './shared/TextInput';
import Error from './shared/Error';
import ResultsContainer from './shared/ResultsContainer';

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
            <label htmlFor='targetSearchEngineUrl'>Search Engine</label>
            <TextInput type='text' name='targetSearchEngineUrl' value={targetSearchEngineUrl} onChange={this.onChange} />
          </div>
          <div>
            <label htmlFor='keywords'>Keywords</label>
            <TextInput type='text' name='keywords' value={keywords} onChange={this.onChange} />
          </div>
          <div>
            <label htmlFor='urlToMatch'>URL to Match</label>
            <TextInput type='text' name='urlToMatch' value={urlToMatch} onChange={this.onChange} />
          </div>
          <button className="btn btn-primary" onClick={this.getSearchResults}>Search</button>

          {otherSearchError &&
            <Error>{otherSearchError}</Error>
          }

        </SearchForm>

        {otherResults &&
          <ResultsContainer>
            <h2>Analysis Results</h2>
            <p>Matching results found at the following search result positions:</p>
            <p>{otherResults}</p>
          </ResultsContainer>
        }
      </div>
    );
  }
}
