using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// Listens to the SDK's activity sources, its own and those of the platform packages, for the
/// length of a test, and collects the activities of the test's own trace: the test runs inside a
/// root activity, so activities that other tests emit at the same time are not collected.
/// </summary>
sealed class RecordedTrace : IDisposable
{
    internal const string SdkSourceName = "com.anthropic.sdk.csharp";

    /// <summary>
    /// Whether <paramref name="source"/> is the SDK's source, or that of a platform package, whose
    /// name is the SDK's and one more part.
    /// </summary>
    internal static bool IsSdkSource(ActivitySource source) =>
        source.Name == SdkSourceName
        || source.Name.StartsWith(SdkSourceName + ".", StringComparison.Ordinal);

    readonly ActivityListener _listener;
    readonly ConcurrentQueue<Activity> _stopped = new();

    public Activity Root { get; }

    public RecordedTrace()
    {
        _listener = new ActivityListener
        {
            ShouldListenTo = IsSdkSource,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => _stopped.Enqueue(activity),
        };
        ActivitySource.AddActivityListener(_listener);
        // A W3C root whatever the runtime's default ID format: .NET Framework defaults to the
        // hierarchical format, whose activities have no trace ID to collect the children by.
        Root = new Activity("test").SetIdFormat(ActivityIdFormat.W3C).Start();
    }

    /// <summary>
    /// The SDK activities of this trace that have stopped, in the order they stopped.
    /// </summary>
    public IReadOnlyList<Activity> Spans =>
        [.. _stopped.Where(a => a.TraceId == Root.TraceId && a != Root)];

    public Activity Single(string name) => Assert.Single(Spans, a => a.OperationName == name);

    public void Dispose()
    {
        Root.Stop();
        _listener.Dispose();
    }
}

/// <summary>
/// Answers requests from a queue of responses and records what was sent. The request headers are
/// copied when the request is sent, because the client disposes the request afterward.
/// </summary>
sealed class ScriptedHandler : HttpMessageHandler
{
    readonly ConcurrentQueue<Func<HttpRequestMessage, HttpResponseMessage>> _responses = new();

    public ConcurrentQueue<RecordedRequest> Requests { get; } = new();

    public ScriptedHandler Respond(Func<HttpRequestMessage, HttpResponseMessage> response)
    {
        _responses.Enqueue(response);
        return this;
    }

    public ScriptedHandler Respond(HttpStatusCode status, string body, string? requestID = null) =>
        Respond(_ => Response(status, body, requestID));

    public ScriptedHandler RespondJson(string body, string? requestID = "req_1") =>
        Respond(HttpStatusCode.OK, body, requestID);

    public ScriptedHandler RespondStream(string body) =>
        Respond(_ =>
        {
            var response = Response(HttpStatusCode.OK, body, "req_stream");
            response.Content.Headers.ContentType = new("text/event-stream");
            return response;
        });

    /// <summary>
    /// Answers with a stream whose connection drops after <paramref name="body"/>.
    /// </summary>
    public ScriptedHandler RespondTornStream(string body) =>
        Respond(_ =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new TornStream(Encoding.UTF8.GetBytes(body))),
            };
            response.Content.Headers.ContentType = new("text/event-stream");
            return response;
        });

    public ScriptedHandler Throw(Func<Exception> exception) =>
        Respond(new Func<HttpRequestMessage, HttpResponseMessage>(_ => throw exception()));

    public static HttpResponseMessage Response(
        HttpStatusCode status,
        string body,
        string? requestID
    )
    {
        var response = new HttpResponseMessage(status)
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json"),
        };
        if (requestID != null)
        {
            response.Headers.TryAddWithoutValidation("request-id", requestID);
            response.Headers.TryAddWithoutValidation("anthropic-organization-id", "org_1");
        }
        return response;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        Requests.Enqueue(RecordedRequest.From(request));
        if (!_responses.TryDequeue(out var response))
        {
            throw new InvalidOperationException("No scripted response left.");
        }
        return Task.FromResult(response(request));
    }
}

/// <summary>
/// A response body whose connection drops after <paramref name="prefix"/>: reads return the prefix,
/// then fail.
/// </summary>
sealed class TornStream(byte[] prefix) : Stream
{
    int _position;

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => throw new NotSupportedException();
    public override long Position
    {
        get => _position;
        set => throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (_position >= prefix.Length)
        {
            throw new IOException("connection reset");
        }
        var read = Math.Min(count, prefix.Length - _position);
        Array.Copy(prefix, _position, buffer, offset, read);
        _position += read;
        return read;
    }

