using System.Buffers;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Bedrock;

/// <summary>
/// Provides an Anthropic client implementation for AWS Bedrock integration.
/// </summary>
public sealed class AnthropicBedrockClient : AnthropicClient
{
    private const string ServiceName = "bedrock-runtime";

    private readonly IAnthropicBedrockCredentials _bedrockCredentials;
    private readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <summary>
    /// Creates a new Instance of the <see cref="AnthropicBedrockClient"/>.
    /// </summary>
    /// <param name="bedrockCredentials">The credential Provider used to authenticate with the AWS Bedrock service.</param>
    public AnthropicBedrockClient(IAnthropicBedrockCredentials bedrockCredentials)
        : base()
    {
        _bedrockCredentials = bedrockCredentials;
        BaseUrl = $"https://{ServiceName}.{_bedrockCredentials.Region}.amazonaws.com";
        _withRawResponse = new(() =>
            new AnthropicBedrockClientWithRawResponse(_bedrockCredentials, _options)
        );
    }

    private AnthropicBedrockClient(
        IAnthropicBedrockCredentials bedrockCredentials,
        ClientOptions clientOptions
    )
        : base(clientOptions)
    {
        _bedrockCredentials = bedrockCredentials;
        _withRawResponse = new(() =>
            new AnthropicBedrockClientWithRawResponse(_bedrockCredentials, _options)
        );
    }

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicBedrockClient(_bedrockCredentials, modifier(this._options));
    }

    public override IAnthropicClientWithRawResponse WithRawResponse => _withRawResponse.Value;
}

internal class AnthropicBedrockClientWithRawResponse : AnthropicClientWithRawResponse
{
    private readonly IAnthropicBedrockCredentials _credentials;
    private const string AnthropicVersion = "bedrock-2023-05-31";
    private const string HeaderAnthropicBeta = "anthropic-beta";

    /// <summary>
    /// The name of the header that identifies the content type for the "payloads" of AWS
    /// <i>EventStream</i> messages in streaming responses from Bedrock.
    /// </summary>
    private const string HeaderPayloadContentType = "x-amzn-bedrock-content-type";

    /// <summary>
    /// The content type for Bedrock responses containing data in the AWS <i>EventStream</i> format.
    /// The value of the <c>Content-Type</c> header identifies the content type of the
    /// "payloads" in this stream.
    /// </summary>
    private const string ContentTypeAwsEventStream = "application/vnd.amazon.eventstream";

    /// <summary>
    /// The content type for Anthropic responses containing Bedrock data after it has been
    /// translated into the Server-Sent Events (SSE) stream format.
    /// </summary>
    private const string ContentTypeSseStreamMediaType = "text/event-stream";

    public AnthropicBedrockClientWithRawResponse(
        IAnthropicBedrockCredentials credentials,
        ClientOptions clientOptions
    )
        : base(clientOptions)
    {
        _credentials = credentials;
    }

