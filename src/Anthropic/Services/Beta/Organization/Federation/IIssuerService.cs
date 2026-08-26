using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Services.Beta.Organization.Federation;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIssuerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIssuerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIssuerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Register an OIDC issuer that Anthropic will trust for workload identity
    /// federation in your organization.</para>
    ///
    /// <para>The `jwks` field controls how the issuer's signing keys are obtained and
    /// takes one of three shapes selected by `type`: `discovery` (resolve keys through
    /// OIDC discovery), `explicit_url` (fetch keys from a fixed JWKS URL), or `inline`
    /// (provide a static key set). When `jwks.type` is `discovery` and no
    /// `discovery_base` is set, the issuer URL must be publicly reachable over HTTPS so
    /// Anthropic can fetch the discovery document; for `explicit_url` and `inline`
    /// modes the issuer URL is only matched as the JWT's `iss` claim and is not
    /// fetched.</para>
    /// </summary>
    Task<BetaFederationIssuer> Create(
        IssuerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Retrieve a federation issuer by its ID (`fdis_...`).</para>
    /// </summary>
    Task<BetaFederationIssuer> Retrieve(
        IssuerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IssuerRetrieveParams, CancellationToken)"/>
    Task<BetaFederationIssuer> Retrieve(
        string federationIssuerID,
        IssuerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Partially update a federation issuer.</para>
    ///
    /// <para>Setting `jwks` replaces the full JWKS shape at once. Archived issuers
    /// cannot be updated; this returns 400. Create a new issuer instead.</para>
    ///
    /// <para>Updating an issuer that backs a rule with a scope outside
    /// `workspace:developer` or `workspace:inference` requires a Console session.</para>
    /// </summary>
    Task<BetaFederationIssuer> Update(
        IssuerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IssuerUpdateParams, CancellationToken)"/>
    Task<BetaFederationIssuer> Update(
        string federationIssuerID,
        IssuerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>List federation issuers in your organization.</para>
    ///
    /// <para>Archived issuers are excluded unless `include_archived=true`.</para>
    /// </summary>
    Task<IssuerListPage> List(
        IssuerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Archive a federation issuer.</para>
    ///
    /// <para>Idempotent; re-archiving returns the issuer with its original
    /// `archived_at`. Rejected with 400 if any live (non-archived) federation rule
    /// still references the issuer; archive those rules first (a rule's issuer cannot
    /// be changed), or recreate them against another issuer.</para>
    /// </summary>
    Task<BetaFederationIssuer> Archive(
        IssuerArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(IssuerArchiveParams, CancellationToken)"/>
    Task<BetaFederationIssuer> Archive(
        string federationIssuerID,
        IssuerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIssuerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIssuerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIssuerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_issuers?beta=true</c>, but is otherwise the
    /// same as <see cref="IIssuerService.Create(IssuerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationIssuer>> Create(
        IssuerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/federation_issuers/{federation_issuer_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IIssuerService.Retrieve(IssuerRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationIssuer>> Retrieve(
        IssuerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IssuerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationIssuer>> Retrieve(
        string federationIssuerID,
        IssuerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_issuers/{federation_issuer_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IIssuerService.Update(IssuerUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationIssuer>> Update(
        IssuerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IssuerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationIssuer>> Update(
        string federationIssuerID,
        IssuerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/federation_issuers?beta=true</c>, but is otherwise the
    /// same as <see cref="IIssuerService.List(IssuerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IssuerListPage>> List(
        IssuerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_issuers/{federation_issuer_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IIssuerService.Archive(IssuerArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationIssuer>> Archive(
        IssuerArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(IssuerArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationIssuer>> Archive(
        string federationIssuerID,
        IssuerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
