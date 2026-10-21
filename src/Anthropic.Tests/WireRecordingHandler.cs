using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Tests;

/// <summary>
/// A request as it went on the wire, copied because the original is disposed after sending.
/// </summary>
sealed class WireRequest
{
    public WireRequest(HttpMethod method, Uri uri, Dictionary<string, string> headers, string body)
    {
        Method = method;
        Uri = uri;
        Headers = headers;
        Body = body;
    }

    public HttpMethod Method { get; }

    public Uri Uri { get; }

    public Dictionary<string, string> Headers { get; }

    public string Body { get; }

    public JsonObject JsonBody => JsonNode.Parse(Body)!.AsObject();
}

/// <summary>
/// Records each request as it goes on the wire, then hands it to the gateway.
/// </summary>
sealed class WireRecordingHandler : DelegatingHandler
{
    public WireRecordingHandler(HttpMessageHandler gateway)
        : base(gateway) { }

    public List<WireRequest> Requests { get; } = [];

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var body =
            request.Content == null
                ? ""
                : await request.Content.ReadAsStringAsync(
#if NET
                    cancellationToken
#endif
                );
        Requests.Add(
            new(
                request.Method,
                request.RequestUri!,
                request.Headers.ToDictionary(
                    header => header.Key,
                    header => string.Join(",", header.Value),
                    StringComparer.OrdinalIgnoreCase
                ),
                body
            )
        );
        return await base.SendAsync(request, cancellationToken);
    }
}
