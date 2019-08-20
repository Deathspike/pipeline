import * as app from '..';
import * as mobxReact from 'mobx-react';
import * as mui from '@material-ui/core';
import * as React from 'react';
import {language} from '../language';

@mobxReact.observer
export class MainView extends React.Component<{vm: app.MainViewModel}> {
  render() {
    return (
      <mui.Grid>
        <mui.Paper style={styles.textContainer}>
          <mui.Typography>
            {language.displayText} {this.props.vm.value}
          </mui.Typography>
        </mui.Paper>
        <mui.Grid style={styles.buttonContainer}>
          <mui.Button color="primary" variant="contained" style={styles.button} onClick={() => this.props.vm.increment()}>
            <app.icons.Add style={styles.buttonIcon} />
            {language.incrementButton}
          </mui.Button>
          <mui.Button color="primary" variant="contained" style={styles.button} onClick={() => this.props.vm.decrement()}>
            <app.icons.Remove style={styles.buttonIcon} />
            {language.decrementButton}
          </mui.Button>
        </mui.Grid>
      </mui.Grid>
    );
  }
}

const styles = app.styles({
  textContainer: {
    padding: app.theme.spacing() 
  },
  buttonContainer: {
    marginTop: app.theme.spacing(),
    textAlign: 'center'
  },
  button: {
    marginRight: app.theme.spacing()
  },
  buttonIcon: {
    marginRight: app.theme.spacing()
  }
});