    /// <inheritdoc />
    public override IAnthropicClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AnthropicBedrockClientWithRawResponse(_credentials, modifier(this._options));
    }

    /// <inheritdoc />
    protected override async ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        ValidateRequest(requestMessage);

        if (requestMessage.Content is not null)
        {
            var bodyContent = JsonNode.Parse(
                await requestMessage.Content!.ReadAsStringAsync(
#if NET
                        cancellationToken
#endif
                ).ConfigureAwait(false)
            )!;

            var betaVersions = requestMessage.Headers.Contains(HeaderAnthropicBeta)
                ? requestMessage.Headers.GetValues(HeaderAnthropicBeta).Distinct().ToArray()
                : [];
            if (betaVersions is not { Length: 0 })
            {
                bodyContent["anthropic_beta"] = new JsonArray(
                    [.. betaVersions.Select(v => JsonValue.Create(v))]
                );
            }

            bodyContent["anthropic_version"] = JsonValue.Create(AnthropicVersion);

            var modelValue = bodyContent["model"]!;
            bodyContent.Root.AsObject().Remove("model");
            var parsedStreamValue = ((bool?)bodyContent["stream"]?.AsValue()) ?? false;
            bodyContent.Root.AsObject().Remove("stream");

            var contentStream = new MemoryStream();
            requestMessage.Content = new StreamContent(contentStream);
            using var writer = new Utf8JsonWriter(contentStream);
            {
                bodyContent.WriteTo(writer);
                await writer.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
            contentStream.Seek(0, SeekOrigin.Begin);
            requestMessage.Headers.TryAddWithoutValidation(
                "content-length",
                contentStream.Length.ToString()
            );
            var strUri =
                $"{requestMessage.RequestUri!.Scheme}://{requestMessage.RequestUri.Host}/model/{modelValue}/{(parsedStreamValue ? "invoke-with-response-stream" : "invoke")}";

#if NET6_0_OR_GREATER
            // The UriCreationOptions and DangerousDisablePathAndQueryCanonicalization were added in .NET 6 and allows
            // us to turn off the Uri behavior of canonicalizing Uri. For example if the resource path was "foo/../bar.txt"
            // the URI class will change the canonicalize path to bar.txt. This behavior of changing the Uri after the
            // request has been signed will trigger a signature mismatch error. It is valid especially for S3 for the resource
            // path to contain ".." segments.

            // as this is only available in net8 or greater we can only enable it there. NetStandard may not support those paths
            var uriCreationOptions = new UriCreationOptions()
            {
                DangerousDisablePathAndQueryCanonicalization = true,
            };

            requestMessage.RequestUri = new Uri(strUri, uriCreationOptions);
#else
            requestMessage.RequestUri = new Uri(strUri);
#endif

            requestMessage.Headers.TryAddWithoutValidation("Host", requestMessage.RequestUri.Host);
            requestMessage.Headers.TryAddWithoutValidation(
                "X-Amzn-Bedrock-Accept",
                "application/json"
            );
            requestMessage.Headers.TryAddWithoutValidation("content-type", "application/json");
            if (parsedStreamValue)
            {
                requestMessage.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip");
            }
        }

        await _credentials.Apply(requestMessage).ConfigureAwait(false);
    }

    private static void ValidateRequest(HttpRequestMessage requestMessage)
    {
        if (requestMessage.RequestUri is null)
        {
            throw new AnthropicInvalidDataException(
                "Request is missing required path segments. Expected > 1 segments found none."
            );
        }

        if (requestMessage.RequestUri.Segments.Length < 1)
        {
            throw new AnthropicInvalidDataException(
                "Request is missing required path segments. Expected at least 1 segment, found none."
            );
        }

        if (requestMessage.RequestUri.Segments[1].Trim('/') != "v1")
        {
            throw new AnthropicInvalidDataException(
                $"Request is missing required path segments. Expected [0] segment to be 'v1', found {requestMessage.RequestUri.Segments[0]}."
            );
        }

        if (
            requestMessage.RequestUri.Segments.Length >= 4
            && requestMessage.RequestUri.Segments[2].Trim('/') is "messages"
            && requestMessage.RequestUri.Segments[3].Trim('/') is "batches" or "count_tokens"
        )
        {
            throw new AnthropicInvalidDataException(
                $"The requested endpoint '{requestMessage.RequestUri.Segments[3].Trim('/')}' is not yet supported."
            );
        }
    }

    /// <inheritdoc />
    protected override async ValueTask AfterSend<T>(
        HttpRequest<T> request,
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken
    )
    {
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            return;
        }

        if (
            !string.Equals(
                httpResponseMessage.Content.Headers.ContentType?.MediaType,
                ContentTypeAwsEventStream,
                StringComparison.CurrentCultureIgnoreCase
            )
        )
        {
            return;
        }

        var headerPayloads = httpResponseMessage.Headers.GetValues(HeaderPayloadContentType);

        if (
            !headerPayloads.Any(f =>
                f.Equals("application/json", StringComparison.OrdinalIgnoreCase)
            )
        )
        {
            throw new AnthropicInvalidDataException(
                $"Expected streaming bedrock events to have content type of application/json but found {string.Join(", ", headerPayloads)}"
            );
        }

        // A decoded AWS EventStream message's payload is JSON. It might look like this (abridged):
        //
        //   {"bytes":"eyJ0eXBlIjoi...ZXJlIn19","p":"abcdefghijkl"}
        //
        // The value of the "bytes" field is a base-64 encoded JSON string (UTF-8). When decoded, it
        // might look like this:
        //
        //   {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello"}}
        //
        // Parse the "type" field to allow the construction of a server-sent event (SSE) that might
        // look like this:
        //
        //   event: content_block_delta
        //   data:
        // {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello"}}
        //
        // Print the SSE (with a blank line after) to the piped output stream to complete the
        // translation process.

        var originalStream = await httpResponseMessage
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);
        httpResponseMessage.Content = new SseEventContentWrapper(originalStream);

        httpResponseMessage.Content.Headers.ContentType = new(
#if NET
            ContentTypeSseStreamMediaType,
            "utf-8"
#else
            $"{ContentTypeSseStreamMediaType}; charset=utf-8"
#endif
        );
    }
}
