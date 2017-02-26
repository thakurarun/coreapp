/// would be use for vendor files...
var path = require('path');
var webpack = require('webpack');

module.exports = {
    resolve: {
        extensions: ['.js']
    },
    entry: {
        vendor: [
            "@angular/common",
            "@angular/compiler",
            "@angular/core",
            "@angular/forms",
            "@angular/http",
            "@angular/platform-browser",
            "@angular/platform-browser-dynamic",
            "@angular/router",

            "angular-in-memory-web-api",
            "systemjs",
            "core-js",
            "rxjs",
            "zone.js",
            "lodash"
        ]
    },
    module: {
        loaders: [
            {
                test: /\.ts$/,
                loader: 'ts-loader'
            }
        ]
    },
    output: {
        path: "./wwwroot/lib",
        filename: '[name].js',
        library: '[name]_[hash]',
    },
    plugins: [
        new webpack.optimize.OccurrenceOrderPlugin(),
        new webpack.DllPlugin({
            path: path.join(__dirname, '[name]-manifest.json'),
            name: '[name]_[hash]'
        })
    ]
};