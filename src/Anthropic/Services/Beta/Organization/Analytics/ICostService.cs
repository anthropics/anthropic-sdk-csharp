using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICostService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICostServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICostService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get cost in USD across a date range, broken out by dimension.
    ///
    /// <para>Returns one row per combination of the requested `group_by[]` dimensions
    /// (and time bucket, when `time_bucket_width` is set) that has cost in the range,
    /// ranked by spend or ordered by time bucket; every combination is returned across
    /// pages. With no `group_by[]` and no `time_bucket_width`, a single row aggregates
    /// the whole range. Includes all cost, whether or not it is attributable to a seat
    /// user. Requires an API key with the `read:analytics` scope, or an Admin API key.</para>
    /// </summary>
    Task<CostListPage> List(
        CostListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICostService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICostServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICostServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/cost</c>, but is otherwise the
    /// same as <see cref="ICostService.List(CostListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CostListPage>> List(
        CostListParams parameters,
        CancellationToken cancellationToken = default
    );
}
