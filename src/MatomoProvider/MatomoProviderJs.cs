using Microsoft.JSInterop;

namespace MatomoProvider;

public static class MatomoProviderJs
{
    public static ValueTask Initialize(IJSRuntime jsRuntime, string apiUrl, int siteId)
    {

        return jsRuntime.InvokeVoidAsync("MatomoProvider.initialize", apiUrl, siteId);
    }

    public static ValueTask TriggerPageChange(IJSRuntime jsRuntime, string userId, string referrerUrl, string url)
    {
        return jsRuntime.InvokeVoidAsync("MatomoProvider.triggerPageChange", userId, referrerUrl, url);
    }

    public static ValueTask ResetUserId(IJSRuntime jsRuntime)
    {
        return jsRuntime.InvokeVoidAsync("MatomoProvider.resetUserId");
    }
}
