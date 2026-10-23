using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;
using Anthropic.Models.Beta.MemoryStores.Memories;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Analytics.Cost;
using Anthropic.Models.Beta.Organization.Analytics.Usage;
using Anthropic.Models.Beta.Organization.Analytics.Users;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;
using Anthropic.Models.Beta.Organization.ComplianceSettings;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;
using Anthropic.Models.Beta.Organization.Plugins.Versions;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;
using Anthropic.Models.Beta.Organization.SpendLimits.Effective;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;
using Anthropic.Models.Beta.Sessions.Resources;
using Anthropic.Models.Beta.Sessions.Threads;
using Anthropic.Models.Beta.UserProfiles.ActionUrls;
using Anthropic.Models.Beta.Webhooks;
using Anthropic.Models.Messages;
using Anthropic.Models.Models;
using Anthropic.Models.Organization;
using Anthropic.Models.Organization.ComplianceSettings;
using Anthropic.Models.Organization.Federation.Issuers;
using Anthropic.Models.Organization.RateLimits;
using Anthropic.Models.Organization.Users;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.UserProfiles;
using Anthropic.Models.UserProfiles.ActionUrls;
using Agents = Anthropic.Models.Beta.Agents;
using Analytics = Anthropic.Models.Beta.Organization.Analytics;
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
using ExternalKeys = Anthropic.Models.Organization.ExternalKeys;
using Files = Anthropic.Models.Files;
using Invites = Anthropic.Models.Organization.Invites;
using Issuers = Anthropic.Models.Beta.Organization.Federation.Issuers;
using Messages = Anthropic.Models.Beta.Messages;
using MessagesBatches = Anthropic.Models.Beta.Messages.Batches;
using Models = Anthropic.Models.Beta.Models;
using OrganizationApiKeys = Anthropic.Models.Beta.Organization.ApiKeys;
using OrganizationExternalKeys = Anthropic.Models.Beta.Organization.ExternalKeys;
using OrganizationInvites = Anthropic.Models.Beta.Organization.Invites;
using OrganizationPlugins = Anthropic.Models.Beta.Organization.Plugins;
using OrganizationRateLimits = Anthropic.Models.Beta.Organization.RateLimits;
using OrganizationServiceAccounts = Anthropic.Models.Beta.Organization.ServiceAccounts;
using PluginMarketplaces = Anthropic.Models.Beta.Organization.PluginMarketplaces;
using Plugins = Anthropic.Models.Beta.Organization.Analytics.Plugins;
using Projects = Anthropic.Models.Beta.Organization.Analytics.Apps.Chat.Projects;
using RateLimits = Anthropic.Models.Organization.Workspaces.RateLimits;
using RbacGroups = Anthropic.Models.Beta.Organization.RbacGroups;
using ServiceAccounts = Anthropic.Models.Organization.ServiceAccounts;
using Sessions = Anthropic.Models.Beta.Sessions;
using Shares = Anthropic.Models.Beta.Organization.Plugins.Shares;
using Skills = Anthropic.Models.Skills;
using SpendLimits = Anthropic.Models.Beta.Organization.SpendLimits;
using UsageReport = Anthropic.Models.Beta.Organization.Analytics.UsageReport;
using UserCostReport = Anthropic.Models.Beta.Organization.Analytics.UserCostReport;
using UserProfiles = Anthropic.Models.Beta.UserProfiles;
using Users = Anthropic.Models.Beta.Organization.Users;
using UserUsageReport = Anthropic.Models.Beta.Organization.Analytics.UserUsageReport;
using Webhooks = Anthropic.Models.Beta.Organization.Webhooks;
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
            new ApiEnumConverter<string, ErrorObjectType>(),
            new ApiEnumConverter<string, ErrorType>(),
            new ApiEnumConverter<string, MediaType>(),
            new ApiEnumConverter<string, BashCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, BrowserClickTargetType>(),
            new ApiEnumConverter<string, BrowserReadPageFilter>(),
            new ApiEnumConverter<string, BrowserScrollDirection>(),
            new ApiEnumConverter<string, BrowserStateChangeType>(),
            new ApiEnumConverter<string, BrowserToolUseBlockName>(),
            new ApiEnumConverter<string, Ttl>(),
            new ApiEnumConverter<string, CacheMissReasonType>(),
            new ApiEnumConverter<string, CitationType>(),
            new ApiEnumConverter<string, AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20260120AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20260521AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, ComputerScrollDirection>(),
            new ApiEnumConverter<string, ComputerToolUseBlockName>(),
            new ApiEnumConverter<string, ContainerSkillType>(),
            new ApiEnumConverter<string, ContentBlockType>(),
            new ApiEnumConverter<string, ContentBlockParamType>(),
            new ApiEnumConverter<string, MessageContentBlockSourceContentType>(),
            new ApiEnumConverter<string, SourceType>(),
            new ApiEnumConverter<string, DocumentBlockParamSourceType>(),
            new ApiEnumConverter<string, ImageBlockParamSourceType>(),
            new ApiEnumConverter<string, OversizedImage>(),
            new ApiEnumConverter<string, MemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, MessageParamRole>(),
            new ApiEnumConverter<string, Model>(),
            new ApiEnumConverter<string, Effort>(),
            new ApiEnumConverter<string, RawContentBlockDeltaType>(),
            new ApiEnumConverter<string, RawContentBlockStartEventContentBlockType>(),
            new ApiEnumConverter<string, RawMessageStreamEventType>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, CallerType>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, ServerToolUseBlockParamName>(),
            new ApiEnumConverter<string, ServerToolUseBlockParamCallerType>(),
            new ApiEnumConverter<string, SkillParamsType>(),
            new ApiEnumConverter<string, StopReason>(),
            new ApiEnumConverter<string, TextCitationType>(),
            new ApiEnumConverter<string, TextCitationParamType>(),
            new ApiEnumConverter<string, TextEditorCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, FileType>(),
            new ApiEnumConverter<string, TextEditorCodeExecutionViewResultBlockParamFileType>(),
            new ApiEnumConverter<string, Display>(),
            new ApiEnumConverter<string, ThinkingConfigEnabledDisplay>(),
            new ApiEnumConverter<string, ThinkingConfigParamType>(),
            new ApiEnumConverter<string, ToolAllowedCaller>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ToolBash20250124AllowedCaller>(),
            new ApiEnumConverter<string, ToolChoiceType>(),
            new ApiEnumConverter<string, BlockType>(),
            new ApiEnumConverter<string, ToolSearchToolBm25_20251119Type>(),
            new ApiEnumConverter<string, ToolSearchToolBm25_20251119AllowedCaller>(),
            new ApiEnumConverter<string, ToolSearchToolRegex20251119Type>(),
            new ApiEnumConverter<string, ToolSearchToolRegex20251119AllowedCaller>(),
            new ApiEnumConverter<string, ToolSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, ToolTextEditor20250124AllowedCaller>(),
            new ApiEnumConverter<string, ToolTextEditor20250429AllowedCaller>(),
            new ApiEnumConverter<string, ToolTextEditor20250728AllowedCaller>(),
            new ApiEnumConverter<string, ToolUseBlockCallerType>(),
            new ApiEnumConverter<string, ToolUseBlockParamCallerType>(),
            new ApiEnumConverter<string, ToolUseCallerType>(),
            new ApiEnumConverter<string, UsageServiceTier>(),
            new ApiEnumConverter<string, UsageSpeed>(),
            new ApiEnumConverter<string, WebFetchTool20250910AllowedCaller>(),
            new ApiEnumConverter<string, WebFetchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, WebFetchTool20260309AllowedCaller>(),
            new ApiEnumConverter<string, WebFetchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, ResponseInclusion>(),
            new ApiEnumConverter<string, WebFetchToolResultBlockCallerType>(),
            new ApiEnumConverter<string, WebFetchToolResultBlockParamCallerType>(),
            new ApiEnumConverter<string, WebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, ClientToolResultsType>(),
            new ApiEnumConverter<string, ServerToolResultsType>(),
            new ApiEnumConverter<string, UserInputType>(),
            new ApiEnumConverter<string, WebSearchTool20250305AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260318ResponseInclusion>(),
            new ApiEnumConverter<string, WebSearchToolResultBlockCallerType>(),
            new ApiEnumConverter<string, WebSearchToolResultBlockParamCallerType>(),
            new ApiEnumConverter<string, WebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, Speed>(),
            new ApiEnumConverter<string, MessageCountTokensParamsSpeed>(),
            new ApiEnumConverter<string, Batches::ProcessingStatus>(),
            new ApiEnumConverter<string, Batches::MessageBatchResultType>(),
            new ApiEnumConverter<string, Batches::ServiceTier>(),
            new ApiEnumConverter<string, Batches::Speed>(),
            new ApiEnumConverter<string, ModelInfoLifecycle>(),
            new ApiEnumConverter<string, ModelLine>(),
            new ApiEnumConverter<string, Lifecycle>(),
            new ApiEnumConverter<string, Files::Type>(),
            new ApiEnumConverter<string, Skills::Type>(),
            new ApiEnumConverter<string, UserProfileAccessType>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, UserProfileEfsFeatureStatus>(),
            new ApiEnumConverter<string, UserProfileEnforcementActionType>(),
            new ApiEnumConverter<string, UserProfileEnforcementActionNextStep>(),
            new ApiEnumConverter<string, UserProfileEnforcementActionReason>(),
            new ApiEnumConverter<string, UserProfileEnforcementStatus>(),
            new ApiEnumConverter<string, UserProfileExternalUserAccountStatus>(),
            new ApiEnumConverter<string, UserProfileExternalUserEntityType>(),
            new ApiEnumConverter<string, UserProfileListOrder>(),
            new ApiEnumConverter<string, UserProfileListOrderBy>(),
            new ApiEnumConverter<string, UserProfileProgramStatus>(),
            new ApiEnumConverter<string, UserProfileActionType>(),
            new ApiEnumConverter<string, OrganizationRole>(),
            new ApiEnumConverter<string, ApiKeys::PrincipalType>(),
            new ApiEnumConverter<string, ApiKeys::ScopeType>(),
            new ApiEnumConverter<string, ApiKeys::ApiKeyStatus>(),
            new ApiEnumConverter<string, ApiKeys::Type>(),
            new ApiEnumConverter<string, ApiKeys::Status>(),
            new ApiEnumConverter<string, ApiKeys::ApiKeyListParamsStatus>(),
            new ApiEnumConverter<string, ExternalKeys::AttachmentType>(),
            new ApiEnumConverter<string, ExternalKeys::ExternalKeyProviderConfigType>(),
            new ApiEnumConverter<string, ExternalKeys::Status>(),
            new ApiEnumConverter<string, ExternalKeys::ProviderConfigType>(),
            new ApiEnumConverter<string, ExternalKeys::Geo>(),
            new ApiEnumConverter<string, ExternalKeys::ExternalKeyUpdateParamsGeo>(),
            new ApiEnumConverter<string, ExternalKeys::ExternalKeyUpdateParamsProviderConfigType>(),
            new ApiEnumConverter<string, FederationIssuerJwksType>(),
            new ApiEnumConverter<string, JwksType>(),
            new ApiEnumConverter<string, IssuerUpdateParamsJwksType>(),
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
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, AllowedInferenceGeo>(),
            new ApiEnumConverter<string, DefaultInferenceGeo>(),
            new ApiEnumConverter<string, WorkspaceGeo>(),
            new ApiEnumConverter<string, DataResidencyCreateConfigDefaultInferenceGeo>(),
            new ApiEnumConverter<string, DataResidencyCreateConfigWorkspaceGeo>(),
            new ApiEnumConverter<string, DataResidencyUpdateConfigDefaultInferenceGeo>(),
            new ApiEnumConverter<string, WorkspaceRole>(),
            new ApiEnumConverter<string, RateLimits::GroupTypeValue>(),
            new ApiEnumConverter<string, RateLimits::WorkspaceRateLimitType>(),
            new ApiEnumConverter<string, RateLimits::SourceType>(),
            new ApiEnumConverter<string, RateLimits::GroupType>(),
            new ApiEnumConverter<string, GroupTypeValue>(),
            new ApiEnumConverter<string, GroupType>(),
            new ApiEnumConverter<string, ComplianceSettingsStateType>(),
            new ApiEnumConverter<string, ComplianceSettingsStateParamType>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, BetaCurrency>(),
            new ApiEnumConverter<string, BetaErrorType>(),
            new ApiEnumConverter<string, Models::BetaModelInfoLifecycle>(),
            new ApiEnumConverter<string, Models::BetaModelLine>(),
            new ApiEnumConverter<string, Models::Lifecycle>(),
            new ApiEnumConverter<string, Messages::AllowedCaller>(),
            new ApiEnumConverter<string, Messages::ErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaAdvisorToolResultErrorParamErrorCode>(),
            new ApiEnumConverter<string, Messages::MediaType>(),
            new ApiEnumConverter<string, Messages::BetaBashCodeExecutionToolResultErrorErrorCode>(),
            new ApiEnumConverter<
                string,
                Messages::BetaBashCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, Messages::BetaBrowserClickTargetType>(),
            new ApiEnumConverter<string, Messages::BetaBrowserReadPageFilter>(),
            new ApiEnumConverter<string, Messages::BetaBrowserScrollDirection>(),
            new ApiEnumConverter<string, Messages::BetaBrowserStateChangeType>(),
            new ApiEnumConverter<string, Messages::BetaBrowserToolUseBlockName>(),
            new ApiEnumConverter<string, Messages::Ttl>(),
            new ApiEnumConverter<string, Messages::BetaCacheMissReasonType>(),
            new ApiEnumConverter<string, Messages::CitationType>(),
            new ApiEnumConverter<string, Messages::TriggerType>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250522AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20260120AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20260521AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::ToolChangeType>(),
            new ApiEnumConverter<string, Messages::BetaCompactionBlockParamToolChangeType>(),
            new ApiEnumConverter<string, Messages::BetaComputerScrollDirection>(),
            new ApiEnumConverter<string, Messages::BetaComputerToolUseBlockName>(),
            new ApiEnumConverter<string, Messages::Type>(),
            new ApiEnumConverter<string, Messages::BetaContentBlockType>(),
            new ApiEnumConverter<string, Messages::BetaContentBlockParamType>(),
            new ApiEnumConverter<string, Messages::MessageBetaContentBlockSourceContentType>(),
            new ApiEnumConverter<string, Messages::EditType>(),
            new ApiEnumConverter<string, Messages::AppliedEditType>(),
            new ApiEnumConverter<string, Messages::SourceType>(),
            new ApiEnumConverter<string, Messages::Reason>(),
            new ApiEnumConverter<string, Messages::Mode>(),
            new ApiEnumConverter<string, Messages::StatusType>(),
            new ApiEnumConverter<string, Messages::BetaFallbackParamSpeed>(),
            new ApiEnumConverter<string, Messages::ThinkingType>(),
            new ApiEnumConverter<string, Messages::BetaFallbackRefusalTriggerCategory>(),
            new ApiEnumConverter<string, Messages::BetaImageBlockParamSourceType>(),
            new ApiEnumConverter<string, Messages::OversizedImage>(),
            new ApiEnumConverter<string, Messages::BetaInputTransformationType>(),
            new ApiEnumConverter<string, Messages::BetaMemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaMemoryTool20250818CommandCommand>(),
            new ApiEnumConverter<string, Messages::IterationType>(),
            new ApiEnumConverter<string, Messages::BetaMessageParamRole>(),
            new ApiEnumConverter<string, Messages::BetaMessageThreadParamType>(),
            new ApiEnumConverter<string, Messages::Effort>(),
            new ApiEnumConverter<string, Messages::BetaRawContentBlockDeltaType>(),
            new ApiEnumConverter<string, Messages::ContentBlockType>(),
            new ApiEnumConverter<string, Messages::BetaRawMessageStreamEventType>(),
            new ApiEnumConverter<string, Messages::Category>(),
            new ApiEnumConverter<string, Messages::BetaRequestDocumentBlockSourceType>(),
            new ApiEnumConverter<string, Messages::BetaRequestToolAdditionBlockToolType>(),
            new ApiEnumConverter<string, Messages::BetaRequestToolRemovalBlockToolType>(),
            new ApiEnumConverter<string, Messages::BetaResponseToolAllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaResponseToolType>(),
            new ApiEnumConverter<string, Messages::BetaResponseToolAdditionBlockToolType>(),
            new ApiEnumConverter<string, Messages::BetaResponseToolRemovalBlockToolType>(),
            new ApiEnumConverter<string, Messages::Name>(),
            new ApiEnumConverter<string, Messages::CallerType>(),
            new ApiEnumConverter<string, Messages::BetaServerToolUseBlockParamName>(),
            new ApiEnumConverter<string, Messages::BetaServerToolUseBlockParamCallerType>(),
            new ApiEnumConverter<string, Messages::BetaSkillParamsType>(),
            new ApiEnumConverter<string, Messages::BetaStopReason>(),
            new ApiEnumConverter<string, Messages::BetaSystemMessageOutputConfigEffort>(),
            new ApiEnumConverter<string, Messages::ClearAt>(),
            new ApiEnumConverter<string, Messages::SystemMessageContentBlockType>(),
            new ApiEnumConverter<string, Messages::BetaTextCitationType>(),
            new ApiEnumConverter<string, Messages::BetaTextCitationParamType>(),
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
            new ApiEnumConverter<string, Messages::BetaThinkingConfigParamType>(),
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
            new ApiEnumConverter<string, Messages::BetaToolChoiceType>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20251124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BlockType>(),
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
            new ApiEnumConverter<string, Messages::BetaToolUseBlockCallerType>(),
            new ApiEnumConverter<string, Messages::BetaToolUseBlockParamCallerType>(),
            new ApiEnumConverter<string, Messages::BetaToolUseCallerType>(),
            new ApiEnumConverter<string, Messages::BetaUsageIterationType>(),
            new ApiEnumConverter<string, Messages::BetaUsageServiceTier>(),
            new ApiEnumConverter<string, Messages::BetaUsageSpeed>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20250910AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20260309AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, Messages::ResponseInclusion>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultBlockCallerType>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultBlockParamCallerType>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::ClientToolResultsType>(),
            new ApiEnumConverter<string, Messages::ServerToolResultsType>(),
            new ApiEnumConverter<string, Messages::UserInputType>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20250305AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260318AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260318ResponseInclusion>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchToolResultBlockCallerType>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchToolResultBlockParamCallerType>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::ServiceTier>(),
            new ApiEnumConverter<string, Messages::Speed>(),
            new ApiEnumConverter<string, Messages::MessageCountTokensParamsSpeed>(),
            new ApiEnumConverter<string, MessagesBatches::ProcessingStatus>(),
            new ApiEnumConverter<string, MessagesBatches::BetaMessageBatchResultType>(),
            new ApiEnumConverter<string, MessagesBatches::ServiceTier>(),
            new ApiEnumConverter<string, MessagesBatches::Speed>(),
            new ApiEnumConverter<string, Agents::SkillType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolConfigType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::PermissionPolicyType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsBashToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsBashToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::Type>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsEditToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsEditToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEditToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsExecutionIdentityType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsExecutionIdentityParamsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsGlobToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsGlobToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsGlobToolConfigParamsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsGrepToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsGrepToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsGrepToolConfigParamsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsMcpToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsMcpToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsMcpToolsetDefaultConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsModel>(),
            new ApiEnumConverter<string, Agents::EffortType>(),
            new ApiEnumConverter<string, Agents::Speed>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsEffortLevel>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsModelConfigParamsSpeed>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentAdvisorType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentAdvisorParamsType>(),
            new ApiEnumConverter<string, Agents::AgentType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentInlineAgentsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsMultiagentInlineAgentsParamsType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentSubagentsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentSubagentsParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentWorkflowsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMultiagentWorkflowsParamsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsReadToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsReadToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsReadToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsSessionThreadAgentSkillType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsSessionThreadAgentToolType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsSkillParamsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWebFetchToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWebFetchToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebFetchToolConfigParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebFetchUrlSourceShorthand>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWebFetchUrlSourceToolFilterType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebFetchUrlSourceUserInputType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWebSearchToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWebSearchToolConfigParamsType>(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWriteToolConfigPermissionPolicyType
            >(),
            new ApiEnumConverter<
                string,
                Agents::BetaManagedAgentsWriteToolConfigParamsPermissionPolicyType
            >(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsWriteToolConfigParamsType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsMultiagentParamsType>(),
            new ApiEnumConverter<string, Agents::ToolType>(),
            new ApiEnumConverter<string, Agents::AgentUpdateParamsToolType>(),
            new ApiEnumConverter<string, Environments::NetworkingType>(),
            new ApiEnumConverter<string, Environments::BetaCloudConfigParamsNetworkingType>(),
            new ApiEnumConverter<string, Environments::BetaEnvironmentConfigType>(),
            new ApiEnumConverter<string, Environments::BetaEnvironmentScope>(),
            new ApiEnumConverter<string, Environments::Type>(),
            new ApiEnumConverter<string, Environments::BetaPackagesParamsType>(),
            new ApiEnumConverter<string, Environments::ConfigType>(),
            new ApiEnumConverter<string, Environments::Scope>(),
            new ApiEnumConverter<string, Environments::EnvironmentUpdateParamsConfigType>(),
            new ApiEnumConverter<string, Environments::EnvironmentUpdateParamsScope>(),
            new ApiEnumConverter<string, State>(),
            new ApiEnumConverter<string, BetaSelfHostedWorkHeartbeatResponseState>(),
            new ApiEnumConverter<string, Sessions::ToolType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsDeltaType>(),
            new ApiEnumConverter<string, Sessions::CheckoutType>(),
            new ApiEnumConverter<string, Sessions::Access>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsMultiagentType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionStatus>(),
            new ApiEnumConverter<string, Sessions::SkillType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionAgentToolType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionAgentUpdateToolType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionMultiagentType>(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsSessionMultiagentCoordinatorAgentType
            >(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsSessionMultiagentSubagentsType
            >(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsSessionMultiagentWorkflowsType
            >(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsStartEventPreviewType>(),
            new ApiEnumConverter<string, Sessions::ContentType>(),
            new ApiEnumConverter<string, Sessions::InitialEventType>(),
            new ApiEnumConverter<string, Sessions::ResourceType>(),
            new ApiEnumConverter<string, Sessions::Order>(),
            new ApiEnumConverter<string, Sessions::Status>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentAutoEvaluatedPermissionType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentEvaluatedPermission>(),
            new ApiEnumConverter<string, Events::ContentType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMessageEventContentType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentThreadMessageReceivedEventContentType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentThreadMessageSentEventContentType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentToolEvaluationType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentToolResultEventContentType
            >(),
            new ApiEnumConverter<string, Events::RetryStatusType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsCredentialHostUnreachableErrorRetryStatusType
            >(),
            new ApiEnumConverter<string, Events::SourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsEventParamsType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsImageBlockSourceType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsModelOverloadedErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsModelRateLimitedErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsModelRequestFailedErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsRepositoryCheckoutErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsRepositoryCloneErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsRepositoryForbiddenErrorRetryStatusType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType
            >(),
            new ApiEnumConverter<string, Events::DataType>(),
            new ApiEnumConverter<string, Events::ErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionEventTypeValue>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionEventType>(),
            new ApiEnumConverter<string, Events::Category>(),
            new ApiEnumConverter<string, Events::StopReasonType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType
            >(),
            new ApiEnumConverter<string, Events::Speed>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsStreamSessionEventsType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUnknownErrorRetryStatusType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserCustomToolResultEventContentType
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserCustomToolResultEventParamsContentType
            >(),
            new ApiEnumConverter<string, Events::RubricType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserDefineOutcomeEventParamsRubricType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserMessageEventContentType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserMessageEventParamsContentType
            >(),
            new ApiEnumConverter<string, Events::Result>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserToolConfirmationEventParamsResult
            >(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserToolResultEventParamsContentType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsWorkflowRunErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsWorkflowRunResultType>(),
            new ApiEnumConverter<string, Events::Order>(),
            new ApiEnumConverter<string, CheckoutType>(),
            new ApiEnumConverter<string, Access>(),
            new ApiEnumConverter<string, BetaManagedAgentsSessionResourceType>(),
            new ApiEnumConverter<string, ResourceRetrieveResponseType>(),
            new ApiEnumConverter<string, ResourceUpdateResponseType>(),
            new ApiEnumConverter<string, SkillType>(),
            new ApiEnumConverter<string, ToolType>(),
            new ApiEnumConverter<string, AgentType>(),
            new ApiEnumConverter<string, BetaManagedAgentsSessionThreadStatus>(),
            new ApiEnumConverter<string, BetaManagedAgentsStreamSessionThreadEventsType>(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentInitialEventType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentInitialEventParamsType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentPausedReasonType
            >(),
            new ApiEnumConverter<
                string,
                Deployments::BetaManagedAgentsDeploymentPausedReasonErrorType
            >(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsDeploymentStatus>(),
            new ApiEnumConverter<string, Deployments::RubricType>(),
            new ApiEnumConverter<string, Deployments::ContentType>(),
            new ApiEnumConverter<string, Deployments::CheckoutType>(),
            new ApiEnumConverter<string, Deployments::Access>(),
            new ApiEnumConverter<string, Deployments::BetaManagedAgentsSessionResourceConfigType>(),
            new ApiEnumConverter<string, Deployments::ResourceType>(),
            new ApiEnumConverter<string, Deployments::DeploymentUpdateParamsResourceType>(),
            new ApiEnumConverter<string, DeploymentRuns::ErrorType>(),
            new ApiEnumConverter<string, DeploymentRuns::BetaManagedAgentsTriggerContextType>(),
            new ApiEnumConverter<string, DeploymentRuns::BetaManagedAgentsTriggerType>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsCredentialAuthType>(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsCredentialNetworkingParamsType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsCredentialValidationStatus
            >(),
            new ApiEnumConverter<string, Credentials::NetworkingType>(),
            new ApiEnumConverter<string, Credentials::TokenEndpointAuthType>(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType
            >(),
            new ApiEnumConverter<
                string,
                Credentials::BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuthType
            >(),
            new ApiEnumConverter<string, Credentials::Status>(),
            new ApiEnumConverter<string, Credentials::AuthType>(),
            new ApiEnumConverter<string, Credentials::CredentialUpdateParamsAuthType>(),
            new ApiEnumConverter<string, BetaManagedAgentsErrorType>(),
            new ApiEnumConverter<string, BetaManagedAgentsMemoryListItemType>(),
            new ApiEnumConverter<string, BetaManagedAgentsMemoryView>(),
            new ApiEnumConverter<string, BetaManagedAgentsActorType>(),
            new ApiEnumConverter<string, BetaManagedAgentsMemoryVersionOperation>(),
            new ApiEnumConverter<string, BetaFiles::Type>(),
            new ApiEnumConverter<string, BetaSkills::Type>(),
            new ApiEnumConverter<string, BetaWebhookEventDataType>(),
            new ApiEnumConverter<string, UserProfiles::BetaUserProfileAccessType>(),
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
            new ApiEnumConverter<string, BetaUserProfileActionType>(),
            new ApiEnumConverter<string, Dreams::BetaDreamInputType>(),
            new ApiEnumConverter<string, Dreams::Speed>(),
            new ApiEnumConverter<string, Dreams::BetaDreamModelConfigParamSpeed>(),
            new ApiEnumConverter<string, Dreams::BetaDreamStatus>(),
            new ApiEnumConverter<string, Dreams::BetaDreamingErrorType>(),
            new ApiEnumConverter<string, Dreams::BetaOutputBehaviorType>(),
            new ApiEnumConverter<string, BetaOrganizationRole>(),
            new ApiEnumConverter<string, OrganizationApiKeys::PrincipalType>(),
            new ApiEnumConverter<string, OrganizationApiKeys::ScopeType>(),
            new ApiEnumConverter<string, OrganizationApiKeys::BetaApiKeyStatus>(),
            new ApiEnumConverter<string, OrganizationApiKeys::Type>(),
            new ApiEnumConverter<string, OrganizationApiKeys::Status>(),
            new ApiEnumConverter<string, OrganizationApiKeys::ApiKeyListParamsStatus>(),
            new ApiEnumConverter<string, OrganizationExternalKeys::AttachmentType>(),
            new ApiEnumConverter<
                string,
                OrganizationExternalKeys::BetaExternalKeyProviderConfigType
            >(),
            new ApiEnumConverter<string, OrganizationExternalKeys::Status>(),
            new ApiEnumConverter<string, OrganizationExternalKeys::ProviderConfigType>(),
            new ApiEnumConverter<string, OrganizationExternalKeys::Geo>(),
            new ApiEnumConverter<string, OrganizationExternalKeys::ExternalKeyUpdateParamsGeo>(),
            new ApiEnumConverter<
                string,
                OrganizationExternalKeys::ExternalKeyUpdateParamsProviderConfigType
            >(),
            new ApiEnumConverter<string, Issuers::BetaFederationIssuerJwksType>(),
            new ApiEnumConverter<string, Issuers::JwksType>(),
            new ApiEnumConverter<string, Issuers::IssuerUpdateParamsJwksType>(),
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
            new ApiEnumConverter<string, Users::Role>(),
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
            new ApiEnumConverter<string, WorkspacesRateLimits::GroupTypeValue>(),
            new ApiEnumConverter<string, WorkspacesRateLimits::BetaWorkspaceRateLimitType>(),
            new ApiEnumConverter<string, WorkspacesRateLimits::SourceType>(),
            new ApiEnumConverter<string, WorkspacesRateLimits::GroupType>(),
            new ApiEnumConverter<string, OrganizationRateLimits::GroupTypeValue>(),
            new ApiEnumConverter<string, OrganizationRateLimits::GroupType>(),
            new ApiEnumConverter<string, BetaComplianceSettingsStateType>(),
            new ApiEnumConverter<string, BetaComplianceSettingsStateParamType>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsActorTypeValue>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsActorType>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsClaudeTagCategory>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsContextWindow>(),
            new ApiEnumConverter<string, Analytics::InferenceGeo>(),
            new ApiEnumConverter<string, Analytics::Speed>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsCostType>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsCostUsersItemInferenceGeo>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsCostUsersItemSpeed>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsFederatedActorProviderType>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsGroupedCostType>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsInferenceGeoFilter>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsProductFilter>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsServiceTier>(),
            new ApiEnumConverter<string, Analytics::ShareStatus>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsSpeed>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsTimeBucketWidth>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsTokenType>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageBucketedResultInferenceGeo>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageBucketedResultSpeed>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageCostInferenceGeo>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageCostProductFilter>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageCostSortOrder>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageUsersItemInferenceGeo>(),
            new ApiEnumConverter<string, Analytics::BetaAnalyticsUsageUsersItemSpeed>(),
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
            new ApiEnumConverter<string, BetaAnalyticsUsageGroupBy>(),
            new ApiEnumConverter<string, BetaAnalyticsUsageOrderBy>(),
            new ApiEnumConverter<string, BetaAnalyticsCostGroupBy>(),
            new ApiEnumConverter<string, BetaAnalyticsCostOrderBy>(),
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
            new ApiEnumConverter<string, SpendLimits::BetaSpendLimitScopeType>(),
            new ApiEnumConverter<string, SpendLimits::BetaSpendLimitPeriod>(),
            new ApiEnumConverter<string, SpendLimits::ActorType>(),
            new ApiEnumConverter<string, SpendLimits::BetaSpendSummaryScopeType>(),
            new ApiEnumConverter<string, SpendLimits::SourceType>(),
            new ApiEnumConverter<string, SpendLimits::ScopeType>(),
            new ApiEnumConverter<string, SpendLimits::ScopeTypeValue>(),
            new ApiEnumConverter<string, Period>(),
            new ApiEnumConverter<string, ActorType>(),
            new ApiEnumConverter<string, ResolvedByType>(),
            new ApiEnumConverter<string, BetaSpendLimitIncreaseRequestStatus>(),
            new ApiEnumConverter<string, IncreaseRequestApproveResponseActorType>(),
            new ApiEnumConverter<string, IncreaseRequestApproveResponseResolvedByType>(),
            new ApiEnumConverter<string, RbacGroups::SourceType>(),
            new ApiEnumConverter<string, ResourceType>(),
            new ApiEnumConverter<string, OrganizationPlugins::CreatedByType>(),
            new ApiEnumConverter<string, OrganizationPlugins::OrganizationInstallationPreference>(),
            new ApiEnumConverter<string, OrganizationPlugins::OwnerTypeValue>(),
            new ApiEnumConverter<string, OrganizationPlugins::Reach>(),
            new ApiEnumConverter<string, OrganizationPlugins::Type>(),
            new ApiEnumConverter<string, OrganizationPlugins::Assessment>(),
            new ApiEnumConverter<string, OrganizationPlugins::Status>(),
            new ApiEnumConverter<string, OrganizationPlugins::OwnerType>(),
            new ApiEnumConverter<string, CreatedByType>(),
            new ApiEnumConverter<string, Reach>(),
            new ApiEnumConverter<string, TargetTypeValue>(),
            new ApiEnumConverter<string, BetaPluginInstallationSettingInstallationPreference>(),
            new ApiEnumConverter<string, BetaPluginInstallationSettingTargetType>(),
            new ApiEnumConverter<string, TargetType>(),
            new ApiEnumConverter<string, InstallationPreference>(),
            new ApiEnumConverter<string, Shares::TargetTypeValue>(),
            new ApiEnumConverter<string, Shares::TargetType>(),
            new ApiEnumConverter<
                string,
                PluginMarketplaces::BetaPluginMarketplaceDefaultInstallationPreference
            >(),
            new ApiEnumConverter<string, PluginMarketplaces::OwnerTypeValue>(),
            new ApiEnumConverter<string, PluginMarketplaces::BetaPluginMarketplaceSource>(),
            new ApiEnumConverter<string, PluginMarketplaces::SyncStatus>(),
            new ApiEnumConverter<string, PluginMarketplaces::DefaultInstallationPreference>(),
            new ApiEnumConverter<string, PluginMarketplaces::OwnerType>(),
            new ApiEnumConverter<string, PluginMarketplaces::Source>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationContentMode>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationDisabledReasonType>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationStateType>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationStateParamsType>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationTestResultType>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationWorkspacesType>(),
            new ApiEnumConverter<string, BetaTelemetryDestinationWorkspacesParamsType>(),
            new ApiEnumConverter<
                string,
                Webhooks::BetaNewOrganizationWebhookEndpointEnabledEvent
            >(),
            new ApiEnumConverter<string, Webhooks::BetaOrganizationWebhookEndpointEnabledEvent>(),
            new ApiEnumConverter<string, Webhooks::BetaOrganizationWebhookEndpointState>(),
            new ApiEnumConverter<string, Webhooks::EnabledEvent>(),
            new ApiEnumConverter<string, Webhooks::WebhookUpdateParamsEnabledEvent>(),
            new ApiEnumConverter<string, Webhooks::State>(),
            new ApiEnumConverter<string, Webhooks::Order>(),
            new ApiEnumConverter<string, BetaClaudeTagGuestPolicyType>(),
            new ApiEnumConverter<string, BetaClaudeTagSettingSourceType>(),
            new ApiEnumConverter<string, BetaClaudeTagBundleTargetType>(),
            new ApiEnumConverter<string, BetaClaudeTagBundleTargetCreateType>(),
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
