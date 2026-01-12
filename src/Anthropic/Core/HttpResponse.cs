using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Exceptions;
using Threading = System.Threading;

namespace Anthropic.Core;

public class HttpResponse : IDisposable
{
    public required HttpResponseMessage Message { get; init; }

    public Threading::CancellationToken CancellationToken { get; init; } = default;

    public async Task<T> Deserialize<T>(Threading::CancellationToken cancellationToken = default)
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
                    .ConfigureAwait(false)
                ?? throw new AnthropicInvalidDataException("Response cannot be null");
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
        return await Message.Content.ReadAsStreamAsync(
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
        return await Message.Content.ReadAsStringAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public void Dispose()
    {
        this.Message.Dispose();
        GC.SuppressFinalize(this);
    }
}

public sealed class HttpResponse<T> : global::Anthropic.Core.HttpResponse
{
    readonly Func<Threading::CancellationToken, Task<T>> _deserialize;

    internal HttpResponse(Func<Threading::CancellationToken, Task<T>> deserialize)
    {
        this._deserialize = deserialize;
    }

    [SetsRequiredMembers]
    internal HttpResponse(
        global::Anthropic.Core.HttpResponse response,
        Func<Threading::CancellationToken, Task<T>> deserialize
    )
        : this(deserialize)
    {
        this.Message = response.Message;
        this.CancellationToken = response.CancellationToken;
    }

    public Task<T> Deserialize(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return this._deserialize(cts.Token);
    }
}

public sealed class StreamingHttpResponse<T> : global::Anthropic.Core.HttpResponse
{
    readonly Func<Threading::CancellationToken, IAsyncEnumerable<T>> _enumerate;

    internal StreamingHttpResponse(
        Func<Threading::CancellationToken, IAsyncEnumerable<T>> enumerate
    )
    {
        this._enumerate = enumerate;
    }

    [SetsRequiredMembers]
    internal StreamingHttpResponse(
        global::Anthropic.Core.HttpResponse response,
        Func<Threading::CancellationToken, IAsyncEnumerable<T>> enumerate
    )
        : this(enumerate)
    {
        this.Message = response.Message;
        this.CancellationToken = response.CancellationToken;
    }

    public IAsyncEnumerable<T> Enumerate(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return this._enumerate(cts.Token);
    }
}
