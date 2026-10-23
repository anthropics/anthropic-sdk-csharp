using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Usage;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get token usage across a date range, broken out by dimension.
    ///
    /// <para>Returns one row per combination of the requested `group_by[]` dimensions
    /// (and time bucket, when `time_bucket_width` is set) that has usage in the range,
    /// ranked by the `order_by` metric or ordered by time bucket; every combination is
    /// returned across pages. With no `group_by[]` and no `time_bucket_width`, a single
    /// row aggregates the whole range. Includes all usage, whether or not it is
    /// attributable to a seat user. Requires an API key with the `read:analytics`
    /// scope, or an Admin API key.</para>
    /// </summary>
    Task<UsageListPage> List(
        UsageListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/usage</c>, but is otherwise the
    /// same as <see cref="IUsageService.List(UsageListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageListPage>> List(
        UsageListParams parameters,
        CancellationToken cancellationToken = default
    );
}
