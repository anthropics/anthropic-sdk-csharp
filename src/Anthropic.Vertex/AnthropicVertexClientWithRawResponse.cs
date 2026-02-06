using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Vertex;

internal class AnthropicVertexClientWithRawResponse : AnthropicClientWithRawResponse
{
    private const string ANTHROPIC_VERSION = "vertex-2023-10-16";

    private readonly IAnthropicVertexCredentials _vertexCredentials;

    /// <summary>
    /// Creates a new Instance of the <see cref="AnthropicVertexClientWithRawResponse"/>.
    /// </summary>
    /// <param name="vertexCredentials">The credential Provider used to authenticate with the AWS Bedrock service.</param>
    public AnthropicVertexClientWithRawResponse(
        IAnthropicVertexCredentials vertexCredentials,
        ClientOptions options
    )
        : base(options)
    {
        _vertexCredentials = vertexCredentials;
    }

    public override IAnthropicClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AnthropicVertexClientWithRawResponse(_vertexCredentials, modifier(_options));
    }

    protected override async ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        ValidateRequest(requestMessage, out var isCountEndpoint);

        var bodyContent = JsonNode.Parse(
            await requestMessage.Content!.ReadAsStringAsync(
#if NET
                cancellationToken
#endif
            ).ConfigureAwait(false)
        )!;

        bodyContent["anthropic_version"] = JsonValue.Create(ANTHROPIC_VERSION);

        var modelValue =
            bodyContent["model"]
            ?? throw new AnthropicInvalidDataException(
                "Expected to find property model in request json but found none."
            );

        bodyContent.Root.AsObject().Remove("model");
        var parsedStreamValue = ((bool?)bodyContent["stream"]?.AsValue()) ?? false;

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

        var requestBuilder = new StringBuilder(
            $"{requestMessage.RequestUri!.Scheme}://{requestMessage.RequestUri.Host}/v1/projects/{_vertexCredentials.Project}/locations/{_vertexCredentials.Region}/publishers/anthropic/models/"
        );
        if (isCountEndpoint)
        {
            requestBuilder.Append("count-tokens:rawPredict");
        }
        else
        {
            requestBuilder.Append(
                $"{modelValue.AsValue()}:{(parsedStreamValue ? "streamRawPredict" : "rawPredict")}"
            );
        }

        requestMessage.RequestUri = new Uri(requestBuilder.ToString());

        await _vertexCredentials.ApplyAsync(requestMessage).ConfigureAwait(false);
    }

    private static void ValidateRequest(HttpRequestMessage requestMessage, out bool isCountEndpoint)
    {
        if (requestMessage.RequestUri is null)
        {
            throw new AnthropicInvalidDataException(
                "Request is missing required path segments. Expected > 1 segments, found none."
            );
        }

        if (requestMessage.RequestUri.Segments.Length < 1)
        {
            throw new AnthropicInvalidDataException(
                "Request is missing required path segments. Expected > 1 segments, found none."
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
                $"The requested endpoint '{requestMessage.RequestUri.Segments.Last().Trim('/')}' is not yet supported."
            );
        }

        isCountEndpoint =
            requestMessage.RequestUri.Segments.Length >= 4
            && requestMessage.RequestUri.Segments[2].Trim('/') is "messages"
            && requestMessage.RequestUri.Segments[3].Trim('/') is "count_tokens";
    }
}
