using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments;
using Anthropic.Models.Beta.Environments.Work;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Files;
using Anthropic.Models.Messages;
using Anthropic.Models.Organization;
using Anthropic.Models.Organization.ApiKeys;
using Anthropic.Models.Organization.ExternalKeys;
using Anthropic.Models.Organization.Invites;
using Anthropic.Models.Organization.RbacGroups;
using Anthropic.Models.Organization.Users;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.Skills;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models;

public class ErrorDetailsTest : TestBase
{
    [Fact]
    public void AvailableToolsLimitExceededValidationWorks()
    {
        ErrorDetails value = new AvailableToolsLimitExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ClaudeCodeKeyCreatorNotMemberValidationWorks()
    {
        ErrorDetails value = new ClaudeCodeKeyCreatorNotMemberErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ClaudeCodeVersionTooOldValidationWorks()
    {
        ErrorDetails value = new ClaudeCodeVersionTooOldErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CmekKeyDisabledValidationWorks()
    {
        ErrorDetails value = new CmekKeyDisabledErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CmekKeyNetworkBlockedValidationWorks()
    {
        ErrorDetails value = new CmekKeyNetworkBlockedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionBlockAmbiguousValidationWorks()
    {
        ErrorDetails value = new CompactionBlockAmbiguousErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionBlockMisplacedValidationWorks()
    {
        ErrorDetails value = new CompactionBlockMisplacedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionContentMismatchValidationWorks()
    {
        ErrorDetails value = new CompactionContentMismatchErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionIncompleteTurnValidationWorks()
    {
        ErrorDetails value = new CompactionIncompleteTurnErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionNothingToSummarizeValidationWorks()
    {
        ErrorDetails value = new CompactionNothingToSummarizeErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionSignatureInvalidValidationWorks()
    {
        ErrorDetails value = new CompactionSignatureInvalidErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionTooManyToolReferencesValidationWorks()
    {
        ErrorDetails value = new CompactionTooManyToolReferencesErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionToolChangesMismatchValidationWorks()
    {
        ErrorDetails value = new CompactionToolChangesMismatchErrorDetails();
        value.Validate();
    }

    [Fact]
    public void OrganizationOnHoldValidationWorks()
    {
        ErrorDetails value = new OrganizationOnHoldErrorDetails() { AppealUrl = "appeal_url" };
        value.Validate();
    }

    [Fact]
    public void RequestBodyEncodingInvalidValidationWorks()
    {
        ErrorDetails value = new RequestBodyEncodingInvalidErrorDetails();
        value.Validate();
    }

    [Fact]
    public void RequestBodyEncodingUnsupportedValidationWorks()
    {
        ErrorDetails value = new RequestBodyEncodingUnsupportedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ThreadAlreadyContinuedValidationWorks()
    {
        ErrorDetails value = new ThreadAlreadyContinuedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ThreadContinueInFlightValidationWorks()
    {
        ErrorDetails value = new ThreadContinueInFlightErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ThreadFingerprintMismatchValidationWorks()
    {
        ErrorDetails value = new ThreadFingerprintMismatchErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ThreadUnsupportedRequestValidationWorks()
    {
        ErrorDetails value = new ThreadUnsupportedRequestErrorDetails()
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };
        value.Validate();
    }

    [Fact]
    public void ToolNameConflictValidationWorks()
    {
        ErrorDetails value = new ToolNameConflictErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ToolReferenceUnresolvedValidationWorks()
    {
        ErrorDetails value = new ToolReferenceUnresolvedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ThreadNotFoundValidationWorks()
    {
        ErrorDetails value = new ThreadNotFoundErrorDetails();
        value.Validate();
    }

    [Fact]
    public void SkillReadBlockedUndecryptableValidationWorks()
    {
        ErrorDetails value = new SkillReadBlockedUndecryptableErrorDetails();
        value.Validate();
    }

    [Fact]
    public void RequestBodyTooLargeAfterDecodingValidationWorks()
    {
        ErrorDetails value = new RequestBodyTooLargeAfterDecodingErrorDetails();
        value.Validate();
    }

    [Fact]
    public void EnforcedSpendLimitReachedValidationWorks()
    {
        ErrorDetails value = new EnforcedSpendLimitReachedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void RampLimitExceededValidationWorks()
    {
        ErrorDetails value = new RampLimitExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CmekKeyUnreachableValidationWorks()
    {
        ErrorDetails value = new CmekKeyUnreachableErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CompactionUnavailableValidationWorks()
    {
        ErrorDetails value = new CompactionUnavailableErrorDetails();
        value.Validate();
    }

    [Fact]
    public void StorageQuotaExceededValidationWorks()
    {
        ErrorDetails value = new StorageQuotaExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void FileNotDownloadableValidationWorks()
    {
        ErrorDetails value = new FileNotDownloadableErrorDetails();
        value.Validate();
    }

    [Fact]
    public void FileExpiredValidationWorks()
    {
        ErrorDetails value = new FileExpiredErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CmekContextUnavailableValidationWorks()
    {
        ErrorDetails value = new CmekContextUnavailableErrorDetails();
        value.Validate();
    }

    [Fact]
    public void OrgApiKeyLimitExceededValidationWorks()
    {
        ErrorDetails value = new OrgApiKeyLimitExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void WorkspaceApiKeyLimitExceededValidationWorks()
    {
        ErrorDetails value = new WorkspaceApiKeyLimitExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void UserProfileNotFoundValidationWorks()
    {
        ErrorDetails value = new UserProfileNotFoundErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ExternalKeyInWorkspacePolicyValidationWorks()
    {
        ErrorDetails value = new ExternalKeyInWorkspacePolicyErrorDetails();
        value.Validate();
    }

    [Fact]
    public void AlreadyMemberValidationWorks()
    {
        ErrorDetails value = new AlreadyMemberErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CannotInviteEmailsWithUnverifiedDomainsValidationWorks()
    {
        ErrorDetails value = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails();
        value.Validate();
    }

    [Fact]
    public void EmailDomainNotAllowedValidationWorks()
    {
        ErrorDetails value = new EmailDomainNotAllowedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void InviteAlreadyExistsValidationWorks()
    {
        ErrorDetails value = new InviteAlreadyExistsErrorDetails();
        value.Validate();
    }

    [Fact]
    public void OrgMemberLimitExceededValidationWorks()
    {
        ErrorDetails value = new OrgMemberLimitExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void RbacGroupGrantsOwnerAccessValidationWorks()
    {
        ErrorDetails value = new RbacGroupGrantsOwnerAccessErrorDetails();
        value.Validate();
    }

    [Fact]
    public void RbacGroupOwnerAccessUnconfirmedValidationWorks()
    {
        ErrorDetails value = new RbacGroupOwnerAccessUnconfirmedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void CannotRemoveLastMemberValidationWorks()
    {
        ErrorDetails value = new CannotRemoveLastMemberErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ConcurrentMembershipChangeValidationWorks()
    {
        ErrorDetails value = new ConcurrentMembershipChangeErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ExternalKeyValidationFailedValidationWorks()
    {
        ErrorDetails value = new ExternalKeyValidationFailedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void ExternalKeyValidationTimedOutValidationWorks()
    {
        ErrorDetails value = new ExternalKeyValidationTimedOutErrorDetails();
        value.Validate();
    }

    [Fact]
    public void KeyProfileMismatchValidationWorks()
    {
        ErrorDetails value = new KeyProfileMismatchErrorDetails();
        value.Validate();
    }

    [Fact]
    public void WorkspacePolicyViolationValidationWorks()
    {
        ErrorDetails value = new WorkspacePolicyViolationErrorDetails(
            WorkspacePolicyField.ExternalKeyID
        );
        value.Validate();
    }

    [Fact]
    public void ExternalKeyChangedValidationWorks()
    {
        ErrorDetails value = new ExternalKeyChangedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void WorkspaceMemberLimitExceededValidationWorks()
    {
        ErrorDetails value = new WorkspaceMemberLimitExceededErrorDetails();
        value.Validate();
    }

    [Fact]
    public void OrganizationTypeNotSupportedValidationWorks()
    {
        ErrorDetails value = new OrganizationTypeNotSupportedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaEnvironmentCreateDisabledValidationWorks()
    {
        ErrorDetails value = new BetaEnvironmentCreateDisabledErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaEnvironmentArchivedValidationWorks()
    {
        ErrorDetails value = new BetaEnvironmentArchivedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaInvalidConfigTypeChangeValidationWorks()
    {
        ErrorDetails value = new BetaInvalidConfigTypeChangeErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaEnvironmentUpdateDisabledValidationWorks()
    {
        ErrorDetails value = new BetaEnvironmentUpdateDisabledErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaHeartbeatPreconditionFailedValidationWorks()
    {
        ErrorDetails value = new BetaHeartbeatPreconditionFailedErrorDetails(
            new BetaWorkLeaseState()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaInvalidMetadataValidationWorks()
    {
        ErrorDetails value = new BetaInvalidMetadataErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaBillingFrozenValidationWorks()
    {
        ErrorDetails value = new BetaBillingFrozenErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitsAdminApiWritesNotEnabledValidationWorks()
    {
        ErrorDetails value = new BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaUnsupportedCharsetValidationWorks()
    {
        ErrorDetails value = new BetaUnsupportedCharsetErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaPluginNameTakenValidationWorks()
    {
        ErrorDetails value = new BetaPluginNameTakenErrorDetails() { PluginID = "plugin_id" };
        value.Validate();
    }

    [Fact]
    public void BetaSkillNameTakenValidationWorks()
    {
        ErrorDetails value = new BetaSkillNameTakenErrorDetails("skill_name");
        value.Validate();
    }

    [Fact]
    public void BetaRegistrationPendingValidationWorks()
    {
        ErrorDetails value = new BetaRegistrationPendingErrorDetails()
        {
            PluginID = "plugin_id",
            PluginVersionID = "plugin_version_id",
        };
        value.Validate();
    }

    [Fact]
    public void BetaScanFailedValidationWorks()
    {
        ErrorDetails value = new BetaScanFailedErrorDetails("plugin_version_id");
        value.Validate();
    }

    [Fact]
    public void BetaScanPendingValidationWorks()
    {
        ErrorDetails value = new BetaScanPendingErrorDetails("plugin_version_id");
        value.Validate();
    }

    [Fact]
    public void BetaSlackChannelSetUpSettingsRefusedValidationWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpSettingsRefusedErrorDetails(
            "slack_channel_id"
        );
        value.Validate();
    }

    [Fact]
    public void BetaApiKeyScopeMissingValidationWorks()
    {
        ErrorDetails value = new BetaApiKeyScopeMissingErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaClaudeTagWritesNotEnabledValidationWorks()
    {
        ErrorDetails value = new BetaClaudeTagWritesNotEnabledErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaComplianceConfigurationRestrictedValidationWorks()
    {
        ErrorDetails value = new BetaComplianceConfigurationRestrictedErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationLevelScopedApiKeyRequiredValidationWorks()
    {
        ErrorDetails value = new BetaOrganizationLevelScopedApiKeyRequiredErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaEnvironmentNotFoundValidationWorks()
    {
        ErrorDetails value = new BetaEnvironmentNotFoundErrorDetails();
        value.Validate();
    }

    [Fact]
    public void BetaSlackChannelSetUpEnvironmentNotFoundValidationWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(
            "slack_channel_id"
        );
        value.Validate();
    }

    [Fact]
    public void BetaSlackChannelSetUpSettingsConflictValidationWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpSettingsConflictErrorDetails(
            "slack_channel_id"
        );
        value.Validate();
    }

    [Fact]
    public void AvailableToolsLimitExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new AvailableToolsLimitExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClaudeCodeKeyCreatorNotMemberSerializationRoundtripWorks()
    {
        ErrorDetails value = new ClaudeCodeKeyCreatorNotMemberErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClaudeCodeVersionTooOldSerializationRoundtripWorks()
    {
        ErrorDetails value = new ClaudeCodeVersionTooOldErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CmekKeyDisabledSerializationRoundtripWorks()
    {
        ErrorDetails value = new CmekKeyDisabledErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CmekKeyNetworkBlockedSerializationRoundtripWorks()
    {
        ErrorDetails value = new CmekKeyNetworkBlockedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionBlockAmbiguousSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionBlockAmbiguousErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionBlockMisplacedSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionBlockMisplacedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionContentMismatchSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionContentMismatchErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionIncompleteTurnSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionIncompleteTurnErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionNothingToSummarizeSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionNothingToSummarizeErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionSignatureInvalidSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionSignatureInvalidErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionTooManyToolReferencesSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionTooManyToolReferencesErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionToolChangesMismatchSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionToolChangesMismatchErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationOnHoldSerializationRoundtripWorks()
    {
        ErrorDetails value = new OrganizationOnHoldErrorDetails() { AppealUrl = "appeal_url" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestBodyEncodingInvalidSerializationRoundtripWorks()
    {
        ErrorDetails value = new RequestBodyEncodingInvalidErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestBodyEncodingUnsupportedSerializationRoundtripWorks()
    {
        ErrorDetails value = new RequestBodyEncodingUnsupportedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadAlreadyContinuedSerializationRoundtripWorks()
    {
        ErrorDetails value = new ThreadAlreadyContinuedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadContinueInFlightSerializationRoundtripWorks()
    {
        ErrorDetails value = new ThreadContinueInFlightErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadFingerprintMismatchSerializationRoundtripWorks()
    {
        ErrorDetails value = new ThreadFingerprintMismatchErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadUnsupportedRequestSerializationRoundtripWorks()
    {
        ErrorDetails value = new ThreadUnsupportedRequestErrorDetails()
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolNameConflictSerializationRoundtripWorks()
    {
        ErrorDetails value = new ToolNameConflictErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolReferenceUnresolvedSerializationRoundtripWorks()
    {
        ErrorDetails value = new ToolReferenceUnresolvedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadNotFoundSerializationRoundtripWorks()
    {
        ErrorDetails value = new ThreadNotFoundErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SkillReadBlockedUndecryptableSerializationRoundtripWorks()
    {
        ErrorDetails value = new SkillReadBlockedUndecryptableErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestBodyTooLargeAfterDecodingSerializationRoundtripWorks()
    {
        ErrorDetails value = new RequestBodyTooLargeAfterDecodingErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnforcedSpendLimitReachedSerializationRoundtripWorks()
    {
        ErrorDetails value = new EnforcedSpendLimitReachedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RampLimitExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new RampLimitExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CmekKeyUnreachableSerializationRoundtripWorks()
    {
        ErrorDetails value = new CmekKeyUnreachableErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionUnavailableSerializationRoundtripWorks()
    {
        ErrorDetails value = new CompactionUnavailableErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StorageQuotaExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new StorageQuotaExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileNotDownloadableSerializationRoundtripWorks()
    {
        ErrorDetails value = new FileNotDownloadableErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileExpiredSerializationRoundtripWorks()
    {
        ErrorDetails value = new FileExpiredErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CmekContextUnavailableSerializationRoundtripWorks()
    {
        ErrorDetails value = new CmekContextUnavailableErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrgApiKeyLimitExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new OrgApiKeyLimitExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkspaceApiKeyLimitExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new WorkspaceApiKeyLimitExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserProfileNotFoundSerializationRoundtripWorks()
    {
        ErrorDetails value = new UserProfileNotFoundErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalKeyInWorkspacePolicySerializationRoundtripWorks()
    {
        ErrorDetails value = new ExternalKeyInWorkspacePolicyErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AlreadyMemberSerializationRoundtripWorks()
    {
        ErrorDetails value = new AlreadyMemberErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CannotInviteEmailsWithUnverifiedDomainsSerializationRoundtripWorks()
    {
        ErrorDetails value = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmailDomainNotAllowedSerializationRoundtripWorks()
    {
        ErrorDetails value = new EmailDomainNotAllowedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InviteAlreadyExistsSerializationRoundtripWorks()
    {
        ErrorDetails value = new InviteAlreadyExistsErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrgMemberLimitExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new OrgMemberLimitExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RbacGroupGrantsOwnerAccessSerializationRoundtripWorks()
    {
        ErrorDetails value = new RbacGroupGrantsOwnerAccessErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RbacGroupOwnerAccessUnconfirmedSerializationRoundtripWorks()
    {
        ErrorDetails value = new RbacGroupOwnerAccessUnconfirmedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CannotRemoveLastMemberSerializationRoundtripWorks()
    {
        ErrorDetails value = new CannotRemoveLastMemberErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConcurrentMembershipChangeSerializationRoundtripWorks()
    {
        ErrorDetails value = new ConcurrentMembershipChangeErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalKeyValidationFailedSerializationRoundtripWorks()
    {
        ErrorDetails value = new ExternalKeyValidationFailedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalKeyValidationTimedOutSerializationRoundtripWorks()
    {
        ErrorDetails value = new ExternalKeyValidationTimedOutErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void KeyProfileMismatchSerializationRoundtripWorks()
    {
        ErrorDetails value = new KeyProfileMismatchErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkspacePolicyViolationSerializationRoundtripWorks()
    {
        ErrorDetails value = new WorkspacePolicyViolationErrorDetails(
            WorkspacePolicyField.ExternalKeyID
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalKeyChangedSerializationRoundtripWorks()
    {
        ErrorDetails value = new ExternalKeyChangedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkspaceMemberLimitExceededSerializationRoundtripWorks()
    {
        ErrorDetails value = new WorkspaceMemberLimitExceededErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationTypeNotSupportedSerializationRoundtripWorks()
    {
        ErrorDetails value = new OrganizationTypeNotSupportedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaEnvironmentCreateDisabledSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaEnvironmentCreateDisabledErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaEnvironmentArchivedSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaEnvironmentArchivedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaInvalidConfigTypeChangeSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaInvalidConfigTypeChangeErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaEnvironmentUpdateDisabledSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaEnvironmentUpdateDisabledErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaHeartbeatPreconditionFailedSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaHeartbeatPreconditionFailedErrorDetails(
            new BetaWorkLeaseState()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaInvalidMetadataSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaInvalidMetadataErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaBillingFrozenSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaBillingFrozenErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitsAdminApiWritesNotEnabledSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaUnsupportedCharsetSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaUnsupportedCharsetErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginNameTakenSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaPluginNameTakenErrorDetails() { PluginID = "plugin_id" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSkillNameTakenSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaSkillNameTakenErrorDetails("skill_name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRegistrationPendingSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaRegistrationPendingErrorDetails()
        {
            PluginID = "plugin_id",
            PluginVersionID = "plugin_version_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaScanFailedSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaScanFailedErrorDetails("plugin_version_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaScanPendingSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaScanPendingErrorDetails("plugin_version_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSlackChannelSetUpSettingsRefusedSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpSettingsRefusedErrorDetails(
            "slack_channel_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaApiKeyScopeMissingSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaApiKeyScopeMissingErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaClaudeTagWritesNotEnabledSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaClaudeTagWritesNotEnabledErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaComplianceConfigurationRestrictedSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaComplianceConfigurationRestrictedErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaOrganizationLevelScopedApiKeyRequiredSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaOrganizationLevelScopedApiKeyRequiredErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaEnvironmentNotFoundSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaEnvironmentNotFoundErrorDetails();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSlackChannelSetUpEnvironmentNotFoundSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(
            "slack_channel_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSlackChannelSetUpSettingsConflictSerializationRoundtripWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpSettingsConflictErrorDetails(
            "slack_channel_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AvailableToolsLimitExceededErrorCodeWorks()
    {
        ErrorDetails value = new AvailableToolsLimitExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.AvailableToolsLimitExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void ClaudeCodeKeyCreatorNotMemberErrorCodeWorks()
    {
        ErrorDetails value = new ClaudeCodeKeyCreatorNotMemberErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ClaudeCodeKeyCreatorNotMember, value.ErrorCode.Value());
    }

    [Fact]
    public void ClaudeCodeVersionTooOldErrorCodeWorks()
    {
        ErrorDetails value = new ClaudeCodeVersionTooOldErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ClaudeCodeVersionTooOld, value.ErrorCode.Value());
    }

    [Fact]
    public void CmekKeyDisabledErrorCodeWorks()
    {
        ErrorDetails value = new CmekKeyDisabledErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CmekKeyDisabled, value.ErrorCode.Value());
    }

    [Fact]
    public void CmekKeyNetworkBlockedErrorCodeWorks()
    {
        ErrorDetails value = new CmekKeyNetworkBlockedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CmekKeyNetworkBlocked, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionBlockAmbiguousErrorCodeWorks()
    {
        ErrorDetails value = new CompactionBlockAmbiguousErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionBlockAmbiguous, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionBlockMisplacedErrorCodeWorks()
    {
        ErrorDetails value = new CompactionBlockMisplacedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionBlockMisplaced, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionContentMismatchErrorCodeWorks()
    {
        ErrorDetails value = new CompactionContentMismatchErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionContentMismatch, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionIncompleteTurnErrorCodeWorks()
    {
        ErrorDetails value = new CompactionIncompleteTurnErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionIncompleteTurn, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionNothingToSummarizeErrorCodeWorks()
    {
        ErrorDetails value = new CompactionNothingToSummarizeErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionNothingToSummarize, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionSignatureInvalidErrorCodeWorks()
    {
        ErrorDetails value = new CompactionSignatureInvalidErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionSignatureInvalid, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionTooManyToolReferencesErrorCodeWorks()
    {
        ErrorDetails value = new CompactionTooManyToolReferencesErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.CompactionTooManyToolReferences,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void CompactionToolChangesMismatchErrorCodeWorks()
    {
        ErrorDetails value = new CompactionToolChangesMismatchErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionToolChangesMismatch, value.ErrorCode.Value());
    }

    [Fact]
    public void OrganizationOnHoldErrorCodeWorks()
    {
        ErrorDetails value = new OrganizationOnHoldErrorDetails() { AppealUrl = "appeal_url" };
        Assert.Equal(ErrorDetailsErrorCode.OrganizationOnHold, value.ErrorCode.Value());
    }

    [Fact]
    public void RequestBodyEncodingInvalidErrorCodeWorks()
    {
        ErrorDetails value = new RequestBodyEncodingInvalidErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.RequestBodyEncodingInvalid, value.ErrorCode.Value());
    }

    [Fact]
    public void RequestBodyEncodingUnsupportedErrorCodeWorks()
    {
        ErrorDetails value = new RequestBodyEncodingUnsupportedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.RequestBodyEncodingUnsupported, value.ErrorCode.Value());
    }

    [Fact]
    public void ThreadAlreadyContinuedErrorCodeWorks()
    {
        ErrorDetails value = new ThreadAlreadyContinuedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ThreadAlreadyContinued, value.ErrorCode.Value());
    }

    [Fact]
    public void ThreadContinueInFlightErrorCodeWorks()
    {
        ErrorDetails value = new ThreadContinueInFlightErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ThreadContinueInFlight, value.ErrorCode.Value());
    }

    [Fact]
    public void ThreadFingerprintMismatchErrorCodeWorks()
    {
        ErrorDetails value = new ThreadFingerprintMismatchErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ThreadFingerprintMismatch, value.ErrorCode.Value());
    }

    [Fact]
    public void ThreadUnsupportedRequestErrorCodeWorks()
    {
        ErrorDetails value = new ThreadUnsupportedRequestErrorDetails()
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };
        Assert.Equal(ErrorDetailsErrorCode.ThreadUnsupportedRequest, value.ErrorCode.Value());
    }

    [Fact]
    public void ToolNameConflictErrorCodeWorks()
    {
        ErrorDetails value = new ToolNameConflictErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ToolNameConflict, value.ErrorCode.Value());
    }

    [Fact]
    public void ToolReferenceUnresolvedErrorCodeWorks()
    {
        ErrorDetails value = new ToolReferenceUnresolvedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ToolReferenceUnresolved, value.ErrorCode.Value());
    }

    [Fact]
    public void ThreadNotFoundErrorCodeWorks()
    {
        ErrorDetails value = new ThreadNotFoundErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ThreadNotFound, value.ErrorCode.Value());
    }

    [Fact]
    public void SkillReadBlockedUndecryptableErrorCodeWorks()
    {
        ErrorDetails value = new SkillReadBlockedUndecryptableErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.SkillReadBlockedUndecryptable, value.ErrorCode.Value());
    }

    [Fact]
    public void RequestBodyTooLargeAfterDecodingErrorCodeWorks()
    {
        ErrorDetails value = new RequestBodyTooLargeAfterDecodingErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.RequestBodyTooLargeAfterDecoding,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void EnforcedSpendLimitReachedErrorCodeWorks()
    {
        ErrorDetails value = new EnforcedSpendLimitReachedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.EnforcedSpendLimitReached, value.ErrorCode.Value());
    }

    [Fact]
    public void RampLimitExceededErrorCodeWorks()
    {
        ErrorDetails value = new RampLimitExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.RampLimitExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void CmekKeyUnreachableErrorCodeWorks()
    {
        ErrorDetails value = new CmekKeyUnreachableErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CmekKeyUnreachable, value.ErrorCode.Value());
    }

    [Fact]
    public void CompactionUnavailableErrorCodeWorks()
    {
        ErrorDetails value = new CompactionUnavailableErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CompactionUnavailable, value.ErrorCode.Value());
    }

    [Fact]
    public void StorageQuotaExceededErrorCodeWorks()
    {
        ErrorDetails value = new StorageQuotaExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.StorageQuotaExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void FileNotDownloadableErrorCodeWorks()
    {
        ErrorDetails value = new FileNotDownloadableErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.FileNotDownloadable, value.ErrorCode.Value());
    }

    [Fact]
    public void FileExpiredErrorCodeWorks()
    {
        ErrorDetails value = new FileExpiredErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.FileExpired, value.ErrorCode.Value());
    }

    [Fact]
    public void CmekContextUnavailableErrorCodeWorks()
    {
        ErrorDetails value = new CmekContextUnavailableErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CmekContextUnavailable, value.ErrorCode.Value());
    }

    [Fact]
    public void OrgApiKeyLimitExceededErrorCodeWorks()
    {
        ErrorDetails value = new OrgApiKeyLimitExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.OrgApiKeyLimitExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void WorkspaceApiKeyLimitExceededErrorCodeWorks()
    {
        ErrorDetails value = new WorkspaceApiKeyLimitExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.WorkspaceApiKeyLimitExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void UserProfileNotFoundErrorCodeWorks()
    {
        ErrorDetails value = new UserProfileNotFoundErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.UserProfileNotFound, value.ErrorCode.Value());
    }

    [Fact]
    public void ExternalKeyInWorkspacePolicyErrorCodeWorks()
    {
        ErrorDetails value = new ExternalKeyInWorkspacePolicyErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ExternalKeyInWorkspacePolicy, value.ErrorCode.Value());
    }

    [Fact]
    public void AlreadyMemberErrorCodeWorks()
    {
        ErrorDetails value = new AlreadyMemberErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.AlreadyMember, value.ErrorCode.Value());
    }

    [Fact]
    public void CannotInviteEmailsWithUnverifiedDomainsErrorCodeWorks()
    {
        ErrorDetails value = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.CannotInviteEmailsWithUnverifiedDomains,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void EmailDomainNotAllowedErrorCodeWorks()
    {
        ErrorDetails value = new EmailDomainNotAllowedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.EmailDomainNotAllowed, value.ErrorCode.Value());
    }

    [Fact]
    public void InviteAlreadyExistsErrorCodeWorks()
    {
        ErrorDetails value = new InviteAlreadyExistsErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.InviteAlreadyExists, value.ErrorCode.Value());
    }

    [Fact]
    public void OrgMemberLimitExceededErrorCodeWorks()
    {
        ErrorDetails value = new OrgMemberLimitExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.OrgMemberLimitExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void RbacGroupGrantsOwnerAccessErrorCodeWorks()
    {
        ErrorDetails value = new RbacGroupGrantsOwnerAccessErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.RbacGroupGrantsOwnerAccess, value.ErrorCode.Value());
    }

    [Fact]
    public void RbacGroupOwnerAccessUnconfirmedErrorCodeWorks()
    {
        ErrorDetails value = new RbacGroupOwnerAccessUnconfirmedErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.RbacGroupOwnerAccessUnconfirmed,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void CannotRemoveLastMemberErrorCodeWorks()
    {
        ErrorDetails value = new CannotRemoveLastMemberErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.CannotRemoveLastMember, value.ErrorCode.Value());
    }

    [Fact]
    public void ConcurrentMembershipChangeErrorCodeWorks()
    {
        ErrorDetails value = new ConcurrentMembershipChangeErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ConcurrentMembershipChange, value.ErrorCode.Value());
    }

    [Fact]
    public void ExternalKeyValidationFailedErrorCodeWorks()
    {
        ErrorDetails value = new ExternalKeyValidationFailedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ExternalKeyValidationFailed, value.ErrorCode.Value());
    }

    [Fact]
    public void ExternalKeyValidationTimedOutErrorCodeWorks()
    {
        ErrorDetails value = new ExternalKeyValidationTimedOutErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ExternalKeyValidationTimedOut, value.ErrorCode.Value());
    }

    [Fact]
    public void KeyProfileMismatchErrorCodeWorks()
    {
        ErrorDetails value = new KeyProfileMismatchErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.KeyProfileMismatch, value.ErrorCode.Value());
    }

    [Fact]
    public void WorkspacePolicyViolationErrorCodeWorks()
    {
        ErrorDetails value = new WorkspacePolicyViolationErrorDetails(
            WorkspacePolicyField.ExternalKeyID
        );
        Assert.Equal(ErrorDetailsErrorCode.WorkspacePolicyViolation, value.ErrorCode.Value());
    }

    [Fact]
    public void ExternalKeyChangedErrorCodeWorks()
    {
        ErrorDetails value = new ExternalKeyChangedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ExternalKeyChanged, value.ErrorCode.Value());
    }

    [Fact]
    public void WorkspaceMemberLimitExceededErrorCodeWorks()
    {
        ErrorDetails value = new WorkspaceMemberLimitExceededErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.WorkspaceMemberLimitExceeded, value.ErrorCode.Value());
    }

    [Fact]
    public void OrganizationTypeNotSupportedErrorCodeWorks()
    {
        ErrorDetails value = new OrganizationTypeNotSupportedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.OrganizationTypeNotSupported, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaEnvironmentCreateDisabledErrorCodeWorks()
    {
        ErrorDetails value = new BetaEnvironmentCreateDisabledErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.EnvironmentCreateDisabled, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaEnvironmentArchivedErrorCodeWorks()
    {
        ErrorDetails value = new BetaEnvironmentArchivedErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.EnvironmentArchived, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaInvalidConfigTypeChangeErrorCodeWorks()
    {
        ErrorDetails value = new BetaInvalidConfigTypeChangeErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.InvalidConfigTypeChange, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaEnvironmentUpdateDisabledErrorCodeWorks()
    {
        ErrorDetails value = new BetaEnvironmentUpdateDisabledErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.EnvironmentUpdateDisabled, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaHeartbeatPreconditionFailedErrorCodeWorks()
    {
        ErrorDetails value = new BetaHeartbeatPreconditionFailedErrorDetails(
            new BetaWorkLeaseState()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            }
        );
        Assert.Equal(ErrorDetailsErrorCode.HeartbeatPreconditionFailed, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaInvalidMetadataErrorCodeWorks()
    {
        ErrorDetails value = new BetaInvalidMetadataErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.InvalidMetadata, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaBillingFrozenErrorCodeWorks()
    {
        ErrorDetails value = new BetaBillingFrozenErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.BillingFrozen, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaSpendLimitsAdminApiWritesNotEnabledErrorCodeWorks()
    {
        ErrorDetails value = new BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.SpendLimitsAdminApiWritesNotEnabled,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void BetaUnsupportedCharsetErrorCodeWorks()
    {
        ErrorDetails value = new BetaUnsupportedCharsetErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.UnsupportedCharset, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaPluginNameTakenErrorCodeWorks()
    {
        ErrorDetails value = new BetaPluginNameTakenErrorDetails() { PluginID = "plugin_id" };
        Assert.Equal(ErrorDetailsErrorCode.PluginNameTaken, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaSkillNameTakenErrorCodeWorks()
    {
        ErrorDetails value = new BetaSkillNameTakenErrorDetails("skill_name");
        Assert.Equal(ErrorDetailsErrorCode.SkillNameTaken, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaRegistrationPendingErrorCodeWorks()
    {
        ErrorDetails value = new BetaRegistrationPendingErrorDetails()
        {
            PluginID = "plugin_id",
            PluginVersionID = "plugin_version_id",
        };
        Assert.Equal(ErrorDetailsErrorCode.RegistrationPending, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaScanFailedErrorCodeWorks()
    {
        ErrorDetails value = new BetaScanFailedErrorDetails("plugin_version_id");
        Assert.Equal(ErrorDetailsErrorCode.ScanFailed, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaScanPendingErrorCodeWorks()
    {
        ErrorDetails value = new BetaScanPendingErrorDetails("plugin_version_id");
        Assert.Equal(ErrorDetailsErrorCode.ScanPending, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaSlackChannelSetUpSettingsRefusedErrorCodeWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpSettingsRefusedErrorDetails(
            "slack_channel_id"
        );
        Assert.Equal(
            ErrorDetailsErrorCode.SlackChannelSetUpSettingsRefused,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void BetaApiKeyScopeMissingErrorCodeWorks()
    {
        ErrorDetails value = new BetaApiKeyScopeMissingErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ApiKeyScopeMissing, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaClaudeTagWritesNotEnabledErrorCodeWorks()
    {
        ErrorDetails value = new BetaClaudeTagWritesNotEnabledErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.ClaudeTagWritesNotEnabled, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaComplianceConfigurationRestrictedErrorCodeWorks()
    {
        ErrorDetails value = new BetaComplianceConfigurationRestrictedErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.ComplianceConfigurationRestricted,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void BetaOrganizationLevelScopedApiKeyRequiredErrorCodeWorks()
    {
        ErrorDetails value = new BetaOrganizationLevelScopedApiKeyRequiredErrorDetails();
        Assert.Equal(
            ErrorDetailsErrorCode.OrganizationLevelScopedApiKeyRequired,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void BetaEnvironmentNotFoundErrorCodeWorks()
    {
        ErrorDetails value = new BetaEnvironmentNotFoundErrorDetails();
        Assert.Equal(ErrorDetailsErrorCode.EnvironmentNotFound, value.ErrorCode.Value());
    }

    [Fact]
    public void BetaSlackChannelSetUpEnvironmentNotFoundErrorCodeWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(
            "slack_channel_id"
        );
        Assert.Equal(
            ErrorDetailsErrorCode.SlackChannelSetUpEnvironmentNotFound,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void BetaSlackChannelSetUpSettingsConflictErrorCodeWorks()
    {
        ErrorDetails value = new BetaSlackChannelSetUpSettingsConflictErrorDetails(
            "slack_channel_id"
        );
        Assert.Equal(
            ErrorDetailsErrorCode.SlackChannelSetUpSettingsConflict,
            value.ErrorCode.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ErrorDetails value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "error_code": "available_tools_limit_exceeded",
                  "plugin_id": "plugin_id",
                  "plugin_version_id": "plugin_version_id",
                  "slack_channel_id": "slack_channel_id"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ErrorDetailsErrorCode> expectedErrorCode =
            ErrorDetailsErrorCode.AvailableToolsLimitExceeded;
        string expectedPluginID = "plugin_id";
        string expectedPluginVersionID = "plugin_version_id";
        string expectedSlackChannelID = "slack_channel_id";

        Assert.Equal(expectedErrorCode, value.ErrorCode);
        Assert.Equal(expectedPluginID, value.PluginID);
        Assert.Equal(expectedPluginVersionID, value.PluginVersionID);
        Assert.Equal(expectedSlackChannelID, value.SlackChannelID);

        ErrorDetails emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ErrorCode);
        Assert.Null(emptyValue.PluginID);
        Assert.Null(emptyValue.PluginVersionID);
        Assert.Null(emptyValue.SlackChannelID);

        ErrorDetails mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "plugin_id": [
                    "invalid"
                  ],
                  "plugin_version_id": [
                    "invalid"
                  ],
                  "slack_channel_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.PluginID);
        Assert.Null(mismatchedValue.PluginVersionID);
        Assert.Null(mismatchedValue.SlackChannelID);
    }
}

public class ErrorDetailsErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(ErrorDetailsErrorCode.AvailableToolsLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.ClaudeCodeKeyCreatorNotMember)]
    [InlineData(ErrorDetailsErrorCode.ClaudeCodeVersionTooOld)]
    [InlineData(ErrorDetailsErrorCode.CmekKeyDisabled)]
    [InlineData(ErrorDetailsErrorCode.CmekKeyNetworkBlocked)]
    [InlineData(ErrorDetailsErrorCode.CompactionBlockAmbiguous)]
    [InlineData(ErrorDetailsErrorCode.CompactionBlockMisplaced)]
    [InlineData(ErrorDetailsErrorCode.CompactionContentMismatch)]
    [InlineData(ErrorDetailsErrorCode.CompactionIncompleteTurn)]
    [InlineData(ErrorDetailsErrorCode.CompactionNothingToSummarize)]
    [InlineData(ErrorDetailsErrorCode.CompactionSignatureInvalid)]
    [InlineData(ErrorDetailsErrorCode.CompactionTooManyToolReferences)]
    [InlineData(ErrorDetailsErrorCode.CompactionToolChangesMismatch)]
    [InlineData(ErrorDetailsErrorCode.OrganizationOnHold)]
    [InlineData(ErrorDetailsErrorCode.RequestBodyEncodingInvalid)]
    [InlineData(ErrorDetailsErrorCode.RequestBodyEncodingUnsupported)]
    [InlineData(ErrorDetailsErrorCode.ThreadAlreadyContinued)]
    [InlineData(ErrorDetailsErrorCode.ThreadContinueInFlight)]
    [InlineData(ErrorDetailsErrorCode.ThreadFingerprintMismatch)]
    [InlineData(ErrorDetailsErrorCode.ThreadUnsupportedRequest)]
    [InlineData(ErrorDetailsErrorCode.ToolNameConflict)]
    [InlineData(ErrorDetailsErrorCode.ToolReferenceUnresolved)]
    [InlineData(ErrorDetailsErrorCode.ThreadNotFound)]
    [InlineData(ErrorDetailsErrorCode.SkillReadBlockedUndecryptable)]
    [InlineData(ErrorDetailsErrorCode.RequestBodyTooLargeAfterDecoding)]
    [InlineData(ErrorDetailsErrorCode.EnforcedSpendLimitReached)]
    [InlineData(ErrorDetailsErrorCode.RampLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.CmekKeyUnreachable)]
    [InlineData(ErrorDetailsErrorCode.CompactionUnavailable)]
    [InlineData(ErrorDetailsErrorCode.StorageQuotaExceeded)]
    [InlineData(ErrorDetailsErrorCode.FileNotDownloadable)]
    [InlineData(ErrorDetailsErrorCode.FileExpired)]
    [InlineData(ErrorDetailsErrorCode.CmekContextUnavailable)]
    [InlineData(ErrorDetailsErrorCode.OrgApiKeyLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.WorkspaceApiKeyLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.UserProfileNotFound)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyInWorkspacePolicy)]
    [InlineData(ErrorDetailsErrorCode.AlreadyMember)]
    [InlineData(ErrorDetailsErrorCode.CannotInviteEmailsWithUnverifiedDomains)]
    [InlineData(ErrorDetailsErrorCode.EmailDomainNotAllowed)]
    [InlineData(ErrorDetailsErrorCode.InviteAlreadyExists)]
    [InlineData(ErrorDetailsErrorCode.OrgMemberLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.RbacGroupGrantsOwnerAccess)]
    [InlineData(ErrorDetailsErrorCode.RbacGroupOwnerAccessUnconfirmed)]
    [InlineData(ErrorDetailsErrorCode.CannotRemoveLastMember)]
    [InlineData(ErrorDetailsErrorCode.ConcurrentMembershipChange)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyValidationFailed)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyValidationTimedOut)]
    [InlineData(ErrorDetailsErrorCode.KeyProfileMismatch)]
    [InlineData(ErrorDetailsErrorCode.WorkspacePolicyViolation)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyChanged)]
    [InlineData(ErrorDetailsErrorCode.WorkspaceMemberLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.OrganizationTypeNotSupported)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentCreateDisabled)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentArchived)]
    [InlineData(ErrorDetailsErrorCode.InvalidConfigTypeChange)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentUpdateDisabled)]
    [InlineData(ErrorDetailsErrorCode.HeartbeatPreconditionFailed)]
    [InlineData(ErrorDetailsErrorCode.InvalidMetadata)]
    [InlineData(ErrorDetailsErrorCode.BillingFrozen)]
    [InlineData(ErrorDetailsErrorCode.SpendLimitsAdminApiWritesNotEnabled)]
    [InlineData(ErrorDetailsErrorCode.UnsupportedCharset)]
    [InlineData(ErrorDetailsErrorCode.PluginNameTaken)]
    [InlineData(ErrorDetailsErrorCode.SkillNameTaken)]
    [InlineData(ErrorDetailsErrorCode.RegistrationPending)]
    [InlineData(ErrorDetailsErrorCode.ScanFailed)]
    [InlineData(ErrorDetailsErrorCode.ScanPending)]
    [InlineData(ErrorDetailsErrorCode.SlackChannelSetUpSettingsRefused)]
    [InlineData(ErrorDetailsErrorCode.ApiKeyScopeMissing)]
    [InlineData(ErrorDetailsErrorCode.ClaudeTagWritesNotEnabled)]
    [InlineData(ErrorDetailsErrorCode.ComplianceConfigurationRestricted)]
    [InlineData(ErrorDetailsErrorCode.OrganizationLevelScopedApiKeyRequired)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentNotFound)]
    [InlineData(ErrorDetailsErrorCode.SlackChannelSetUpEnvironmentNotFound)]
    [InlineData(ErrorDetailsErrorCode.SlackChannelSetUpSettingsConflict)]
    public void Validation_Works(ErrorDetailsErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorDetailsErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorDetailsErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorDetailsErrorCode.AvailableToolsLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.ClaudeCodeKeyCreatorNotMember)]
    [InlineData(ErrorDetailsErrorCode.ClaudeCodeVersionTooOld)]
    [InlineData(ErrorDetailsErrorCode.CmekKeyDisabled)]
    [InlineData(ErrorDetailsErrorCode.CmekKeyNetworkBlocked)]
    [InlineData(ErrorDetailsErrorCode.CompactionBlockAmbiguous)]
    [InlineData(ErrorDetailsErrorCode.CompactionBlockMisplaced)]
    [InlineData(ErrorDetailsErrorCode.CompactionContentMismatch)]
    [InlineData(ErrorDetailsErrorCode.CompactionIncompleteTurn)]
    [InlineData(ErrorDetailsErrorCode.CompactionNothingToSummarize)]
    [InlineData(ErrorDetailsErrorCode.CompactionSignatureInvalid)]
    [InlineData(ErrorDetailsErrorCode.CompactionTooManyToolReferences)]
    [InlineData(ErrorDetailsErrorCode.CompactionToolChangesMismatch)]
    [InlineData(ErrorDetailsErrorCode.OrganizationOnHold)]
    [InlineData(ErrorDetailsErrorCode.RequestBodyEncodingInvalid)]
    [InlineData(ErrorDetailsErrorCode.RequestBodyEncodingUnsupported)]
    [InlineData(ErrorDetailsErrorCode.ThreadAlreadyContinued)]
    [InlineData(ErrorDetailsErrorCode.ThreadContinueInFlight)]
    [InlineData(ErrorDetailsErrorCode.ThreadFingerprintMismatch)]
    [InlineData(ErrorDetailsErrorCode.ThreadUnsupportedRequest)]
    [InlineData(ErrorDetailsErrorCode.ToolNameConflict)]
    [InlineData(ErrorDetailsErrorCode.ToolReferenceUnresolved)]
    [InlineData(ErrorDetailsErrorCode.ThreadNotFound)]
    [InlineData(ErrorDetailsErrorCode.SkillReadBlockedUndecryptable)]
    [InlineData(ErrorDetailsErrorCode.RequestBodyTooLargeAfterDecoding)]
    [InlineData(ErrorDetailsErrorCode.EnforcedSpendLimitReached)]
    [InlineData(ErrorDetailsErrorCode.RampLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.CmekKeyUnreachable)]
    [InlineData(ErrorDetailsErrorCode.CompactionUnavailable)]
    [InlineData(ErrorDetailsErrorCode.StorageQuotaExceeded)]
    [InlineData(ErrorDetailsErrorCode.FileNotDownloadable)]
    [InlineData(ErrorDetailsErrorCode.FileExpired)]
    [InlineData(ErrorDetailsErrorCode.CmekContextUnavailable)]
    [InlineData(ErrorDetailsErrorCode.OrgApiKeyLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.WorkspaceApiKeyLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.UserProfileNotFound)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyInWorkspacePolicy)]
    [InlineData(ErrorDetailsErrorCode.AlreadyMember)]
    [InlineData(ErrorDetailsErrorCode.CannotInviteEmailsWithUnverifiedDomains)]
    [InlineData(ErrorDetailsErrorCode.EmailDomainNotAllowed)]
    [InlineData(ErrorDetailsErrorCode.InviteAlreadyExists)]
    [InlineData(ErrorDetailsErrorCode.OrgMemberLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.RbacGroupGrantsOwnerAccess)]
    [InlineData(ErrorDetailsErrorCode.RbacGroupOwnerAccessUnconfirmed)]
    [InlineData(ErrorDetailsErrorCode.CannotRemoveLastMember)]
    [InlineData(ErrorDetailsErrorCode.ConcurrentMembershipChange)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyValidationFailed)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyValidationTimedOut)]
    [InlineData(ErrorDetailsErrorCode.KeyProfileMismatch)]
    [InlineData(ErrorDetailsErrorCode.WorkspacePolicyViolation)]
    [InlineData(ErrorDetailsErrorCode.ExternalKeyChanged)]
    [InlineData(ErrorDetailsErrorCode.WorkspaceMemberLimitExceeded)]
    [InlineData(ErrorDetailsErrorCode.OrganizationTypeNotSupported)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentCreateDisabled)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentArchived)]
    [InlineData(ErrorDetailsErrorCode.InvalidConfigTypeChange)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentUpdateDisabled)]
    [InlineData(ErrorDetailsErrorCode.HeartbeatPreconditionFailed)]
    [InlineData(ErrorDetailsErrorCode.InvalidMetadata)]
    [InlineData(ErrorDetailsErrorCode.BillingFrozen)]
    [InlineData(ErrorDetailsErrorCode.SpendLimitsAdminApiWritesNotEnabled)]
    [InlineData(ErrorDetailsErrorCode.UnsupportedCharset)]
    [InlineData(ErrorDetailsErrorCode.PluginNameTaken)]
    [InlineData(ErrorDetailsErrorCode.SkillNameTaken)]
    [InlineData(ErrorDetailsErrorCode.RegistrationPending)]
    [InlineData(ErrorDetailsErrorCode.ScanFailed)]
    [InlineData(ErrorDetailsErrorCode.ScanPending)]
    [InlineData(ErrorDetailsErrorCode.SlackChannelSetUpSettingsRefused)]
    [InlineData(ErrorDetailsErrorCode.ApiKeyScopeMissing)]
    [InlineData(ErrorDetailsErrorCode.ClaudeTagWritesNotEnabled)]
    [InlineData(ErrorDetailsErrorCode.ComplianceConfigurationRestricted)]
    [InlineData(ErrorDetailsErrorCode.OrganizationLevelScopedApiKeyRequired)]
    [InlineData(ErrorDetailsErrorCode.EnvironmentNotFound)]
    [InlineData(ErrorDetailsErrorCode.SlackChannelSetUpEnvironmentNotFound)]
    [InlineData(ErrorDetailsErrorCode.SlackChannelSetUpSettingsConflict)]
    public void SerializationRoundtrip_Works(ErrorDetailsErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorDetailsErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorDetailsErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorDetailsErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorDetailsErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
