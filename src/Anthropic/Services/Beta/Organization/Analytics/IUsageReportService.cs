using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.UsageReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageReportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get token usage over time across a date range.
    ///
    /// <para>Returns token usage bucketed by minute, hour, or day, optionally broken
    /// down by product, model, context window, inference region, or speed. Available to
    /// organizations on a Claude Enterprise plan. Requires an API key with the
    /// `read:analytics` scope.</para>
    /// </summary>
    Task<UsageReportListPage> List(
        UsageReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageReportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/usage_report?beta=true</c>, but is otherwise the
    /// same as <see cref="IUsageReportService.List(UsageReportListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageReportListPage>> List(
        UsageReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}
