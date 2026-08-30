[![](https://img.shields.io/nuget/v/soenneker.adyen.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.adyen.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.adyen.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.adyen.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.adyen.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.adyen.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.adyen.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.adyen.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Adyen.OpenApiClient

A Kiota-generated .NET client containing request builders and models for Adyen APIs.

## Installation

```bash
dotnet add package Soenneker.Adyen.OpenApiClient
```

## Creating the client

`AdyenOpenApiClient` requires a configured Kiota `IRequestAdapter`:

```csharp
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Abstractions.Authentication;
using Soenneker.Adyen.OpenApiClient;

httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
var authentication = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authentication, httpClient: httpClient);
var client = new AdyenOpenApiClient(adapter);
```

Configure the adapter's `HttpClient`, base address, and authentication for the particular Adyen API and environment you are using.

For dependency-injection setup and cached client creation, use [`Soenneker.Adyen.OpenApiClientUtil`](https://www.nuget.org/packages/Soenneker.Adyen.OpenApiClientUtil) instead.

## Usage

The top-level client exposes versioned service request builders. Select the service, then follow its generated resource hierarchy:

```csharp
using Soenneker.Adyen.OpenApiClient.Models;

PaymentMethodsResponse? response = await client
    .CheckoutServiceV72
    .PaymentMethods
    .PostAsync(requestBody, cancellationToken: cancellationToken);
```

Request and response types are in `Soenneker.Adyen.OpenApiClient.Models`. Generated methods expose Kiota request configuration for headers, query parameters, and middleware options where the operation supports them.

## Important behavior

- The client combines multiple Adyen service schemas, so service versions are part of property and model names.
- The generated default base URL belongs to one test endpoint and cannot represent every Adyen service or environment. Supply the correct base address through the request adapter or the companion utility's HTTP-client configuration.
- Kiota throws `ApiException` for mapped non-success responses. Inspect its status code and response headers rather than treating all failures as transport errors.
- The source is generated. Put authentication, retries, logging, and other cross-cutting behavior in the request adapter or HTTP pipeline instead of modifying generated request builders.
