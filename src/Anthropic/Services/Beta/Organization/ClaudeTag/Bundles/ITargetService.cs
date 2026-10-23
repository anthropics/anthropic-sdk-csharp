using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Services.Beta.Organization.ClaudeTag.Bundles;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITargetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITargetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITargetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Attach a Bundle to a Slack channel or a Slack workspace. A Bundle attached to a
    /// workspace can be used in the workspace and in every channel in it. Attaching a
    /// Bundle to a channel or workspace it is already attached to returns the existing
    /// Bundle Target. The channel or workspace must be set up: attaching never sets a
    /// channel up. A group direct message takes no Bundle and returns 400.
    /// </summary>
    Task<BetaClaudeTagBundleTarget> Create(
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TargetCreateParams, CancellationToken)"/>
    Task<BetaClaudeTagBundleTarget> Create(
        string bundleID,
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get one Bundle Target. Returns 404 when `target_id` is the identifier of another
    /// Bundle's Bundle Target, or the Bundle Target was detached.
    /// </summary>
    Task<BetaClaudeTagBundleTarget> Retrieve(
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TargetRetrieveParams, CancellationToken)"/>
    Task<BetaClaudeTagBundleTarget> Retrieve(
        string targetID,
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the Slack channels and Slack workspaces a Bundle is attached to, newest
    /// first by `created_at`. Only channels and workspaces the organization owns are
    /// listed; a Bundle that is attached to anything else has no Bundle Target for it.
    /// </summary>
    Task<TargetListPage> List(
        TargetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TargetListParams, CancellationToken)"/>
    Task<TargetListPage> List(
        string bundleID,
        TargetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Detach a Bundle from a Slack channel or a Slack workspace. A repeated detach
    /// returns 404.
    /// </summary>
    Task<BetaClaudeTagDeletedBundleTarget> Delete(
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TargetDeleteParams, CancellationToken)"/>
    Task<BetaClaudeTagDeletedBundleTarget> Delete(
        string targetID,
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITargetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITargetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITargetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_tag/bundles/{bundle_id}/targets</c>, but is otherwise the
    /// same as <see cref="ITargetService.Create(TargetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagBundleTarget>> Create(
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TargetCreateParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagBundleTarget>> Create(
        string bundleID,
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/bundles/{bundle_id}/targets/{target_id}</c>, but is otherwise the
    /// same as <see cref="ITargetService.Retrieve(TargetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagBundleTarget>> Retrieve(
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TargetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagBundleTarget>> Retrieve(
        string targetID,
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/bundles/{bundle_id}/targets</c>, but is otherwise the
    /// same as <see cref="ITargetService.List(TargetListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TargetListPage>> List(
        TargetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TargetListParams, CancellationToken)"/>
    Task<HttpResponse<TargetListPage>> List(
        string bundleID,
        TargetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/claude_tag/bundles/{bundle_id}/targets/{target_id}</c>, but is otherwise the
    /// same as <see cref="ITargetService.Delete(TargetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagDeletedBundleTarget>> Delete(
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TargetDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagDeletedBundleTarget>> Delete(
        string targetID,
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
