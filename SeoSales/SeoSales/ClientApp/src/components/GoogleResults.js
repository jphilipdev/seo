import React, { Component } from 'react';

export default class GoogleResults extends Component {

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

  render() {
    const { keywords, urlToMatch } = this.state;

    return (
      <div>
        <h1>Google Results</h1>

        <p>Enter search keywords and the URL to match</p>

        <input type='text' name='keywords' value={keywords} onChange={this.onChange} />
        <input type='text' name='urlToMatch' value={urlToMatch} onChange={this.onChange} />

        <button onClick={this.incrementCounter}>Search</button>
      </div>
    );
  }
}
