import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <h1>Hello, CEO!</h1>
        <p>Please use the menu to instantly see results from Google, or from some <i>other</i> search engine.</p>        
      </div>
    );
  }
}
