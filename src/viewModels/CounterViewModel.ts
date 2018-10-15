export class CounterViewModel {
  @mobx.action
  increment() {
    this.value++;
  }

  @mobx.observable
  value = 0;
}
