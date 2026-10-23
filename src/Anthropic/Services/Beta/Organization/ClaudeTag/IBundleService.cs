using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles;
using Anthropic.Services.Beta.Organization.ClaudeTag.Bundles;

namespace Anthropic.Services.Beta.Organization.ClaudeTag;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBundleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBundleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBundleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITargetService Targets { get; }

    /// <summary>
    /// Get one Bundle. What the Bundle grants (connectors, repositories and
    /// credentials) is never returned.
    /// </summary>
    Task<BetaClaudeTagBundle> Retrieve(
        BundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BundleRetrieveParams, CancellationToken)"/>
    Task<BetaClaudeTagBundle> Retrieve(
        string bundleID,
        BundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's Bundles, newest first by `created_at`. A Bundle that
    /// Claude Tag manages for itself is not listed.
    /// </summary>
    Task<BundleListPage> List(
        BundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBundleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBundleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBundleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITargetServiceWithRawResponse Targets { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/bundles/{bundle_id}</c>, but is otherwise the
    /// same as <see cref="IBundleService.Retrieve(BundleRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagBundle>> Retrieve(
        BundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BundleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagBundle>> Retrieve(
        string bundleID,
        BundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/bundles</c>, but is otherwise the
    /// same as <see cref="IBundleService.List(BundleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BundleListPage>> List(
        BundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
