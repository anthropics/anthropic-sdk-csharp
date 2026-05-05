using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Credentials;

/// <summary>
/// Provides identity tokens (external OIDC JWTs) for workload identity federation.
/// </summary>
public interface IIdentityTokenProvider
{
    /// <summary>
    /// Returns a JWT string suitable for the jwt-bearer assertion in token exchange.
    /// </summary>
    Task<string> GetIdentityTokenAsync(CancellationToken cancellationToken = default);
}
