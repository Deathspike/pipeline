import * as areas from './areas';
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
        <areas.shared.DialogManagerView />
        <areas.shared.ScreenManagerView />
      </mui.MuiThemeProvider>
    );
  }
}

@mobxReact.observer
class Root extends React.Component {
  render() {
    switch (areas.shared.core.screen.rootType) {
      case areas.shared.RootType.Counter:
        return <areas.counter.MainController />;
    }
  }
}

(function() {
  areas.shared.core.screen.open(Root);
  ReactDOM.render(<App />, document.getElementById('container'));
})();
