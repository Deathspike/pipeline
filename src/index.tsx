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

if (window.oni) {
  window.oni.addEventListener('backbutton', () => {
    window.oni!.sendAsync('shell.minimizeApp');
  });
}

(function() {
  areas.shared.connectStyles(areas);
  areas.shared.core.screen.openAsync(areas.counter.MainController.constructAsync);
  ReactDOM.render(<App />, document.getElementById('container'));
  setTimeout(() => window.oni && window.oni.sendAsync('shell.hideSplashScreen'), 1000);
})();
