namespace Anthropic.Oidc;

/// <summary>
/// Returns a fixed JWT identity token string.
/// Useful when the token is provided via environment variable.
/// </summary>
public sealed class StaticIdentityTokenProvider : IIdentityTokenProvider
{
    private readonly string _token;

    public StaticIdentityTokenProvider(string token)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
    }

    public Task<string> GetIdentityTokenAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_token);
    }
}
