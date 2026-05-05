using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Credentials;

/// <summary>
/// Provides access tokens for authenticating with the Anthropic API.
///
/// <para>The client wraps every provider in an internal cache, so implementations should
/// always return a token that is currently valid and need not cache themselves.</para>
///
/// <para>Implementations must be thread-safe.</para>
/// </summary>
public interface IAccessTokenProvider : IDisposable
{
    /// <summary>
    /// Retrieves an access token.
    /// </summary>
    /// <param name="forceRefresh">When <c>true</c>, the provider must bypass any internal
    /// short-circuit and obtain a fresh token from its source. Set by the client after a
    /// <c>401 Unauthorized</c> response.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask<AccessToken> GetTokenAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default
    );
}
