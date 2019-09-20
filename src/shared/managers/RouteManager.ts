import * as app from '..';
import * as mobx from 'mobx';

export class RouteManager {
  constructor() {
    this.rootType = 0;
  }

  @mobx.action
  changeRoot(rootType: app.RootType) {
    this.rootType = rootType;
  }

  @mobx.observable
  rootType: app.RootType;
}
