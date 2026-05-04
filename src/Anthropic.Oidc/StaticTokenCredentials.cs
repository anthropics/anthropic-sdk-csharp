using System.Net.Http;
using System.Net.Http.Headers;

namespace Anthropic.Oidc;

/// <summary>
/// Wraps a static bearer token for use with <see cref="AnthropicOidcClient"/>.
/// The token is never refreshed or exchanged.
/// </summary>
public sealed class StaticTokenCredentials : IAnthropicOidcCredentials
{
    private readonly string _token;

    public StaticTokenCredentials(string token)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
    }

    public ValueTask ApplyAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken = default
    )
    {
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        requestMessage.Headers.TryAddWithoutValidation(
            "anthropic-beta",
            OidcConstants.ApiRequestBetaValue
        );
        return default;
    }

    public void InvalidateToken()
    {
        // Static tokens cannot be invalidated.
    }

    public void Dispose()
    {
        // Nothing to dispose.
    }
}
