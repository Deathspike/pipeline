import {DialogManager} from './managers/DialogManager';
import {RouteManager} from './managers/RouteManager';
import {ScreenManager} from './managers/ScreenManager';

export const core = {
  dialog: new DialogManager(),
  route: new RouteManager(),
  screen: new ScreenManager()
};
