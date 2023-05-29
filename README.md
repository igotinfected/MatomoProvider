# MatomoProvider

<p align="center">
    <a href="https://www.nuget.org/packages/MatomoProvider/"><img alt="Nuget" src="https://img.shields.io/nuget/v/MatomoProvider?style=for-the-badge" /></a>
    <img alt="GitHub Workflow Status (with branch)" src="https://img.shields.io/github/actions/workflow/status/igotinfected/MatomoProvider/build-and-test.yml?branch=main&label=build%20%26%20test&style=for-the-badge" />
</p>

`MatomoProvider` is a Blazor component that registers and enables the [Matomo Analytics](https://matomo.org/) tracking code for you.

This component is based on [cmoissl's `Blazor.Matomo`](https://github.com/cmoissl/Blazor.Matomo) component but adapted to provide extra functionality, with a focus on Blazor WASM's SPA nature.

Some of the recommendations from [Matomo's SPA tracking documentation](https://developer.matomo.org/guides/spa-tracking) have been applied to allow proper page, page title, referrer URL, and user id tracking. Other features may follow.

More details in the [documentation](./src/MatomoProvider/README.md).

## Development

For ease of development, a docker image has been provided (`/tools/matomo`) that sets up a `mariadb` and a `matomo` instance.

After starting up this docker image, follow the setup instructions (at [http://localhost](http://localhost)), this should be limited to pressing "next" until asked to create an admin account.

Once the setup is complete no extra configuration needs to be made, the samples should work as-is.
