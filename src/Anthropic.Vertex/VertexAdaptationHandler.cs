using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Vertex;

/// <summary>
/// Adapts requests for Google Vertex AI: rewrites the Anthropic-shaped URL and body
/// into Vertex's wire shape and applies the Vertex credentials.
///
/// <para>Attached as the innermost handler so user handlers observe Anthropic-shaped
/// requests regardless of backend.</para>
/// </summary>
internal sealed class VertexAdaptationHandler : DelegatingHandler
{
    private const string HEADER_ANTHROPIC_VERSION = "anthropic-version";

    private readonly IAnthropicVertexCredentials _vertexCredentials;

    public VertexAdaptationHandler(IAnthropicVertexCredentials vertexCredentials)
    {
        _vertexCredentials = vertexCredentials;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        await AdaptRequest(requestMessage, cancellationToken).ConfigureAwait(false);
        return await base.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
    }

    private async Task AdaptRequest(
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

        // Vertex takes the API version from the body. A caller's value follows the SDK's own.
        if (requestMessage.Headers.TryGetValues(HEADER_ANTHROPIC_VERSION, out var values))
        {
            bodyContent["anthropic_version"] = JsonValue.Create(values.Last());
            requestMessage.Headers.Remove(HEADER_ANTHROPIC_VERSION);
        }

        var modelValue =
            bodyContent["model"]
            ?? throw new AnthropicInvalidDataException(
                "Expected to find property model in request json but found none."
            );

        bodyContent.Root.AsObject().Remove("model");
        var parsedStreamValue = ((bool?)bodyContent["stream"]?.AsValue()) ?? false;

        var contentStream = new MemoryStream();
        requestMessage.Content = new StreamContent(contentStream);
        requestMessage.Content.Headers.ContentType = new("application/json");
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

        var project = ParamsBase.EncodePathSegment(_vertexCredentials.Project, "project");
        var region = ParamsBase.EncodePathSegment(_vertexCredentials.Region, "region");
        var requestBuilder = new StringBuilder(
            $"{requestMessage.RequestUri!.Scheme}://{requestMessage.RequestUri.Authority}/v1/projects/{project}/locations/{region}/publishers/anthropic/models/"
        );
        if (isCountEndpoint)
        {
            requestBuilder.Append("count-tokens:rawPredict");
        }
        else
        {
            var rawModel = modelValue.AsValue().ToString();
            // Some servers drop ";" and what follows it from a segment before they route the request, so the
            // part before it can't be empty, "." or "..". With no ";", the specifier keeps "." and ".." from
            // being dot-segments.
            if (rawModel == "" || rawModel[0] == ';')
            {
                throw new AnthropicInvalidDataException("Expected a non-empty value for `model`");
            }
            if (
                rawModel.StartsWith(".;", StringComparison.Ordinal)
                || rawModel.StartsWith("..;", StringComparison.Ordinal)
            )
            {
                throw new AnthropicInvalidDataException(
                    $"'model' value \"{rawModel}\" is a dot-segment and can't be safely passed as a path parameter"
                );
            }
            // "@" and ":" are valid in a path segment as they are, and Vertex model IDs contain "@".
            // ";" stays escaped, because such a server would drop the specifier along with it.
            var model = Uri.EscapeDataString(rawModel).Replace("%40", "@").Replace("%3A", ":");
            requestBuilder.Append(
                $"{model}:{(parsedStreamValue ? "streamRawPredict" : "rawPredict")}"
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

        if (
            requestMessage.RequestUri.Segments.Length >= 3
            && requestMessage.RequestUri.Segments[2].Trim('/') is "user_profiles"
        )
        {
            throw new NotSupportedException(
                "The UserProfiles resource is not supported on Vertex."
            );
        }

        isCountEndpoint =
            requestMessage.RequestUri.Segments.Length >= 4
            && requestMessage.RequestUri.Segments[2].Trim('/') is "messages"
            && requestMessage.RequestUri.Segments[3].Trim('/') is "count_tokens";
    }
}
