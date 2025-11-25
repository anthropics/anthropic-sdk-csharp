using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Bedrock;

public class AnthropicBedrockClient : AnthropicClient
{
    private const string ServiceName = "bedrock-runtime";
    private const string AnthropicVersion = "bedrock-2023-05-31";
    private const string HEADER_ANTHROPIC_BETA = "anthropic-beta";

    /// <summary>
    /// The name of the header that identifies the content type for the "payloads" of AWS
    /// _EventStream_ messages in streaming responses from Bedrock.
    /// </summary>
    private const string HEADER_PAYLOAD_CONTENT_TYPE = "x-amzn-bedrock-content-type";

    /// <summary>
    /// The content type for Bedrock responses containing data in the AWS _EventStream_ format.
    /// The value of the[HEADER_PAYLOAD_CONTENT_TYPE] header identifies the content type of the
    /// "payloads" in this stream.
    /// </summary>
    private const string CONTENT_TYPE_AWS_EVENT_STREAM = "application/vnd.amazon.eventstream";

    /// <summary>
    /// The content type for Anthropic responses containing Bedrock data after it has been
    /// translated into the Server-Sent Events (SSE) stream format.
    /// </summary>
    private const string CONTENT_TYPE_SSE_STREAM = "text/event-stream; charset=utf-8";

    private readonly IAnthropicBedrockCredentials _bedrockCredentials;

    /// <summary>
    /// Creates a new Instance of the <see cref="AnthropicBedrockClient"/>.
    /// </summary>
    /// <param name="bedrockCredentials">The credential Provider used to authenticate with the AWS Bedrock service.</param>
    public AnthropicBedrockClient(IAnthropicBedrockCredentials bedrockCredentials) : base()
    {
        _bedrockCredentials = bedrockCredentials ?? throw new ArgumentNullException(nameof(bedrockCredentials));
        BaseUrl = new Uri($"https://{ServiceName}.{_bedrockCredentials.Region}.amazonaws.com");
    }

    private AnthropicBedrockClient(IAnthropicBedrockCredentials bedrockCredentials, ClientOptions clientOptions) : base(clientOptions)
    {
        _bedrockCredentials = bedrockCredentials;
    }

    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicBedrockClient(_bedrockCredentials, modifier(this._options));
    }

    protected override async ValueTask BeforeSend<T>(HttpRequest<T> request, HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        ValidateRequest(requestMessage);

        requestMessage.Headers.TryAddWithoutValidation("anthropic_version", AnthropicVersion);

        var bodyContent = JsonNode.Parse(await requestMessage.Content!.ReadAsStringAsync().ConfigureAwait(false));

        if (bodyContent?["model"] == null)
        {
            throw new AnthropicInvalidDataException("Expected to find property model in request json but found none.");
        }

        var betaVersions = requestMessage.Headers.GetValues(HEADER_ANTHROPIC_BETA).Distinct().ToArray();
        if (betaVersions is not { Length: 0 })
        {
            bodyContent["anthropic_beta"] = new JsonArray(betaVersions.Select(v => JsonValue.Create(v)).ToArray());
        }

        var modelValue = bodyContent["model"];

        if (modelValue is null)
        {
            throw new AnthropicInvalidDataException("Expected to find property model in request json but found none.");
        }

        bodyContent["model"] = null;
        var parsedStreamValue = ((bool?)bodyContent["stream"]?.AsValue()) ?? false;

        var contentStream = new MemoryStream();
        requestMessage.Content = new StreamContent(contentStream);
        using var writer = new Utf8JsonWriter(contentStream);
        {
            bodyContent.WriteTo(writer);
        }

        var uriBuilder = new UriBuilder(requestMessage.RequestUri);
        uriBuilder.Path = string.Join('/', [.. uriBuilder.Path.Split("/").Select(e => e == "model" ? modelValue.ToString() : e), (parsedStreamValue ? "invoke-with-response-stream" : "invoke")]);

        requestMessage.RequestUri = uriBuilder.Uri;
        requestMessage.Headers.TryAddWithoutValidation("Host", uriBuilder.Uri.Host);

        _bedrockCredentials.Apply(requestMessage);
    }

    private static void ValidateRequest(HttpRequestMessage requestMessage)
    {
        if (requestMessage.RequestUri is null)
        {
            throw new AnthropicInvalidDataException("Request is missing required path segments. Expected > 1 segments found none.");
        }

        if (requestMessage.RequestUri.Segments.Length < 1)
        {
            throw new AnthropicInvalidDataException("Request is missing required path segments. Expected > 1 segments found none.");
        }

        if (requestMessage.RequestUri.Segments[0] != "v1")
        {
            throw new AnthropicInvalidDataException($"Request is missing required path segments. Expected [0] segment to be 'v1' found {requestMessage.RequestUri.Segments[0]}.");
        }

        if (requestMessage.RequestUri.Segments[1] is "messages" && requestMessage.RequestUri.Segments[2] is "batches" or "count_tokens")
        {
            throw new AnthropicInvalidDataException($"The requested endpoint '{requestMessage.RequestUri.Segments[2]}' is not yet supported.");
        }
    }

    protected override async ValueTask AfterSend<T>(HttpRequest<T> request, HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken)
    {
        if (!httpResponseMessage.Headers.GetValues("content-type").Any(f => string.Equals(f, CONTENT_TYPE_AWS_EVENT_STREAM, StringComparison.CurrentCultureIgnoreCase)))
        {
            return;
        }

        var headerPayloads = httpResponseMessage.Headers.GetValues(HEADER_PAYLOAD_CONTENT_TYPE);

        if (!headerPayloads.Any(f => f.Equals("application/json", StringComparison.OrdinalIgnoreCase)))
        {
            throw new AnthropicInvalidDataException($"Expected streaming bedrock events to have content type of application/json but found {string.Join(", ", headerPayloads)}");
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

        var originalStream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
        httpResponseMessage.Content = new SseEventContentWrapper(originalStream);
        httpResponseMessage.Headers.Remove("Content-Type");
        httpResponseMessage.Headers.TryAddWithoutValidation("Content-Type", CONTENT_TYPE_SSE_STREAM);
    }

    private class SseEventContentWrapper : HttpContent
    {
        private Stream _originalStream;

        public SseEventContentWrapper(Stream originalStream)
        {
            _originalStream = originalStream;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            var nodeOptions = new JsonNodeOptions();
            var documentOption = new JsonDocumentOptions();
            var eventBuilder = new StringBuilder();

            using var streamReader = new StreamReader(_originalStream, true);
            while (!streamReader.EndOfStream)
            {
                var line = await streamReader.ReadLineAsync().ConfigureAwait(false);
                if (line is null)
                {
                    continue;
                }

                var eventLine = JsonNode.Parse(line, nodeOptions, documentOption);
                var eventContents = eventLine?["bytes"]?.AsValue().GetValue<string>();
                if (string.IsNullOrWhiteSpace(eventContents))
                {
                    continue;
                }

                var parsedEvent = JsonNode.Parse(Convert.FromBase64String(eventContents), nodeOptions, documentOption);
                if (parsedEvent is null)
                {
                    continue;
                }

                eventBuilder.AppendLine($"event: {parsedEvent["type"]}\ndata: {parsedEvent}");

                await stream.WriteAsync(Encoding.UTF8.GetBytes(eventBuilder.ToString())).ConfigureAwait(false);
                eventBuilder.Clear();
            }
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            _originalStream.Dispose();
            base.Dispose(disposing);
        }
    }
}
