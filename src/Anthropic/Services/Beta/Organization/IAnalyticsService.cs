using System;
using Anthropic.Core;
using Analytics = Anthropic.Services.Beta.Organization.Analytics;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAnalyticsServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAnalyticsService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Analytics::ISummaryService Summaries { get; }

    Analytics::IUserService Users { get; }

    Analytics::IAppService Apps { get; }

    Analytics::IConnectorService Connectors { get; }

    Analytics::IPluginService Plugins { get; }

    Analytics::ISkillService Skills { get; }

    Analytics::IArtifactService Artifacts { get; }

    Analytics::IUsageReportService UsageReport { get; }

    Analytics::IUserUsageReportService UserUsageReport { get; }

    Analytics::ICostReportService CostReport { get; }

    Analytics::IUserCostReportService UserCostReport { get; }
}

/// <summary>
/// A view of <see cref="IAnalyticsService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAnalyticsServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAnalyticsServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Analytics::ISummaryServiceWithRawResponse Summaries { get; }

    Analytics::IUserServiceWithRawResponse Users { get; }

    Analytics::IAppServiceWithRawResponse Apps { get; }

    Analytics::IConnectorServiceWithRawResponse Connectors { get; }

    Analytics::IPluginServiceWithRawResponse Plugins { get; }

    Analytics::ISkillServiceWithRawResponse Skills { get; }

    Analytics::IArtifactServiceWithRawResponse Artifacts { get; }

    Analytics::IUsageReportServiceWithRawResponse UsageReport { get; }

    Analytics::IUserUsageReportServiceWithRawResponse UserUsageReport { get; }

    Analytics::ICostReportServiceWithRawResponse CostReport { get; }

    Analytics::IUserCostReportServiceWithRawResponse UserCostReport { get; }
}
