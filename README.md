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
using Anthropic = Anthropic;
using MessageParamProperties = Anthropic.Models.Messages.MessageParamProperties;
using Messages = Anthropic.Models.Messages;
using System = System;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
Anthropic::AnthropicClient client = new();

Messages::MessageCreateParams param = new()
{
  MaxTokens = 1024,
  Messages = [
    new()
    {
      Role = MessageParamProperties::Role.User,
      Content = "Hello, Claude",
    }
  ],
  Model = Messages::Model.Claude3_7SonnetLatest
};

var message = await client.Messages.Create(param);

System::Console.WriteLine(message);
```

## Client Configuration

Configure the client using environment variables:

```C#
using Anthropic = Anthropic;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
Anthropic::AnthropicClient client = new();
```

Or manually:

```C#
using Anthropic = Anthropic;

Anthropic::AnthropicClient client = new()
{
  APIKey = "my-anthropic-api-key", AuthToken = "my-auth-token"
};
```

Alternatively, you can use a combination of the two approaches.
