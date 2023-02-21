const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/choice",
    "/choices",
    "/play",
    "/getscoreboard"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7109',
        secure: false
    });

    app.use(appProxy);
};
