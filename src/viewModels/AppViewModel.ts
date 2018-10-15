export class AppViewModel {
  @mobx.observable
  readonly counter = new app.CounterViewModel();
}
