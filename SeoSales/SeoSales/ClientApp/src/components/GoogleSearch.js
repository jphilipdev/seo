import React, { Component } from 'react';

export default class GoogleSearch extends Component {

  constructor(props) {
    super(props);

    this.state = {
      keywords: '',
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
    this.props.searchGoogle('http://www.google.com', keywords, urlToMatch);
  }

  render() {
    const { googleResults, googleSearchError } = this.props;
    const { keywords, urlToMatch } = this.state;

    return (
      <div>
        <h1>Google Search</h1>

        <p>Enter search keywords and the URL to match</p>

        <input type='text' name='keywords' value={keywords} onChange={this.onChange} />
        <input type='text' name='urlToMatch' value={urlToMatch} onChange={this.onChange} />

        <button onClick={this.getSearchResults}>Search</button>

        {googleSearchError && 
          <div className='server-error'>{googleSearchError}</div>
        }

        {googleResults && 
          <div>
            <h2>Analysis Results</h2>
            <p>Matching results found at the following search result positions:</p>
            <p>{googleResults}</p>
          </div>
        }
      </div>
    );
  }
}
