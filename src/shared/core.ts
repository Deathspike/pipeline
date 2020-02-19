import * as app from '.';
let dialog: app.DialogManager;
let screen: app.ScreenManager;

export const core = {
  get dialog() {
    if (dialog) return dialog;
    dialog = new app.DialogManager();
    return dialog;
  },

  get screen() {
    if (screen) return screen;
    screen = new app.ScreenManager();
    return screen;
  }
};
