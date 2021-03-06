import { Provider } from 'react-redux';
import ReactDOM from 'react-dom';
import React from 'react';
import darkBaseTheme from 'material-ui/styles/baseThemes/darkBaseTheme';
import getMuiTheme from 'material-ui/styles/getMuiTheme'
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';

import App from './App';
import configureStore from '../data/';

if(process.env.NODE_ENV === 'development') {
  require('./index.html');
}

import './app.css'

ReactDOM.render(
  <MuiThemeProvider muiTheme={getMuiTheme(darkBaseTheme)}>
    <Provider store={configureStore()}>
      <App />
    </Provider>
  </MuiThemeProvider>,
  document.getElementById('root')
);
