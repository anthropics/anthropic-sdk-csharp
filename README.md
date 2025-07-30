# Anthropic C# API Library

> [!NOTE]
> The Anthropic C# API Library is currently in alpha.
>
> There may be frequent breaking changes.

The Anthropic C# SDK provides convenient access to the [Anthropic REST API](https://docs.anthropic.com/claude/reference/) from applications written in C#.

The REST API documentation can be found on [docs.anthropic.com](https://docs.anthropic.com/claude/reference/).

## Installation

### Dotnet

```bash
dotnet add reference /path/to/anthropic-csharp/src/Anthropic/
```

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```C#
using Anthropic;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.MessageParamProperties;
using System;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();

MessageCreateParams param = new()
{
  MaxTokens = 1024,
  Messages = [
    new()
    {
      Role = Role.User,
      Content = "Hello, Claude",
    }
  ],
  Model = Model.Claude3_7SonnetLatest
};

var message = await client.Messages.Create(param);

Console.WriteLine(message);
```

## Client Configuration

Configure the client using environment variables:

```C#
using Anthropic;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();
```

Or manually:

```C#
using Anthropic;

AnthropicClient client = new()
{
  APIKey = "my-anthropic-api-key", AuthToken = "my-auth-token"
};
```

Alternatively, you can use a combination of the two approaches.
