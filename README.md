# MatomoProvider

`MatomoProvider` is a Blazor component that registers and enables the [Matomo Analytics](https://matomo.org/) tracking code for you.

This component is based on [cmoissl's `Blazor.Matomo`](https://github.com/cmoissl/Blazor.Matomo) component but adapted to provide extra functionality, with a focus on Blazor WASM's SPA nature.

Some of the recommendations from [Matomo's SPA tracking documentation](https://developer.matomo.org/guides/spa-tracking) has been applied to allow proper page, page title, referrer URL, and user id tracking. Other features may follow.

## Usage

TODO: add nuget

### Registering the component

The recommended way to use `MatomoProvider` is to add it to the bottom of your `App.razor` file:

```diff
 <Router AppAssembly="@typeof(App).Assembly">
     ...
 </Router>

+@* Register matomo provider application-wide *@
+<MatomoProvider ApiUrl="@_matomoOptions.ApiUrl"
+                SiteId="@_matomoOptions.SiteId"
+                UserIdFunc="async () => await Task.FromResult(Guid.NewGuid().ToString())" />

 @code {
 
     [Inject]
     private MatomoOptions _matomoOptions { get; set; } = default!;
 
 }
```

You must provide:

- `ApiUrl`: the endpoint at which your Matomo instance is hosted
- `SiteId`: your Matomo website id

You may provide:

- `UserIdFunc`: a function returning the user id to set for the current user

### Adding the script reference

`MatomoProvider` comes bundled with a Javascript file which needs to be added as a script reference in `wwwroot/index.html` for Blazor WASM and `Pages/_Host.cshtml` for Blazor Server:

```diff
<body>
    ...

    <script src="_framework/blazor.server.js"></script>
+   <script src="_content/MatomoProvider/matomo-provider.js"></script>
</body>
```

## Development

For ease of development, a docker image has been provided (`/tools/matomo`) that sets up a `mariadb` and a `matomo` instance.

After starting up this docker image, follow the setup instructions (at http://localhost), this should be limited to pressing "next" until asked to create an admin account.

Once the setup is complete no extra configuration needs to be made, the samples should work as-is.
