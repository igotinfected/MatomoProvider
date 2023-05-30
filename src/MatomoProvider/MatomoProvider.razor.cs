using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace MatomoProvider;

public partial class MatomoProvider : ComponentBase, IDisposable
{
    [CascadingParameter]
    private Task<AuthenticationState>? _authenticationStateTask { get; set; }

    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;

    [Inject]
    private ILogger<MatomoProvider> _logger { get; set; } = default!;

    [Inject]
    private NavigationManager _navigationManager { get; set; } = default!;

    [Parameter, EditorRequired]
    public string ApiUrl { get; set; } = null!;

    [Parameter, EditorRequired]
    public int SiteId { get; set; }

    [Parameter]
    public Func<Task<string>>? UserIdFunc { get; set; }

    private string _referrerUrl = string.Empty;

    public void Dispose()
    {
        _navigationManager.LocationChanged -= OnLocationChanged;
        GC.SuppressFinalize(this);
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _navigationManager.LocationChanged -= OnLocationChanged;
        _navigationManager.LocationChanged += OnLocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MatomoProviderJs.Initialize(_jsRuntime, ApiUrl, SiteId);
        }
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs args)
    {
        try
        {
            var userId = string.Empty;

            if (UserIdFunc is not null)
            {
                userId = await UserIdFunc();
            }

            await MatomoProviderJs.TriggerPageChange(_jsRuntime, userId, _referrerUrl, args.Location);
        }
        catch (Exception exception)
        {
            _logger.LogWarning(exception, "An error occurred while triggering a page change");
        }
        finally
        {
            _referrerUrl = args.Location;
        }
    }
}
