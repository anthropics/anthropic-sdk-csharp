# Claude SDK for C#

[![NuGet Version](https://img.shields.io/nuget/v/Anthropic.svg)](https://www.nuget.org/packages/Anthropic)

> [!IMPORTANT]
> As of version 10+, the `Anthropic` package is now the official Claude SDK for C#. Package versions 3.X and below were previously used for the tryAGI community-built SDK, which has moved to [`tryAGI.Anthropic`](https://www.nuget.org/packages/tryagi.Anthropic/). If you need to continue using the former client in your project, update your package reference to `tryAGI.Anthropic`.

The Claude SDK for C# provides access to the [Claude API](https://docs.anthropic.com/en/api/) from C# applications.

## Documentation

Full documentation is available at **[platform.claude.com/docs/en/api/sdks/csharp](https://platform.claude.com/docs/en/api/sdks/csharp)**.

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
        new UserMessageParam("Hello, Claude")
    ],
    Model = Model.ClaudeOpus5_5,
};

var message = await client.Messages.Create(parameters);

Console.WriteLine(message);
```

## Requirements

.NET Standard 2.0+

## Contributing

See [CONTRIBUTING.md](./CONTRIBUTING.md).

## License

This project is licensed under the Apache License, Version 2.0. See the [LICENSE](LICENSE) file for details. Versions released before the change from the MIT License, and third-party contributions merged before it, remain under the MIT License. See [LICENSE-MIT](LICENSE-MIT).
