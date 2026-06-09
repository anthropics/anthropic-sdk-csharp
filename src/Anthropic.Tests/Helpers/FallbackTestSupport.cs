using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Helpers;

/// <summary>
/// A scripted terminal <see cref="HttpMessageHandler"/> for fallback-handler tests: returns the
/// queued responses in order while recording every request's URI, headers, and JSON body.
/// </summary>
sealed class FakeTransport : HttpMessageHandler
{
    readonly Queue<Func<Task<HttpResponseMessage>>> _responses = new();

    public List<Uri?> Uris { get; } = [];

    public List<List<KeyValuePair<string, string[]>>> RequestHeaders { get; } = [];

    public List<JsonObject> JsonBodies { get; } = [];

    /// <summary>Every request body verbatim, for asserting pass-through bytes.</summary>
    public List<string> RawBodies { get; } = [];

    /// <summary>Every response body stream handed out, for asserting disposal.</summary>
    public List<TrackedStream> Issued { get; } = [];

    public int RequestCount => Uris.Count;

    public IEnumerable<string?> Models =>
        JsonBodies.Select(body => body["model"]?.GetValue<string>());

    public string[] BetaHeaderValues(int index) =>
        [
            .. RequestHeaders[index]
                .Where(header =>
                    string.Equals(header.Key, "anthropic-beta", StringComparison.OrdinalIgnoreCase)
                )
                .SelectMany(header => header.Value),
        ];

    public FakeTransport Enqueue(Func<Task<HttpResponseMessage>> factory)
    {
        _responses.Enqueue(factory);
        return this;
    }

    public FakeTransport EnqueueSse(string body) =>
        Enqueue(() => Task.FromResult(Response(200, body, "text/event-stream")));

    public FakeTransport EnqueueJson(int status, string body) =>
        Enqueue(() => Task.FromResult(Response(status, body, "application/json")));

    public FakeTransport EnqueueFailure(Exception exception) => Enqueue(() => throw exception);

    public FakeTransport EnqueueStreaming(Stream body) =>
        Enqueue(() =>
        {
            StreamContent content = new(body);
            content.Headers.TryAddWithoutValidation("Content-Type", "text/event-stream");
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK) { Content = content }
            );
        });

    public HttpResponseMessage Response(int status, string body, string contentType)
    {
        TrackedStream stream = new(Encoding.UTF8.GetBytes(body));
        Issued.Add(stream);
        StreamContent content = new(stream);
        content.Headers.TryAddWithoutValidation("Content-Type", contentType);
        return new HttpResponseMessage((HttpStatusCode)status) { Content = content };
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        Uris.Add(request.RequestUri);
        RequestHeaders.Add(
            [
                .. request.Headers.Select(header => new KeyValuePair<string, string[]>(
                    header.Key,
                    [.. header.Value]
                )),
            ]
        );
        if (request.Content != null)
        {
            var body = await request.Content.ReadAsStringAsync(
#if NET
                cancellationToken
#endif
            );
            RawBodies.Add(body);
            if (JsonNode.Parse(body) is JsonObject jsonBody)
            {
                JsonBodies.Add(jsonBody);
            }
        }
        return await _responses.Dequeue()();
    }
}

/// <summary>A response body stream whose reads throw, recording disposal.</summary>
sealed class ThrowingStream : Stream
{
    public bool Disposed { get; private set; }

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => throw new NotSupportedException();
    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override void Flush() { }

    public override int Read(byte[] buffer, int offset, int count) =>
        throw new IOException("read failed");

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
        Disposed = true;
        base.Dispose(disposing);
    }
}

/// <summary>A response body stream that records whether it has been disposed.</summary>
sealed class TrackedStream : MemoryStream
{
    public TrackedStream(byte[] bytes)
        : base(bytes) { }

    public bool Disposed { get; private set; }

    protected override void Dispose(bool disposing)
    {
        Disposed = true;
        base.Dispose(disposing);
    }
}

/// <summary>
/// A blocking producer/consumer stream so a test can pace a streaming response body.
/// </summary>
sealed class ProducerStream : Stream
{
    readonly BlockingCollection<byte[]> _chunks = [];
    byte[] _current = [];
    int _position;

    public void Produce(string text) => _chunks.Add(Encoding.UTF8.GetBytes(text));

    public void Complete() => _chunks.CompleteAdding();

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => throw new NotSupportedException();
    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override void Flush() { }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (count == 0)
        {
            return 0;
        }
        while (_position >= _current.Length)
        {
            if (!_chunks.TryTake(out var next, Timeout.Infinite))
            {
                return 0;
            }
            _current = next;
            _position = 0;
        }
        var copied = Math.Min(count, _current.Length - _position);
        Array.Copy(_current, _position, buffer, offset, copied);
        _position += copied;
        return copied;
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();
}

static class FallbackTestSupport
{
    /// <summary>Serializes a typed content block for a replayed-history fixture.</summary>
    public static JsonNode Block(BetaContentBlockParam block) =>
        JsonSerializer.SerializeToNode(block, ModelBase.SerializerOptions)!;

    /// <summary>Loads an embedded SSE fixture from <c>Helpers/FableFallback/</c>.</summary>
    public static string Fixture(string name)
    {
        using var stream = typeof(FallbackTestSupport).Assembly.GetManifestResourceStream(
            $"Anthropic.Tests.Helpers.FableFallback.{name}"
        );
        using StreamReader reader = new(
            stream ?? throw new InvalidOperationException($"missing fixture {name}")
        );
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Captures everything the action writes to <see cref="Console.Error"/>. Tests using this
    /// must share the "console stderr" xunit collection so they don't race on the global writer.
    /// </summary>
    public static async Task<string> CaptureStderr(Func<Task> action)
    {
        var original = Console.Error;
        StringWriter writer = new();
        Console.SetError(writer);
        try
        {
            await action();
        }
        finally
        {
            Console.SetError(original);
        }
        return writer.ToString();
    }

    /// <summary>Splits an SSE body into its events' parsed JSON data payloads.</summary>
    public static List<JsonObject> ParseEvents(string sseBody) =>
        [
            .. sseBody
                .Split(["\n\n"], StringSplitOptions.RemoveEmptyEntries)
                .Select(chunk =>
                    string.Join(
                        "\n",
                        chunk
                            .Split('\n')
                            .Where(line => line.StartsWith("data:", StringComparison.Ordinal))
                            .Select(line => line.Substring("data:".Length).Trim())
                    )
                )
                .Where(data => data.Length > 0)
                .Select(data => JsonNode.Parse(data) as JsonObject)
                .OfType<JsonObject>(),
        ];
}
