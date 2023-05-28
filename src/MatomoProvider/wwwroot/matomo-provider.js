let _paq = window._paq || [];

_paq.push(['trackPageView']);
_paq.push(['enableLinkTracking']);

window.MatomoProvider = {
    initialize: function (apiUrl, siteId) {
        var u = apiUrl;
        _paq.push(['setTrackerUrl', u + 'matomo.php']);
        _paq.push(['setSiteId', siteId]);
        var d = document, g = d.createElement('script'), s = d.getElementsByTagName('script')[0];
        g.type = 'text/javascript'; g.async = true; g.defer = true; g.src = u + 'matomo.js'; s.parentNode.insertBefore(g, s);
    },

    triggerPageChange: function (userId, referrerUrl, url) {
        if (userId) {
            _paq.push(['setUserId', userId]);
        }
        _paq.push(['setReferrerUrl', referrerUrl]);
        _paq.push(['setCustomUrl', url]);
        _paq.push(['setDocumentTitle', document.title]);

        _paq.push(['trackPageView']);

        _paq.push(['enableLinkTracking']);
    },

    resetUserId: function () {
        _paq.push(['resetUserId']);
        _paq.push(['appendToTrackingUrl', 'new_visit=1']);

        _paq.push(['trackPageView']);

        _paq.push(['appendToTrackingUrl', '']);
    }
}
