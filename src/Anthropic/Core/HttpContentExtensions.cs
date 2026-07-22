#if !NET
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Core;

/// <summary>
/// Cancellation-token overloads of the <see cref="HttpContent"/> readers that modern TFMs have
/// but netstandard2.0 lacks. The token can't cancel the underlying read on those TFMs; callers
/// get the same best-effort behaviour either way without conditional compilation.
/// </summary>
internal static class HttpContentExtensions
{
    public static Task<string> ReadAsStringAsync(
        this HttpContent content,
        CancellationToken cancellationToken
    ) => content.ReadAsStringAsync();

    public static Task<byte[]> ReadAsByteArrayAsync(
        this HttpContent content,
        CancellationToken cancellationToken
    ) => content.ReadAsByteArrayAsync();

    public static Task<Stream> ReadAsStreamAsync(
        this HttpContent content,
        CancellationToken cancellationToken
    ) => content.ReadAsStreamAsync();
}
#endif
