const { expect } = require('chai');
require('chai').use(require('chai-dom'));

const utils = require('./utils');

const scriptPath = `${__dirname}/../../MatomoProvider/wwwroot/matomo-provider.js`;
const htmlPath = `${__dirname}/matomo-provider.test.html`;

describe('matomo script tests', () => {
    beforeEach((callback) => {
        utils.loadDom(scriptPath, htmlPath, callback);
    });

    it('pushes "trackPageView" and "enableLinkTracking" to _paq on load', () => {
        [['trackPageView'], ['enableLinkTracking']].forEach((item) => {
            expect(_paq).to.deep.contain(item);
        });
    });

    it('initializes correctly when provided correct values', () => {
        const apiUrl = 'localhost/';
        const siteId = '1';
        const expectedScriptElement = `script[type="text/javascript"][defer][src="${apiUrl}matomo.js"]`;

        window.MatomoProvider.initialize(apiUrl, siteId);

        [['setTrackerUrl', `${apiUrl}matomo.php`], ['setSiteId', siteId]].forEach((item) => {
            expect(_paq, `should push ${item} to _paq`).to.deep.contain(item);
        })
        expect(document.querySelectorAll(expectedScriptElement), 'should inject the matomo.js script tag')
            .to.have.lengthOf(2);
    });
});
