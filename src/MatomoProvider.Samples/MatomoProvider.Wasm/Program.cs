using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MatomoProvider.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var matomoOptions = new MatomoOptions();
builder.Configuration
    .GetSection(MatomoOptions.Path)
    .Bind(matomoOptions);
builder.Services.AddSingleton(matomoOptions);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Logging.SetMinimumLevel(LogLevel.Trace);

await builder.Build().RunAsync();
