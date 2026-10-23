using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.CostReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICostReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICostReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICostReportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// [Legacy] Get cost in USD over time across a date range.
    ///
    /// <para>Returns cost bucketed by minute, hour, or day, optionally broken down by
    /// one or more `group_by[]` dimensions, such as model or cost type. Available to
    /// organizations on a Claude Enterprise plan. Requires an API key with the
    /// `read:analytics` scope.</para>
    ///
    /// <para>This endpoint is one of the legacy Claude Enterprise usage and cost
    /// reports. For new integrations, use [`GET
    /// /v1/organizations/analytics/cost`](/docs/en/api/beta/organization/analytics/cost/list)
    /// in the Usage and Cost Analytics API instead. To move an existing integration,
    /// see [Migrate from the Claude Enterprise usage and cost
    /// reports](/docs/en/manage-claude/usage-cost-analytics-api#migrate-from-enterprise-analytics-reports).</para>
    /// </summary>
    Task<CostReportListPage> List(
        CostReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICostReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICostReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICostReportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/cost_report</c>, but is otherwise the
    /// same as <see cref="ICostReportService.List(CostReportListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CostReportListPage>> List(
        CostReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}
