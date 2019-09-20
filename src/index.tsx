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
        <areas.shared.DialogManagerView />
        <areas.shared.ScreenManagerView />
      </mui.MuiThemeProvider>
    );
  }
}

async function RootAsync(rootType: areas.shared.RootType) {
  switch (rootType) {
    case areas.shared.RootType.Counter:
      return await areas.shared.core.screen.openAsync(areas.counter.MainController.constructAsync);
  }
}

(async function() {
  mobx.reaction(() => areas.shared.core.route.rootType, RootAsync, {fireImmediately: true});
  ReactDOM.render(<App />, document.getElementById('container'));
})();
