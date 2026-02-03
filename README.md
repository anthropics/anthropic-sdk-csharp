# Anthropic C# API Library

> **📦 Package Versioning Update**
>
> As of version 10+, the `Anthropic` package is now the **official Anthropic SDK for C#** (currently in beta).
>
> Package versions 3.X and below were previously used for the tryAGI community-built SDK, which has moved to [`tryAGI.Anthropic`](https://www.nuget.org/packages/tryagi.Anthropic/). If you need to continue using the former client in your project, please update your package reference to `tryAGI.Anthropic`.
>
> We're grateful to the maintainers of tryAGI.Anthropic for their work serving the Claude ecosystem and C# community.

---

> **ℹ️ Beta Release**
>
> The Anthropic C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> **Important:** While this package is versioned as 10.0+ due to the package transition described above, it should be treated as an early beta release. This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. **There may be breaking changes** as we continue development.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/anthropics/anthropic-sdk-csharp/issues/new).

The Anthropic C# SDK provides convenient access to the [Anthropic REST API](https://docs.anthropic.com/claude/reference/) from applications written in C#.

The REST API documentation can be found on [docs.anthropic.com](https://docs.anthropic.com/claude/reference/).

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/Anthropic):

```bash
dotnet add package Anthropic
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

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

## Client configuration

Configure the client using environment variables:

```csharp
using Anthropic;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();
```

Or manually:

```csharp
using Anthropic;

