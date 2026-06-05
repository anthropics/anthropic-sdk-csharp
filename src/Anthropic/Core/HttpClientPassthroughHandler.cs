using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Core;

/// <summary>
/// An HTTP message handler that forwards requests to an <see cref="HttpClient"/>.
///
/// <para>Used as the innermost handler of the handler chain that requests are sent through.</para>
/// </summary>
sealed class HttpClientPassthroughHandler : HttpMessageHandler
{
    readonly HttpClient _httpClient;

    public HttpClientPassthroughHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        return _httpClient.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken
        );
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _httpClient.Dispose();
        }

        base.Dispose(disposing);
    }
}
