using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.UserUsageReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserUsageReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserUsageReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserUsageReportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// [Legacy] Get per-user token usage across a date range.
    ///
    /// <para>Returns usage per user, ranked by the chosen token metric; `group_by[]` or
    /// `bucket_width` splits a user across several rows. Use this to see which users
    /// consume the most tokens. Only usage attributed to a user account is included;
    /// usage with no user attributed to it, such as Code Review usage and Claude Tag
    /// usage in Slack channels, is left out. Available to organizations on a Claude
    /// Enterprise plan. Requires an API key with the `read:analytics` scope.</para>
    ///
    /// <para>This endpoint is one of the legacy Claude Enterprise usage and cost
    /// reports. For new integrations, use [`GET
    /// /v1/organizations/analytics/usage`](/docs/en/api/beta/organization/analytics/usage/list)
    /// in the Usage and Cost Analytics API instead. To move an existing integration,
    /// see [Migrate from the Claude Enterprise usage and cost
    /// reports](/docs/en/manage-claude/usage-cost-analytics-api#migrate-from-enterprise-analytics-reports).</para>
    /// </summary>
    Task<UserUsageReportListPage> List(
        UserUsageReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserUsageReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserUsageReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserUsageReportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/user_usage_report</c>, but is otherwise the
    /// same as <see cref="IUserUsageReportService.List(UserUsageReportListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserUsageReportListPage>> List(
        UserUsageReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}
