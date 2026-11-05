using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Organization;
using Anthropic.Models.Organization.ExternalKeys;
using Anthropic.Models.Organization.Invites;
using Anthropic.Models.Organization.RbacGroups;
using Anthropic.Models.Organization.Users;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.UserProfiles;
using ApiKeys = Anthropic.Models.Organization.ApiKeys;
using Environments = Anthropic.Models.Beta.Environments;
using Files = Anthropic.Models.Files;
using Messages = Anthropic.Models.Messages;
using Plugins = Anthropic.Models.Beta.Organization.Plugins;
using Skills = Anthropic.Models.Skills;

namespace Anthropic.Models;

[JsonConverter(typeof(ErrorDetailsConverter))]
public record class ErrorDetails : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, ErrorDetailsErrorCode> ErrorCode
    {
        get
        {
            return this.Value switch
            {
                Messages::AvailableToolsLimitExceededErrorDetails _ =>
                    ErrorDetailsErrorCode.AvailableToolsLimitExceeded,
                ClaudeCodeKeyCreatorNotMemberErrorDetails _ =>
                    ErrorDetailsErrorCode.ClaudeCodeKeyCreatorNotMember,
                ClaudeCodeVersionTooOldErrorDetails _ =>
                    ErrorDetailsErrorCode.ClaudeCodeVersionTooOld,
                CmekKeyDisabledErrorDetails _ => ErrorDetailsErrorCode.CmekKeyDisabled,
                CmekKeyNetworkBlockedErrorDetails _ => ErrorDetailsErrorCode.CmekKeyNetworkBlocked,
                Messages::CompactionBlockAmbiguousErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionBlockAmbiguous,
                Messages::CompactionBlockMisplacedErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionBlockMisplaced,
                Messages::CompactionContentMismatchErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionContentMismatch,
                Messages::CompactionIncompleteTurnErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionIncompleteTurn,
                Messages::CompactionNothingToSummarizeErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionNothingToSummarize,
                Messages::CompactionSignatureInvalidErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionSignatureInvalid,
                Messages::CompactionTooManyToolReferencesErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionTooManyToolReferences,
                Messages::CompactionToolChangesMismatchErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionToolChangesMismatch,
                OrganizationOnHoldErrorDetails _ => ErrorDetailsErrorCode.OrganizationOnHold,
                RequestBodyEncodingInvalidErrorDetails _ =>
                    ErrorDetailsErrorCode.RequestBodyEncodingInvalid,
                RequestBodyEncodingUnsupportedErrorDetails _ =>
                    ErrorDetailsErrorCode.RequestBodyEncodingUnsupported,
                Messages::ThreadAlreadyContinuedErrorDetails _ =>
                    ErrorDetailsErrorCode.ThreadAlreadyContinued,
                Messages::ThreadContinueInFlightErrorDetails _ =>
                    ErrorDetailsErrorCode.ThreadContinueInFlight,
                Messages::ThreadFingerprintMismatchErrorDetails _ =>
                    ErrorDetailsErrorCode.ThreadFingerprintMismatch,
                Messages::ThreadUnsupportedRequestErrorDetails _ =>
                    ErrorDetailsErrorCode.ThreadUnsupportedRequest,
                Messages::ToolNameConflictErrorDetails _ => ErrorDetailsErrorCode.ToolNameConflict,
                Messages::ToolReferenceUnresolvedErrorDetails _ =>
                    ErrorDetailsErrorCode.ToolReferenceUnresolved,
                Messages::ThreadNotFoundErrorDetails _ => ErrorDetailsErrorCode.ThreadNotFound,
                Skills::SkillReadBlockedUndecryptableErrorDetails _ =>
                    ErrorDetailsErrorCode.SkillReadBlockedUndecryptable,
                RequestBodyTooLargeAfterDecodingErrorDetails _ =>
                    ErrorDetailsErrorCode.RequestBodyTooLargeAfterDecoding,
                EnforcedSpendLimitReachedErrorDetails _ =>
                    ErrorDetailsErrorCode.EnforcedSpendLimitReached,
                RampLimitExceededErrorDetails _ => ErrorDetailsErrorCode.RampLimitExceeded,
                CmekKeyUnreachableErrorDetails _ => ErrorDetailsErrorCode.CmekKeyUnreachable,
                Messages::CompactionUnavailableErrorDetails _ =>
                    ErrorDetailsErrorCode.CompactionUnavailable,
                Files::StorageQuotaExceededErrorDetails _ =>
                    ErrorDetailsErrorCode.StorageQuotaExceeded,
                Files::FileNotDownloadableErrorDetails _ =>
                    ErrorDetailsErrorCode.FileNotDownloadable,
                Files::FileExpiredErrorDetails _ => ErrorDetailsErrorCode.FileExpired,
                CmekContextUnavailableErrorDetails _ =>
                    ErrorDetailsErrorCode.CmekContextUnavailable,
                ApiKeys::OrgApiKeyLimitExceededErrorDetails _ =>
                    ErrorDetailsErrorCode.OrgApiKeyLimitExceeded,
                ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails _ =>
                    ErrorDetailsErrorCode.WorkspaceApiKeyLimitExceeded,
                UserProfileNotFoundErrorDetails _ => ErrorDetailsErrorCode.UserProfileNotFound,
                ExternalKeyInWorkspacePolicyErrorDetails _ =>
                    ErrorDetailsErrorCode.ExternalKeyInWorkspacePolicy,
                AlreadyMemberErrorDetails _ => ErrorDetailsErrorCode.AlreadyMember,
                CannotInviteEmailsWithUnverifiedDomainsErrorDetails _ =>
                    ErrorDetailsErrorCode.CannotInviteEmailsWithUnverifiedDomains,
                EmailDomainNotAllowedErrorDetails _ => ErrorDetailsErrorCode.EmailDomainNotAllowed,
                InviteAlreadyExistsErrorDetails _ => ErrorDetailsErrorCode.InviteAlreadyExists,
                OrgMemberLimitExceededErrorDetails _ =>
                    ErrorDetailsErrorCode.OrgMemberLimitExceeded,
                RbacGroupGrantsOwnerAccessErrorDetails _ =>
                    ErrorDetailsErrorCode.RbacGroupGrantsOwnerAccess,
                RbacGroupOwnerAccessUnconfirmedErrorDetails _ =>
                    ErrorDetailsErrorCode.RbacGroupOwnerAccessUnconfirmed,
                CannotRemoveLastMemberErrorDetails _ =>
                    ErrorDetailsErrorCode.CannotRemoveLastMember,
                ConcurrentMembershipChangeErrorDetails _ =>
                    ErrorDetailsErrorCode.ConcurrentMembershipChange,
                ExternalKeyValidationFailedErrorDetails _ =>
                    ErrorDetailsErrorCode.ExternalKeyValidationFailed,
                ExternalKeyValidationTimedOutErrorDetails _ =>
                    ErrorDetailsErrorCode.ExternalKeyValidationTimedOut,
                KeyProfileMismatchErrorDetails _ => ErrorDetailsErrorCode.KeyProfileMismatch,
                WorkspacePolicyViolationErrorDetails _ =>
                    ErrorDetailsErrorCode.WorkspacePolicyViolation,
                ExternalKeyChangedErrorDetails _ => ErrorDetailsErrorCode.ExternalKeyChanged,
                WorkspaceMemberLimitExceededErrorDetails _ =>
                    ErrorDetailsErrorCode.WorkspaceMemberLimitExceeded,
                OrganizationTypeNotSupportedErrorDetails _ =>
                    ErrorDetailsErrorCode.OrganizationTypeNotSupported,
                Environments::BetaEnvironmentCreateDisabledErrorDetails _ =>
                    ErrorDetailsErrorCode.EnvironmentCreateDisabled,
                Environments::BetaEnvironmentArchivedErrorDetails _ =>
                    ErrorDetailsErrorCode.EnvironmentArchived,
                Environments::BetaInvalidConfigTypeChangeErrorDetails _ =>
                    ErrorDetailsErrorCode.InvalidConfigTypeChange,
                Environments::BetaEnvironmentUpdateDisabledErrorDetails _ =>
                    ErrorDetailsErrorCode.EnvironmentUpdateDisabled,
                BetaHeartbeatPreconditionFailedErrorDetails _ =>
                    ErrorDetailsErrorCode.HeartbeatPreconditionFailed,
                Environments::BetaInvalidMetadataErrorDetails _ =>
                    ErrorDetailsErrorCode.InvalidMetadata,
                BetaBillingFrozenErrorDetails _ => ErrorDetailsErrorCode.BillingFrozen,
                BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails _ =>
                    ErrorDetailsErrorCode.SpendLimitsAdminApiWritesNotEnabled,
                BetaUnsupportedCharsetErrorDetails _ => ErrorDetailsErrorCode.UnsupportedCharset,
                Plugins::BetaPluginNameTakenErrorDetails _ => ErrorDetailsErrorCode.PluginNameTaken,
                Plugins::BetaSkillNameTakenErrorDetails _ => ErrorDetailsErrorCode.SkillNameTaken,
                Plugins::BetaRegistrationPendingErrorDetails _ =>
                    ErrorDetailsErrorCode.RegistrationPending,
                Plugins::BetaScanFailedErrorDetails _ => ErrorDetailsErrorCode.ScanFailed,
                Plugins::BetaScanPendingErrorDetails _ => ErrorDetailsErrorCode.ScanPending,
                BetaSlackChannelSetUpSettingsRefusedErrorDetails _ =>
                    ErrorDetailsErrorCode.SlackChannelSetUpSettingsRefused,
                BetaApiKeyScopeMissingErrorDetails _ => ErrorDetailsErrorCode.ApiKeyScopeMissing,
                BetaClaudeTagWritesNotEnabledErrorDetails _ =>
                    ErrorDetailsErrorCode.ClaudeTagWritesNotEnabled,
                BetaComplianceConfigurationRestrictedErrorDetails _ =>
                    ErrorDetailsErrorCode.ComplianceConfigurationRestricted,
                BetaOrganizationLevelScopedApiKeyRequiredErrorDetails _ =>
                    ErrorDetailsErrorCode.OrganizationLevelScopedApiKeyRequired,
                Environments::BetaEnvironmentNotFoundErrorDetails _ =>
                    ErrorDetailsErrorCode.EnvironmentNotFound,
                BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails _ =>
                    ErrorDetailsErrorCode.SlackChannelSetUpEnvironmentNotFound,
                BetaSlackChannelSetUpSettingsConflictErrorDetails _ =>
                    ErrorDetailsErrorCode.SlackChannelSetUpSettingsConflict,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, ErrorDetailsErrorCode>
                >(this.Json, "error_code"),
            };
        }
    }

    public string? PluginID
    {
        get
        {
            return this.Value switch
            {
                Messages::AvailableToolsLimitExceededErrorDetails _ => null,
                ClaudeCodeKeyCreatorNotMemberErrorDetails _ => null,
                ClaudeCodeVersionTooOldErrorDetails _ => null,
                CmekKeyDisabledErrorDetails _ => null,
                CmekKeyNetworkBlockedErrorDetails _ => null,
                Messages::CompactionBlockAmbiguousErrorDetails _ => null,
                Messages::CompactionBlockMisplacedErrorDetails _ => null,
                Messages::CompactionContentMismatchErrorDetails _ => null,
                Messages::CompactionIncompleteTurnErrorDetails _ => null,
                Messages::CompactionNothingToSummarizeErrorDetails _ => null,
                Messages::CompactionSignatureInvalidErrorDetails _ => null,
                Messages::CompactionTooManyToolReferencesErrorDetails _ => null,
                Messages::CompactionToolChangesMismatchErrorDetails _ => null,
                OrganizationOnHoldErrorDetails _ => null,
                RequestBodyEncodingInvalidErrorDetails _ => null,
                RequestBodyEncodingUnsupportedErrorDetails _ => null,
                Messages::ThreadAlreadyContinuedErrorDetails _ => null,
                Messages::ThreadContinueInFlightErrorDetails _ => null,
                Messages::ThreadFingerprintMismatchErrorDetails _ => null,
                Messages::ThreadUnsupportedRequestErrorDetails _ => null,
                Messages::ToolNameConflictErrorDetails _ => null,
                Messages::ToolReferenceUnresolvedErrorDetails _ => null,
                Messages::ThreadNotFoundErrorDetails _ => null,
                Skills::SkillReadBlockedUndecryptableErrorDetails _ => null,
                RequestBodyTooLargeAfterDecodingErrorDetails _ => null,
                EnforcedSpendLimitReachedErrorDetails _ => null,
                RampLimitExceededErrorDetails _ => null,
                CmekKeyUnreachableErrorDetails _ => null,
                Messages::CompactionUnavailableErrorDetails _ => null,
                Files::StorageQuotaExceededErrorDetails _ => null,
                Files::FileNotDownloadableErrorDetails _ => null,
                Files::FileExpiredErrorDetails _ => null,
                CmekContextUnavailableErrorDetails _ => null,
                ApiKeys::OrgApiKeyLimitExceededErrorDetails _ => null,
                ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails _ => null,
                UserProfileNotFoundErrorDetails _ => null,
                ExternalKeyInWorkspacePolicyErrorDetails _ => null,
                AlreadyMemberErrorDetails _ => null,
                CannotInviteEmailsWithUnverifiedDomainsErrorDetails _ => null,
                EmailDomainNotAllowedErrorDetails _ => null,
                InviteAlreadyExistsErrorDetails _ => null,
                OrgMemberLimitExceededErrorDetails _ => null,
                RbacGroupGrantsOwnerAccessErrorDetails _ => null,
                RbacGroupOwnerAccessUnconfirmedErrorDetails _ => null,
                CannotRemoveLastMemberErrorDetails _ => null,
                ConcurrentMembershipChangeErrorDetails _ => null,
                ExternalKeyValidationFailedErrorDetails _ => null,
                ExternalKeyValidationTimedOutErrorDetails _ => null,
                KeyProfileMismatchErrorDetails _ => null,
                WorkspacePolicyViolationErrorDetails _ => null,
                ExternalKeyChangedErrorDetails _ => null,
                WorkspaceMemberLimitExceededErrorDetails _ => null,
                OrganizationTypeNotSupportedErrorDetails _ => null,
                Environments::BetaEnvironmentCreateDisabledErrorDetails _ => null,
                Environments::BetaEnvironmentArchivedErrorDetails _ => null,
                Environments::BetaInvalidConfigTypeChangeErrorDetails _ => null,
                Environments::BetaEnvironmentUpdateDisabledErrorDetails _ => null,
                BetaHeartbeatPreconditionFailedErrorDetails _ => null,
                Environments::BetaInvalidMetadataErrorDetails _ => null,
                BetaBillingFrozenErrorDetails _ => null,
                BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails _ => null,
                BetaUnsupportedCharsetErrorDetails _ => null,
                Plugins::BetaPluginNameTakenErrorDetails x => x.PluginID,
                Plugins::BetaSkillNameTakenErrorDetails _ => null,
                Plugins::BetaRegistrationPendingErrorDetails x => x.PluginID,
                Plugins::BetaScanFailedErrorDetails _ => null,
                Plugins::BetaScanPendingErrorDetails _ => null,
                BetaSlackChannelSetUpSettingsRefusedErrorDetails _ => null,
                BetaApiKeyScopeMissingErrorDetails _ => null,
                BetaClaudeTagWritesNotEnabledErrorDetails _ => null,
                BetaComplianceConfigurationRestrictedErrorDetails _ => null,
                BetaOrganizationLevelScopedApiKeyRequiredErrorDetails _ => null,
                Environments::BetaEnvironmentNotFoundErrorDetails _ => null,
                BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails _ => null,
                BetaSlackChannelSetUpSettingsConflictErrorDetails _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "plugin_id"),
            };
        }
    }

    public string? PluginVersionID
    {
        get
        {
            return this.Value switch
            {
                Messages::AvailableToolsLimitExceededErrorDetails _ => null,
                ClaudeCodeKeyCreatorNotMemberErrorDetails _ => null,
                ClaudeCodeVersionTooOldErrorDetails _ => null,
                CmekKeyDisabledErrorDetails _ => null,
                CmekKeyNetworkBlockedErrorDetails _ => null,
                Messages::CompactionBlockAmbiguousErrorDetails _ => null,
                Messages::CompactionBlockMisplacedErrorDetails _ => null,
                Messages::CompactionContentMismatchErrorDetails _ => null,
                Messages::CompactionIncompleteTurnErrorDetails _ => null,
                Messages::CompactionNothingToSummarizeErrorDetails _ => null,
                Messages::CompactionSignatureInvalidErrorDetails _ => null,
                Messages::CompactionTooManyToolReferencesErrorDetails _ => null,
                Messages::CompactionToolChangesMismatchErrorDetails _ => null,
                OrganizationOnHoldErrorDetails _ => null,
                RequestBodyEncodingInvalidErrorDetails _ => null,
                RequestBodyEncodingUnsupportedErrorDetails _ => null,
                Messages::ThreadAlreadyContinuedErrorDetails _ => null,
                Messages::ThreadContinueInFlightErrorDetails _ => null,
                Messages::ThreadFingerprintMismatchErrorDetails _ => null,
                Messages::ThreadUnsupportedRequestErrorDetails _ => null,
                Messages::ToolNameConflictErrorDetails _ => null,
                Messages::ToolReferenceUnresolvedErrorDetails _ => null,
                Messages::ThreadNotFoundErrorDetails _ => null,
                Skills::SkillReadBlockedUndecryptableErrorDetails _ => null,
                RequestBodyTooLargeAfterDecodingErrorDetails _ => null,
                EnforcedSpendLimitReachedErrorDetails _ => null,
                RampLimitExceededErrorDetails _ => null,
                CmekKeyUnreachableErrorDetails _ => null,
                Messages::CompactionUnavailableErrorDetails _ => null,
                Files::StorageQuotaExceededErrorDetails _ => null,
                Files::FileNotDownloadableErrorDetails _ => null,
                Files::FileExpiredErrorDetails _ => null,
                CmekContextUnavailableErrorDetails _ => null,
                ApiKeys::OrgApiKeyLimitExceededErrorDetails _ => null,
                ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails _ => null,
                UserProfileNotFoundErrorDetails _ => null,
                ExternalKeyInWorkspacePolicyErrorDetails _ => null,
                AlreadyMemberErrorDetails _ => null,
                CannotInviteEmailsWithUnverifiedDomainsErrorDetails _ => null,
                EmailDomainNotAllowedErrorDetails _ => null,
                InviteAlreadyExistsErrorDetails _ => null,
                OrgMemberLimitExceededErrorDetails _ => null,
                RbacGroupGrantsOwnerAccessErrorDetails _ => null,
                RbacGroupOwnerAccessUnconfirmedErrorDetails _ => null,
                CannotRemoveLastMemberErrorDetails _ => null,
                ConcurrentMembershipChangeErrorDetails _ => null,
                ExternalKeyValidationFailedErrorDetails _ => null,
                ExternalKeyValidationTimedOutErrorDetails _ => null,
                KeyProfileMismatchErrorDetails _ => null,
                WorkspacePolicyViolationErrorDetails _ => null,
                ExternalKeyChangedErrorDetails _ => null,
                WorkspaceMemberLimitExceededErrorDetails _ => null,
                OrganizationTypeNotSupportedErrorDetails _ => null,
                Environments::BetaEnvironmentCreateDisabledErrorDetails _ => null,
                Environments::BetaEnvironmentArchivedErrorDetails _ => null,
                Environments::BetaInvalidConfigTypeChangeErrorDetails _ => null,
                Environments::BetaEnvironmentUpdateDisabledErrorDetails _ => null,
                BetaHeartbeatPreconditionFailedErrorDetails _ => null,
                Environments::BetaInvalidMetadataErrorDetails _ => null,
                BetaBillingFrozenErrorDetails _ => null,
                BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails _ => null,
                BetaUnsupportedCharsetErrorDetails _ => null,
                Plugins::BetaPluginNameTakenErrorDetails _ => null,
                Plugins::BetaSkillNameTakenErrorDetails _ => null,
                Plugins::BetaRegistrationPendingErrorDetails x => x.PluginVersionID,
                Plugins::BetaScanFailedErrorDetails x => x.PluginVersionID,
                Plugins::BetaScanPendingErrorDetails x => x.PluginVersionID,
                BetaSlackChannelSetUpSettingsRefusedErrorDetails _ => null,
                BetaApiKeyScopeMissingErrorDetails _ => null,
                BetaClaudeTagWritesNotEnabledErrorDetails _ => null,
                BetaComplianceConfigurationRestrictedErrorDetails _ => null,
                BetaOrganizationLevelScopedApiKeyRequiredErrorDetails _ => null,
                Environments::BetaEnvironmentNotFoundErrorDetails _ => null,
                BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails _ => null,
                BetaSlackChannelSetUpSettingsConflictErrorDetails _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "plugin_version_id"
                ),
            };
        }
    }

    public string? SlackChannelID
    {
        get
        {
            return this.Value switch
            {
                Messages::AvailableToolsLimitExceededErrorDetails _ => null,
                ClaudeCodeKeyCreatorNotMemberErrorDetails _ => null,
                ClaudeCodeVersionTooOldErrorDetails _ => null,
                CmekKeyDisabledErrorDetails _ => null,
                CmekKeyNetworkBlockedErrorDetails _ => null,
                Messages::CompactionBlockAmbiguousErrorDetails _ => null,
                Messages::CompactionBlockMisplacedErrorDetails _ => null,
                Messages::CompactionContentMismatchErrorDetails _ => null,
                Messages::CompactionIncompleteTurnErrorDetails _ => null,
                Messages::CompactionNothingToSummarizeErrorDetails _ => null,
                Messages::CompactionSignatureInvalidErrorDetails _ => null,
                Messages::CompactionTooManyToolReferencesErrorDetails _ => null,
                Messages::CompactionToolChangesMismatchErrorDetails _ => null,
                OrganizationOnHoldErrorDetails _ => null,
                RequestBodyEncodingInvalidErrorDetails _ => null,
                RequestBodyEncodingUnsupportedErrorDetails _ => null,
                Messages::ThreadAlreadyContinuedErrorDetails _ => null,
                Messages::ThreadContinueInFlightErrorDetails _ => null,
                Messages::ThreadFingerprintMismatchErrorDetails _ => null,
                Messages::ThreadUnsupportedRequestErrorDetails _ => null,
                Messages::ToolNameConflictErrorDetails _ => null,
                Messages::ToolReferenceUnresolvedErrorDetails _ => null,
                Messages::ThreadNotFoundErrorDetails _ => null,
                Skills::SkillReadBlockedUndecryptableErrorDetails _ => null,
                RequestBodyTooLargeAfterDecodingErrorDetails _ => null,
                EnforcedSpendLimitReachedErrorDetails _ => null,
                RampLimitExceededErrorDetails _ => null,
                CmekKeyUnreachableErrorDetails _ => null,
                Messages::CompactionUnavailableErrorDetails _ => null,
                Files::StorageQuotaExceededErrorDetails _ => null,
                Files::FileNotDownloadableErrorDetails _ => null,
                Files::FileExpiredErrorDetails _ => null,
                CmekContextUnavailableErrorDetails _ => null,
                ApiKeys::OrgApiKeyLimitExceededErrorDetails _ => null,
                ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails _ => null,
                UserProfileNotFoundErrorDetails _ => null,
                ExternalKeyInWorkspacePolicyErrorDetails _ => null,
                AlreadyMemberErrorDetails _ => null,
                CannotInviteEmailsWithUnverifiedDomainsErrorDetails _ => null,
                EmailDomainNotAllowedErrorDetails _ => null,
                InviteAlreadyExistsErrorDetails _ => null,
                OrgMemberLimitExceededErrorDetails _ => null,
                RbacGroupGrantsOwnerAccessErrorDetails _ => null,
                RbacGroupOwnerAccessUnconfirmedErrorDetails _ => null,
                CannotRemoveLastMemberErrorDetails _ => null,
                ConcurrentMembershipChangeErrorDetails _ => null,
                ExternalKeyValidationFailedErrorDetails _ => null,
                ExternalKeyValidationTimedOutErrorDetails _ => null,
                KeyProfileMismatchErrorDetails _ => null,
                WorkspacePolicyViolationErrorDetails _ => null,
                ExternalKeyChangedErrorDetails _ => null,
                WorkspaceMemberLimitExceededErrorDetails _ => null,
                OrganizationTypeNotSupportedErrorDetails _ => null,
                Environments::BetaEnvironmentCreateDisabledErrorDetails _ => null,
                Environments::BetaEnvironmentArchivedErrorDetails _ => null,
                Environments::BetaInvalidConfigTypeChangeErrorDetails _ => null,
                Environments::BetaEnvironmentUpdateDisabledErrorDetails _ => null,
                BetaHeartbeatPreconditionFailedErrorDetails _ => null,
                Environments::BetaInvalidMetadataErrorDetails _ => null,
                BetaBillingFrozenErrorDetails _ => null,
                BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails _ => null,
                BetaUnsupportedCharsetErrorDetails _ => null,
                Plugins::BetaPluginNameTakenErrorDetails _ => null,
                Plugins::BetaSkillNameTakenErrorDetails _ => null,
                Plugins::BetaRegistrationPendingErrorDetails _ => null,
                Plugins::BetaScanFailedErrorDetails _ => null,
                Plugins::BetaScanPendingErrorDetails _ => null,
                BetaSlackChannelSetUpSettingsRefusedErrorDetails x => x.SlackChannelID,
                BetaApiKeyScopeMissingErrorDetails _ => null,
                BetaClaudeTagWritesNotEnabledErrorDetails _ => null,
                BetaComplianceConfigurationRestrictedErrorDetails _ => null,
                BetaOrganizationLevelScopedApiKeyRequiredErrorDetails _ => null,
                Environments::BetaEnvironmentNotFoundErrorDetails _ => null,
                BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails x => x.SlackChannelID,
                BetaSlackChannelSetUpSettingsConflictErrorDetails x => x.SlackChannelID,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "slack_channel_id"
                ),
            };
        }
    }

    public ErrorDetails(
        Messages::AvailableToolsLimitExceededErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        ClaudeCodeKeyCreatorNotMemberErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(ClaudeCodeVersionTooOldErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(CmekKeyDisabledErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(CmekKeyNetworkBlockedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionBlockAmbiguousErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionBlockMisplacedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionContentMismatchErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionIncompleteTurnErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionNothingToSummarizeErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionSignatureInvalidErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionTooManyToolReferencesErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionToolChangesMismatchErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(OrganizationOnHoldErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(RequestBodyEncodingInvalidErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        RequestBodyEncodingUnsupportedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::ThreadAlreadyContinuedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::ThreadContinueInFlightErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::ThreadFingerprintMismatchErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::ThreadUnsupportedRequestErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Messages::ToolNameConflictErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::ToolReferenceUnresolvedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Messages::ThreadNotFoundErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Skills::SkillReadBlockedUndecryptableErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        RequestBodyTooLargeAfterDecodingErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(EnforcedSpendLimitReachedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(RampLimitExceededErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(CmekKeyUnreachableErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Messages::CompactionUnavailableErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Files::StorageQuotaExceededErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Files::FileNotDownloadableErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Files::FileExpiredErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(CmekContextUnavailableErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        ApiKeys::OrgApiKeyLimitExceededErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(UserProfileNotFoundErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(ExternalKeyInWorkspacePolicyErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(AlreadyMemberErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        CannotInviteEmailsWithUnverifiedDomainsErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(EmailDomainNotAllowedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(InviteAlreadyExistsErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(OrgMemberLimitExceededErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(RbacGroupGrantsOwnerAccessErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        RbacGroupOwnerAccessUnconfirmedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(CannotRemoveLastMemberErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(ConcurrentMembershipChangeErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(ExternalKeyValidationFailedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        ExternalKeyValidationTimedOutErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(KeyProfileMismatchErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(WorkspacePolicyViolationErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(ExternalKeyChangedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(WorkspaceMemberLimitExceededErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(OrganizationTypeNotSupportedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Environments::BetaEnvironmentCreateDisabledErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Environments::BetaEnvironmentArchivedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Environments::BetaInvalidConfigTypeChangeErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Environments::BetaEnvironmentUpdateDisabledErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaHeartbeatPreconditionFailedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Environments::BetaInvalidMetadataErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(BetaBillingFrozenErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(BetaUnsupportedCharsetErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Plugins::BetaPluginNameTakenErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Plugins::BetaSkillNameTakenErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Plugins::BetaRegistrationPendingErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Plugins::BetaScanFailedErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(Plugins::BetaScanPendingErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaSlackChannelSetUpSettingsRefusedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(BetaApiKeyScopeMissingErrorDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaClaudeTagWritesNotEnabledErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaComplianceConfigurationRestrictedErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaOrganizationLevelScopedApiKeyRequiredErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        Environments::BetaEnvironmentNotFoundErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(
        BetaSlackChannelSetUpSettingsConflictErrorDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorDetails(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::AvailableToolsLimitExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAvailableToolsLimitExceeded(out var value)) {
    ///     // `value` is of type `Messages::AvailableToolsLimitExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAvailableToolsLimitExceeded(
        [NotNullWhen(true)] out Messages::AvailableToolsLimitExceededErrorDetails? value
    )
    {
        value = this.Value as Messages::AvailableToolsLimitExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ClaudeCodeKeyCreatorNotMemberErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClaudeCodeKeyCreatorNotMember(out var value)) {
    ///     // `value` is of type `ClaudeCodeKeyCreatorNotMemberErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClaudeCodeKeyCreatorNotMember(
        [NotNullWhen(true)] out ClaudeCodeKeyCreatorNotMemberErrorDetails? value
    )
    {
        value = this.Value as ClaudeCodeKeyCreatorNotMemberErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ClaudeCodeVersionTooOldErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClaudeCodeVersionTooOld(out var value)) {
    ///     // `value` is of type `ClaudeCodeVersionTooOldErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClaudeCodeVersionTooOld(
        [NotNullWhen(true)] out ClaudeCodeVersionTooOldErrorDetails? value
    )
    {
        value = this.Value as ClaudeCodeVersionTooOldErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CmekKeyDisabledErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCmekKeyDisabled(out var value)) {
    ///     // `value` is of type `CmekKeyDisabledErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCmekKeyDisabled([NotNullWhen(true)] out CmekKeyDisabledErrorDetails? value)
    {
        value = this.Value as CmekKeyDisabledErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CmekKeyNetworkBlockedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCmekKeyNetworkBlocked(out var value)) {
    ///     // `value` is of type `CmekKeyNetworkBlockedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCmekKeyNetworkBlocked(
        [NotNullWhen(true)] out CmekKeyNetworkBlockedErrorDetails? value
    )
    {
        value = this.Value as CmekKeyNetworkBlockedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionBlockAmbiguousErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionBlockAmbiguous(out var value)) {
    ///     // `value` is of type `Messages::CompactionBlockAmbiguousErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionBlockAmbiguous(
        [NotNullWhen(true)] out Messages::CompactionBlockAmbiguousErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionBlockAmbiguousErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionBlockMisplacedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionBlockMisplaced(out var value)) {
    ///     // `value` is of type `Messages::CompactionBlockMisplacedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionBlockMisplaced(
        [NotNullWhen(true)] out Messages::CompactionBlockMisplacedErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionBlockMisplacedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionContentMismatchErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionContentMismatch(out var value)) {
    ///     // `value` is of type `Messages::CompactionContentMismatchErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionContentMismatch(
        [NotNullWhen(true)] out Messages::CompactionContentMismatchErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionContentMismatchErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionIncompleteTurnErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionIncompleteTurn(out var value)) {
    ///     // `value` is of type `Messages::CompactionIncompleteTurnErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionIncompleteTurn(
        [NotNullWhen(true)] out Messages::CompactionIncompleteTurnErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionIncompleteTurnErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionNothingToSummarizeErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionNothingToSummarize(out var value)) {
    ///     // `value` is of type `Messages::CompactionNothingToSummarizeErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionNothingToSummarize(
        [NotNullWhen(true)] out Messages::CompactionNothingToSummarizeErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionNothingToSummarizeErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionSignatureInvalidErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionSignatureInvalid(out var value)) {
    ///     // `value` is of type `Messages::CompactionSignatureInvalidErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionSignatureInvalid(
        [NotNullWhen(true)] out Messages::CompactionSignatureInvalidErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionSignatureInvalidErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionTooManyToolReferencesErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionTooManyToolReferences(out var value)) {
    ///     // `value` is of type `Messages::CompactionTooManyToolReferencesErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionTooManyToolReferences(
        [NotNullWhen(true)] out Messages::CompactionTooManyToolReferencesErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionTooManyToolReferencesErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionToolChangesMismatchErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionToolChangesMismatch(out var value)) {
    ///     // `value` is of type `Messages::CompactionToolChangesMismatchErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionToolChangesMismatch(
        [NotNullWhen(true)] out Messages::CompactionToolChangesMismatchErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionToolChangesMismatchErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationOnHoldErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationOnHold(out var value)) {
    ///     // `value` is of type `OrganizationOnHoldErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationOnHold(
        [NotNullWhen(true)] out OrganizationOnHoldErrorDetails? value
    )
    {
        value = this.Value as OrganizationOnHoldErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RequestBodyEncodingInvalidErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRequestBodyEncodingInvalid(out var value)) {
    ///     // `value` is of type `RequestBodyEncodingInvalidErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRequestBodyEncodingInvalid(
        [NotNullWhen(true)] out RequestBodyEncodingInvalidErrorDetails? value
    )
    {
        value = this.Value as RequestBodyEncodingInvalidErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RequestBodyEncodingUnsupportedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRequestBodyEncodingUnsupported(out var value)) {
    ///     // `value` is of type `RequestBodyEncodingUnsupportedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRequestBodyEncodingUnsupported(
        [NotNullWhen(true)] out RequestBodyEncodingUnsupportedErrorDetails? value
    )
    {
        value = this.Value as RequestBodyEncodingUnsupportedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ThreadAlreadyContinuedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadAlreadyContinued(out var value)) {
    ///     // `value` is of type `Messages::ThreadAlreadyContinuedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadAlreadyContinued(
        [NotNullWhen(true)] out Messages::ThreadAlreadyContinuedErrorDetails? value
    )
    {
        value = this.Value as Messages::ThreadAlreadyContinuedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ThreadContinueInFlightErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadContinueInFlight(out var value)) {
    ///     // `value` is of type `Messages::ThreadContinueInFlightErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadContinueInFlight(
        [NotNullWhen(true)] out Messages::ThreadContinueInFlightErrorDetails? value
    )
    {
        value = this.Value as Messages::ThreadContinueInFlightErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ThreadFingerprintMismatchErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadFingerprintMismatch(out var value)) {
    ///     // `value` is of type `Messages::ThreadFingerprintMismatchErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadFingerprintMismatch(
        [NotNullWhen(true)] out Messages::ThreadFingerprintMismatchErrorDetails? value
    )
    {
        value = this.Value as Messages::ThreadFingerprintMismatchErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ThreadUnsupportedRequestErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadUnsupportedRequest(out var value)) {
    ///     // `value` is of type `Messages::ThreadUnsupportedRequestErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadUnsupportedRequest(
        [NotNullWhen(true)] out Messages::ThreadUnsupportedRequestErrorDetails? value
    )
    {
        value = this.Value as Messages::ThreadUnsupportedRequestErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ToolNameConflictErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolNameConflict(out var value)) {
    ///     // `value` is of type `Messages::ToolNameConflictErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolNameConflict(
        [NotNullWhen(true)] out Messages::ToolNameConflictErrorDetails? value
    )
    {
        value = this.Value as Messages::ToolNameConflictErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ToolReferenceUnresolvedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolReferenceUnresolved(out var value)) {
    ///     // `value` is of type `Messages::ToolReferenceUnresolvedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolReferenceUnresolved(
        [NotNullWhen(true)] out Messages::ToolReferenceUnresolvedErrorDetails? value
    )
    {
        value = this.Value as Messages::ToolReferenceUnresolvedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::ThreadNotFoundErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadNotFound(out var value)) {
    ///     // `value` is of type `Messages::ThreadNotFoundErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadNotFound(
        [NotNullWhen(true)] out Messages::ThreadNotFoundErrorDetails? value
    )
    {
        value = this.Value as Messages::ThreadNotFoundErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Skills::SkillReadBlockedUndecryptableErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSkillReadBlockedUndecryptable(out var value)) {
    ///     // `value` is of type `Skills::SkillReadBlockedUndecryptableErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSkillReadBlockedUndecryptable(
        [NotNullWhen(true)] out Skills::SkillReadBlockedUndecryptableErrorDetails? value
    )
    {
        value = this.Value as Skills::SkillReadBlockedUndecryptableErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RequestBodyTooLargeAfterDecodingErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRequestBodyTooLargeAfterDecoding(out var value)) {
    ///     // `value` is of type `RequestBodyTooLargeAfterDecodingErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRequestBodyTooLargeAfterDecoding(
        [NotNullWhen(true)] out RequestBodyTooLargeAfterDecodingErrorDetails? value
    )
    {
        value = this.Value as RequestBodyTooLargeAfterDecodingErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EnforcedSpendLimitReachedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnforcedSpendLimitReached(out var value)) {
    ///     // `value` is of type `EnforcedSpendLimitReachedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnforcedSpendLimitReached(
        [NotNullWhen(true)] out EnforcedSpendLimitReachedErrorDetails? value
    )
    {
        value = this.Value as EnforcedSpendLimitReachedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RampLimitExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRampLimitExceeded(out var value)) {
    ///     // `value` is of type `RampLimitExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRampLimitExceeded(
        [NotNullWhen(true)] out RampLimitExceededErrorDetails? value
    )
    {
        value = this.Value as RampLimitExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CmekKeyUnreachableErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCmekKeyUnreachable(out var value)) {
    ///     // `value` is of type `CmekKeyUnreachableErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCmekKeyUnreachable(
        [NotNullWhen(true)] out CmekKeyUnreachableErrorDetails? value
    )
    {
        value = this.Value as CmekKeyUnreachableErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Messages::CompactionUnavailableErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompactionUnavailable(out var value)) {
    ///     // `value` is of type `Messages::CompactionUnavailableErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompactionUnavailable(
        [NotNullWhen(true)] out Messages::CompactionUnavailableErrorDetails? value
    )
    {
        value = this.Value as Messages::CompactionUnavailableErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Files::StorageQuotaExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStorageQuotaExceeded(out var value)) {
    ///     // `value` is of type `Files::StorageQuotaExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStorageQuotaExceeded(
        [NotNullWhen(true)] out Files::StorageQuotaExceededErrorDetails? value
    )
    {
        value = this.Value as Files::StorageQuotaExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Files::FileNotDownloadableErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileNotDownloadable(out var value)) {
    ///     // `value` is of type `Files::FileNotDownloadableErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileNotDownloadable(
        [NotNullWhen(true)] out Files::FileNotDownloadableErrorDetails? value
    )
    {
        value = this.Value as Files::FileNotDownloadableErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Files::FileExpiredErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileExpired(out var value)) {
    ///     // `value` is of type `Files::FileExpiredErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileExpired([NotNullWhen(true)] out Files::FileExpiredErrorDetails? value)
    {
        value = this.Value as Files::FileExpiredErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CmekContextUnavailableErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCmekContextUnavailable(out var value)) {
    ///     // `value` is of type `CmekContextUnavailableErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCmekContextUnavailable(
        [NotNullWhen(true)] out CmekContextUnavailableErrorDetails? value
    )
    {
        value = this.Value as CmekContextUnavailableErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiKeys::OrgApiKeyLimitExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrgApiKeyLimitExceeded(out var value)) {
    ///     // `value` is of type `ApiKeys::OrgApiKeyLimitExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrgApiKeyLimitExceeded(
        [NotNullWhen(true)] out ApiKeys::OrgApiKeyLimitExceededErrorDetails? value
    )
    {
        value = this.Value as ApiKeys::OrgApiKeyLimitExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWorkspaceApiKeyLimitExceeded(out var value)) {
    ///     // `value` is of type `ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWorkspaceApiKeyLimitExceeded(
        [NotNullWhen(true)] out ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails? value
    )
    {
        value = this.Value as ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserProfileNotFoundErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserProfileNotFound(out var value)) {
    ///     // `value` is of type `UserProfileNotFoundErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserProfileNotFound(
        [NotNullWhen(true)] out UserProfileNotFoundErrorDetails? value
    )
    {
        value = this.Value as UserProfileNotFoundErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExternalKeyInWorkspacePolicyErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternalKeyInWorkspacePolicy(out var value)) {
    ///     // `value` is of type `ExternalKeyInWorkspacePolicyErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternalKeyInWorkspacePolicy(
        [NotNullWhen(true)] out ExternalKeyInWorkspacePolicyErrorDetails? value
    )
    {
        value = this.Value as ExternalKeyInWorkspacePolicyErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AlreadyMemberErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAlreadyMember(out var value)) {
    ///     // `value` is of type `AlreadyMemberErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAlreadyMember([NotNullWhen(true)] out AlreadyMemberErrorDetails? value)
    {
        value = this.Value as AlreadyMemberErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CannotInviteEmailsWithUnverifiedDomainsErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCannotInviteEmailsWithUnverifiedDomains(out var value)) {
    ///     // `value` is of type `CannotInviteEmailsWithUnverifiedDomainsErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCannotInviteEmailsWithUnverifiedDomains(
        [NotNullWhen(true)] out CannotInviteEmailsWithUnverifiedDomainsErrorDetails? value
    )
    {
        value = this.Value as CannotInviteEmailsWithUnverifiedDomainsErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EmailDomainNotAllowedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEmailDomainNotAllowed(out var value)) {
    ///     // `value` is of type `EmailDomainNotAllowedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEmailDomainNotAllowed(
        [NotNullWhen(true)] out EmailDomainNotAllowedErrorDetails? value
    )
    {
        value = this.Value as EmailDomainNotAllowedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InviteAlreadyExistsErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInviteAlreadyExists(out var value)) {
    ///     // `value` is of type `InviteAlreadyExistsErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInviteAlreadyExists(
        [NotNullWhen(true)] out InviteAlreadyExistsErrorDetails? value
    )
    {
        value = this.Value as InviteAlreadyExistsErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrgMemberLimitExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrgMemberLimitExceeded(out var value)) {
    ///     // `value` is of type `OrgMemberLimitExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrgMemberLimitExceeded(
        [NotNullWhen(true)] out OrgMemberLimitExceededErrorDetails? value
    )
    {
        value = this.Value as OrgMemberLimitExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacGroupGrantsOwnerAccessErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacGroupGrantsOwnerAccess(out var value)) {
    ///     // `value` is of type `RbacGroupGrantsOwnerAccessErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacGroupGrantsOwnerAccess(
        [NotNullWhen(true)] out RbacGroupGrantsOwnerAccessErrorDetails? value
    )
    {
        value = this.Value as RbacGroupGrantsOwnerAccessErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacGroupOwnerAccessUnconfirmedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacGroupOwnerAccessUnconfirmed(out var value)) {
    ///     // `value` is of type `RbacGroupOwnerAccessUnconfirmedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacGroupOwnerAccessUnconfirmed(
        [NotNullWhen(true)] out RbacGroupOwnerAccessUnconfirmedErrorDetails? value
    )
    {
        value = this.Value as RbacGroupOwnerAccessUnconfirmedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CannotRemoveLastMemberErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCannotRemoveLastMember(out var value)) {
    ///     // `value` is of type `CannotRemoveLastMemberErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCannotRemoveLastMember(
        [NotNullWhen(true)] out CannotRemoveLastMemberErrorDetails? value
    )
    {
        value = this.Value as CannotRemoveLastMemberErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ConcurrentMembershipChangeErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConcurrentMembershipChange(out var value)) {
    ///     // `value` is of type `ConcurrentMembershipChangeErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConcurrentMembershipChange(
        [NotNullWhen(true)] out ConcurrentMembershipChangeErrorDetails? value
    )
    {
        value = this.Value as ConcurrentMembershipChangeErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExternalKeyValidationFailedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternalKeyValidationFailed(out var value)) {
    ///     // `value` is of type `ExternalKeyValidationFailedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternalKeyValidationFailed(
        [NotNullWhen(true)] out ExternalKeyValidationFailedErrorDetails? value
    )
    {
        value = this.Value as ExternalKeyValidationFailedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExternalKeyValidationTimedOutErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternalKeyValidationTimedOut(out var value)) {
    ///     // `value` is of type `ExternalKeyValidationTimedOutErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternalKeyValidationTimedOut(
        [NotNullWhen(true)] out ExternalKeyValidationTimedOutErrorDetails? value
    )
    {
        value = this.Value as ExternalKeyValidationTimedOutErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="KeyProfileMismatchErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickKeyProfileMismatch(out var value)) {
    ///     // `value` is of type `KeyProfileMismatchErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickKeyProfileMismatch(
        [NotNullWhen(true)] out KeyProfileMismatchErrorDetails? value
    )
    {
        value = this.Value as KeyProfileMismatchErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WorkspacePolicyViolationErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWorkspacePolicyViolation(out var value)) {
    ///     // `value` is of type `WorkspacePolicyViolationErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWorkspacePolicyViolation(
        [NotNullWhen(true)] out WorkspacePolicyViolationErrorDetails? value
    )
    {
        value = this.Value as WorkspacePolicyViolationErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExternalKeyChangedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternalKeyChanged(out var value)) {
    ///     // `value` is of type `ExternalKeyChangedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternalKeyChanged(
        [NotNullWhen(true)] out ExternalKeyChangedErrorDetails? value
    )
    {
        value = this.Value as ExternalKeyChangedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WorkspaceMemberLimitExceededErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWorkspaceMemberLimitExceeded(out var value)) {
    ///     // `value` is of type `WorkspaceMemberLimitExceededErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWorkspaceMemberLimitExceeded(
        [NotNullWhen(true)] out WorkspaceMemberLimitExceededErrorDetails? value
    )
    {
        value = this.Value as WorkspaceMemberLimitExceededErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationTypeNotSupportedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationTypeNotSupported(out var value)) {
    ///     // `value` is of type `OrganizationTypeNotSupportedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationTypeNotSupported(
        [NotNullWhen(true)] out OrganizationTypeNotSupportedErrorDetails? value
    )
    {
        value = this.Value as OrganizationTypeNotSupportedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Environments::BetaEnvironmentCreateDisabledErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaEnvironmentCreateDisabled(out var value)) {
    ///     // `value` is of type `Environments::BetaEnvironmentCreateDisabledErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaEnvironmentCreateDisabled(
        [NotNullWhen(true)] out Environments::BetaEnvironmentCreateDisabledErrorDetails? value
    )
    {
        value = this.Value as Environments::BetaEnvironmentCreateDisabledErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Environments::BetaEnvironmentArchivedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaEnvironmentArchived(out var value)) {
    ///     // `value` is of type `Environments::BetaEnvironmentArchivedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaEnvironmentArchived(
        [NotNullWhen(true)] out Environments::BetaEnvironmentArchivedErrorDetails? value
    )
    {
        value = this.Value as Environments::BetaEnvironmentArchivedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Environments::BetaInvalidConfigTypeChangeErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaInvalidConfigTypeChange(out var value)) {
    ///     // `value` is of type `Environments::BetaInvalidConfigTypeChangeErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaInvalidConfigTypeChange(
        [NotNullWhen(true)] out Environments::BetaInvalidConfigTypeChangeErrorDetails? value
    )
    {
        value = this.Value as Environments::BetaInvalidConfigTypeChangeErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Environments::BetaEnvironmentUpdateDisabledErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaEnvironmentUpdateDisabled(out var value)) {
    ///     // `value` is of type `Environments::BetaEnvironmentUpdateDisabledErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaEnvironmentUpdateDisabled(
        [NotNullWhen(true)] out Environments::BetaEnvironmentUpdateDisabledErrorDetails? value
    )
    {
        value = this.Value as Environments::BetaEnvironmentUpdateDisabledErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaHeartbeatPreconditionFailedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaHeartbeatPreconditionFailed(out var value)) {
    ///     // `value` is of type `BetaHeartbeatPreconditionFailedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaHeartbeatPreconditionFailed(
        [NotNullWhen(true)] out BetaHeartbeatPreconditionFailedErrorDetails? value
    )
    {
        value = this.Value as BetaHeartbeatPreconditionFailedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Environments::BetaInvalidMetadataErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaInvalidMetadata(out var value)) {
    ///     // `value` is of type `Environments::BetaInvalidMetadataErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaInvalidMetadata(
        [NotNullWhen(true)] out Environments::BetaInvalidMetadataErrorDetails? value
    )
    {
        value = this.Value as Environments::BetaInvalidMetadataErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBillingFrozenErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaBillingFrozen(out var value)) {
    ///     // `value` is of type `BetaBillingFrozenErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaBillingFrozen(
        [NotNullWhen(true)] out BetaBillingFrozenErrorDetails? value
    )
    {
        value = this.Value as BetaBillingFrozenErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitsAdminApiWritesNotEnabled(out var value)) {
    ///     // `value` is of type `BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitsAdminApiWritesNotEnabled(
        [NotNullWhen(true)] out BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails? value
    )
    {
        value = this.Value as BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaUnsupportedCharsetErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaUnsupportedCharset(out var value)) {
    ///     // `value` is of type `BetaUnsupportedCharsetErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaUnsupportedCharset(
        [NotNullWhen(true)] out BetaUnsupportedCharsetErrorDetails? value
    )
    {
        value = this.Value as BetaUnsupportedCharsetErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Plugins::BetaPluginNameTakenErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginNameTaken(out var value)) {
    ///     // `value` is of type `Plugins::BetaPluginNameTakenErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginNameTaken(
        [NotNullWhen(true)] out Plugins::BetaPluginNameTakenErrorDetails? value
    )
    {
        value = this.Value as Plugins::BetaPluginNameTakenErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Plugins::BetaSkillNameTakenErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSkillNameTaken(out var value)) {
    ///     // `value` is of type `Plugins::BetaSkillNameTakenErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSkillNameTaken(
        [NotNullWhen(true)] out Plugins::BetaSkillNameTakenErrorDetails? value
    )
    {
        value = this.Value as Plugins::BetaSkillNameTakenErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Plugins::BetaRegistrationPendingErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRegistrationPending(out var value)) {
    ///     // `value` is of type `Plugins::BetaRegistrationPendingErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRegistrationPending(
        [NotNullWhen(true)] out Plugins::BetaRegistrationPendingErrorDetails? value
    )
    {
        value = this.Value as Plugins::BetaRegistrationPendingErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Plugins::BetaScanFailedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaScanFailed(out var value)) {
    ///     // `value` is of type `Plugins::BetaScanFailedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaScanFailed(
        [NotNullWhen(true)] out Plugins::BetaScanFailedErrorDetails? value
    )
    {
        value = this.Value as Plugins::BetaScanFailedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Plugins::BetaScanPendingErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaScanPending(out var value)) {
    ///     // `value` is of type `Plugins::BetaScanPendingErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaScanPending(
        [NotNullWhen(true)] out Plugins::BetaScanPendingErrorDetails? value
    )
    {
        value = this.Value as Plugins::BetaScanPendingErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSlackChannelSetUpSettingsRefusedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSlackChannelSetUpSettingsRefused(out var value)) {
    ///     // `value` is of type `BetaSlackChannelSetUpSettingsRefusedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSlackChannelSetUpSettingsRefused(
        [NotNullWhen(true)] out BetaSlackChannelSetUpSettingsRefusedErrorDetails? value
    )
    {
        value = this.Value as BetaSlackChannelSetUpSettingsRefusedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaApiKeyScopeMissingErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaApiKeyScopeMissing(out var value)) {
    ///     // `value` is of type `BetaApiKeyScopeMissingErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaApiKeyScopeMissing(
        [NotNullWhen(true)] out BetaApiKeyScopeMissingErrorDetails? value
    )
    {
        value = this.Value as BetaApiKeyScopeMissingErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagWritesNotEnabledErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaClaudeTagWritesNotEnabled(out var value)) {
    ///     // `value` is of type `BetaClaudeTagWritesNotEnabledErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaClaudeTagWritesNotEnabled(
        [NotNullWhen(true)] out BetaClaudeTagWritesNotEnabledErrorDetails? value
    )
    {
        value = this.Value as BetaClaudeTagWritesNotEnabledErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceConfigurationRestrictedErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaComplianceConfigurationRestricted(out var value)) {
    ///     // `value` is of type `BetaComplianceConfigurationRestrictedErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaComplianceConfigurationRestricted(
        [NotNullWhen(true)] out BetaComplianceConfigurationRestrictedErrorDetails? value
    )
    {
        value = this.Value as BetaComplianceConfigurationRestrictedErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOrganizationLevelScopedApiKeyRequiredErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationLevelScopedApiKeyRequired(out var value)) {
    ///     // `value` is of type `BetaOrganizationLevelScopedApiKeyRequiredErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationLevelScopedApiKeyRequired(
        [NotNullWhen(true)] out BetaOrganizationLevelScopedApiKeyRequiredErrorDetails? value
    )
    {
        value = this.Value as BetaOrganizationLevelScopedApiKeyRequiredErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Environments::BetaEnvironmentNotFoundErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaEnvironmentNotFound(out var value)) {
    ///     // `value` is of type `Environments::BetaEnvironmentNotFoundErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaEnvironmentNotFound(
        [NotNullWhen(true)] out Environments::BetaEnvironmentNotFoundErrorDetails? value
    )
    {
        value = this.Value as Environments::BetaEnvironmentNotFoundErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSlackChannelSetUpEnvironmentNotFound(out var value)) {
    ///     // `value` is of type `BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSlackChannelSetUpEnvironmentNotFound(
        [NotNullWhen(true)] out BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails? value
    )
    {
        value = this.Value as BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSlackChannelSetUpSettingsConflictErrorDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSlackChannelSetUpSettingsConflict(out var value)) {
    ///     // `value` is of type `BetaSlackChannelSetUpSettingsConflictErrorDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSlackChannelSetUpSettingsConflict(
        [NotNullWhen(true)] out BetaSlackChannelSetUpSettingsConflictErrorDetails? value
    )
    {
        value = this.Value as BetaSlackChannelSetUpSettingsConflictErrorDetails;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Messages::AvailableToolsLimitExceededErrorDetails value) =&gt; {...},
    ///     (ClaudeCodeKeyCreatorNotMemberErrorDetails value) =&gt; {...},
    ///     (ClaudeCodeVersionTooOldErrorDetails value) =&gt; {...},
    ///     (CmekKeyDisabledErrorDetails value) =&gt; {...},
    ///     (CmekKeyNetworkBlockedErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionBlockAmbiguousErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionBlockMisplacedErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionContentMismatchErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionIncompleteTurnErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionNothingToSummarizeErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionSignatureInvalidErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionTooManyToolReferencesErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionToolChangesMismatchErrorDetails value) =&gt; {...},
    ///     (OrganizationOnHoldErrorDetails value) =&gt; {...},
    ///     (RequestBodyEncodingInvalidErrorDetails value) =&gt; {...},
    ///     (RequestBodyEncodingUnsupportedErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadAlreadyContinuedErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadContinueInFlightErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadFingerprintMismatchErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadUnsupportedRequestErrorDetails value) =&gt; {...},
    ///     (Messages::ToolNameConflictErrorDetails value) =&gt; {...},
    ///     (Messages::ToolReferenceUnresolvedErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadNotFoundErrorDetails value) =&gt; {...},
    ///     (Skills::SkillReadBlockedUndecryptableErrorDetails value) =&gt; {...},
    ///     (RequestBodyTooLargeAfterDecodingErrorDetails value) =&gt; {...},
    ///     (EnforcedSpendLimitReachedErrorDetails value) =&gt; {...},
    ///     (RampLimitExceededErrorDetails value) =&gt; {...},
    ///     (CmekKeyUnreachableErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionUnavailableErrorDetails value) =&gt; {...},
    ///     (Files::StorageQuotaExceededErrorDetails value) =&gt; {...},
    ///     (Files::FileNotDownloadableErrorDetails value) =&gt; {...},
    ///     (Files::FileExpiredErrorDetails value) =&gt; {...},
    ///     (CmekContextUnavailableErrorDetails value) =&gt; {...},
    ///     (ApiKeys::OrgApiKeyLimitExceededErrorDetails value) =&gt; {...},
    ///     (ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails value) =&gt; {...},
    ///     (UserProfileNotFoundErrorDetails value) =&gt; {...},
    ///     (ExternalKeyInWorkspacePolicyErrorDetails value) =&gt; {...},
    ///     (AlreadyMemberErrorDetails value) =&gt; {...},
    ///     (CannotInviteEmailsWithUnverifiedDomainsErrorDetails value) =&gt; {...},
    ///     (EmailDomainNotAllowedErrorDetails value) =&gt; {...},
    ///     (InviteAlreadyExistsErrorDetails value) =&gt; {...},
    ///     (OrgMemberLimitExceededErrorDetails value) =&gt; {...},
    ///     (RbacGroupGrantsOwnerAccessErrorDetails value) =&gt; {...},
    ///     (RbacGroupOwnerAccessUnconfirmedErrorDetails value) =&gt; {...},
    ///     (CannotRemoveLastMemberErrorDetails value) =&gt; {...},
    ///     (ConcurrentMembershipChangeErrorDetails value) =&gt; {...},
    ///     (ExternalKeyValidationFailedErrorDetails value) =&gt; {...},
    ///     (ExternalKeyValidationTimedOutErrorDetails value) =&gt; {...},
    ///     (KeyProfileMismatchErrorDetails value) =&gt; {...},
    ///     (WorkspacePolicyViolationErrorDetails value) =&gt; {...},
    ///     (ExternalKeyChangedErrorDetails value) =&gt; {...},
    ///     (WorkspaceMemberLimitExceededErrorDetails value) =&gt; {...},
    ///     (OrganizationTypeNotSupportedErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentCreateDisabledErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentArchivedErrorDetails value) =&gt; {...},
    ///     (Environments::BetaInvalidConfigTypeChangeErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentUpdateDisabledErrorDetails value) =&gt; {...},
    ///     (BetaHeartbeatPreconditionFailedErrorDetails value) =&gt; {...},
    ///     (Environments::BetaInvalidMetadataErrorDetails value) =&gt; {...},
    ///     (BetaBillingFrozenErrorDetails value) =&gt; {...},
    ///     (BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails value) =&gt; {...},
    ///     (BetaUnsupportedCharsetErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaPluginNameTakenErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaSkillNameTakenErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaRegistrationPendingErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaScanFailedErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaScanPendingErrorDetails value) =&gt; {...},
    ///     (BetaSlackChannelSetUpSettingsRefusedErrorDetails value) =&gt; {...},
    ///     (BetaApiKeyScopeMissingErrorDetails value) =&gt; {...},
    ///     (BetaClaudeTagWritesNotEnabledErrorDetails value) =&gt; {...},
    ///     (BetaComplianceConfigurationRestrictedErrorDetails value) =&gt; {...},
    ///     (BetaOrganizationLevelScopedApiKeyRequiredErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentNotFoundErrorDetails value) =&gt; {...},
    ///     (BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails value) =&gt; {...},
    ///     (BetaSlackChannelSetUpSettingsConflictErrorDetails value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Messages::AvailableToolsLimitExceededErrorDetails> availableToolsLimitExceeded,
        Action<ClaudeCodeKeyCreatorNotMemberErrorDetails> claudeCodeKeyCreatorNotMember,
        Action<ClaudeCodeVersionTooOldErrorDetails> claudeCodeVersionTooOld,
        Action<CmekKeyDisabledErrorDetails> cmekKeyDisabled,
        Action<CmekKeyNetworkBlockedErrorDetails> cmekKeyNetworkBlocked,
        Action<Messages::CompactionBlockAmbiguousErrorDetails> compactionBlockAmbiguous,
        Action<Messages::CompactionBlockMisplacedErrorDetails> compactionBlockMisplaced,
        Action<Messages::CompactionContentMismatchErrorDetails> compactionContentMismatch,
        Action<Messages::CompactionIncompleteTurnErrorDetails> compactionIncompleteTurn,
        Action<Messages::CompactionNothingToSummarizeErrorDetails> compactionNothingToSummarize,
        Action<Messages::CompactionSignatureInvalidErrorDetails> compactionSignatureInvalid,
        Action<Messages::CompactionTooManyToolReferencesErrorDetails> compactionTooManyToolReferences,
        Action<Messages::CompactionToolChangesMismatchErrorDetails> compactionToolChangesMismatch,
        Action<OrganizationOnHoldErrorDetails> organizationOnHold,
        Action<RequestBodyEncodingInvalidErrorDetails> requestBodyEncodingInvalid,
        Action<RequestBodyEncodingUnsupportedErrorDetails> requestBodyEncodingUnsupported,
        Action<Messages::ThreadAlreadyContinuedErrorDetails> threadAlreadyContinued,
        Action<Messages::ThreadContinueInFlightErrorDetails> threadContinueInFlight,
        Action<Messages::ThreadFingerprintMismatchErrorDetails> threadFingerprintMismatch,
        Action<Messages::ThreadUnsupportedRequestErrorDetails> threadUnsupportedRequest,
        Action<Messages::ToolNameConflictErrorDetails> toolNameConflict,
        Action<Messages::ToolReferenceUnresolvedErrorDetails> toolReferenceUnresolved,
        Action<Messages::ThreadNotFoundErrorDetails> threadNotFound,
        Action<Skills::SkillReadBlockedUndecryptableErrorDetails> skillReadBlockedUndecryptable,
        Action<RequestBodyTooLargeAfterDecodingErrorDetails> requestBodyTooLargeAfterDecoding,
        Action<EnforcedSpendLimitReachedErrorDetails> enforcedSpendLimitReached,
        Action<RampLimitExceededErrorDetails> rampLimitExceeded,
        Action<CmekKeyUnreachableErrorDetails> cmekKeyUnreachable,
        Action<Messages::CompactionUnavailableErrorDetails> compactionUnavailable,
        Action<Files::StorageQuotaExceededErrorDetails> storageQuotaExceeded,
        Action<Files::FileNotDownloadableErrorDetails> fileNotDownloadable,
        Action<Files::FileExpiredErrorDetails> fileExpired,
        Action<CmekContextUnavailableErrorDetails> cmekContextUnavailable,
        Action<ApiKeys::OrgApiKeyLimitExceededErrorDetails> orgApiKeyLimitExceeded,
        Action<ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails> workspaceApiKeyLimitExceeded,
        Action<UserProfileNotFoundErrorDetails> userProfileNotFound,
        Action<ExternalKeyInWorkspacePolicyErrorDetails> externalKeyInWorkspacePolicy,
        Action<AlreadyMemberErrorDetails> alreadyMember,
        Action<CannotInviteEmailsWithUnverifiedDomainsErrorDetails> cannotInviteEmailsWithUnverifiedDomains,
        Action<EmailDomainNotAllowedErrorDetails> emailDomainNotAllowed,
        Action<InviteAlreadyExistsErrorDetails> inviteAlreadyExists,
        Action<OrgMemberLimitExceededErrorDetails> orgMemberLimitExceeded,
        Action<RbacGroupGrantsOwnerAccessErrorDetails> rbacGroupGrantsOwnerAccess,
        Action<RbacGroupOwnerAccessUnconfirmedErrorDetails> rbacGroupOwnerAccessUnconfirmed,
        Action<CannotRemoveLastMemberErrorDetails> cannotRemoveLastMember,
        Action<ConcurrentMembershipChangeErrorDetails> concurrentMembershipChange,
        Action<ExternalKeyValidationFailedErrorDetails> externalKeyValidationFailed,
        Action<ExternalKeyValidationTimedOutErrorDetails> externalKeyValidationTimedOut,
        Action<KeyProfileMismatchErrorDetails> keyProfileMismatch,
        Action<WorkspacePolicyViolationErrorDetails> workspacePolicyViolation,
        Action<ExternalKeyChangedErrorDetails> externalKeyChanged,
        Action<WorkspaceMemberLimitExceededErrorDetails> workspaceMemberLimitExceeded,
        Action<OrganizationTypeNotSupportedErrorDetails> organizationTypeNotSupported,
        Action<Environments::BetaEnvironmentCreateDisabledErrorDetails> betaEnvironmentCreateDisabled,
        Action<Environments::BetaEnvironmentArchivedErrorDetails> betaEnvironmentArchived,
        Action<Environments::BetaInvalidConfigTypeChangeErrorDetails> betaInvalidConfigTypeChange,
        Action<Environments::BetaEnvironmentUpdateDisabledErrorDetails> betaEnvironmentUpdateDisabled,
        Action<BetaHeartbeatPreconditionFailedErrorDetails> betaHeartbeatPreconditionFailed,
        Action<Environments::BetaInvalidMetadataErrorDetails> betaInvalidMetadata,
        Action<BetaBillingFrozenErrorDetails> betaBillingFrozen,
        Action<BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails> betaSpendLimitsAdminApiWritesNotEnabled,
        Action<BetaUnsupportedCharsetErrorDetails> betaUnsupportedCharset,
        Action<Plugins::BetaPluginNameTakenErrorDetails> betaPluginNameTaken,
        Action<Plugins::BetaSkillNameTakenErrorDetails> betaSkillNameTaken,
        Action<Plugins::BetaRegistrationPendingErrorDetails> betaRegistrationPending,
        Action<Plugins::BetaScanFailedErrorDetails> betaScanFailed,
        Action<Plugins::BetaScanPendingErrorDetails> betaScanPending,
        Action<BetaSlackChannelSetUpSettingsRefusedErrorDetails> betaSlackChannelSetUpSettingsRefused,
        Action<BetaApiKeyScopeMissingErrorDetails> betaApiKeyScopeMissing,
        Action<BetaClaudeTagWritesNotEnabledErrorDetails> betaClaudeTagWritesNotEnabled,
        Action<BetaComplianceConfigurationRestrictedErrorDetails> betaComplianceConfigurationRestricted,
        Action<BetaOrganizationLevelScopedApiKeyRequiredErrorDetails> betaOrganizationLevelScopedApiKeyRequired,
        Action<Environments::BetaEnvironmentNotFoundErrorDetails> betaEnvironmentNotFound,
        Action<BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails> betaSlackChannelSetUpEnvironmentNotFound,
        Action<BetaSlackChannelSetUpSettingsConflictErrorDetails> betaSlackChannelSetUpSettingsConflict
    )
    {
        switch (this.Value)
        {
            case Messages::AvailableToolsLimitExceededErrorDetails value:
                availableToolsLimitExceeded(value);
                break;
            case ClaudeCodeKeyCreatorNotMemberErrorDetails value:
                claudeCodeKeyCreatorNotMember(value);
                break;
            case ClaudeCodeVersionTooOldErrorDetails value:
                claudeCodeVersionTooOld(value);
                break;
            case CmekKeyDisabledErrorDetails value:
                cmekKeyDisabled(value);
                break;
            case CmekKeyNetworkBlockedErrorDetails value:
                cmekKeyNetworkBlocked(value);
                break;
            case Messages::CompactionBlockAmbiguousErrorDetails value:
                compactionBlockAmbiguous(value);
                break;
            case Messages::CompactionBlockMisplacedErrorDetails value:
                compactionBlockMisplaced(value);
                break;
            case Messages::CompactionContentMismatchErrorDetails value:
                compactionContentMismatch(value);
                break;
            case Messages::CompactionIncompleteTurnErrorDetails value:
                compactionIncompleteTurn(value);
                break;
            case Messages::CompactionNothingToSummarizeErrorDetails value:
                compactionNothingToSummarize(value);
                break;
            case Messages::CompactionSignatureInvalidErrorDetails value:
                compactionSignatureInvalid(value);
                break;
            case Messages::CompactionTooManyToolReferencesErrorDetails value:
                compactionTooManyToolReferences(value);
                break;
            case Messages::CompactionToolChangesMismatchErrorDetails value:
                compactionToolChangesMismatch(value);
                break;
            case OrganizationOnHoldErrorDetails value:
                organizationOnHold(value);
                break;
            case RequestBodyEncodingInvalidErrorDetails value:
                requestBodyEncodingInvalid(value);
                break;
            case RequestBodyEncodingUnsupportedErrorDetails value:
                requestBodyEncodingUnsupported(value);
                break;
            case Messages::ThreadAlreadyContinuedErrorDetails value:
                threadAlreadyContinued(value);
                break;
            case Messages::ThreadContinueInFlightErrorDetails value:
                threadContinueInFlight(value);
                break;
            case Messages::ThreadFingerprintMismatchErrorDetails value:
                threadFingerprintMismatch(value);
                break;
            case Messages::ThreadUnsupportedRequestErrorDetails value:
                threadUnsupportedRequest(value);
                break;
            case Messages::ToolNameConflictErrorDetails value:
                toolNameConflict(value);
                break;
            case Messages::ToolReferenceUnresolvedErrorDetails value:
                toolReferenceUnresolved(value);
                break;
            case Messages::ThreadNotFoundErrorDetails value:
                threadNotFound(value);
                break;
            case Skills::SkillReadBlockedUndecryptableErrorDetails value:
                skillReadBlockedUndecryptable(value);
                break;
            case RequestBodyTooLargeAfterDecodingErrorDetails value:
                requestBodyTooLargeAfterDecoding(value);
                break;
            case EnforcedSpendLimitReachedErrorDetails value:
                enforcedSpendLimitReached(value);
                break;
            case RampLimitExceededErrorDetails value:
                rampLimitExceeded(value);
                break;
            case CmekKeyUnreachableErrorDetails value:
                cmekKeyUnreachable(value);
                break;
            case Messages::CompactionUnavailableErrorDetails value:
                compactionUnavailable(value);
                break;
            case Files::StorageQuotaExceededErrorDetails value:
                storageQuotaExceeded(value);
                break;
            case Files::FileNotDownloadableErrorDetails value:
                fileNotDownloadable(value);
                break;
            case Files::FileExpiredErrorDetails value:
                fileExpired(value);
                break;
            case CmekContextUnavailableErrorDetails value:
                cmekContextUnavailable(value);
                break;
            case ApiKeys::OrgApiKeyLimitExceededErrorDetails value:
                orgApiKeyLimitExceeded(value);
                break;
            case ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails value:
                workspaceApiKeyLimitExceeded(value);
                break;
            case UserProfileNotFoundErrorDetails value:
                userProfileNotFound(value);
                break;
            case ExternalKeyInWorkspacePolicyErrorDetails value:
                externalKeyInWorkspacePolicy(value);
                break;
            case AlreadyMemberErrorDetails value:
                alreadyMember(value);
                break;
            case CannotInviteEmailsWithUnverifiedDomainsErrorDetails value:
                cannotInviteEmailsWithUnverifiedDomains(value);
                break;
            case EmailDomainNotAllowedErrorDetails value:
                emailDomainNotAllowed(value);
                break;
            case InviteAlreadyExistsErrorDetails value:
                inviteAlreadyExists(value);
                break;
            case OrgMemberLimitExceededErrorDetails value:
                orgMemberLimitExceeded(value);
                break;
            case RbacGroupGrantsOwnerAccessErrorDetails value:
                rbacGroupGrantsOwnerAccess(value);
                break;
            case RbacGroupOwnerAccessUnconfirmedErrorDetails value:
                rbacGroupOwnerAccessUnconfirmed(value);
                break;
            case CannotRemoveLastMemberErrorDetails value:
                cannotRemoveLastMember(value);
                break;
            case ConcurrentMembershipChangeErrorDetails value:
                concurrentMembershipChange(value);
                break;
            case ExternalKeyValidationFailedErrorDetails value:
                externalKeyValidationFailed(value);
                break;
            case ExternalKeyValidationTimedOutErrorDetails value:
                externalKeyValidationTimedOut(value);
                break;
            case KeyProfileMismatchErrorDetails value:
                keyProfileMismatch(value);
                break;
            case WorkspacePolicyViolationErrorDetails value:
                workspacePolicyViolation(value);
                break;
            case ExternalKeyChangedErrorDetails value:
                externalKeyChanged(value);
                break;
            case WorkspaceMemberLimitExceededErrorDetails value:
                workspaceMemberLimitExceeded(value);
                break;
            case OrganizationTypeNotSupportedErrorDetails value:
                organizationTypeNotSupported(value);
                break;
            case Environments::BetaEnvironmentCreateDisabledErrorDetails value:
                betaEnvironmentCreateDisabled(value);
                break;
            case Environments::BetaEnvironmentArchivedErrorDetails value:
                betaEnvironmentArchived(value);
                break;
            case Environments::BetaInvalidConfigTypeChangeErrorDetails value:
                betaInvalidConfigTypeChange(value);
                break;
            case Environments::BetaEnvironmentUpdateDisabledErrorDetails value:
                betaEnvironmentUpdateDisabled(value);
                break;
            case BetaHeartbeatPreconditionFailedErrorDetails value:
                betaHeartbeatPreconditionFailed(value);
                break;
            case Environments::BetaInvalidMetadataErrorDetails value:
                betaInvalidMetadata(value);
                break;
            case BetaBillingFrozenErrorDetails value:
                betaBillingFrozen(value);
                break;
            case BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails value:
                betaSpendLimitsAdminApiWritesNotEnabled(value);
                break;
            case BetaUnsupportedCharsetErrorDetails value:
                betaUnsupportedCharset(value);
                break;
            case Plugins::BetaPluginNameTakenErrorDetails value:
                betaPluginNameTaken(value);
                break;
            case Plugins::BetaSkillNameTakenErrorDetails value:
                betaSkillNameTaken(value);
                break;
            case Plugins::BetaRegistrationPendingErrorDetails value:
                betaRegistrationPending(value);
                break;
            case Plugins::BetaScanFailedErrorDetails value:
                betaScanFailed(value);
                break;
            case Plugins::BetaScanPendingErrorDetails value:
                betaScanPending(value);
                break;
            case BetaSlackChannelSetUpSettingsRefusedErrorDetails value:
                betaSlackChannelSetUpSettingsRefused(value);
                break;
            case BetaApiKeyScopeMissingErrorDetails value:
                betaApiKeyScopeMissing(value);
                break;
            case BetaClaudeTagWritesNotEnabledErrorDetails value:
                betaClaudeTagWritesNotEnabled(value);
                break;
            case BetaComplianceConfigurationRestrictedErrorDetails value:
                betaComplianceConfigurationRestricted(value);
                break;
            case BetaOrganizationLevelScopedApiKeyRequiredErrorDetails value:
                betaOrganizationLevelScopedApiKeyRequired(value);
                break;
            case Environments::BetaEnvironmentNotFoundErrorDetails value:
                betaEnvironmentNotFound(value);
                break;
            case BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails value:
                betaSlackChannelSetUpEnvironmentNotFound(value);
                break;
            case BetaSlackChannelSetUpSettingsConflictErrorDetails value:
                betaSlackChannelSetUpSettingsConflict(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ErrorDetails"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Messages::AvailableToolsLimitExceededErrorDetails value) =&gt; {...},
    ///     (ClaudeCodeKeyCreatorNotMemberErrorDetails value) =&gt; {...},
    ///     (ClaudeCodeVersionTooOldErrorDetails value) =&gt; {...},
    ///     (CmekKeyDisabledErrorDetails value) =&gt; {...},
    ///     (CmekKeyNetworkBlockedErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionBlockAmbiguousErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionBlockMisplacedErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionContentMismatchErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionIncompleteTurnErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionNothingToSummarizeErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionSignatureInvalidErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionTooManyToolReferencesErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionToolChangesMismatchErrorDetails value) =&gt; {...},
    ///     (OrganizationOnHoldErrorDetails value) =&gt; {...},
    ///     (RequestBodyEncodingInvalidErrorDetails value) =&gt; {...},
    ///     (RequestBodyEncodingUnsupportedErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadAlreadyContinuedErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadContinueInFlightErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadFingerprintMismatchErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadUnsupportedRequestErrorDetails value) =&gt; {...},
    ///     (Messages::ToolNameConflictErrorDetails value) =&gt; {...},
    ///     (Messages::ToolReferenceUnresolvedErrorDetails value) =&gt; {...},
    ///     (Messages::ThreadNotFoundErrorDetails value) =&gt; {...},
    ///     (Skills::SkillReadBlockedUndecryptableErrorDetails value) =&gt; {...},
    ///     (RequestBodyTooLargeAfterDecodingErrorDetails value) =&gt; {...},
    ///     (EnforcedSpendLimitReachedErrorDetails value) =&gt; {...},
    ///     (RampLimitExceededErrorDetails value) =&gt; {...},
    ///     (CmekKeyUnreachableErrorDetails value) =&gt; {...},
    ///     (Messages::CompactionUnavailableErrorDetails value) =&gt; {...},
    ///     (Files::StorageQuotaExceededErrorDetails value) =&gt; {...},
    ///     (Files::FileNotDownloadableErrorDetails value) =&gt; {...},
    ///     (Files::FileExpiredErrorDetails value) =&gt; {...},
    ///     (CmekContextUnavailableErrorDetails value) =&gt; {...},
    ///     (ApiKeys::OrgApiKeyLimitExceededErrorDetails value) =&gt; {...},
    ///     (ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails value) =&gt; {...},
    ///     (UserProfileNotFoundErrorDetails value) =&gt; {...},
    ///     (ExternalKeyInWorkspacePolicyErrorDetails value) =&gt; {...},
    ///     (AlreadyMemberErrorDetails value) =&gt; {...},
    ///     (CannotInviteEmailsWithUnverifiedDomainsErrorDetails value) =&gt; {...},
    ///     (EmailDomainNotAllowedErrorDetails value) =&gt; {...},
    ///     (InviteAlreadyExistsErrorDetails value) =&gt; {...},
    ///     (OrgMemberLimitExceededErrorDetails value) =&gt; {...},
    ///     (RbacGroupGrantsOwnerAccessErrorDetails value) =&gt; {...},
    ///     (RbacGroupOwnerAccessUnconfirmedErrorDetails value) =&gt; {...},
    ///     (CannotRemoveLastMemberErrorDetails value) =&gt; {...},
    ///     (ConcurrentMembershipChangeErrorDetails value) =&gt; {...},
    ///     (ExternalKeyValidationFailedErrorDetails value) =&gt; {...},
    ///     (ExternalKeyValidationTimedOutErrorDetails value) =&gt; {...},
    ///     (KeyProfileMismatchErrorDetails value) =&gt; {...},
    ///     (WorkspacePolicyViolationErrorDetails value) =&gt; {...},
    ///     (ExternalKeyChangedErrorDetails value) =&gt; {...},
    ///     (WorkspaceMemberLimitExceededErrorDetails value) =&gt; {...},
    ///     (OrganizationTypeNotSupportedErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentCreateDisabledErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentArchivedErrorDetails value) =&gt; {...},
    ///     (Environments::BetaInvalidConfigTypeChangeErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentUpdateDisabledErrorDetails value) =&gt; {...},
    ///     (BetaHeartbeatPreconditionFailedErrorDetails value) =&gt; {...},
    ///     (Environments::BetaInvalidMetadataErrorDetails value) =&gt; {...},
    ///     (BetaBillingFrozenErrorDetails value) =&gt; {...},
    ///     (BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails value) =&gt; {...},
    ///     (BetaUnsupportedCharsetErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaPluginNameTakenErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaSkillNameTakenErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaRegistrationPendingErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaScanFailedErrorDetails value) =&gt; {...},
    ///     (Plugins::BetaScanPendingErrorDetails value) =&gt; {...},
    ///     (BetaSlackChannelSetUpSettingsRefusedErrorDetails value) =&gt; {...},
    ///     (BetaApiKeyScopeMissingErrorDetails value) =&gt; {...},
    ///     (BetaClaudeTagWritesNotEnabledErrorDetails value) =&gt; {...},
    ///     (BetaComplianceConfigurationRestrictedErrorDetails value) =&gt; {...},
    ///     (BetaOrganizationLevelScopedApiKeyRequiredErrorDetails value) =&gt; {...},
    ///     (Environments::BetaEnvironmentNotFoundErrorDetails value) =&gt; {...},
    ///     (BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails value) =&gt; {...},
    ///     (BetaSlackChannelSetUpSettingsConflictErrorDetails value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Messages::AvailableToolsLimitExceededErrorDetails, T> availableToolsLimitExceeded,
        Func<ClaudeCodeKeyCreatorNotMemberErrorDetails, T> claudeCodeKeyCreatorNotMember,
        Func<ClaudeCodeVersionTooOldErrorDetails, T> claudeCodeVersionTooOld,
        Func<CmekKeyDisabledErrorDetails, T> cmekKeyDisabled,
        Func<CmekKeyNetworkBlockedErrorDetails, T> cmekKeyNetworkBlocked,
        Func<Messages::CompactionBlockAmbiguousErrorDetails, T> compactionBlockAmbiguous,
        Func<Messages::CompactionBlockMisplacedErrorDetails, T> compactionBlockMisplaced,
        Func<Messages::CompactionContentMismatchErrorDetails, T> compactionContentMismatch,
        Func<Messages::CompactionIncompleteTurnErrorDetails, T> compactionIncompleteTurn,
        Func<Messages::CompactionNothingToSummarizeErrorDetails, T> compactionNothingToSummarize,
        Func<Messages::CompactionSignatureInvalidErrorDetails, T> compactionSignatureInvalid,
        Func<
            Messages::CompactionTooManyToolReferencesErrorDetails,
            T
        > compactionTooManyToolReferences,
        Func<Messages::CompactionToolChangesMismatchErrorDetails, T> compactionToolChangesMismatch,
        Func<OrganizationOnHoldErrorDetails, T> organizationOnHold,
        Func<RequestBodyEncodingInvalidErrorDetails, T> requestBodyEncodingInvalid,
        Func<RequestBodyEncodingUnsupportedErrorDetails, T> requestBodyEncodingUnsupported,
        Func<Messages::ThreadAlreadyContinuedErrorDetails, T> threadAlreadyContinued,
        Func<Messages::ThreadContinueInFlightErrorDetails, T> threadContinueInFlight,
        Func<Messages::ThreadFingerprintMismatchErrorDetails, T> threadFingerprintMismatch,
        Func<Messages::ThreadUnsupportedRequestErrorDetails, T> threadUnsupportedRequest,
        Func<Messages::ToolNameConflictErrorDetails, T> toolNameConflict,
        Func<Messages::ToolReferenceUnresolvedErrorDetails, T> toolReferenceUnresolved,
        Func<Messages::ThreadNotFoundErrorDetails, T> threadNotFound,
        Func<Skills::SkillReadBlockedUndecryptableErrorDetails, T> skillReadBlockedUndecryptable,
        Func<RequestBodyTooLargeAfterDecodingErrorDetails, T> requestBodyTooLargeAfterDecoding,
        Func<EnforcedSpendLimitReachedErrorDetails, T> enforcedSpendLimitReached,
        Func<RampLimitExceededErrorDetails, T> rampLimitExceeded,
        Func<CmekKeyUnreachableErrorDetails, T> cmekKeyUnreachable,
        Func<Messages::CompactionUnavailableErrorDetails, T> compactionUnavailable,
        Func<Files::StorageQuotaExceededErrorDetails, T> storageQuotaExceeded,
        Func<Files::FileNotDownloadableErrorDetails, T> fileNotDownloadable,
        Func<Files::FileExpiredErrorDetails, T> fileExpired,
        Func<CmekContextUnavailableErrorDetails, T> cmekContextUnavailable,
        Func<ApiKeys::OrgApiKeyLimitExceededErrorDetails, T> orgApiKeyLimitExceeded,
        Func<ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails, T> workspaceApiKeyLimitExceeded,
        Func<UserProfileNotFoundErrorDetails, T> userProfileNotFound,
        Func<ExternalKeyInWorkspacePolicyErrorDetails, T> externalKeyInWorkspacePolicy,
        Func<AlreadyMemberErrorDetails, T> alreadyMember,
        Func<
            CannotInviteEmailsWithUnverifiedDomainsErrorDetails,
            T
        > cannotInviteEmailsWithUnverifiedDomains,
        Func<EmailDomainNotAllowedErrorDetails, T> emailDomainNotAllowed,
        Func<InviteAlreadyExistsErrorDetails, T> inviteAlreadyExists,
        Func<OrgMemberLimitExceededErrorDetails, T> orgMemberLimitExceeded,
        Func<RbacGroupGrantsOwnerAccessErrorDetails, T> rbacGroupGrantsOwnerAccess,
        Func<RbacGroupOwnerAccessUnconfirmedErrorDetails, T> rbacGroupOwnerAccessUnconfirmed,
        Func<CannotRemoveLastMemberErrorDetails, T> cannotRemoveLastMember,
        Func<ConcurrentMembershipChangeErrorDetails, T> concurrentMembershipChange,
        Func<ExternalKeyValidationFailedErrorDetails, T> externalKeyValidationFailed,
        Func<ExternalKeyValidationTimedOutErrorDetails, T> externalKeyValidationTimedOut,
        Func<KeyProfileMismatchErrorDetails, T> keyProfileMismatch,
        Func<WorkspacePolicyViolationErrorDetails, T> workspacePolicyViolation,
        Func<ExternalKeyChangedErrorDetails, T> externalKeyChanged,
        Func<WorkspaceMemberLimitExceededErrorDetails, T> workspaceMemberLimitExceeded,
        Func<OrganizationTypeNotSupportedErrorDetails, T> organizationTypeNotSupported,
        Func<
            Environments::BetaEnvironmentCreateDisabledErrorDetails,
            T
        > betaEnvironmentCreateDisabled,
        Func<Environments::BetaEnvironmentArchivedErrorDetails, T> betaEnvironmentArchived,
        Func<Environments::BetaInvalidConfigTypeChangeErrorDetails, T> betaInvalidConfigTypeChange,
        Func<
            Environments::BetaEnvironmentUpdateDisabledErrorDetails,
            T
        > betaEnvironmentUpdateDisabled,
        Func<BetaHeartbeatPreconditionFailedErrorDetails, T> betaHeartbeatPreconditionFailed,
        Func<Environments::BetaInvalidMetadataErrorDetails, T> betaInvalidMetadata,
        Func<BetaBillingFrozenErrorDetails, T> betaBillingFrozen,
        Func<
            BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails,
            T
        > betaSpendLimitsAdminApiWritesNotEnabled,
        Func<BetaUnsupportedCharsetErrorDetails, T> betaUnsupportedCharset,
        Func<Plugins::BetaPluginNameTakenErrorDetails, T> betaPluginNameTaken,
        Func<Plugins::BetaSkillNameTakenErrorDetails, T> betaSkillNameTaken,
        Func<Plugins::BetaRegistrationPendingErrorDetails, T> betaRegistrationPending,
        Func<Plugins::BetaScanFailedErrorDetails, T> betaScanFailed,
        Func<Plugins::BetaScanPendingErrorDetails, T> betaScanPending,
        Func<
            BetaSlackChannelSetUpSettingsRefusedErrorDetails,
            T
        > betaSlackChannelSetUpSettingsRefused,
        Func<BetaApiKeyScopeMissingErrorDetails, T> betaApiKeyScopeMissing,
        Func<BetaClaudeTagWritesNotEnabledErrorDetails, T> betaClaudeTagWritesNotEnabled,
        Func<
            BetaComplianceConfigurationRestrictedErrorDetails,
            T
        > betaComplianceConfigurationRestricted,
        Func<
            BetaOrganizationLevelScopedApiKeyRequiredErrorDetails,
            T
        > betaOrganizationLevelScopedApiKeyRequired,
        Func<Environments::BetaEnvironmentNotFoundErrorDetails, T> betaEnvironmentNotFound,
        Func<
            BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails,
            T
        > betaSlackChannelSetUpEnvironmentNotFound,
        Func<
            BetaSlackChannelSetUpSettingsConflictErrorDetails,
            T
        > betaSlackChannelSetUpSettingsConflict
    )
    {
        return this.Value switch
        {
            Messages::AvailableToolsLimitExceededErrorDetails value => availableToolsLimitExceeded(
                value
            ),
            ClaudeCodeKeyCreatorNotMemberErrorDetails value => claudeCodeKeyCreatorNotMember(value),
            ClaudeCodeVersionTooOldErrorDetails value => claudeCodeVersionTooOld(value),
            CmekKeyDisabledErrorDetails value => cmekKeyDisabled(value),
            CmekKeyNetworkBlockedErrorDetails value => cmekKeyNetworkBlocked(value),
            Messages::CompactionBlockAmbiguousErrorDetails value => compactionBlockAmbiguous(value),
            Messages::CompactionBlockMisplacedErrorDetails value => compactionBlockMisplaced(value),
            Messages::CompactionContentMismatchErrorDetails value => compactionContentMismatch(
                value
            ),
            Messages::CompactionIncompleteTurnErrorDetails value => compactionIncompleteTurn(value),
            Messages::CompactionNothingToSummarizeErrorDetails value =>
                compactionNothingToSummarize(value),
            Messages::CompactionSignatureInvalidErrorDetails value => compactionSignatureInvalid(
                value
            ),
            Messages::CompactionTooManyToolReferencesErrorDetails value =>
                compactionTooManyToolReferences(value),
            Messages::CompactionToolChangesMismatchErrorDetails value =>
                compactionToolChangesMismatch(value),
            OrganizationOnHoldErrorDetails value => organizationOnHold(value),
            RequestBodyEncodingInvalidErrorDetails value => requestBodyEncodingInvalid(value),
            RequestBodyEncodingUnsupportedErrorDetails value => requestBodyEncodingUnsupported(
                value
            ),
            Messages::ThreadAlreadyContinuedErrorDetails value => threadAlreadyContinued(value),
            Messages::ThreadContinueInFlightErrorDetails value => threadContinueInFlight(value),
            Messages::ThreadFingerprintMismatchErrorDetails value => threadFingerprintMismatch(
                value
            ),
            Messages::ThreadUnsupportedRequestErrorDetails value => threadUnsupportedRequest(value),
            Messages::ToolNameConflictErrorDetails value => toolNameConflict(value),
            Messages::ToolReferenceUnresolvedErrorDetails value => toolReferenceUnresolved(value),
            Messages::ThreadNotFoundErrorDetails value => threadNotFound(value),
            Skills::SkillReadBlockedUndecryptableErrorDetails value =>
                skillReadBlockedUndecryptable(value),
            RequestBodyTooLargeAfterDecodingErrorDetails value => requestBodyTooLargeAfterDecoding(
                value
            ),
            EnforcedSpendLimitReachedErrorDetails value => enforcedSpendLimitReached(value),
            RampLimitExceededErrorDetails value => rampLimitExceeded(value),
            CmekKeyUnreachableErrorDetails value => cmekKeyUnreachable(value),
            Messages::CompactionUnavailableErrorDetails value => compactionUnavailable(value),
            Files::StorageQuotaExceededErrorDetails value => storageQuotaExceeded(value),
            Files::FileNotDownloadableErrorDetails value => fileNotDownloadable(value),
            Files::FileExpiredErrorDetails value => fileExpired(value),
            CmekContextUnavailableErrorDetails value => cmekContextUnavailable(value),
            ApiKeys::OrgApiKeyLimitExceededErrorDetails value => orgApiKeyLimitExceeded(value),
            ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails value => workspaceApiKeyLimitExceeded(
                value
            ),
            UserProfileNotFoundErrorDetails value => userProfileNotFound(value),
            ExternalKeyInWorkspacePolicyErrorDetails value => externalKeyInWorkspacePolicy(value),
            AlreadyMemberErrorDetails value => alreadyMember(value),
            CannotInviteEmailsWithUnverifiedDomainsErrorDetails value =>
                cannotInviteEmailsWithUnverifiedDomains(value),
            EmailDomainNotAllowedErrorDetails value => emailDomainNotAllowed(value),
            InviteAlreadyExistsErrorDetails value => inviteAlreadyExists(value),
            OrgMemberLimitExceededErrorDetails value => orgMemberLimitExceeded(value),
            RbacGroupGrantsOwnerAccessErrorDetails value => rbacGroupGrantsOwnerAccess(value),
            RbacGroupOwnerAccessUnconfirmedErrorDetails value => rbacGroupOwnerAccessUnconfirmed(
                value
            ),
            CannotRemoveLastMemberErrorDetails value => cannotRemoveLastMember(value),
            ConcurrentMembershipChangeErrorDetails value => concurrentMembershipChange(value),
            ExternalKeyValidationFailedErrorDetails value => externalKeyValidationFailed(value),
            ExternalKeyValidationTimedOutErrorDetails value => externalKeyValidationTimedOut(value),
            KeyProfileMismatchErrorDetails value => keyProfileMismatch(value),
            WorkspacePolicyViolationErrorDetails value => workspacePolicyViolation(value),
            ExternalKeyChangedErrorDetails value => externalKeyChanged(value),
            WorkspaceMemberLimitExceededErrorDetails value => workspaceMemberLimitExceeded(value),
            OrganizationTypeNotSupportedErrorDetails value => organizationTypeNotSupported(value),
            Environments::BetaEnvironmentCreateDisabledErrorDetails value =>
                betaEnvironmentCreateDisabled(value),
            Environments::BetaEnvironmentArchivedErrorDetails value => betaEnvironmentArchived(
                value
            ),
            Environments::BetaInvalidConfigTypeChangeErrorDetails value =>
                betaInvalidConfigTypeChange(value),
            Environments::BetaEnvironmentUpdateDisabledErrorDetails value =>
                betaEnvironmentUpdateDisabled(value),
            BetaHeartbeatPreconditionFailedErrorDetails value => betaHeartbeatPreconditionFailed(
                value
            ),
            Environments::BetaInvalidMetadataErrorDetails value => betaInvalidMetadata(value),
            BetaBillingFrozenErrorDetails value => betaBillingFrozen(value),
            BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails value =>
                betaSpendLimitsAdminApiWritesNotEnabled(value),
            BetaUnsupportedCharsetErrorDetails value => betaUnsupportedCharset(value),
            Plugins::BetaPluginNameTakenErrorDetails value => betaPluginNameTaken(value),
            Plugins::BetaSkillNameTakenErrorDetails value => betaSkillNameTaken(value),
            Plugins::BetaRegistrationPendingErrorDetails value => betaRegistrationPending(value),
            Plugins::BetaScanFailedErrorDetails value => betaScanFailed(value),
            Plugins::BetaScanPendingErrorDetails value => betaScanPending(value),
            BetaSlackChannelSetUpSettingsRefusedErrorDetails value =>
                betaSlackChannelSetUpSettingsRefused(value),
            BetaApiKeyScopeMissingErrorDetails value => betaApiKeyScopeMissing(value),
            BetaClaudeTagWritesNotEnabledErrorDetails value => betaClaudeTagWritesNotEnabled(value),
            BetaComplianceConfigurationRestrictedErrorDetails value =>
                betaComplianceConfigurationRestricted(value),
            BetaOrganizationLevelScopedApiKeyRequiredErrorDetails value =>
                betaOrganizationLevelScopedApiKeyRequired(value),
            Environments::BetaEnvironmentNotFoundErrorDetails value => betaEnvironmentNotFound(
                value
            ),
            BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails value =>
                betaSlackChannelSetUpEnvironmentNotFound(value),
            BetaSlackChannelSetUpSettingsConflictErrorDetails value =>
                betaSlackChannelSetUpSettingsConflict(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorDetails"
            ),
        };
    }

    public static implicit operator ErrorDetails(
        Messages::AvailableToolsLimitExceededErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(ClaudeCodeKeyCreatorNotMemberErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(ClaudeCodeVersionTooOldErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(CmekKeyDisabledErrorDetails value) => new(value);

    public static implicit operator ErrorDetails(CmekKeyNetworkBlockedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionBlockAmbiguousErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionBlockMisplacedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionContentMismatchErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionIncompleteTurnErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionNothingToSummarizeErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionSignatureInvalidErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionTooManyToolReferencesErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionToolChangesMismatchErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(OrganizationOnHoldErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(RequestBodyEncodingInvalidErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        RequestBodyEncodingUnsupportedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::ThreadAlreadyContinuedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::ThreadContinueInFlightErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::ThreadFingerprintMismatchErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Messages::ThreadUnsupportedRequestErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(Messages::ToolNameConflictErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        Messages::ToolReferenceUnresolvedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(Messages::ThreadNotFoundErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        Skills::SkillReadBlockedUndecryptableErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        RequestBodyTooLargeAfterDecodingErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(EnforcedSpendLimitReachedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(RampLimitExceededErrorDetails value) => new(value);

    public static implicit operator ErrorDetails(CmekKeyUnreachableErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        Messages::CompactionUnavailableErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(Files::StorageQuotaExceededErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(Files::FileNotDownloadableErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(Files::FileExpiredErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(CmekContextUnavailableErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        ApiKeys::OrgApiKeyLimitExceededErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(UserProfileNotFoundErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(ExternalKeyInWorkspacePolicyErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(AlreadyMemberErrorDetails value) => new(value);

    public static implicit operator ErrorDetails(
        CannotInviteEmailsWithUnverifiedDomainsErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(EmailDomainNotAllowedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(InviteAlreadyExistsErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(OrgMemberLimitExceededErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(RbacGroupGrantsOwnerAccessErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        RbacGroupOwnerAccessUnconfirmedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(CannotRemoveLastMemberErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(ConcurrentMembershipChangeErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(ExternalKeyValidationFailedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(ExternalKeyValidationTimedOutErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(KeyProfileMismatchErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(WorkspacePolicyViolationErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(ExternalKeyChangedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(WorkspaceMemberLimitExceededErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(OrganizationTypeNotSupportedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        Environments::BetaEnvironmentCreateDisabledErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Environments::BetaEnvironmentArchivedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Environments::BetaInvalidConfigTypeChangeErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Environments::BetaEnvironmentUpdateDisabledErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        BetaHeartbeatPreconditionFailedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Environments::BetaInvalidMetadataErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(BetaBillingFrozenErrorDetails value) => new(value);

    public static implicit operator ErrorDetails(
        BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(BetaUnsupportedCharsetErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(Plugins::BetaPluginNameTakenErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(Plugins::BetaSkillNameTakenErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        Plugins::BetaRegistrationPendingErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(Plugins::BetaScanFailedErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(Plugins::BetaScanPendingErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        BetaSlackChannelSetUpSettingsRefusedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(BetaApiKeyScopeMissingErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(BetaClaudeTagWritesNotEnabledErrorDetails value) =>
        new(value);

    public static implicit operator ErrorDetails(
        BetaComplianceConfigurationRestrictedErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        BetaOrganizationLevelScopedApiKeyRequiredErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        Environments::BetaEnvironmentNotFoundErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails value
    ) => new(value);

    public static implicit operator ErrorDetails(
        BetaSlackChannelSetUpSettingsConflictErrorDetails value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorDetails"
            );
        }
        this.Switch(
            (availableToolsLimitExceeded) => availableToolsLimitExceeded.Validate(),
            (claudeCodeKeyCreatorNotMember) => claudeCodeKeyCreatorNotMember.Validate(),
            (claudeCodeVersionTooOld) => claudeCodeVersionTooOld.Validate(),
            (cmekKeyDisabled) => cmekKeyDisabled.Validate(),
            (cmekKeyNetworkBlocked) => cmekKeyNetworkBlocked.Validate(),
            (compactionBlockAmbiguous) => compactionBlockAmbiguous.Validate(),
            (compactionBlockMisplaced) => compactionBlockMisplaced.Validate(),
            (compactionContentMismatch) => compactionContentMismatch.Validate(),
            (compactionIncompleteTurn) => compactionIncompleteTurn.Validate(),
            (compactionNothingToSummarize) => compactionNothingToSummarize.Validate(),
            (compactionSignatureInvalid) => compactionSignatureInvalid.Validate(),
            (compactionTooManyToolReferences) => compactionTooManyToolReferences.Validate(),
            (compactionToolChangesMismatch) => compactionToolChangesMismatch.Validate(),
            (organizationOnHold) => organizationOnHold.Validate(),
            (requestBodyEncodingInvalid) => requestBodyEncodingInvalid.Validate(),
            (requestBodyEncodingUnsupported) => requestBodyEncodingUnsupported.Validate(),
            (threadAlreadyContinued) => threadAlreadyContinued.Validate(),
            (threadContinueInFlight) => threadContinueInFlight.Validate(),
            (threadFingerprintMismatch) => threadFingerprintMismatch.Validate(),
            (threadUnsupportedRequest) => threadUnsupportedRequest.Validate(),
            (toolNameConflict) => toolNameConflict.Validate(),
            (toolReferenceUnresolved) => toolReferenceUnresolved.Validate(),
            (threadNotFound) => threadNotFound.Validate(),
            (skillReadBlockedUndecryptable) => skillReadBlockedUndecryptable.Validate(),
            (requestBodyTooLargeAfterDecoding) => requestBodyTooLargeAfterDecoding.Validate(),
            (enforcedSpendLimitReached) => enforcedSpendLimitReached.Validate(),
            (rampLimitExceeded) => rampLimitExceeded.Validate(),
            (cmekKeyUnreachable) => cmekKeyUnreachable.Validate(),
            (compactionUnavailable) => compactionUnavailable.Validate(),
            (storageQuotaExceeded) => storageQuotaExceeded.Validate(),
            (fileNotDownloadable) => fileNotDownloadable.Validate(),
            (fileExpired) => fileExpired.Validate(),
            (cmekContextUnavailable) => cmekContextUnavailable.Validate(),
            (orgApiKeyLimitExceeded) => orgApiKeyLimitExceeded.Validate(),
            (workspaceApiKeyLimitExceeded) => workspaceApiKeyLimitExceeded.Validate(),
            (userProfileNotFound) => userProfileNotFound.Validate(),
            (externalKeyInWorkspacePolicy) => externalKeyInWorkspacePolicy.Validate(),
            (alreadyMember) => alreadyMember.Validate(),
            (cannotInviteEmailsWithUnverifiedDomains) =>
                cannotInviteEmailsWithUnverifiedDomains.Validate(),
            (emailDomainNotAllowed) => emailDomainNotAllowed.Validate(),
            (inviteAlreadyExists) => inviteAlreadyExists.Validate(),
            (orgMemberLimitExceeded) => orgMemberLimitExceeded.Validate(),
            (rbacGroupGrantsOwnerAccess) => rbacGroupGrantsOwnerAccess.Validate(),
            (rbacGroupOwnerAccessUnconfirmed) => rbacGroupOwnerAccessUnconfirmed.Validate(),
            (cannotRemoveLastMember) => cannotRemoveLastMember.Validate(),
            (concurrentMembershipChange) => concurrentMembershipChange.Validate(),
            (externalKeyValidationFailed) => externalKeyValidationFailed.Validate(),
            (externalKeyValidationTimedOut) => externalKeyValidationTimedOut.Validate(),
            (keyProfileMismatch) => keyProfileMismatch.Validate(),
            (workspacePolicyViolation) => workspacePolicyViolation.Validate(),
            (externalKeyChanged) => externalKeyChanged.Validate(),
            (workspaceMemberLimitExceeded) => workspaceMemberLimitExceeded.Validate(),
            (organizationTypeNotSupported) => organizationTypeNotSupported.Validate(),
            (betaEnvironmentCreateDisabled) => betaEnvironmentCreateDisabled.Validate(),
            (betaEnvironmentArchived) => betaEnvironmentArchived.Validate(),
            (betaInvalidConfigTypeChange) => betaInvalidConfigTypeChange.Validate(),
            (betaEnvironmentUpdateDisabled) => betaEnvironmentUpdateDisabled.Validate(),
            (betaHeartbeatPreconditionFailed) => betaHeartbeatPreconditionFailed.Validate(),
            (betaInvalidMetadata) => betaInvalidMetadata.Validate(),
            (betaBillingFrozen) => betaBillingFrozen.Validate(),
            (betaSpendLimitsAdminApiWritesNotEnabled) =>
                betaSpendLimitsAdminApiWritesNotEnabled.Validate(),
            (betaUnsupportedCharset) => betaUnsupportedCharset.Validate(),
            (betaPluginNameTaken) => betaPluginNameTaken.Validate(),
            (betaSkillNameTaken) => betaSkillNameTaken.Validate(),
            (betaRegistrationPending) => betaRegistrationPending.Validate(),
            (betaScanFailed) => betaScanFailed.Validate(),
            (betaScanPending) => betaScanPending.Validate(),
            (betaSlackChannelSetUpSettingsRefused) =>
                betaSlackChannelSetUpSettingsRefused.Validate(),
            (betaApiKeyScopeMissing) => betaApiKeyScopeMissing.Validate(),
            (betaClaudeTagWritesNotEnabled) => betaClaudeTagWritesNotEnabled.Validate(),
            (betaComplianceConfigurationRestricted) =>
                betaComplianceConfigurationRestricted.Validate(),
            (betaOrganizationLevelScopedApiKeyRequired) =>
                betaOrganizationLevelScopedApiKeyRequired.Validate(),
            (betaEnvironmentNotFound) => betaEnvironmentNotFound.Validate(),
            (betaSlackChannelSetUpEnvironmentNotFound) =>
                betaSlackChannelSetUpEnvironmentNotFound.Validate(),
            (betaSlackChannelSetUpSettingsConflict) =>
                betaSlackChannelSetUpSettingsConflict.Validate()
        );
    }

    public virtual bool Equals(ErrorDetails? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Messages::AvailableToolsLimitExceededErrorDetails _ => 0,
            ClaudeCodeKeyCreatorNotMemberErrorDetails _ => 1,
            ClaudeCodeVersionTooOldErrorDetails _ => 2,
            CmekKeyDisabledErrorDetails _ => 3,
            CmekKeyNetworkBlockedErrorDetails _ => 4,
            Messages::CompactionBlockAmbiguousErrorDetails _ => 5,
            Messages::CompactionBlockMisplacedErrorDetails _ => 6,
            Messages::CompactionContentMismatchErrorDetails _ => 7,
            Messages::CompactionIncompleteTurnErrorDetails _ => 8,
            Messages::CompactionNothingToSummarizeErrorDetails _ => 9,
            Messages::CompactionSignatureInvalidErrorDetails _ => 10,
            Messages::CompactionTooManyToolReferencesErrorDetails _ => 11,
            Messages::CompactionToolChangesMismatchErrorDetails _ => 12,
            OrganizationOnHoldErrorDetails _ => 13,
            RequestBodyEncodingInvalidErrorDetails _ => 14,
            RequestBodyEncodingUnsupportedErrorDetails _ => 15,
            Messages::ThreadAlreadyContinuedErrorDetails _ => 16,
            Messages::ThreadContinueInFlightErrorDetails _ => 17,
            Messages::ThreadFingerprintMismatchErrorDetails _ => 18,
            Messages::ThreadUnsupportedRequestErrorDetails _ => 19,
            Messages::ToolNameConflictErrorDetails _ => 20,
            Messages::ToolReferenceUnresolvedErrorDetails _ => 21,
            Messages::ThreadNotFoundErrorDetails _ => 22,
            Skills::SkillReadBlockedUndecryptableErrorDetails _ => 23,
            RequestBodyTooLargeAfterDecodingErrorDetails _ => 24,
            EnforcedSpendLimitReachedErrorDetails _ => 25,
            RampLimitExceededErrorDetails _ => 26,
            CmekKeyUnreachableErrorDetails _ => 27,
            Messages::CompactionUnavailableErrorDetails _ => 28,
            Files::StorageQuotaExceededErrorDetails _ => 29,
            Files::FileNotDownloadableErrorDetails _ => 30,
            Files::FileExpiredErrorDetails _ => 31,
            CmekContextUnavailableErrorDetails _ => 32,
            ApiKeys::OrgApiKeyLimitExceededErrorDetails _ => 33,
            ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails _ => 34,
            UserProfileNotFoundErrorDetails _ => 35,
            ExternalKeyInWorkspacePolicyErrorDetails _ => 36,
            AlreadyMemberErrorDetails _ => 37,
            CannotInviteEmailsWithUnverifiedDomainsErrorDetails _ => 38,
            EmailDomainNotAllowedErrorDetails _ => 39,
            InviteAlreadyExistsErrorDetails _ => 40,
            OrgMemberLimitExceededErrorDetails _ => 41,
            RbacGroupGrantsOwnerAccessErrorDetails _ => 42,
            RbacGroupOwnerAccessUnconfirmedErrorDetails _ => 43,
            CannotRemoveLastMemberErrorDetails _ => 44,
            ConcurrentMembershipChangeErrorDetails _ => 45,
            ExternalKeyValidationFailedErrorDetails _ => 46,
            ExternalKeyValidationTimedOutErrorDetails _ => 47,
            KeyProfileMismatchErrorDetails _ => 48,
            WorkspacePolicyViolationErrorDetails _ => 49,
            ExternalKeyChangedErrorDetails _ => 50,
            WorkspaceMemberLimitExceededErrorDetails _ => 51,
            OrganizationTypeNotSupportedErrorDetails _ => 52,
            Environments::BetaEnvironmentCreateDisabledErrorDetails _ => 53,
            Environments::BetaEnvironmentArchivedErrorDetails _ => 54,
            Environments::BetaInvalidConfigTypeChangeErrorDetails _ => 55,
            Environments::BetaEnvironmentUpdateDisabledErrorDetails _ => 56,
            BetaHeartbeatPreconditionFailedErrorDetails _ => 57,
            Environments::BetaInvalidMetadataErrorDetails _ => 58,
            BetaBillingFrozenErrorDetails _ => 59,
            BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails _ => 60,
            BetaUnsupportedCharsetErrorDetails _ => 61,
            Plugins::BetaPluginNameTakenErrorDetails _ => 62,
            Plugins::BetaSkillNameTakenErrorDetails _ => 63,
            Plugins::BetaRegistrationPendingErrorDetails _ => 64,
            Plugins::BetaScanFailedErrorDetails _ => 65,
            Plugins::BetaScanPendingErrorDetails _ => 66,
            BetaSlackChannelSetUpSettingsRefusedErrorDetails _ => 67,
            BetaApiKeyScopeMissingErrorDetails _ => 68,
            BetaClaudeTagWritesNotEnabledErrorDetails _ => 69,
            BetaComplianceConfigurationRestrictedErrorDetails _ => 70,
            BetaOrganizationLevelScopedApiKeyRequiredErrorDetails _ => 71,
            Environments::BetaEnvironmentNotFoundErrorDetails _ => 72,
            BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails _ => 73,
            BetaSlackChannelSetUpSettingsConflictErrorDetails _ => 74,
            _ => -1,
        };
    }
}

sealed class ErrorDetailsConverter : JsonConverter<ErrorDetails>
{
    public override ErrorDetails? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? errorCode;
        try
        {
            errorCode = element.GetProperty("error_code").GetString();
        }
        catch
        {
            errorCode = null;
        }

        switch (errorCode)
        {
            case "available_tools_limit_exceeded":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::AvailableToolsLimitExceededErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "claude_code_key_creator_not_member":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ClaudeCodeKeyCreatorNotMemberErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "claude_code_version_too_old":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ClaudeCodeVersionTooOldErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cmek_key_disabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CmekKeyDisabledErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cmek_key_network_blocked":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CmekKeyNetworkBlockedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_block_ambiguous":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionBlockAmbiguousErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_block_misplaced":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionBlockMisplacedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_content_mismatch":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionContentMismatchErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_incomplete_turn":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionIncompleteTurnErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_nothing_to_summarize":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionNothingToSummarizeErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_signature_invalid":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionSignatureInvalidErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_too_many_tool_references":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionTooManyToolReferencesErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_tool_changes_mismatch":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionToolChangesMismatchErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "organization_on_hold":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OrganizationOnHoldErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "request_body_encoding_invalid":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<RequestBodyEncodingInvalidErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "request_body_encoding_unsupported":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<RequestBodyEncodingUnsupportedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thread_already_continued":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ThreadAlreadyContinuedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thread_continue_in_flight":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ThreadContinueInFlightErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thread_fingerprint_mismatch":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ThreadFingerprintMismatchErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thread_unsupported_request":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ThreadUnsupportedRequestErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_name_conflict":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ToolNameConflictErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_reference_unresolved":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ToolReferenceUnresolvedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thread_not_found":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::ThreadNotFoundErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "skill_read_blocked_undecryptable":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Skills::SkillReadBlockedUndecryptableErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "request_body_too_large_after_decoding":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<RequestBodyTooLargeAfterDecodingErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "enforced_spend_limit_reached":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EnforcedSpendLimitReachedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "ramp_limit_exceeded":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RampLimitExceededErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cmek_key_unreachable":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CmekKeyUnreachableErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction_unavailable":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::CompactionUnavailableErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "storage_quota_exceeded":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Files::StorageQuotaExceededErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "file_not_downloadable":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Files::FileNotDownloadableErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "file_expired":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Files::FileExpiredErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cmek_context_unavailable":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CmekContextUnavailableErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "org_api_key_limit_exceeded":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ApiKeys::OrgApiKeyLimitExceededErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "workspace_api_key_limit_exceeded":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ApiKeys::WorkspaceApiKeyLimitExceededErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user_profile_not_found":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UserProfileNotFoundErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "external_key_in_workspace_policy":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ExternalKeyInWorkspacePolicyErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "already_member":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AlreadyMemberErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cannot_invite_emails_with_unverified_domains":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CannotInviteEmailsWithUnverifiedDomainsErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "email_domain_not_allowed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EmailDomainNotAllowedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "invite_already_exists":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InviteAlreadyExistsErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "org_member_limit_exceeded":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<OrgMemberLimitExceededErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "rbac_group_grants_owner_access":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<RbacGroupGrantsOwnerAccessErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "rbac_group_owner_access_unconfirmed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<RbacGroupOwnerAccessUnconfirmedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cannot_remove_last_member":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CannotRemoveLastMemberErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "concurrent_membership_change":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ConcurrentMembershipChangeErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "external_key_validation_failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ExternalKeyValidationFailedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "external_key_validation_timed_out":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ExternalKeyValidationTimedOutErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "key_profile_mismatch":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<KeyProfileMismatchErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "workspace_policy_violation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<WorkspacePolicyViolationErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "external_key_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExternalKeyChangedErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "workspace_member_limit_exceeded":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<WorkspaceMemberLimitExceededErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "organization_type_not_supported":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<OrganizationTypeNotSupportedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "environment_create_disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Environments::BetaEnvironmentCreateDisabledErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "environment_archived":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Environments::BetaEnvironmentArchivedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "invalid_config_type_change":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Environments::BetaInvalidConfigTypeChangeErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "environment_update_disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Environments::BetaEnvironmentUpdateDisabledErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "heartbeat_precondition_failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaHeartbeatPreconditionFailedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "invalid_metadata":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Environments::BetaInvalidMetadataErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "billing_frozen":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBillingFrozenErrorDetails>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "spend_limits_admin_api_writes_not_enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unsupported_charset":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaUnsupportedCharsetErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "plugin_name_taken":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Plugins::BetaPluginNameTakenErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "skill_name_taken":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Plugins::BetaSkillNameTakenErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "registration_pending":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Plugins::BetaRegistrationPendingErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scan_failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Plugins::BetaScanFailedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scan_pending":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Plugins::BetaScanPendingErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "slack_channel_set_up_settings_refused":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaSlackChannelSetUpSettingsRefusedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "api_key_scope_missing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaApiKeyScopeMissingErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "claude_tag_writes_not_enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagWritesNotEnabledErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compliance_configuration_restricted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceConfigurationRestrictedErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "organization_level_scoped_api_key_required":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaOrganizationLevelScopedApiKeyRequiredErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "environment_not_found":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Environments::BetaEnvironmentNotFoundErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "slack_channel_set_up_environment_not_found":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "slack_channel_set_up_settings_conflict":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaSlackChannelSetUpSettingsConflictErrorDetails>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ErrorDetails(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorDetails value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ErrorDetailsErrorCodeConverter))]
public enum ErrorDetailsErrorCode
{
    AvailableToolsLimitExceeded,
    ClaudeCodeKeyCreatorNotMember,
    ClaudeCodeVersionTooOld,
    CmekKeyDisabled,
    CmekKeyNetworkBlocked,
    CompactionBlockAmbiguous,
    CompactionBlockMisplaced,
    CompactionContentMismatch,
    CompactionIncompleteTurn,
    CompactionNothingToSummarize,
    CompactionSignatureInvalid,
    CompactionTooManyToolReferences,
    CompactionToolChangesMismatch,
    OrganizationOnHold,
    RequestBodyEncodingInvalid,
    RequestBodyEncodingUnsupported,
    ThreadAlreadyContinued,
    ThreadContinueInFlight,
    ThreadFingerprintMismatch,
    ThreadUnsupportedRequest,
    ToolNameConflict,
    ToolReferenceUnresolved,
    ThreadNotFound,
    SkillReadBlockedUndecryptable,
    RequestBodyTooLargeAfterDecoding,
    EnforcedSpendLimitReached,
    RampLimitExceeded,
    CmekKeyUnreachable,
    CompactionUnavailable,
    StorageQuotaExceeded,
    FileNotDownloadable,
    FileExpired,
    CmekContextUnavailable,
    OrgApiKeyLimitExceeded,
    WorkspaceApiKeyLimitExceeded,
    UserProfileNotFound,
    ExternalKeyInWorkspacePolicy,
    AlreadyMember,
    CannotInviteEmailsWithUnverifiedDomains,
    EmailDomainNotAllowed,
    InviteAlreadyExists,
    OrgMemberLimitExceeded,
    RbacGroupGrantsOwnerAccess,
    RbacGroupOwnerAccessUnconfirmed,
    CannotRemoveLastMember,
    ConcurrentMembershipChange,
    ExternalKeyValidationFailed,
    ExternalKeyValidationTimedOut,
    KeyProfileMismatch,
    WorkspacePolicyViolation,
    ExternalKeyChanged,
    WorkspaceMemberLimitExceeded,
    OrganizationTypeNotSupported,
    EnvironmentCreateDisabled,
    EnvironmentArchived,
    InvalidConfigTypeChange,
    EnvironmentUpdateDisabled,
    HeartbeatPreconditionFailed,
    InvalidMetadata,
    BillingFrozen,
    SpendLimitsAdminApiWritesNotEnabled,
    UnsupportedCharset,
    PluginNameTaken,
    SkillNameTaken,
    RegistrationPending,
    ScanFailed,
    ScanPending,
    SlackChannelSetUpSettingsRefused,
    ApiKeyScopeMissing,
    ClaudeTagWritesNotEnabled,
    ComplianceConfigurationRestricted,
    OrganizationLevelScopedApiKeyRequired,
    EnvironmentNotFound,
    SlackChannelSetUpEnvironmentNotFound,
    SlackChannelSetUpSettingsConflict,
}

sealed class ErrorDetailsErrorCodeConverter : JsonConverter<ErrorDetailsErrorCode>
{
    public override ErrorDetailsErrorCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available_tools_limit_exceeded" => ErrorDetailsErrorCode.AvailableToolsLimitExceeded,
            "claude_code_key_creator_not_member" =>
                ErrorDetailsErrorCode.ClaudeCodeKeyCreatorNotMember,
            "claude_code_version_too_old" => ErrorDetailsErrorCode.ClaudeCodeVersionTooOld,
            "cmek_key_disabled" => ErrorDetailsErrorCode.CmekKeyDisabled,
            "cmek_key_network_blocked" => ErrorDetailsErrorCode.CmekKeyNetworkBlocked,
            "compaction_block_ambiguous" => ErrorDetailsErrorCode.CompactionBlockAmbiguous,
            "compaction_block_misplaced" => ErrorDetailsErrorCode.CompactionBlockMisplaced,
            "compaction_content_mismatch" => ErrorDetailsErrorCode.CompactionContentMismatch,
            "compaction_incomplete_turn" => ErrorDetailsErrorCode.CompactionIncompleteTurn,
            "compaction_nothing_to_summarize" => ErrorDetailsErrorCode.CompactionNothingToSummarize,
            "compaction_signature_invalid" => ErrorDetailsErrorCode.CompactionSignatureInvalid,
            "compaction_too_many_tool_references" =>
                ErrorDetailsErrorCode.CompactionTooManyToolReferences,
            "compaction_tool_changes_mismatch" =>
                ErrorDetailsErrorCode.CompactionToolChangesMismatch,
            "organization_on_hold" => ErrorDetailsErrorCode.OrganizationOnHold,
            "request_body_encoding_invalid" => ErrorDetailsErrorCode.RequestBodyEncodingInvalid,
            "request_body_encoding_unsupported" =>
                ErrorDetailsErrorCode.RequestBodyEncodingUnsupported,
            "thread_already_continued" => ErrorDetailsErrorCode.ThreadAlreadyContinued,
            "thread_continue_in_flight" => ErrorDetailsErrorCode.ThreadContinueInFlight,
            "thread_fingerprint_mismatch" => ErrorDetailsErrorCode.ThreadFingerprintMismatch,
            "thread_unsupported_request" => ErrorDetailsErrorCode.ThreadUnsupportedRequest,
            "tool_name_conflict" => ErrorDetailsErrorCode.ToolNameConflict,
            "tool_reference_unresolved" => ErrorDetailsErrorCode.ToolReferenceUnresolved,
            "thread_not_found" => ErrorDetailsErrorCode.ThreadNotFound,
            "skill_read_blocked_undecryptable" =>
                ErrorDetailsErrorCode.SkillReadBlockedUndecryptable,
            "request_body_too_large_after_decoding" =>
                ErrorDetailsErrorCode.RequestBodyTooLargeAfterDecoding,
            "enforced_spend_limit_reached" => ErrorDetailsErrorCode.EnforcedSpendLimitReached,
            "ramp_limit_exceeded" => ErrorDetailsErrorCode.RampLimitExceeded,
            "cmek_key_unreachable" => ErrorDetailsErrorCode.CmekKeyUnreachable,
            "compaction_unavailable" => ErrorDetailsErrorCode.CompactionUnavailable,
            "storage_quota_exceeded" => ErrorDetailsErrorCode.StorageQuotaExceeded,
            "file_not_downloadable" => ErrorDetailsErrorCode.FileNotDownloadable,
            "file_expired" => ErrorDetailsErrorCode.FileExpired,
            "cmek_context_unavailable" => ErrorDetailsErrorCode.CmekContextUnavailable,
            "org_api_key_limit_exceeded" => ErrorDetailsErrorCode.OrgApiKeyLimitExceeded,
            "workspace_api_key_limit_exceeded" =>
                ErrorDetailsErrorCode.WorkspaceApiKeyLimitExceeded,
            "user_profile_not_found" => ErrorDetailsErrorCode.UserProfileNotFound,
            "external_key_in_workspace_policy" =>
                ErrorDetailsErrorCode.ExternalKeyInWorkspacePolicy,
            "already_member" => ErrorDetailsErrorCode.AlreadyMember,
            "cannot_invite_emails_with_unverified_domains" =>
                ErrorDetailsErrorCode.CannotInviteEmailsWithUnverifiedDomains,
            "email_domain_not_allowed" => ErrorDetailsErrorCode.EmailDomainNotAllowed,
            "invite_already_exists" => ErrorDetailsErrorCode.InviteAlreadyExists,
            "org_member_limit_exceeded" => ErrorDetailsErrorCode.OrgMemberLimitExceeded,
            "rbac_group_grants_owner_access" => ErrorDetailsErrorCode.RbacGroupGrantsOwnerAccess,
            "rbac_group_owner_access_unconfirmed" =>
                ErrorDetailsErrorCode.RbacGroupOwnerAccessUnconfirmed,
            "cannot_remove_last_member" => ErrorDetailsErrorCode.CannotRemoveLastMember,
            "concurrent_membership_change" => ErrorDetailsErrorCode.ConcurrentMembershipChange,
            "external_key_validation_failed" => ErrorDetailsErrorCode.ExternalKeyValidationFailed,
            "external_key_validation_timed_out" =>
                ErrorDetailsErrorCode.ExternalKeyValidationTimedOut,
            "key_profile_mismatch" => ErrorDetailsErrorCode.KeyProfileMismatch,
            "workspace_policy_violation" => ErrorDetailsErrorCode.WorkspacePolicyViolation,
            "external_key_changed" => ErrorDetailsErrorCode.ExternalKeyChanged,
            "workspace_member_limit_exceeded" => ErrorDetailsErrorCode.WorkspaceMemberLimitExceeded,
            "organization_type_not_supported" => ErrorDetailsErrorCode.OrganizationTypeNotSupported,
            "environment_create_disabled" => ErrorDetailsErrorCode.EnvironmentCreateDisabled,
            "environment_archived" => ErrorDetailsErrorCode.EnvironmentArchived,
            "invalid_config_type_change" => ErrorDetailsErrorCode.InvalidConfigTypeChange,
            "environment_update_disabled" => ErrorDetailsErrorCode.EnvironmentUpdateDisabled,
            "heartbeat_precondition_failed" => ErrorDetailsErrorCode.HeartbeatPreconditionFailed,
            "invalid_metadata" => ErrorDetailsErrorCode.InvalidMetadata,
            "billing_frozen" => ErrorDetailsErrorCode.BillingFrozen,
            "spend_limits_admin_api_writes_not_enabled" =>
                ErrorDetailsErrorCode.SpendLimitsAdminApiWritesNotEnabled,
            "unsupported_charset" => ErrorDetailsErrorCode.UnsupportedCharset,
            "plugin_name_taken" => ErrorDetailsErrorCode.PluginNameTaken,
            "skill_name_taken" => ErrorDetailsErrorCode.SkillNameTaken,
            "registration_pending" => ErrorDetailsErrorCode.RegistrationPending,
            "scan_failed" => ErrorDetailsErrorCode.ScanFailed,
            "scan_pending" => ErrorDetailsErrorCode.ScanPending,
            "slack_channel_set_up_settings_refused" =>
                ErrorDetailsErrorCode.SlackChannelSetUpSettingsRefused,
            "api_key_scope_missing" => ErrorDetailsErrorCode.ApiKeyScopeMissing,
            "claude_tag_writes_not_enabled" => ErrorDetailsErrorCode.ClaudeTagWritesNotEnabled,
            "compliance_configuration_restricted" =>
                ErrorDetailsErrorCode.ComplianceConfigurationRestricted,
            "organization_level_scoped_api_key_required" =>
                ErrorDetailsErrorCode.OrganizationLevelScopedApiKeyRequired,
            "environment_not_found" => ErrorDetailsErrorCode.EnvironmentNotFound,
            "slack_channel_set_up_environment_not_found" =>
                ErrorDetailsErrorCode.SlackChannelSetUpEnvironmentNotFound,
            "slack_channel_set_up_settings_conflict" =>
                ErrorDetailsErrorCode.SlackChannelSetUpSettingsConflict,
            _ => (ErrorDetailsErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorDetailsErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorDetailsErrorCode.AvailableToolsLimitExceeded =>
                    "available_tools_limit_exceeded",
                ErrorDetailsErrorCode.ClaudeCodeKeyCreatorNotMember =>
                    "claude_code_key_creator_not_member",
                ErrorDetailsErrorCode.ClaudeCodeVersionTooOld => "claude_code_version_too_old",
                ErrorDetailsErrorCode.CmekKeyDisabled => "cmek_key_disabled",
                ErrorDetailsErrorCode.CmekKeyNetworkBlocked => "cmek_key_network_blocked",
                ErrorDetailsErrorCode.CompactionBlockAmbiguous => "compaction_block_ambiguous",
                ErrorDetailsErrorCode.CompactionBlockMisplaced => "compaction_block_misplaced",
                ErrorDetailsErrorCode.CompactionContentMismatch => "compaction_content_mismatch",
                ErrorDetailsErrorCode.CompactionIncompleteTurn => "compaction_incomplete_turn",
                ErrorDetailsErrorCode.CompactionNothingToSummarize =>
                    "compaction_nothing_to_summarize",
                ErrorDetailsErrorCode.CompactionSignatureInvalid => "compaction_signature_invalid",
                ErrorDetailsErrorCode.CompactionTooManyToolReferences =>
                    "compaction_too_many_tool_references",
                ErrorDetailsErrorCode.CompactionToolChangesMismatch =>
                    "compaction_tool_changes_mismatch",
                ErrorDetailsErrorCode.OrganizationOnHold => "organization_on_hold",
                ErrorDetailsErrorCode.RequestBodyEncodingInvalid => "request_body_encoding_invalid",
                ErrorDetailsErrorCode.RequestBodyEncodingUnsupported =>
                    "request_body_encoding_unsupported",
                ErrorDetailsErrorCode.ThreadAlreadyContinued => "thread_already_continued",
                ErrorDetailsErrorCode.ThreadContinueInFlight => "thread_continue_in_flight",
                ErrorDetailsErrorCode.ThreadFingerprintMismatch => "thread_fingerprint_mismatch",
                ErrorDetailsErrorCode.ThreadUnsupportedRequest => "thread_unsupported_request",
                ErrorDetailsErrorCode.ToolNameConflict => "tool_name_conflict",
                ErrorDetailsErrorCode.ToolReferenceUnresolved => "tool_reference_unresolved",
                ErrorDetailsErrorCode.ThreadNotFound => "thread_not_found",
                ErrorDetailsErrorCode.SkillReadBlockedUndecryptable =>
                    "skill_read_blocked_undecryptable",
                ErrorDetailsErrorCode.RequestBodyTooLargeAfterDecoding =>
                    "request_body_too_large_after_decoding",
                ErrorDetailsErrorCode.EnforcedSpendLimitReached => "enforced_spend_limit_reached",
                ErrorDetailsErrorCode.RampLimitExceeded => "ramp_limit_exceeded",
                ErrorDetailsErrorCode.CmekKeyUnreachable => "cmek_key_unreachable",
                ErrorDetailsErrorCode.CompactionUnavailable => "compaction_unavailable",
                ErrorDetailsErrorCode.StorageQuotaExceeded => "storage_quota_exceeded",
                ErrorDetailsErrorCode.FileNotDownloadable => "file_not_downloadable",
                ErrorDetailsErrorCode.FileExpired => "file_expired",
                ErrorDetailsErrorCode.CmekContextUnavailable => "cmek_context_unavailable",
                ErrorDetailsErrorCode.OrgApiKeyLimitExceeded => "org_api_key_limit_exceeded",
                ErrorDetailsErrorCode.WorkspaceApiKeyLimitExceeded =>
                    "workspace_api_key_limit_exceeded",
                ErrorDetailsErrorCode.UserProfileNotFound => "user_profile_not_found",
                ErrorDetailsErrorCode.ExternalKeyInWorkspacePolicy =>
                    "external_key_in_workspace_policy",
                ErrorDetailsErrorCode.AlreadyMember => "already_member",
                ErrorDetailsErrorCode.CannotInviteEmailsWithUnverifiedDomains =>
                    "cannot_invite_emails_with_unverified_domains",
                ErrorDetailsErrorCode.EmailDomainNotAllowed => "email_domain_not_allowed",
                ErrorDetailsErrorCode.InviteAlreadyExists => "invite_already_exists",
                ErrorDetailsErrorCode.OrgMemberLimitExceeded => "org_member_limit_exceeded",
                ErrorDetailsErrorCode.RbacGroupGrantsOwnerAccess =>
                    "rbac_group_grants_owner_access",
                ErrorDetailsErrorCode.RbacGroupOwnerAccessUnconfirmed =>
                    "rbac_group_owner_access_unconfirmed",
                ErrorDetailsErrorCode.CannotRemoveLastMember => "cannot_remove_last_member",
                ErrorDetailsErrorCode.ConcurrentMembershipChange => "concurrent_membership_change",
                ErrorDetailsErrorCode.ExternalKeyValidationFailed =>
                    "external_key_validation_failed",
                ErrorDetailsErrorCode.ExternalKeyValidationTimedOut =>
                    "external_key_validation_timed_out",
                ErrorDetailsErrorCode.KeyProfileMismatch => "key_profile_mismatch",
                ErrorDetailsErrorCode.WorkspacePolicyViolation => "workspace_policy_violation",
                ErrorDetailsErrorCode.ExternalKeyChanged => "external_key_changed",
                ErrorDetailsErrorCode.WorkspaceMemberLimitExceeded =>
                    "workspace_member_limit_exceeded",
                ErrorDetailsErrorCode.OrganizationTypeNotSupported =>
                    "organization_type_not_supported",
                ErrorDetailsErrorCode.EnvironmentCreateDisabled => "environment_create_disabled",
                ErrorDetailsErrorCode.EnvironmentArchived => "environment_archived",
                ErrorDetailsErrorCode.InvalidConfigTypeChange => "invalid_config_type_change",
                ErrorDetailsErrorCode.EnvironmentUpdateDisabled => "environment_update_disabled",
                ErrorDetailsErrorCode.HeartbeatPreconditionFailed =>
                    "heartbeat_precondition_failed",
                ErrorDetailsErrorCode.InvalidMetadata => "invalid_metadata",
                ErrorDetailsErrorCode.BillingFrozen => "billing_frozen",
                ErrorDetailsErrorCode.SpendLimitsAdminApiWritesNotEnabled =>
                    "spend_limits_admin_api_writes_not_enabled",
                ErrorDetailsErrorCode.UnsupportedCharset => "unsupported_charset",
                ErrorDetailsErrorCode.PluginNameTaken => "plugin_name_taken",
                ErrorDetailsErrorCode.SkillNameTaken => "skill_name_taken",
                ErrorDetailsErrorCode.RegistrationPending => "registration_pending",
                ErrorDetailsErrorCode.ScanFailed => "scan_failed",
                ErrorDetailsErrorCode.ScanPending => "scan_pending",
                ErrorDetailsErrorCode.SlackChannelSetUpSettingsRefused =>
                    "slack_channel_set_up_settings_refused",
                ErrorDetailsErrorCode.ApiKeyScopeMissing => "api_key_scope_missing",
                ErrorDetailsErrorCode.ClaudeTagWritesNotEnabled => "claude_tag_writes_not_enabled",
                ErrorDetailsErrorCode.ComplianceConfigurationRestricted =>
                    "compliance_configuration_restricted",
                ErrorDetailsErrorCode.OrganizationLevelScopedApiKeyRequired =>
                    "organization_level_scoped_api_key_required",
                ErrorDetailsErrorCode.EnvironmentNotFound => "environment_not_found",
                ErrorDetailsErrorCode.SlackChannelSetUpEnvironmentNotFound =>
                    "slack_channel_set_up_environment_not_found",
                ErrorDetailsErrorCode.SlackChannelSetUpSettingsConflict =>
                    "slack_channel_set_up_settings_conflict",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
