using System;
using Anthropic.Core;
using Analytics = Anthropic.Services.Beta.Organization.Analytics;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class AnalyticsService : IAnalyticsService
{
    readonly Lazy<IAnalyticsServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAnalyticsServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IAnalyticsService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnalyticsService(this._client.WithOptions(modifier));
    }

    public AnalyticsService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AnalyticsServiceWithRawResponse(client.WithRawResponse));
        _summaries = new(() => new Analytics::SummaryService(client));
        _users = new(() => new Analytics::UserService(client));
        _apps = new(() => new Analytics::AppService(client));
        _connectors = new(() => new Analytics::ConnectorService(client));
        _plugins = new(() => new Analytics::PluginService(client));
        _skills = new(() => new Analytics::SkillService(client));
        _artifacts = new(() => new Analytics::ArtifactService(client));
        _usageReport = new(() => new Analytics::UsageReportService(client));
        _userUsageReport = new(() => new Analytics::UserUsageReportService(client));
        _costReport = new(() => new Analytics::CostReportService(client));
        _userCostReport = new(() => new Analytics::UserCostReportService(client));
    }

    readonly Lazy<Analytics::ISummaryService> _summaries;
    public Analytics::ISummaryService Summaries
    {
        get { return _summaries.Value; }
    }

    readonly Lazy<Analytics::IUserService> _users;
    public Analytics::IUserService Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<Analytics::IAppService> _apps;
    public Analytics::IAppService Apps
    {
        get { return _apps.Value; }
    }

    readonly Lazy<Analytics::IConnectorService> _connectors;
    public Analytics::IConnectorService Connectors
    {
        get { return _connectors.Value; }
    }

    readonly Lazy<Analytics::IPluginService> _plugins;
    public Analytics::IPluginService Plugins
    {
        get { return _plugins.Value; }
    }

    readonly Lazy<Analytics::ISkillService> _skills;
    public Analytics::ISkillService Skills
    {
        get { return _skills.Value; }
    }

    readonly Lazy<Analytics::IArtifactService> _artifacts;
    public Analytics::IArtifactService Artifacts
    {
        get { return _artifacts.Value; }
    }

    readonly Lazy<Analytics::IUsageReportService> _usageReport;
    public Analytics::IUsageReportService UsageReport
    {
        get { return _usageReport.Value; }
    }

    readonly Lazy<Analytics::IUserUsageReportService> _userUsageReport;
    public Analytics::IUserUsageReportService UserUsageReport
    {
        get { return _userUsageReport.Value; }
    }

    readonly Lazy<Analytics::ICostReportService> _costReport;
    public Analytics::ICostReportService CostReport
    {
        get { return _costReport.Value; }
    }

    readonly Lazy<Analytics::IUserCostReportService> _userCostReport;
    public Analytics::IUserCostReportService UserCostReport
    {
        get { return _userCostReport.Value; }
    }
}

/// <inheritdoc/>
public sealed class AnalyticsServiceWithRawResponse : IAnalyticsServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAnalyticsServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnalyticsServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AnalyticsServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _summaries = new(() => new Analytics::SummaryServiceWithRawResponse(client));
        _users = new(() => new Analytics::UserServiceWithRawResponse(client));
        _apps = new(() => new Analytics::AppServiceWithRawResponse(client));
        _connectors = new(() => new Analytics::ConnectorServiceWithRawResponse(client));
        _plugins = new(() => new Analytics::PluginServiceWithRawResponse(client));
        _skills = new(() => new Analytics::SkillServiceWithRawResponse(client));
        _artifacts = new(() => new Analytics::ArtifactServiceWithRawResponse(client));
        _usageReport = new(() => new Analytics::UsageReportServiceWithRawResponse(client));
        _userUsageReport = new(() => new Analytics::UserUsageReportServiceWithRawResponse(client));
        _costReport = new(() => new Analytics::CostReportServiceWithRawResponse(client));
        _userCostReport = new(() => new Analytics::UserCostReportServiceWithRawResponse(client));
    }

    readonly Lazy<Analytics::ISummaryServiceWithRawResponse> _summaries;
    public Analytics::ISummaryServiceWithRawResponse Summaries
    {
        get { return _summaries.Value; }
    }

    readonly Lazy<Analytics::IUserServiceWithRawResponse> _users;
    public Analytics::IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<Analytics::IAppServiceWithRawResponse> _apps;
    public Analytics::IAppServiceWithRawResponse Apps
    {
        get { return _apps.Value; }
    }

    readonly Lazy<Analytics::IConnectorServiceWithRawResponse> _connectors;
    public Analytics::IConnectorServiceWithRawResponse Connectors
    {
        get { return _connectors.Value; }
    }

    readonly Lazy<Analytics::IPluginServiceWithRawResponse> _plugins;
    public Analytics::IPluginServiceWithRawResponse Plugins
    {
        get { return _plugins.Value; }
    }

    readonly Lazy<Analytics::ISkillServiceWithRawResponse> _skills;
    public Analytics::ISkillServiceWithRawResponse Skills
    {
        get { return _skills.Value; }
    }

    readonly Lazy<Analytics::IArtifactServiceWithRawResponse> _artifacts;
    public Analytics::IArtifactServiceWithRawResponse Artifacts
    {
        get { return _artifacts.Value; }
    }

    readonly Lazy<Analytics::IUsageReportServiceWithRawResponse> _usageReport;
    public Analytics::IUsageReportServiceWithRawResponse UsageReport
    {
        get { return _usageReport.Value; }
    }

    readonly Lazy<Analytics::IUserUsageReportServiceWithRawResponse> _userUsageReport;
    public Analytics::IUserUsageReportServiceWithRawResponse UserUsageReport
    {
        get { return _userUsageReport.Value; }
    }

    readonly Lazy<Analytics::ICostReportServiceWithRawResponse> _costReport;
    public Analytics::ICostReportServiceWithRawResponse CostReport
    {
        get { return _costReport.Value; }
    }

    readonly Lazy<Analytics::IUserCostReportServiceWithRawResponse> _userCostReport;
    public Analytics::IUserCostReportServiceWithRawResponse UserCostReport
    {
        get { return _userCostReport.Value; }
    }
}
