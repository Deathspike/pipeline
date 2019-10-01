import * as app from '.';
let cacheDialog: app.DialogManager;
let cacheScreen: app.ScreenManager;

export const core = {
  get dialog() {
    if (cacheDialog) return cacheDialog;
    cacheDialog = new app.DialogManager();
    return cacheDialog;
  },

  get screen() {
    if (cacheScreen) return cacheScreen;
    cacheScreen = new app.ScreenManager();
    return cacheScreen;
  }
};
