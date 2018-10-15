@mobxReact.observer
class App extends React.Component<{vm: app.AppViewModel}> {
  render() {
    return (
      <div>
        <header>
          Sunfish
        </header>
        <main>
          <app.CounterView vm={this.props.vm.counter} />
        </main>
      </div>
    );
  }
}

(function() {
  let vm = new app.AppViewModel();
  mobx.configure({enforceActions: 'always'});
  ReactDOM.render(<App vm={vm} />, document.getElementById('container'));
  if (window.oni) window.oni.toNativeAsync('shell.hideSplashScreen');
})();
