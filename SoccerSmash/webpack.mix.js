let mix = require('laravel-mix');

mix.autoload({
    axios:['$axios']
})

mix.js('srcvue/webapp/app/Home/Home.js', 'wwwroot/js').vue()
    .webpackConfig({
        module: {
            rules: [
                // We're registering the TypeScript loader here. It should only
                // apply when we're dealing with a `.ts` or `.tsx` file.
                {
                    test: /\.tsx?$/,
                    loader: 'ts-loader',
                    options: { appendTsSuffixTo: [/\.vue$/] },
                    exclude: /node_modules/,
                },
            ],
        },

        resolve: {
            // We need to register the `.ts` extension so Webpack can resolve
            // TypeScript modules without explicitly providing an extension.
            // The other extensions in this list are identical to the Mix
            // defaults.
            extensions: ['*', '.js', '.jsx', '.vue', '.ts', '.tsx'],
        },
    });
