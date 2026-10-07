using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;
using Anthropic.Models.Beta.Models;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Users;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;
using Anthropic.Models.Beta.Organization.Plugins.Versions;
using Anthropic.Models.Beta.Organization.RbacGroups;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.Effective;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;
using Anthropic.Models.Messages;
using Anthropic.Models.Models;
using Anthropic.Models.Organization;
using Anthropic.Models.Organization.ExternalKeys;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.Organization.Workspaces.RateLimits;
using Agents = Anthropic.Models.Beta.Agents;
using AnalyticsSkills = Anthropic.Models.Beta.Organization.Analytics.Skills;
using ApiKeys = Anthropic.Models.Organization.ApiKeys;
using Artifacts = Anthropic.Models.Beta.Organization.Analytics.Artifacts;
using Batches = Anthropic.Models.Messages.Batches;
using BetaFiles = Anthropic.Models.Beta.Files;
using BetaSkills = Anthropic.Models.Beta.Skills;
using Connectors = Anthropic.Models.Beta.Organization.Analytics.Connectors;
using CostReport = Anthropic.Models.Beta.Organization.Analytics.CostReport;
using Credentials = Anthropic.Models.Beta.Vaults.Credentials;
using DeploymentRuns = Anthropic.Models.Beta.DeploymentRuns;
using Deployments = Anthropic.Models.Beta.Deployments;
using Dreams = Anthropic.Models.Beta.Dreams;
using Environments = Anthropic.Models.Beta.Environments;
using Events = Anthropic.Models.Beta.Sessions.Events;
using ExternalKeys = Anthropic.Models.Beta.Organization.ExternalKeys;
using Files = Anthropic.Models.Files;
using Invites = Anthropic.Models.Organization.Invites;
using Memories = Anthropic.Models.Beta.MemoryStores.Memories;
using MemoryStores = Anthropic.Models.Beta.MemoryStores;
using MemoryVersions = Anthropic.Models.Beta.MemoryStores.MemoryVersions;
using Messages = Anthropic.Models.Beta.Messages;
using MessagesBatches = Anthropic.Models.Beta.Messages.Batches;
using OrganizationApiKeys = Anthropic.Models.Beta.Organization.ApiKeys;
using OrganizationInvites = Anthropic.Models.Beta.Organization.Invites;
using OrganizationPlugins = Anthropic.Models.Beta.Organization.Plugins;
using OrganizationRateLimits = Anthropic.Models.Beta.Organization.RateLimits;
using OrganizationServiceAccounts = Anthropic.Models.Beta.Organization.ServiceAccounts;
using OrganizationUsers = Anthropic.Models.Beta.Organization.Users;
using PluginMarketplaces = Anthropic.Models.Beta.Organization.PluginMarketplaces;
using Plugins = Anthropic.Models.Beta.Organization.Analytics.Plugins;
using Projects = Anthropic.Models.Beta.Organization.Analytics.Apps.Chat.Projects;
using RateLimits = Anthropic.Models.Organization.RateLimits;
using Resources = Anthropic.Models.Beta.Sessions.Resources;
using ServiceAccounts = Anthropic.Models.Organization.ServiceAccounts;
using Sessions = Anthropic.Models.Beta.Sessions;
using Shares = Anthropic.Models.Beta.Organization.Plugins.Shares;
using Skills = Anthropic.Models.Skills;
using Threads = Anthropic.Models.Beta.Sessions.Threads;
using UsageReport = Anthropic.Models.Beta.Organization.Analytics.UsageReport;
using UserCostReport = Anthropic.Models.Beta.Organization.Analytics.UserCostReport;
using UserProfiles = Anthropic.Models.Beta.UserProfiles;
using Users = Anthropic.Models.Organization.Users;
using UserUsageReport = Anthropic.Models.Beta.Organization.Analytics.UserUsageReport;
using Vaults = Anthropic.Models.Beta.Vaults;
using Workspaces = Anthropic.Models.Beta.Organization.Workspaces;
using WorkspacesRateLimits = Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, ErrorType>(),
            new ApiEnumConverter<string, MediaType>(),
            new ApiEnumConverter<string, BashCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, BrowserReadPageFilter>(),
            new ApiEnumConverter<string, BrowserScrollDirection>(),
            new ApiEnumConverter<string, Ttl>(),
            new ApiEnumConverter<string, AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20260120AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20260521AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, ComputerScrollDirection>(),
            new ApiEnumConverter<string, ContainerSkillType>(),
            new ApiEnumConverter<string, OversizedImage>(),
            new ApiEnumConverter<string, MemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, Model>(),
            new ApiEnumConverter<string, Effort>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, ServerToolUseBlockParamName>(),
            new ApiEnumConverter<string, SkillParamsType>(),
            new ApiEnumConverter<string, StopReason>(),
            new ApiEnumConverter<string, TextEditorCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, FileType>(),
            new ApiEnumConverter<string, TextEditorCodeExecutionViewResultBlockParamFileType>(),
            new ApiEnumConverter<string, Display>(),
            new ApiEnumConverter<string, ThinkingConfigEnabledDisplay>(),
            new ApiEnumConverter<string, ToolAllowedCaller>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ToolBash20250124AllowedCaller>(),
            new ApiEnumConverter<string, ToolSearchToolBm25_20251119Type>(),
            new ApiEnumConverter<string, ToolSearchToolBm25_20251119AllowedCaller>(),
            new ApiEnumConverter<string, ToolSearchToolRegex20251119Type>(),
            new ApiEnumConverter<string, ToolSearchToolRegex20251119AllowedCaller>(),
            new ApiEnumConverter<string, ToolSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, ToolTextEditor20250124AllowedCaller>(),
            new ApiEnumConverter<string, ToolTextEditor20250429AllowedCaller>(),
            new ApiEnumConverter<string, ToolTextEditor20250728AllowedCaller>(),
            new ApiEnumConverter<string, UsageServiceTier>(),
            new ApiEnumConverter<string, WebFetchTool20250910AllowedCaller>(),
            new ApiEnumConverter<string, WebFetchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, WebFetchTool20260309AllowedCaller>(),
            new ApiEnumConverter<string, WebFetchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, ResponseInclusion>(),
            new ApiEnumConverter<string, WebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, WebSearchTool20250305AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260318ResponseInclusion>(),
            new ApiEnumConverter<string, WebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, Batches::ProcessingStatus>(),
            new ApiEnumConverter<string, Batches::ServiceTier>(),
            new ApiEnumConverter<string, ModelLine>(),
            new ApiEnumConverter<string, Files::Type>(),
            new ApiEnumConverter<string, Skills::Type>(),
            new ApiEnumConverter<string, OrganizationRole>(),
            new ApiEnumConverter<string, ApiKeys::ApiKeyStatus>(),
            new ApiEnumConverter<string, ApiKeys::Type>(),
            new ApiEnumConverter<string, ApiKeys::Status>(),
            new ApiEnumConverter<string, ApiKeys::ApiKeyListParamsStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Geo>(),
            new ApiEnumConverter<string, ExternalKeyUpdateParamsGeo>(),
            new ApiEnumConverter<string, Invites::OrganizationInviteStatus>(),
            new ApiEnumConverter<string, Invites::Role>(),
            new ApiEnumConverter<string, Invites::Status>(),
            new ApiEnumConverter<string, ServiceAccounts::ServiceAccountOrganizationRole>(),
            new ApiEnumConverter<string, ServiceAccounts::OrganizationRole>(),
            new ApiEnumConverter<
                string,
                ServiceAccounts::ServiceAccountUpdateParamsOrganizationRole
            >(),
            new ApiEnumConverter<string, NoBillingWorkspaceRole>(),
            new ApiEnumConverter<string, Users::Role>(),
            new ApiEnumConverter<string, AllowedInferenceGeo>(),
            new ApiEnumConverter<string, DefaultInferenceGeo>(),
            new ApiEnumConverter<string, WorkspaceGeo>(),
            new ApiEnumConverter<string, DataResidencyCreateConfigDefaultInferenceGeo>(),
            new ApiEnumConverter<string, DataResidencyCreateConfigWorkspaceGeo>(),
            new ApiEnumConverter<string, DataResidencyUpdateConfigDefaultInferenceGeo>(),
            new ApiEnumConverter<string, WorkspaceRole>(),
            new ApiEnumConverter<string, GroupType>(),
            new ApiEnumConverter<string, RateLimits::GroupType>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, BetaCurrency>(),
            new ApiEnumConverter<string, BetaModelLine>(),
            new ApiEnumConverter<string, Messages::AllowedCaller>(),
            new ApiEnumConverter<string, Messages::ErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaAdvisorToolResultErrorParamErrorCode>(),
            new ApiEnumConverter<string, Messages::MediaType>(),
            new ApiEnumConverter<string, Messages::BetaBashCodeExecutionToolResultErrorErrorCode>(),
            new ApiEnumConverter<
                string,
                Messages::BetaBashCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, Messages::BetaBrowserReadPageFilter>(),
            new ApiEnumConverter<string, Messages::BetaBrowserScrollDirection>(),
            new ApiEnumConverter<string, Messages::Ttl>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250522AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20260120AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20260521AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaComputerScrollDirection>(),
            new ApiEnumConverter<string, Messages::Type>(),
            new ApiEnumConverter<string, Messages::Reason>(),
            new ApiEnumConverter<string, Messages::Mode>(),
            new ApiEnumConverter<string, Messages::BetaFallbackParamSpeed>(),
            new ApiEnumConverter<string, Messages::BetaFallbackRefusalTriggerCategory>(),
            new ApiEnumConverter<string, Messages::OversizedImage>(),
            new ApiEnumConverter<string, Messages::BetaMemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, Messages::Role>(),
            new ApiEnumConverter<string, Messages::ClearAt>(),
            new ApiEnumConverter<string, Messages::Effort>(),
            new ApiEnumConverter<string, Messages::Category>(),
            new ApiEnumConverter<string, Messages::BetaResponseToolAllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaResponseToolType>(),
            new ApiEnumConverter<string, Messages::Name>(),
            new ApiEnumConverter<string, Messages::BetaServerToolUseBlockParamName>(),
            new ApiEnumConverter<string, Messages::BetaSkillParamsType>(),
            new ApiEnumConverter<string, Messages::BetaStopReason>(),
            new ApiEnumConverter<string, Messages::BetaSystemMessageOutputConfigEffort>(),
            new ApiEnumConverter<
                string,
                Messages::BetaTextEditorCodeExecutionToolResultErrorErrorCode
            >(),
            new ApiEnumConverter<
                string,
                Messages::BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, Messages::FileType>(),
            new ApiEnumConverter<
                string,
                Messages::BetaTextEditorCodeExecutionViewResultBlockParamFileType
            >(),
            new ApiEnumConverter<string, Messages::Display>(),
            new ApiEnumConverter<string, Messages::BetaThinkingConfigEnabledDisplay>(),
            new ApiEnumConverter<string, Messages::BetaThinkingDroppedInputTransformationReason>(),
            new ApiEnumConverter<
                string,
                Messages::BetaThinkingMismatchAllowedInputTransformationReason
            >(),
            new ApiEnumConverter<string, Messages::BetaThinkingPrefixMismatchBehavior>(),
            new ApiEnumConverter<string, Messages::BetaToolAllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolType>(),
            new ApiEnumConverter<string, Messages::BetaToolBash20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolBash20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20251124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolBm25_20251119Type>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolBm25_20251119AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolRegex20251119Type>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolRegex20251119AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolResultErrorErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolResultErrorParamErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20250429AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20250728AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaUsageServiceTier>(),
            new ApiEnumConverter<string, Messages::BetaUsageSpeed>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20250910AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20260309AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, Messages::ResponseInclusion>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20250305AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260318ResponseInclusion>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::ServiceTier>(),
            new ApiEnumConverter<string, Messages::Speed>(),
            new ApiEnumConverter<string, Messages::MessageCountTokensParamsSpeed>(),
            new ApiEnumConverter<string, MessagesBatches::ProcessingStatus>(),
            new ApiEnumConverter<string, MessagesBatches::ServiceTier>(),
            new ApiEnumConverter<string, MessagesBatches::Speed>(),
            new ApiEnumConverter<string, Agents::Type>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentReferenceType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolset20260401Type>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolset20260401ParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAlwaysAllowPolicyType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAlwaysAskPolicyType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAnthropicSkillType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAnthropicSkillParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsBashToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomSkillType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomSkillParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomToolType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomToolParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEditToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortHighType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortLowType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortMaxType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortMediumType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortXhighType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsGlobToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsGrepToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMcpServerUrlDefinitionType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMcpToolsetType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMcpToolsetParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsModel>(),
            new ApiEnumConverter<string, Agents::Speed>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortLevel>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsModelConfigParamsSpeed>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentCoordinatorType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsMultiagentCoordinatorParamsType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentSelfParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsReadToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsSessionThreadAgentType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsUrlMcpServerParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebFetchToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebFetchUrlSourceShorthand>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebSearchToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWriteToolConfigParamsType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsMultiagentParamsType>(),
            new ApiEnumConverter<string, Environments::BetaEnvironmentScope>(),
            new ApiEnumConverter<string, Environments::Type>(),
            new ApiEnumConverter<string, Environments::BetaPackagesType>(),
            new ApiEnumConverter<string, Environments::BetaPackagesParamsType>(),
            new ApiEnumConverter<string, Environments::Scope>(),
            new ApiEnumConverter<string, Environments::EnvironmentUpdateParamsScope>(),
            new ApiEnumConverter<string, State>(),
            new ApiEnumConverter<string, BetaSelfHostedWorkHeartbeatResponseState>(),
            new ApiEnumConverter<string, Sessions::Type>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsAgentMessagePreviewType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsAgentParamsType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsAgentThinkingPreviewType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsAgentWithOverridesParamsType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsBranchCheckoutType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsBudgetLimitType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsCommitCheckoutType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsDeletedSessionType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsDeltaContentType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsDeltaEventType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsDeltaType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsFileResourceParamsType>(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsGitHubRepositoryResourceParamsType
            >(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsMemoryStoreResourceParamType>(),
            new ApiEnumConverter<string, Sessions::Access>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsMultiagentType>(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsOutcomeEvaluationResourceType
            >(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionStatus>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionAgentType>(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsSessionMultiagentCoordinatorType
            >(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionUpdatedEventType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionUsageEventType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsStartEventType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSystemContentBlockType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSystemMessageEventType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsUserToolResultEventType>(),
            new ApiEnumConverter<string, Sessions::Order>(),
            new ApiEnumConverter<string, Sessions::Status>(),
            new ApiEnumConverter<string, Events::Type>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentEvaluatedPermission>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMcpToolResultEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMcpToolUseEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMessageEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentThinkingEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentThreadContextCompactedEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentThreadMessageReceivedEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentThreadMessageSentEventType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentToolResultEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentToolUseEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsBase64DocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsBase64ImageSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsBillingErrorType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsCredentialHostUnreachableErrorType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsDocumentBlockType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsFileDocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsFileImageSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsFileRubricType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsFileRubricParamsType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsImageBlockType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsMcpAuthenticationFailedErrorType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsMcpConnectionFailedErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsModelOverloadedErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsModelRateLimitedErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsModelRequestFailedErrorType>(),
            new ApiEnumConverter<string, Events::MediaType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsPlainTextDocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsRedactedBlockType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsRetryStatusExhaustedType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsRetryStatusRetryingType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsRetryStatusTerminalType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSearchResultBlockType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSearchResultContentType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionBudgetReachedType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionDeletedEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionEndTurnType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionErrorEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionEventType>(),
            new ApiEnumConverter<string, Events::Category>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionRequiresActionType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionRetriesExhaustedType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionStatusIdleEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionStatusRescheduledEventType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionStatusRunningEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionStatusTerminatedEventType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionThreadCreatedEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionThreadStatusIdleEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionThreadStatusRescheduledEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionThreadStatusRunningEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionThreadStatusTerminatedEventType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSpanModelRequestEndEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSpanModelRequestStartEventType>(),
            new ApiEnumConverter<string, Events::Speed>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSpanOutcomeEvaluationEndEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSpanOutcomeEvaluationStartEventType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSystemMessageEventParamsType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsTextBlockType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsTextRubricType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsTextRubricParamsType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUnknownErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUrlDocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUrlImageSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserCustomToolResultEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserCustomToolResultEventParamsType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserDefineOutcomeEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserDefineOutcomeEventParamsType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserInterruptEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserInterruptEventParamsType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserMessageEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserMessageEventParamsType>(),
            new ApiEnumConverter<string, Events::Result>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserToolConfirmationEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserToolConfirmationEventParamsResult
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserToolConfirmationEventParamsType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserToolResultEventParamsType>(),
            new ApiEnumConverter<string, Events::Order>(),
            new ApiEnumConverter<string, Resources::BetaManagedAgentsDeleteSessionResourceType>(),
            new ApiEnumConverter<string, Resources::BetaManagedAgentsFileResourceType>(),
            new ApiEnumConverter<
                string,
                Resources::BetaManagedAgentsGitHubRepositoryResourceType
            >(),
            new ApiEnumConverter<string, Resources::BetaManagedAgentsMemoryStoreResourceType>(),
            new ApiEnumConverter<string, Resources::Access>(),
            new ApiEnumConverter<string, Resources::Type>(),
            new ApiEnumConverter<string, Threads::Type>(),
            new ApiEnumConverter<string, Threads::BetaManagedAgentsSessionThreadStatus>(),
            new ApiEnumConverter<string, Deployments::Type>(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsCronScheduleType>(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsCronScheduleParamsType>(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsDeploymentType>(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsDeploymentStatus>(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentSystemMessageEventType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentUserDefineOutcomeEventType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentUserMessageEventType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsErrorDeploymentPausedReasonType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsFileResourceConfigType>(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsGitHubRepositoryResourceConfigType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsManualDeploymentPausedReasonType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsMemoryStoreResourceConfigType
            >(),
            new ApiEnumConverter<string, Deployments::Access>(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsScheduleType>(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsScheduleParamsType>(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsSkillNotFoundDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsUnknownDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<string, DeploymentRuns::Type>(),
            new ApiEnumConverter<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType>(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsEnvironmentNotFoundRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsFileNotFoundRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsManualTriggerContextType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsMcpEgressBlockedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsMemoryStoreArchivedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsOrganizationDisabledRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsSessionCreationRejectedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsSessionRateLimitedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsSessionResourceNotFoundRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsSkillNotFoundRunErrorType
            >(),
            new ApiEnumConverter<string, DeploymentRuns::BetaManagedAgentsTriggerType>(),
            new ApiEnumConverter<string, DeploymentRuns::BetaManagedAgentsUnknownRunErrorType>(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsVaultArchivedRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsVaultNotFoundRunErrorType
            >(),
            new ApiEnumConverter<
                string,
                DeploymentRuns::BetaManagedAgentsWorkspaceArchivedRunErrorType
            >(),
            new ApiEnumConverter<string, Vaults::Type>(),
            new ApiEnumConverter<string, Vaults::BetaManagedAgentsVaultType>(),
            new ApiEnumConverter<string, Credentials::Type>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsCredentialValidationType>(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsCredentialValidationStatus
            >(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsDeletedCredentialType>(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsEnvironmentVariableAuthResponseType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsEnvironmentVariableCreateParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsEnvironmentVariableUpdateParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsLimitedCredentialNetworkingParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsLimitedCredentialNetworkingResponseType
            >(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsMcpOAuthAuthResponseType>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsMcpOAuthCreateParamsType>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsMcpOAuthUpdateParamsType>(),
            new ApiEnumConverter<string, Credentials::Status>(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsStaticBearerAuthResponseType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsStaticBearerCreateParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsStaticBearerUpdateParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthBasicParamType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthBasicResponseType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthNoneParamType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthNoneResponseType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthPostParamType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthPostResponseType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsTokenEndpointAuthPostUpdateParamType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType
            >(),
            new ApiEnumConverter<string, MemoryStores::Type>(),
            new ApiEnumConverter<string, MemoryStores::BetaManagedAgentsMemoryStoreType>(),
            new ApiEnumConverter<string, Memories::Type>(),
            new ApiEnumConverter<
                string,
                Memories::BetaManagedAgentsContentSha256PreconditionType
            >(),
            new ApiEnumConverter<string, Memories::BetaManagedAgentsDeletedMemoryType>(),
            new ApiEnumConverter<string, Memories::BetaManagedAgentsMemoryType>(),
            new ApiEnumConverter<string, Memories::BetaManagedAgentsMemoryPathConflictErrorType>(),
            new ApiEnumConverter<
                string,
                Memories::BetaManagedAgentsMemoryPreconditionFailedErrorType
            >(),
            new ApiEnumConverter<string, Memories::BetaManagedAgentsMemoryPrefixType>(),
            new ApiEnumConverter<string, Memories::BetaManagedAgentsMemoryView>(),
            new ApiEnumConverter<string, Memories::BetaManagedAgentsPreconditionType>(),
            new ApiEnumConverter<string, MemoryVersions::Type>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsMemoryVersionType>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsMemoryVersionOperation>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsSessionActorType>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsUserActorType>(),
            new ApiEnumConverter<string, BetaFiles::Type>(),
            new ApiEnumConverter<string, BetaSkills::Type>(),
            new ApiEnumConverter<string, UserProfiles::Type>(),
            new ApiEnumConverter<string, UserProfiles::BetaUserProfileAccessType>(),
            new ApiEnumConverter<string, UserProfiles::BetaUserProfileEnrollmentUrlType>(),
            new ApiEnumConverter<string, UserProfiles::AccountStatus>(),
            new ApiEnumConverter<string, UserProfiles::EntityType>(),
            new ApiEnumConverter<
                string,
                UserProfiles::BetaUserProfileExternalUserDetailsParamsAccountStatus
            >(),
            new ApiEnumConverter<
                string,
                UserProfiles::BetaUserProfileExternalUserDetailsParamsEntityType
            >(),
            new ApiEnumConverter<string, UserProfiles::Status>(),
            new ApiEnumConverter<string, UserProfiles::AccessType>(),
            new ApiEnumConverter<string, UserProfiles::UserProfileUpdateParamsAccessType>(),
            new ApiEnumConverter<string, UserProfiles::Order>(),
            new ApiEnumConverter<string, UserProfiles::OrderBy>(),
            new ApiEnumConverter<string, Dreams::Type>(),
            new ApiEnumConverter<string, Dreams::BetaDreamMemoryStoreInputType>(),
            new ApiEnumConverter<string, Dreams::BetaDreamMemoryStoreOutputType>(),
            new ApiEnumConverter<string, Dreams::Speed>(),
            new ApiEnumConverter<string, Dreams::BetaDreamModelConfigParamSpeed>(),
            new ApiEnumConverter<string, Dreams::BetaDreamOutputType>(),
            new ApiEnumConverter<string, Dreams::BetaDreamSessionsInputType>(),
            new ApiEnumConverter<string, Dreams::BetaDreamStatus>(),
            new ApiEnumConverter<string, Dreams::BetaOutputBehaviorCreateNewType>(),
            new ApiEnumConverter<string, Dreams::BetaOutputBehaviorUpdateExistingType>(),
            new ApiEnumConverter<string, BetaOrganizationRole>(),
            new ApiEnumConverter<string, OrganizationApiKeys::BetaApiKeyStatus>(),
            new ApiEnumConverter<string, OrganizationApiKeys::Type>(),
            new ApiEnumConverter<string, OrganizationApiKeys::Status>(),
            new ApiEnumConverter<string, OrganizationApiKeys::ApiKeyListParamsStatus>(),
            new ApiEnumConverter<string, ExternalKeys::Status>(),
            new ApiEnumConverter<string, ExternalKeys::Geo>(),
            new ApiEnumConverter<string, ExternalKeys::ExternalKeyUpdateParamsGeo>(),
            new ApiEnumConverter<string, OrganizationInvites::BetaOrganizationInviteStatus>(),
            new ApiEnumConverter<string, OrganizationInvites::Role>(),
            new ApiEnumConverter<string, OrganizationInvites::Status>(),
            new ApiEnumConverter<
                string,
                OrganizationServiceAccounts::BetaServiceAccountOrganizationRole
            >(),
            new ApiEnumConverter<string, OrganizationServiceAccounts::OrganizationRole>(),
            new ApiEnumConverter<
                string,
                OrganizationServiceAccounts::ServiceAccountUpdateParamsOrganizationRole
            >(),
            new ApiEnumConverter<string, Workspaces::BetaNoBillingWorkspaceRole>(),
            new ApiEnumConverter<string, OrganizationUsers::Role>(),
            new ApiEnumConverter<string, Workspaces::BetaAllowedInferenceGeo>(),
            new ApiEnumConverter<string, Workspaces::DefaultInferenceGeo>(),
            new ApiEnumConverter<string, Workspaces::WorkspaceGeo>(),
            new ApiEnumConverter<
                string,
                Workspaces::BetaDataResidencyCreateConfigDefaultInferenceGeo
            >(),
            new ApiEnumConverter<string, Workspaces::BetaDataResidencyCreateConfigWorkspaceGeo>(),
            new ApiEnumConverter<
                string,
                Workspaces::BetaDataResidencyUpdateConfigDefaultInferenceGeo
            >(),
            new ApiEnumConverter<string, Workspaces::BetaWorkspaceRole>(),
            new ApiEnumConverter<string, WorkspacesRateLimits::BetaWorkspaceRateLimitGroupType>(),
            new ApiEnumConverter<string, WorkspacesRateLimits::GroupType>(),
            new ApiEnumConverter<
                string,
                OrganizationRateLimits::BetaOrganizationRateLimitGroupType
            >(),
            new ApiEnumConverter<string, OrganizationRateLimits::GroupType>(),
            new ApiEnumConverter<string, BetaAnalyticsClaudeTagCategory>(),
            new ApiEnumConverter<string, BetaAnalyticsContextWindow>(),
            new ApiEnumConverter<string, InferenceGeo>(),
            new ApiEnumConverter<string, Speed>(),
            new ApiEnumConverter<string, BetaAnalyticsCostType>(),
            new ApiEnumConverter<string, BetaAnalyticsCostUsersItemInferenceGeo>(),
            new ApiEnumConverter<string, BetaAnalyticsCostUsersItemSpeed>(),
            new ApiEnumConverter<string, BetaAnalyticsInferenceGeoFilter>(),
            new ApiEnumConverter<string, BetaAnalyticsProductFilter>(),
            new ApiEnumConverter<string, ShareStatus>(),
            new ApiEnumConverter<string, BetaAnalyticsTokenType>(),
            new ApiEnumConverter<string, BetaAnalyticsUsageBucketedResultInferenceGeo>(),
            new ApiEnumConverter<string, BetaAnalyticsUsageBucketedResultSpeed>(),
            new ApiEnumConverter<string, BetaAnalyticsUsageUsersItemInferenceGeo>(),
            new ApiEnumConverter<string, BetaAnalyticsUsageUsersItemSpeed>(),
            new ApiEnumConverter<string, GroupBy>(),
            new ApiEnumConverter<string, Order>(),
            new ApiEnumConverter<string, Projects::GroupBy>(),
            new ApiEnumConverter<string, Projects::Order>(),
            new ApiEnumConverter<string, Connectors::GroupBy>(),
            new ApiEnumConverter<string, Connectors::Order>(),
            new ApiEnumConverter<string, Plugins::GroupBy>(),
            new ApiEnumConverter<string, Plugins::Order>(),
            new ApiEnumConverter<string, AnalyticsSkills::GroupBy>(),
            new ApiEnumConverter<string, AnalyticsSkills::Order>(),
            new ApiEnumConverter<string, Artifacts::GroupBy>(),
            new ApiEnumConverter<string, UsageReport::BucketWidth>(),
            new ApiEnumConverter<string, UsageReport::GroupBy>(),
            new ApiEnumConverter<string, UsageReport::Speed>(),
            new ApiEnumConverter<string, UserUsageReport::BucketWidth>(),
            new ApiEnumConverter<string, UserUsageReport::GroupBy>(),
            new ApiEnumConverter<string, UserUsageReport::Order>(),
            new ApiEnumConverter<string, UserUsageReport::OrderBy>(),
            new ApiEnumConverter<string, UserUsageReport::Speed>(),
            new ApiEnumConverter<string, CostReport::BucketWidth>(),
            new ApiEnumConverter<string, CostReport::GroupBy>(),
            new ApiEnumConverter<string, CostReport::Speed>(),
            new ApiEnumConverter<string, UserCostReport::BucketWidth>(),
            new ApiEnumConverter<string, UserCostReport::GroupBy>(),
            new ApiEnumConverter<string, UserCostReport::Order>(),
            new ApiEnumConverter<string, UserCostReport::OrderBy>(),
            new ApiEnumConverter<string, UserCostReport::Speed>(),
            new ApiEnumConverter<string, BetaSpendLimitPeriod>(),
            new ApiEnumConverter<string, ScopeType>(),
            new ApiEnumConverter<string, Period>(),
            new ApiEnumConverter<string, BetaSpendLimitIncreaseRequestStatus>(),
            new ApiEnumConverter<string, SourceType>(),
            new ApiEnumConverter<string, OrganizationPlugins::OrganizationInstallationPreference>(),
            new ApiEnumConverter<string, OrganizationPlugins::Reach>(),
            new ApiEnumConverter<string, OrganizationPlugins::Type>(),
            new ApiEnumConverter<string, OrganizationPlugins::Assessment>(),
            new ApiEnumConverter<string, OrganizationPlugins::Status>(),
            new ApiEnumConverter<string, OrganizationPlugins::OwnerType>(),
            new ApiEnumConverter<string, Reach>(),
            new ApiEnumConverter<string, BetaPluginInstallationSettingInstallationPreference>(),
            new ApiEnumConverter<string, TargetType>(),
            new ApiEnumConverter<string, InstallationPreference>(),
            new ApiEnumConverter<string, Shares::TargetType>(),
            new ApiEnumConverter<
                string,
                PluginMarketplaces::BetaPluginMarketplaceDefaultInstallationPreference
            >(),
            new ApiEnumConverter<string, PluginMarketplaces::BetaPluginMarketplaceSource>(),
            new ApiEnumConverter<string, PluginMarketplaces::SyncStatus>(),
            new ApiEnumConverter<string, PluginMarketplaces::DefaultInstallationPreference>(),
            new ApiEnumConverter<string, PluginMarketplaces::OwnerType>(),
            new ApiEnumConverter<string, PluginMarketplaces::Source>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
