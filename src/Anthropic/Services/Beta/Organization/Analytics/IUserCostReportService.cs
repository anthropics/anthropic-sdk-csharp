using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.UserCostReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserCostReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserCostReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserCostReportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get per-user cost in USD across a date range.
    ///
    /// <para>Returns one row per user, ranked by spend. Use this to see which users
    /// account for the most cost. Only cost attributable to a seat user is included;
    /// for organization-wide totals including direct API-key and automation traffic,
    /// use the bucketed `/v1/organizations/analytics/cost_report` endpoint. Available
    /// to organizations on a Claude Enterprise plan. Requires an API key with the
    /// `read:analytics` scope.</para>
    /// </summary>
    Task<UserCostReportListPage> List(
        UserCostReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserCostReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserCostReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserCostReportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/user_cost_report?beta=true</c>, but is otherwise the
    /// same as <see cref="IUserCostReportService.List(UserCostReportListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserCostReportListPage>> List(
        UserCostReportListParams parameters,
        CancellationToken cancellationToken = default
    );
}
