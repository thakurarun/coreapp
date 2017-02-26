var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
    devtool: 'source-map',
    entry: './Client/main.ts',
    module: {
        loaders: [
            {
                test: /\.ts$/,
                include: path.resolve(__dirname, "Client"),
                loader: 'ts-loader'
            },
            {
                // use ExtractTextPlugin to extract css to seperate file
                test: /\.s(a|c)ss$/,
                include: path.resolve(__dirname, "Views"),
                loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: 'css-loader!sass-loader' })
            },
            {
                test: /\.html$/,
                loader: "html-loader"
            }
        ]
    },
    output: {
        filename: 'bundle.js',
        path: "./wwwroot/appScript"
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin({
            sourceMap: true
        }),
        new ExtractTextPlugin("../appStyles.css"),
        new webpack.DllReferencePlugin({
            context: __dirname,
            manifest: require('./vendor-manifest.json')
        })
    ],
    resolve: {
        extensions: ['.webpack.js', '.web.js', '.ts', '.js']
    },
    watch: true
};