const { JSDOM } = require('jsdom');
const fs = require('fs');
require('jsdom-global')();

function loadDom(pathToScriptToTest, pathToHtmlForTestScript, callback) {
    JSDOM.fromFile(pathToHtmlForTestScript, {
        runScripts: "dangerously",
        resources: "usable",
        url: `file:///${pathToHtmlForTestScript}`
    })
        .then((dom) => {
            let scriptContent = fs.readFileSync(pathToScriptToTest, 'utf-8');
            let scriptElement = dom.window.document.createElement('script');
            scriptElement.textContent = scriptContent;
            dom.window.document.head.appendChild(scriptElement);

            global.window = dom.window;
            global._paq = dom.window.eval("_paq");
            global.document = dom.window.document;
        })
        .then(callback, callback);
}

module.exports = {
    loadDom: loadDom,
}
