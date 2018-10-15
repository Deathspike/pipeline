const common = require('./webpack.common.js');
const merge = require('webpack-merge');

module.exports = merge(common, {
  devtool: 'eval',
  devServer: {contentBase: __dirname + '/public', host: '0.0.0.0', port: 3000},
  mode: 'development'
});
