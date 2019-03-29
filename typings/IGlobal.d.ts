import _app = require('../');
import _mobx = require('mobx');
import _mobxReact = require('mobx-react');
import _mui = require('@material-ui/core');
import _React = require('react');
import _ReactDOM = require('react-dom');

declare global {
  const app: typeof _app;
  const mobx: typeof _mobx;
  const mobxReact: typeof _mobxReact;
  const mui: typeof _mui;
  const React: typeof _React;
  const ReactDOM: typeof _ReactDOM;
}