AnthropicClient client = new() { ApiKey = "my-anthropic-api-key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property    | Environment variable   | Required | Default value                 |
| ----------- | ---------------------- | -------- | ----------------------------- |
| `ApiKey`    | `ANTHROPIC_API_KEY`    | false    | -                             |
| `AuthToken` | `ANTHROPIC_AUTH_TOKEN` | false    | -                             |
| `BaseUrl`   | `ANTHROPIC_BASE_URL`   | true     | `"https://api.anthropic.com"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var message = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Messages.Create(parameters);

Console.WriteLine(message);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Anthropic API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Messages.Create` should be called with an instance of `MessageCreateParams`, and it will return an instance of `Task<Message>`.

> [!IMPORTANT]
> We highly encourage you to use [streaming](#streaming) for longer running requests.

We do not recommend setting a large `maxTokens` value without using streaming. Some networks may drop idle connections after a certain period of time, which can cause the request to fail or [timeout](#timeouts) without receiving a response from Anthropic. We periodically ping the API to keep the connection alive and reduce the impact of these networks.

The SDK throws an error if a non-streaming request is expected to take longer than 10 minutes. Using a [streaming method](#streaming) or [overriding the timeout](#timeouts) at the client or request level disables the error.

## Streaming

The SDK defines methods that return response "chunk" streams, where each chunk can be individually processed as soon as it arrives instead of waiting on the full response. Streaming methods generally correspond to [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) or [JSONL](https://jsonlines.org) responses.

Some of these methods may have streaming and non-streaming variants, but a streaming method will always have a `Streaming` suffix in its name, even if it doesn't have a non-streaming variant.

These streaming methods return [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;
using Anthropic.Models.Messages;

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

await foreach (var message in client.Messages.CreateStreaming(parameters))
{
    Console.WriteLine(message);
}
```

### Aggregators

Both the [Messages](src/Anthropic/Models/Messages/Message.cs) and [BetaMessages](src/Anthropic/Models/Beta/Messages/BetaMessage.cs) streaming endpoints have built-in aggregators that can produce the same object as its non-streaming counterparts.

It is possible to either only get the full result object via the `.Aggregate()` extension on the `IAsyncEnumerable` returned by the `CreateStreaming` method or insert an external aggregator into a LINQ tree:

```csharp
IAsyncEnumerable<RawMessageStreamEvent> responseUpdates = client.Messages.CreateStreaming(
    parameters
);

// This produces a single object based on the streaming output.
var message = await responseUpdates.Aggregate().ConfigureAwait(false);

// You can also add an aggregator as part of your LINQ chain to get realtime streaming and aggregation

var aggregator = new MessageContentAggregator();
await foreach (RawMessageStreamEvent rawEvent in responseUpdates.CollectAsync(aggregator))
{
    // Do something with the stream events
    if (rawEvent.TryPickContentBlockDelta(out var delta))
    {
        if (delta.Delta.TryPickThinking(out var thinkingDelta))
        {
            Console.Write(thinkingDelta.Thinking);
        }
        else if (delta.Delta.TryPickText(out var textDelta))
        {
            Console.Write(textDelta.Text);
        }
    }
}

// And then get the full aggregated message.
var fullMessage = await aggregator.Message();

```

## `IChatClient`

The SDK provides an implementation of the `IChatClient` interface from the `Microsoft.Extensions.AI.Abstractions` library.
This enables `AnthropicClient` (and `Anthropic.Services.IBetaService`) to be used with other libraries that integrate with
these core abstractions. For example, tools in the MCP C# SDK (`ModelContextProtocol`) library can be used directly with an `AnthropicClient`
exposed via `IChatClient`.

```csharp
using Anthropic;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
IChatClient chatClient = client.AsIChatClient("claude-haiku-4-5")
    .AsBuilder()
    .UseFunctionInvocation()
    .Build();

// Using McpClient from the MCP C# SDK
McpClient learningServer = await McpClient.CreateAsync(
    new HttpClientTransport(new() { Endpoint = new("https://learn.microsoft.com/api/mcp") }));

ChatOptions options = new() { Tools = [.. await learningServer.ListToolsAsync()] };

Console.WriteLine(await chatClient.GetResponseAsync("Tell me about IChatClient", options));
```

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

```csharp
using System;
using Anthropic.Models.Beta.Files;

FileDownloadParams parameters = new() { FileID = "file_id" };

var response = await client.Beta.Files.Download(parameters);

Console.WriteLine(response);
```

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Beta.Files.Download(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Messages.Create(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Anthropic.Models.Messages;

var response = await client.WithRawResponse.Messages.Create(parameters);
Message deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

For streaming responses, you can deserialize the response to an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1) if needed:

```csharp
using System;

var response = await client.WithRawResponse.Messages.CreateStreaming(parameters);
await foreach (var item in response.Enumerate())
{
    Console.WriteLine(item);
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

## Pagination

The SDK defines methods that return a paginated lists of results. It provides convenient ways to access the results either one page at a time or item-by-item across all pages.

### Auto-pagination

To iterate through all results across all pages, use the `Paginate` method, which automatically fetches more pages as needed. The method returns an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;

var page = await client.Beta.Messages.Batches.List(parameters);
await foreach (var item in page.Paginate())
{
    Console.WriteLine(item);
}
```

### Manual pagination

To access individual page items and manually request the next page, use the `Items` property, and `HasNext` and `Next` methods:

```csharp
using System;

var page = await client.Beta.Messages.Batches.List();
while (true)
{
    foreach (var item in page.Items)
    {
        Console.WriteLine(item);
    }
    if (!page.HasNext())
    {
        break;
    }
    page = await page.Next();
}
```

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Anthropic;

AnthropicClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var message = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Messages.Create(parameters);

Console.WriteLine(message);
```

### Timeouts

Requests time out after 10 minutes by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Anthropic;

AnthropicClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var message = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Messages.Create(parameters);

Console.WriteLine(message);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `AnthropicInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var message = client.Messages.Create(parameters);
message.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Anthropic;

AnthropicClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var message = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Messages.Create(parameters);

Console.WriteLine(message);
```

## Semantic versioning

> **⚠️ Beta Release:** While this package is versioned as 10+, it is currently in beta. During the beta period, breaking changes may occur in minor or patch releases. Once the library reaches stable release, we will follow SemVer conventions more strictly.

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/anthropics/anthropic-sdk-csharp/issues) with questions, bugs, or suggestions.
