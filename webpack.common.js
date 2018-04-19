const rules = [
  {test: /\.tsx?$/, loader: 'ts-loader'}
];

module.exports = {
  entry: './src',
  output: {filename: 'app.min.js', path: __dirname + '/public'},
  module: {rules},
  performance: {hints: false},
  resolve: {extensions: ['.js', '.ts', '.tsx']}
};
