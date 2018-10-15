module.exports = {
  entry: './dist',
  output: {filename: 'app.min.js', path: __dirname + '/public'},
  resolve: {extensions: ['.js', '.ts', '.tsx']}
};
