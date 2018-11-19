@mobxReact.observer
class App extends React.Component<{vm: app.AppViewModel}> {
  render() {
    return (
      <div>
        <header className="ios-inset-top">
          Sunfish
        </header>
        <main className="ios-inset-top ios-inset-bottom">
          <app.CounterView vm={this.props.vm.counter} />
        </main>
        <footer className="ios-inset-bottom">
          Footer
        </footer>
      </div>
    );
  }
}

(function() {
  let vm = new app.AppViewModel();
  mobx.configure({enforceActions: 'always'});
  ReactDOM.render(<App vm={vm} />, document.getElementById('container'));
  setTimeout(() => {
    if (window.oni) window.oni.sendAsync('shell.hideSplashScreen');
  }, 1000);
})();
