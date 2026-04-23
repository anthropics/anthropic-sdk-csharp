using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Messages;
using Agents = Anthropic.Models.Beta.Agents;
using Batches = Anthropic.Models.Messages.Batches;
using Credentials = Anthropic.Models.Beta.Vaults.Credentials;
using Environments = Anthropic.Models.Beta.Environments;
using Events = Anthropic.Models.Beta.Sessions.Events;
using Files = Anthropic.Models.Beta.Files;
using Memories = Anthropic.Models.Beta.MemoryStores.Memories;
using MemoryStores = Anthropic.Models.Beta.MemoryStores;
using MemoryVersions = Anthropic.Models.Beta.MemoryStores.MemoryVersions;
using Messages = Anthropic.Models.Beta.Messages;
using MessagesBatches = Anthropic.Models.Beta.Messages.Batches;
using Resources = Anthropic.Models.Beta.Sessions.Resources;
using Sessions = Anthropic.Models.Beta.Sessions;
using UserProfiles = Anthropic.Models.Beta.UserProfiles;
using Vaults = Anthropic.Models.Beta.Vaults;

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
            new ApiEnumConverter<string, Ttl>(),
            new ApiEnumConverter<string, AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionTool20260120AllowedCaller>(),
            new ApiEnumConverter<string, CodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, MemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, Model>(),
            new ApiEnumConverter<string, Effort>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, ServerToolUseBlockParamName>(),
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
            new ApiEnumConverter<string, WebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, WebSearchTool20250305AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, WebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, Batches::ProcessingStatus>(),
            new ApiEnumConverter<string, Batches::ServiceTier>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, Messages::AllowedCaller>(),
            new ApiEnumConverter<string, Messages::ErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaAdvisorToolResultErrorParamErrorCode>(),
            new ApiEnumConverter<string, Messages::MediaType>(),
            new ApiEnumConverter<string, Messages::BetaBashCodeExecutionToolResultErrorErrorCode>(),
            new ApiEnumConverter<
                string,
                Messages::BetaBashCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, Messages::Ttl>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250522AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20260120AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaMemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, Messages::Role>(),
            new ApiEnumConverter<string, Messages::Effort>(),
            new ApiEnumConverter<string, Messages::Category>(),
            new ApiEnumConverter<string, Messages::Name>(),
            new ApiEnumConverter<string, Messages::BetaServerToolUseBlockParamName>(),
            new ApiEnumConverter<string, Messages::Type>(),
            new ApiEnumConverter<string, Messages::BetaSkillParamsType>(),
            new ApiEnumConverter<string, Messages::BetaStopReason>(),
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
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20250305AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20260209AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::ServiceTier>(),
            new ApiEnumConverter<string, Messages::Speed>(),
            new ApiEnumConverter<string, Messages::MessageCountTokensParamsSpeed>(),
            new ApiEnumConverter<string, MessagesBatches::ProcessingStatus>(),
            new ApiEnumConverter<string, MessagesBatches::ServiceTier>(),
            new ApiEnumConverter<string, MessagesBatches::Speed>(),
            new ApiEnumConverter<string, Agents::Type>(),
            new ApiEnumConverter<string, Agents::Name>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolConfigParamsName>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolset20260401Type>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAgentToolset20260401ParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAlwaysAllowPolicyType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAlwaysAskPolicyType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAnthropicSkillType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsAnthropicSkillParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomSkillType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomSkillParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomToolType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomToolInputSchemaType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsCustomToolParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMcpServerUrlDefinitionType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMcpToolsetType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsMcpToolsetParamsType>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsModel>(),
            new ApiEnumConverter<string, Agents::Speed>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsModelConfigParamsSpeed>(),
            new ApiEnumConverter<string, Agents::BetaManagedAgentsUrlMcpServerParamsType>(),
            new ApiEnumConverter<string, Environments::Type>(),
            new ApiEnumConverter<string, Environments::BetaPackagesParamsType>(),
            new ApiEnumConverter<string, Sessions::Type>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsBranchCheckoutType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsCommitCheckoutType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsDeletedSessionType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsFileResourceParamsType>(),
            new ApiEnumConverter<
                string,
                Sessions::BetaManagedAgentsGitHubRepositoryResourceParamsType
            >(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsMemoryStoreResourceParamType>(),
            new ApiEnumConverter<string, Sessions::Access>(),
            new ApiEnumConverter<string, Sessions::Status>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionType>(),
            new ApiEnumConverter<string, Sessions::BetaManagedAgentsSessionAgentType>(),
            new ApiEnumConverter<string, Sessions::Order>(),
            new ApiEnumConverter<string, Events::Type>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMcpToolResultEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMcpToolUseEventType>(),
            new ApiEnumConverter<string, Events::EvaluatedPermission>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentMessageEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentThinkingEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentThreadContextCompactedEventType
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentToolResultEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsAgentToolUseEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsAgentToolUseEventEvaluatedPermission
            >(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsBase64DocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsBase64ImageSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsBillingErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsDocumentBlockType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsFileDocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsFileImageSourceType>(),
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
            new ApiEnumConverter<string, Events::BetaManagedAgentsRetryStatusExhaustedType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsRetryStatusRetryingType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsRetryStatusTerminalType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionDeletedEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionEndTurnType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSessionErrorEventType>(),
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
            new ApiEnumConverter<string, Events::BetaManagedAgentsSpanModelRequestEndEventType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsSpanModelRequestStartEventType>(),
            new ApiEnumConverter<string, Events::Speed>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsTextBlockType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUnknownErrorType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUrlDocumentSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUrlImageSourceType>(),
            new ApiEnumConverter<string, Events::BetaManagedAgentsUserCustomToolResultEventType>(),
            new ApiEnumConverter<
                string,
                Events::BetaManagedAgentsUserCustomToolResultEventParamsType
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
            new ApiEnumConverter<string, Vaults::Type>(),
            new ApiEnumConverter<string, Vaults::BetaManagedAgentsVaultType>(),
            new ApiEnumConverter<string, Credentials::Type>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsDeletedCredentialType>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsMcpOAuthAuthResponseType>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsMcpOAuthCreateParamsType>(),
            new ApiEnumConverter<string, Credentials::BetaManagedAgentsMcpOAuthUpdateParamsType>(),
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
            new ApiEnumConverter<string, Memories::Order>(),
            new ApiEnumConverter<string, MemoryVersions::Type>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsMemoryVersionType>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsMemoryVersionOperation>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsSessionActorType>(),
            new ApiEnumConverter<string, MemoryVersions::BetaManagedAgentsUserActorType>(),
            new ApiEnumConverter<string, Files::Type>(),
            new ApiEnumConverter<string, UserProfiles::Type>(),
            new ApiEnumConverter<string, UserProfiles::BetaUserProfileEnrollmentUrlType>(),
            new ApiEnumConverter<string, UserProfiles::Status>(),
            new ApiEnumConverter<string, UserProfiles::Order>(),
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
