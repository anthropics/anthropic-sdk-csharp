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
    /// List a workspace's rate limits.
    ///
    /// <para>By default, returns only the groups and limiter types that have a
    /// workspace-level override. With `include_inherited=true`, returns every group
    /// with organization-level limits the workspace can see, listing for each the
    /// values it inherits from the organization as well as its own overrides. Each
    /// value's `source` says which it is.</para>
    ///
    /// <para>When `limit` is omitted, every matching entry is returned in a single
    /// page; when `limit` truncates the result, follow `next_page` to fetch the
    /// remaining entries.</para>
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
