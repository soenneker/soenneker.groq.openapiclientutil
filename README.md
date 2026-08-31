[![](https://img.shields.io/nuget/v/soenneker.groq.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.groq.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclientutil/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.groq.openapiclientutil/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.groq.openapiclientutil/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.groq.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.openapiclientutil/)

# Soenneker.Groq.OpenApiClientUtil

Provides a lazily created Groq Kiota client over a shared, configured Groq `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.Groq.OpenApiClientUtil
```

## Configuration

```json
{
  "Groq": {
    "ApiKey": "gsk_...",
    "ClientBaseUrl": "https://api.groq.com",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

Only `ApiKey` is required. The other values show their defaults, and `{token}` is replaced with the API key.

## Registration

```csharp
using Soenneker.Groq.OpenApiClientUtil.Registrars;

services.AddGroqOpenApiClientUtilAsScoped();
```

The scoped registration is deliberate: each scope can release its generated-client utility while the singleton HTTP client remains available to later scopes. Use `AddGroqOpenApiClientUtilAsSingleton()` when the utility and generated client should also live for the application lifetime.

## Usage

```csharp
using Soenneker.Groq.OpenApiClient;
using Soenneker.Groq.OpenApiClient.Models;
using Soenneker.Groq.OpenApiClientUtil.Abstract;

GroqOpenApiClient client = await clientUtil.Get(cancellationToken);

ListModelsResponse? result = await client.Openai.V1.Models.GetAsync(
    cancellationToken: cancellationToken);
```

Repeated and concurrent `Get()` calls on the same utility reuse one lazily initialized generated client. Cancellation can stop first-time initialization; pass a cancellation token separately to each generated API operation.

Authentication is supplied by the underlying HTTP provider, so the Kiota adapter does not add a second authorization header.

Let the service container dispose the utility. Do not dispose the shared `HttpClient` returned by the lower-level HTTP-client provider.
