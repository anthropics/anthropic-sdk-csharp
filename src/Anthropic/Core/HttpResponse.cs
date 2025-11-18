using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Exceptions;

namespace Anthropic.Core;

public sealed class HttpResponse : IDisposable
{
    public required HttpResponseMessage Message { get; init; }

    public CancellationToken CancellationToken { get; init; } = default;

    public async Task<T> Deserialize<T>(CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        try
        {
            return JsonSerializer.Deserialize<T>(
                    await this.ReadAsStream(cts.Token).ConfigureAwait(false),
                    ModelBase.SerializerOptions
                ) ?? throw new AnthropicInvalidDataException("Response cannot be null");
        }
        catch (HttpRequestException e)
        {
            throw new AnthropicIOException("I/O Exception", e);
        }
    }

    public async Task<Stream> ReadAsStream(CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
#if NET5_0_OR_GREATER
        return await Message.Content.ReadAsStreamAsync(cts.Token).ConfigureAwait(false);
#else
        return await Message.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
    }

    public async Task<string> ReadAsString(CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
#if NET5_0_OR_GREATER
        return await Message.Content.ReadAsStringAsync(cts.Token).ConfigureAwait(false);
#else
        return await Message.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
    }

    public void Dispose()
    {
        this.Message.Dispose();
    }
}
