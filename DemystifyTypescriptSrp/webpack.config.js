"use strict"
{
    // Required to form the full output paths
    let path = require('path');

    // This plugin cleans up the output bundle before bundling again
    const CleanWebpackPlugin = require('clean-webpack-plugin');

    // Output bundle path
    const bundleFolder = "wwwroot/bundle/";

    module.exports = {
        // Application entry point
        entry: "./Scripts/main.js",

        // Output file
        output: {
            filename: 'script.js',
            path: path.resolve(__dirname, bundleFolder)
        },
        plugins: [
            new CleanWebpackPlugin([bundleFolder])
        ]
    };
}