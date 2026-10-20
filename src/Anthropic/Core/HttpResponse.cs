using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Exceptions;
using Threading = System.Threading;

namespace Anthropic.Core;

public class HttpResponse : IDisposable
{
    public required HttpResponseMessage RawMessage { get; init; }

    public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers
    {
        get { return RawMessage.Headers; }
    }

    public bool IsSuccessStatusCode
    {
        get { return RawMessage.IsSuccessStatusCode; }
    }

    public HttpStatusCode StatusCode
    {
        get { return RawMessage.StatusCode; }
    }

    public Threading::CancellationToken CancellationToken { get; init; } = default;

    /// <summary>
    /// The call span of the API call that returned this response, when it has one: reading the
    /// response, or disposing of it, ends the span.
    /// </summary>
    internal Activity? Span { get; set; }

    /// <summary>
    /// Whether the body is a stream, which the application reads item by item or not at all.
    /// </summary>
    internal virtual bool IsStream => false;

    /// <summary>
    /// Returns the value of the <c>request-id</c> header,
    /// or null if there's no such header in the response.
    /// </summary>
    public string? RequestID
    {
        get
        {
            return RawMessage.Headers.TryGetValues("request-id", out var value)
                ? Enumerable.FirstOrDefault(value)
                : null;
        }
    }

    /// <summary>
    /// Returns the value of the <c>anthropic-workspace-id</c> header,
    /// or null if there's no such header in the response.
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            return RawMessage.Headers.TryGetValues("anthropic-workspace-id", out var value)
                ? Enumerable.FirstOrDefault(value)
                : null;
        }
    }

    public IEnumerable<string> GetHeaderValues(string name) => RawMessage.Headers.GetValues(name);

    public bool TryGetHeaderValues(
        string name,
        [NotNullWhen(true)] out IEnumerable<string>? values
    ) => RawMessage.Headers.TryGetValues(name, out values);

    public sealed override string ToString() => this.RawMessage.ToString();

    public override bool Equals(object? obj)
    {
        if (obj is not HttpResponse other)
        {
            return false;
        }

        return this.RawMessage.Equals(other.RawMessage);
    }

    public override int GetHashCode() => this.RawMessage.GetHashCode();

    public async Task<T> Deserialize<T>(Threading::CancellationToken cancellationToken = default)
    {
        return await this.DeserializeNullable<T>(cancellationToken).ConfigureAwait(false)
            ?? throw new AnthropicInvalidDataException("Response cannot be null");
    }

    internal async Task<T?> DeserializeNullable<T>(
        Threading::CancellationToken cancellationToken = default
    )
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        try
        {
            return await JsonSerializer
                .DeserializeAsync<T>(
                    await this.ReadAsStream(cts.Token).ConfigureAwait(false),
                    ModelBase.SerializerOptions,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new AnthropicIOException("I/O Exception", e);
        }
    }

    public async Task<Stream> ReadAsStream(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return await RawMessage.Content.ReadAsStreamAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public async Task<string> ReadAsString(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return await RawMessage.Content.ReadAsStringAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public void Dispose()
    {
        if (this.Span is { } span)
        {
            // The application is done with the response, so this ends the call unless reading it
            // did: a body counts as read, and a stream as stopped early.
            if (this.IsStream)
            {
                Tracing.EndApiCallSpanOfUnreadStream(span);
            }
            else
            {
                Tracing.EndApiCallSpan(span);
            }
        }
        this.RawMessage.Dispose();
        GC.SuppressFinalize(this);
    }
}

public sealed class HttpResponse<T> : HttpResponse
{
    readonly Func<Threading::CancellationToken, Task<T>> _deserialize;

    internal HttpResponse(Func<Threading::CancellationToken, Task<T>> deserialize)
    {
        this._deserialize = deserialize;
    }

    [SetsRequiredMembers]
    internal HttpResponse(
        HttpResponse response,
        Func<Threading::CancellationToken, Task<T>> deserialize
    )
        : this(deserialize)
    {
        this.RawMessage = response.RawMessage;
        this.CancellationToken = response.CancellationToken;
        this.Span = response.Span;
    }

    public async Task<T> Deserialize(Threading::CancellationToken cancellationToken = default)
    {
        // Awaited rather than returned: the linked source has to outlive the read, or the tokens
        // it links stop reaching the read as soon as this method returns.
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        if (this.Span is not { } span)
        {
            return await this._deserialize(cts.Token).ConfigureAwait(false);
        }
        // The call ends when its value has been read.
        T value;
        try
        {
            value = await this._deserialize(cts.Token).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Tracing.EndApiCallSpan(span, e, cts.Token);
            throw;
        }
        Tracing.EndApiCallSpan(span);
        return value;
    }
}

public sealed class StreamingHttpResponse<T> : HttpResponse
{
    readonly Func<Threading::CancellationToken, IAsyncEnumerable<T>> _enumerate;

    /// <inheritdoc/>
    internal override bool IsStream => true;

    /// <summary>
    /// For a stream that has an end event, whether the items read so far include it. The SDK
    /// method that makes the stream sets it.
    /// </summary>
    internal Func<bool>? HasReadEndEvent { get; init; }

    internal StreamingHttpResponse(
        Func<Threading::CancellationToken, IAsyncEnumerable<T>> enumerate
    )
    {
        this._enumerate = enumerate;
    }

    [SetsRequiredMembers]
    internal StreamingHttpResponse(
        HttpResponse response,
        Func<Threading::CancellationToken, IAsyncEnumerable<T>> enumerate
    )
        : this(enumerate)
    {
        this.RawMessage = response.RawMessage;
        this.CancellationToken = response.CancellationToken;
        this.Span = response.Span;
    }

    public async IAsyncEnumerable<T> Enumerate(
        [EnumeratorCancellationAttribute] Threading::CancellationToken cancellationToken = default
    )
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        var items = this._enumerate(cts.Token);
        if (this.Span is { } span)
        {
            items = Tracing.EndApiCallSpanWhenStreamEnds(
                span,
                items,
                this.RawMessage,
                this.HasReadEndEvent,
                cts.Token
            );
        }
        await foreach (var item in items)
        {
            yield return item;
        }
    }
}
