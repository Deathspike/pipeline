import * as app from '../';
import * as mobx from 'mobx';

export class AppViewModel {
  @mobx.observable
  readonly counter = new app.CounterViewModel();
}
