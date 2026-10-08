using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Summaries;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISummaryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISummaryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISummaryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get organization-wide activity summaries for a date range.
    ///
    /// <para>Returns one entry per day from `starting_date` (inclusive) to
    /// `ending_date` (exclusive) in `data`, the same `data` / `next_page` envelope as
    /// the other analytics list endpoints; the series is currently returned in full, so
    /// `next_page` is always null. Data is typically available with a 1-day lag and may
    /// be revised by a few percent over the following days: when `ending_date` is
    /// omitted it defaults to the most recent available day + 1, so the last entry
    /// covers the most recent available day. The series can be scoped to an RBAC group
    /// via `filter[]=rbac_group_id:{id}`. Available to organizations on a Claude
    /// Enterprise plan. Requires an API key with the `read:analytics` scope.</para>
    /// </summary>
    Task<SummaryListPage> List(
        SummaryListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISummaryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISummaryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISummaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/summaries?beta=true</c>, but is otherwise the
    /// same as <see cref="ISummaryService.List(SummaryListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SummaryListPage>> List(
        SummaryListParams parameters,
        CancellationToken cancellationToken = default
    );
}
