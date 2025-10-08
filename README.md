# Anthropic C# API Library

> [!NOTE]
> The Anthropic C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/anthropics/anthropic-sdk-csharp/issues/new).

The Anthropic C# SDK provides convenient access to the [Anthropic REST API](https://docs.anthropic.com/claude/reference/) from applications written in C#.

The REST API documentation can be found on [docs.anthropic.com](https://docs.anthropic.com/claude/reference/).

## Installation

```bash
git clone git@github.com:anthropics/anthropic-sdk-csharp.git
dotnet add reference anthropic-sdk-csharp/src/Anthropic.Client
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Anthropic.Client;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Models.Messages.MessageParamProperties;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();

MessageCreateParams parameters = new()
{
    MaxTokens = 1024,
    Messages =
    [
        new()
        {
            Role = Role.User,
            Content = new("Hello, Claude"),
        },
    ],
    Model = Model.Claude3_7SonnetLatest,
};

var message = await client.Messages.Create(parameters);

Console.WriteLine(message);
```

## Client Configuration

Configure the client using environment variables:

```csharp
using Anthropic.Client;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();
```

Or manually:

```csharp
using Anthropic.Client;

AnthropicClient client = new() { APIKey = "my-anthropic-api-key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property    | Environment variable   | Required | Default value                 |
| ----------- | ---------------------- | -------- | ----------------------------- |
| `APIKey`    | `ANTHROPIC_API_KEY`    | false    | -                             |
| `AuthToken` | `ANTHROPIC_AUTH_TOKEN` | false    | -                             |
| `BaseUrl`   | `ANTHROPIC_BASE_URL`   | true     | `"https://api.anthropic.com"` |

## Requests and responses

To send a request to the Anthropic API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Messages.Create` should be called with an instance of `MessageCreateParams`, and it will return an instance of `Task<Message>`.

## Streaming

The SDK defines methods that return response "chunk" streams, where each chunk can be individually processed as soon as it arrives instead of waiting on the full response. Streaming methods generally correspond to [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) or [JSONL](https://jsonlines.org) responses.

Some of these methods may have streaming and non-streaming variants, but a streaming method will always have a `Streaming` suffix in its name, even if it doesn't have a non-streaming variant.

These streaming methods return [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Models.Messages.MessageParamProperties;

MessageCreateParams parameters = new()
{
    MaxTokens = 1024,
    Messages =
    [
        new()
        {
            Role = Role.User,
            Content = new("Hello, Claude"),
        },
    ],
    Model = Model.Claude3_7SonnetLatest,
};

await foreach (var message in client.Messages.CreateStreaming(parameters))
{
    Console.WriteLine(message);
}
```

## Error handling

The SDK throws custom unchecked exception types:

- `AnthropicApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                |
| ------ | ---------------------------------------- |
| 400    | `AnthropicBadRequestException`           |
| 401    | `AnthropicUnauthorizedException`         |
| 403    | `AnthropicForbiddenException`            |
| 404    | `AnthropicNotFoundException`             |
| 422    | `AnthropicUnprocessableEntityException`  |
| 429    | `AnthropicRateLimitException`            |
| 5xx    | `Anthropic5xxException`                  |
| others | `AnthropicUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Anthropic4xxException`.

- `AnthropicSseException`: thrown for errors encountered during [SSE streaming](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) after a successful initial HTTP response.

- `AnthropicIOException`: I/O networking errors.

- `AnthropicInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `AnthropicException`: Base class for all exceptions.

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/anthropics/anthropic-sdk-csharp/issues) with questions, bugs, or suggestions.
