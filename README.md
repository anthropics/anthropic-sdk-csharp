# Anthropic C# API Library

[![NuGet Version](https://img.shields.io/nuget/v/Anthropic.svg)](https://www.nuget.org/packages/Anthropic)

> [!IMPORTANT]
> As of version 10+, the `Anthropic` package is now the official Anthropic SDK for C#. Package versions 3.X and below were previously used for the tryAGI community-built SDK, which has moved to [`tryAGI.Anthropic`](https://www.nuget.org/packages/tryagi.Anthropic/). If you need to continue using the former client in your project, update your package reference to `tryAGI.Anthropic`.

> [!NOTE]
> The Anthropic C# API Library is currently in beta. We'd love your feedback — please share suggestions, bug reports, or feature requests by [filing an issue](https://www.github.com/anthropics/anthropic-sdk-csharp/issues/new).

The Anthropic C# library provides access to the [Anthropic API](https://docs.anthropic.com/en/api/) from C# applications.

## Documentation

Full documentation is available at **[docs.anthropic.com/en/api/sdks/csharp](https://docs.anthropic.com/en/api/sdks/csharp)**.

## Installation

```bash
dotnet add package Anthropic
```

## Getting started

```csharp
using System;
using Anthropic;
using Anthropic.Models.Messages;

AnthropicClient client = new();

MessageCreateParams parameters = new()
{
    MaxTokens = 1024,
    Messages =
    [
        new()
        {
            Role = Role.User,
            Content = "Hello, Claude",
        },
    ],
    Model = Model.ClaudeSonnet4_5_20250929,
};

var message = await client.Messages.Create(parameters);

Console.WriteLine(message);
```

## Requirements

.NET Standard 2.0+

## Contributing

See [CONTRIBUTING.md](./CONTRIBUTING.md).

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
