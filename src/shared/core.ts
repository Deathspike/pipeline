import {DialogManager} from './managers/DialogManager';
import {ScreenManager} from './managers/ScreenManager';

export const core = {
  dialog: new DialogManager(),
  screen: new ScreenManager()
};
