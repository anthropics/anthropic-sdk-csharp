using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Tunnels;
using Anthropic.Services.Beta.Tunnels;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITunnelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITunnelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITunnelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICertificateService Certificates { get; }

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Creates a tunnel. Creation allocates a fresh hostname and provisions the
    /// tunnel; it is not idempotent. The new tunnel rejects MCP traffic until at least
    /// one CA certificate is added.</para>
    /// </summary>
    Task<BetaTunnel> Create(
        TunnelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Fetches a tunnel by ID.</para>
    /// </summary>
    Task<BetaTunnel> Retrieve(
        TunnelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TunnelRetrieveParams, CancellationToken)"/>
    Task<BetaTunnel> Retrieve(
        string tunnelID,
        TunnelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Lists tunnels. Results are ordered by creation time, newest first;
    /// archived tunnels are excluded unless include_archived is set.</para>
    /// </summary>
    Task<TunnelListPage> List(
        TunnelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Archives a tunnel. Archival is irreversible: every non-archived
    /// certificate on the tunnel is archived in the same operation, the hostname is
    /// retired and never re-allocated, and the tunnel token is invalidated. Retrying
    /// against an already-archived tunnel returns the existing record unchanged.</para>
    /// </summary>
    Task<BetaTunnel> Archive(
        TunnelArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(TunnelArchiveParams, CancellationToken)"/>
    Task<BetaTunnel> Archive(
        string tunnelID,
        TunnelArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Reveals a tunnel's connector token. The value is fetched live on each
    /// call; Anthropic does not store it. Repeated calls return the same value until
    /// the token is rotated. Exposed as POST so the token does not appear in
    /// intermediary access logs.</para>
    /// </summary>
    Task<BetaTunnelToken> RevealToken(
        TunnelRevealTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RevealToken(TunnelRevealTokenParams, CancellationToken)"/>
    Task<BetaTunnelToken> RevealToken(
        string tunnelID,
        TunnelRevealTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Rotates a tunnel's connector token. Rotation invalidates the current token
    /// for new connections and returns a fresh value; established connections are not
    /// severed. A connector restarted after rotation must use the new value.</para>
    /// </summary>
    Task<BetaTunnelToken> RotateToken(
        TunnelRotateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateToken(TunnelRotateTokenParams, CancellationToken)"/>
    Task<BetaTunnelToken> RotateToken(
        string tunnelID,
        TunnelRotateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITunnelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITunnelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITunnelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICertificateServiceWithRawResponse Certificates { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tunnels?beta=true</c>, but is otherwise the
    /// same as <see cref="ITunnelService.Create(TunnelCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnel>> Create(
        TunnelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tunnels/{tunnel_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ITunnelService.Retrieve(TunnelRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnel>> Retrieve(
        TunnelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TunnelRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnel>> Retrieve(
        string tunnelID,
        TunnelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tunnels?beta=true</c>, but is otherwise the
    /// same as <see cref="ITunnelService.List(TunnelListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TunnelListPage>> List(
        TunnelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tunnels/{tunnel_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="ITunnelService.Archive(TunnelArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnel>> Archive(
        TunnelArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(TunnelArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnel>> Archive(
        string tunnelID,
        TunnelArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tunnels/{tunnel_id}/reveal_token?beta=true</c>, but is otherwise the
    /// same as <see cref="ITunnelService.RevealToken(TunnelRevealTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnelToken>> RevealToken(
        TunnelRevealTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RevealToken(TunnelRevealTokenParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnelToken>> RevealToken(
        string tunnelID,
        TunnelRevealTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tunnels/{tunnel_id}/rotate_token?beta=true</c>, but is otherwise the
    /// same as <see cref="ITunnelService.RotateToken(TunnelRotateTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnelToken>> RotateToken(
        TunnelRotateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateToken(TunnelRotateTokenParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnelToken>> RotateToken(
        string tunnelID,
        TunnelRotateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
