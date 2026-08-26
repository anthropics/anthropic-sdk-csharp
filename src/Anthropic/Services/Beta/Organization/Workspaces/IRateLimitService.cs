using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Services.Beta.Organization.Workspaces;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRateLimitService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRateLimitServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRateLimitService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List rate-limit overrides configured for a workspace.
    ///
    /// <para>Returns only the groups and limiter types that have a workspace-level
    /// override. Groups without overrides inherit the organization limits and are not
    /// listed; use `GET /v1/organizations/rate_limits` to see those.</para>
    ///
    /// <para>This endpoint currently returns every matching entry in a single page
    /// regardless of `limit`; follow `next_page` so that clients keep working when
    /// pagination is enabled.</para>
    /// </summary>
    Task<RateLimitListPage> List(
        RateLimitListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(RateLimitListParams, CancellationToken)"/>
    Task<RateLimitListPage> List(
        string workspaceID,
        RateLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRateLimitService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRateLimitServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRateLimitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}/rate_limits?beta=true</c>, but is otherwise the
    /// same as <see cref="IRateLimitService.List(RateLimitListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RateLimitListPage>> List(
        RateLimitListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(RateLimitListParams, CancellationToken)"/>
    Task<HttpResponse<RateLimitListPage>> List(
        string workspaceID,
        RateLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
