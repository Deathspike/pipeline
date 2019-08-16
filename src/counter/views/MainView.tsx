import * as app from '..';
import * as mobxReact from 'mobx-react';
import * as mui from '@material-ui/core';
import * as React from 'react';

@mobxReact.observer
export class MainView extends React.Component<{vm: app.MainViewModel}> {
  render() {
    return (
      <mui.Grid>
        <mui.Paper style={styles.textContainer}>
          <mui.Typography>
            {app.language.displayText} {this.props.vm.value}
          </mui.Typography>
        </mui.Paper>
        <mui.Grid style={styles.buttonContainer}>
          <mui.Button color="primary" variant="contained" style={styles.button} onClick={() => this.props.vm.increment()}>
            <app.icons.Add style={styles.buttonIcon} />
            {app.language.incrementButton}
          </mui.Button>
          <mui.Button color="primary" variant="contained" style={styles.button} onClick={() => this.props.vm.decrement()}>
            <app.icons.Remove style={styles.buttonIcon} />
            {app.language.decrementButton}
          </mui.Button>
        </mui.Grid>
      </mui.Grid>
    );
  }
}

const styles = app.styles({
  textContainer: {
    padding: app.theme.spacing.unit 
  },
  buttonContainer: {
    marginTop: app.theme.spacing.unit,
    textAlign: 'center'
  },
  button: {
    marginRight: app.theme.spacing.unit
  },
  buttonIcon: {
    marginRight: app.theme.spacing.unit
  }
});
