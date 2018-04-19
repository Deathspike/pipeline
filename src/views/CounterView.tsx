import * as app from '../';
import * as mobxReact from 'mobx-react';
import * as React from 'react';

@mobxReact.observer
export class CounterView extends React.Component<{vm: app.CounterViewModel}> {
  render() {
    return (
      <span onClick={() => this.props.vm.increment()}>
        Clicked {this.props.vm.value} times!
      </span>
    );
  }
}
