import * as app from '..';
import * as mobxReact from 'mobx-react';
import * as mui from '@material-ui/core';
import * as React from 'react';
import {language} from '../language';

@mobxReact.observer
export class MainView extends app.BaseComponent<typeof MainViewStyles, {vm: app.MainViewModel}> {
  render() {
    return (
      <mui.Grid>
        <mui.Paper className={this.classes.textContainer}>
          <mui.Typography>
            {language.displayText} {this.props.vm.value}
          </mui.Typography>
        </mui.Paper>
        <mui.Grid className={this.classes.buttonContainer}>
          <mui.Button color="primary" variant="contained" className={this.classes.button} onClick={() => this.props.vm.increment()}>
            <app.icons.Add className={this.classes.buttonIcon} />
            {language.incrementButton}
          </mui.Button>
          <mui.Button color="primary" variant="contained" className={this.classes.button} onClick={() => this.props.vm.decrement()}>
            <app.icons.Remove className={this.classes.buttonIcon} />
            {language.decrementButton}
          </mui.Button>
        </mui.Grid>
      </mui.Grid>
    );
  }
}

export const MainViewStyles = mui.createStyles({
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
