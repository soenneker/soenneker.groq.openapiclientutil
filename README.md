[![](https://img.shields.io/nuget/v/soenneker.groq.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.groq.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.groq.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.openapiclientutil/)

# Soenneker.Groq.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Groq.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Groq.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddGroqOpenApiClientUtilAsSingleton();
```

Adds `GroqOpenApiClientUtil` as a singleton service.

## What you get

- `IGroqOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `GroqOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `GroqOpenApiClientUtilRegistrar.AddGroqOpenApiClientUtilAsSingleton(services)` | Adds `GroqOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `GroqOpenApiClientUtilRegistrar.AddGroqOpenApiClientUtilAsScoped(services)` | Adds `GroqOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
