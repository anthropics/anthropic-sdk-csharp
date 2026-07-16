using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Services.Beta.Tunnels;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICertificateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICertificateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICertificateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Registers a public CA certificate on a tunnel. Anthropic verifies the
    /// gateway's server certificate against this CA when it terminates the inner TLS
    /// session. A tunnel holds at most two non-archived certificates.</para>
    /// </summary>
    Task<BetaTunnelCertificate> Create(
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CertificateCreateParams, CancellationToken)"/>
    Task<BetaTunnelCertificate> Create(
        string tunnelID,
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Fetches a tunnel certificate by ID.</para>
    /// </summary>
    Task<BetaTunnelCertificate> Retrieve(
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CertificateRetrieveParams, CancellationToken)"/>
    Task<BetaTunnelCertificate> Retrieve(
        string certificateID,
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Lists the certificates registered on a tunnel. Archived certificates are
    /// excluded unless include_archived is set.</para>
    /// </summary>
    Task<CertificateListPage> List(
        CertificateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CertificateListParams, CancellationToken)"/>
    Task<CertificateListPage> List(
        string tunnelID,
        CertificateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Tunnels API is in research preview. It requires the `anthropic-beta:
    /// mcp-tunnels-2026-06-22` header and may change without a deprecation period. It
    /// supersedes the Admin API endpoints at `/v1/organizations/tunnels`, which remain
    /// available during a migration window.
    ///
    /// <para>Archives a tunnel certificate, removing it from the set Anthropic trusts
    /// for the tunnel. The certificate record is retained. Archiving the last
    /// non-archived certificate is permitted; the tunnel rejects MCP traffic until a
    /// new certificate is added.</para>
    /// </summary>
    Task<BetaTunnelCertificate> Archive(
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CertificateArchiveParams, CancellationToken)"/>
    Task<BetaTunnelCertificate> Archive(
        string certificateID,
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICertificateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICertificateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICertificateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tunnels/{tunnel_id}/certificates?beta=true</c>, but is otherwise the
    /// same as <see cref="ICertificateService.Create(CertificateCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnelCertificate>> Create(
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CertificateCreateParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnelCertificate>> Create(
        string tunnelID,
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tunnels/{tunnel_id}/certificates/{certificate_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ICertificateService.Retrieve(CertificateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnelCertificate>> Retrieve(
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CertificateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnelCertificate>> Retrieve(
        string certificateID,
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tunnels/{tunnel_id}/certificates?beta=true</c>, but is otherwise the
    /// same as <see cref="ICertificateService.List(CertificateListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CertificateListPage>> List(
        CertificateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CertificateListParams, CancellationToken)"/>
    Task<HttpResponse<CertificateListPage>> List(
        string tunnelID,
        CertificateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tunnels/{tunnel_id}/certificates/{certificate_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="ICertificateService.Archive(CertificateArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTunnelCertificate>> Archive(
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CertificateArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaTunnelCertificate>> Archive(
        string certificateID,
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}