    public override void Flush() { }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();
}

sealed class RecordedRequest
{
    public Uri? Uri { get; }
    public Dictionary<string, string> Headers { get; }

    RecordedRequest(Uri? uri, Dictionary<string, string> headers)
    {
        Uri = uri;
        Headers = headers;
    }

    public static RecordedRequest From(HttpRequestMessage request) =>
        new(
            request.RequestUri,
            request.Headers.ToDictionary(
                h => h.Key.ToLowerInvariant(),
                h => string.Join(",", h.Value),
                StringComparer.Ordinal
            )
        );

    public string? Header(string name) =>
        Headers.TryGetValue(name.ToLowerInvariant(), out var value) ? value : null;
}

static class Fixtures
{
    public const string BaseUrl = "https://api.example.test";

    public static AnthropicClient Client(
        ScriptedHandler handler,
        OpenTelemetryOptions? openTelemetry = null,
        int maxRetries = 2
    ) =>
        new()
        {
            HttpClient = new HttpClient(handler),
            BaseUrl = BaseUrl,
            ApiKey = "test-key",
            MaxRetries = maxRetries,
            OpenTelemetry = openTelemetry,
        };

    public const string MessageJson = """
        {
          "id": "msg_1",
          "type": "message",
          "role": "assistant",
          "model": "claude-test-20260101",
          "content": [
            {"type": "text", "text": "Hi there"},
            {"type": "tool_use", "id": "toolu_1", "name": "get_weather", "input": {"city": "Paris"}}
          ],
          "stop_reason": "end_turn",
          "stop_sequence": null,
          "usage": {
            "input_tokens": 10,
            "output_tokens": 5,
            "cache_creation_input_tokens": 2,
            "cache_read_input_tokens": 3,
            "cache_creation": {"ephemeral_5m_input_tokens": 2, "ephemeral_1h_input_tokens": 0},
            "service_tier": "standard",
            "output_tokens_details": {"thinking_tokens": 1}
          }
        }
        """;

    public const string ErrorJson = """
        {"type": "error", "error": {"type": "invalid_request_error", "message": "bad"}}
        """;

    public static string Sse(params (string Event, string Data)[] events)
    {
        var builder = new StringBuilder();
        foreach (var (name, data) in events)
        {
            builder.Append("event: ").Append(name).Append('\n');
            builder.Append("data: ").Append(data).Append("\n\n");
        }
        return builder.ToString();
    }

    public static readonly (string, string) MessageStart = (
        "message_start",
        """{"type":"message_start","message":{"id":"msg_s","type":"message","role":"assistant","model":"claude-test-20260101","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":7,"output_tokens":1,"cache_read_input_tokens":1,"cache_creation":{"ephemeral_5m_input_tokens":4,"ephemeral_1h_input_tokens":0},"service_tier":"priority"}}}"""
    );

    public static readonly (string, string)[] StreamBody =
    [
        MessageStart,
        (
            "content_block_start",
            """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello"}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":" world"}}"""
        ),
        ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
        (
            "content_block_start",
            """{"type":"content_block_start","index":1,"content_block":{"type":"tool_use","id":"toolu_9","name":"lookup","input":{}}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"{\"q\":"}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"\"x\"}"}}"""
        ),
        ("content_block_stop", """{"type":"content_block_stop","index":1}"""),
        (
            "content_block_start",
            """{"type":"content_block_start","index":2,"content_block":{"type":"thinking","thinking":"","signature":""}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":2,"delta":{"type":"thinking_delta","thinking":"Let me"}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":2,"delta":{"type":"thinking_delta","thinking":" think"}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":2,"delta":{"type":"signature_delta","signature":"sig_stream"}}"""
        ),
        ("content_block_stop", """{"type":"content_block_stop","index":2}"""),
        (
            "content_block_start",
            """{"type":"content_block_start","index":3,"content_block":{"type":"redacted_thinking","data":"enc_stream"}}"""
        ),
        ("content_block_stop", """{"type":"content_block_stop","index":3}"""),
        (
            "message_delta",
            """{"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":12}}"""
        ),
        ("message_stop", """{"type":"message_stop"}"""),
    ];
}
