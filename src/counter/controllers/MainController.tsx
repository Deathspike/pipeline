import * as app from '..';
import * as React from 'react';

export class MainController extends React.Component {
  state = {
    vm: new app.MainViewModel()
  };

  render() {
    return (
      <app.HeaderComponent title={document.title}>
        <app.MainView vm={this.state.vm} />
      </app.HeaderComponent>
    );
  }
}
