import * as areas from './areas';
import * as mobx from 'mobx';
import * as mobxReact from 'mobx-react';
import * as mui from '@material-ui/core';
import * as React from 'react';
import * as ReactDOM from 'react-dom';

@mobxReact.observer
class App extends React.Component {
  render() {
    return (
      <mui.MuiThemeProvider theme={areas.shared.theme}>
        <mui.CssBaseline />
        <Builder />
      </mui.MuiThemeProvider>
    );
  }
}

@mobxReact.observer
class Builder extends React.Component {
  render() {
    return <areas.counter.MainController />;
  }
}

(function() {
  mobx.configure({enforceActions: 'observed'});
  ReactDOM.render(<App />, document.getElementById('container'));
})();
