using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments;
using Anthropic.Models.Beta.Environments.Work;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.Users;
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

namespace Anthropic.Exceptions;

public class AnthropicExceptionFactory
{
    static readonly Dictionary<
        (int, string?),
        Func<HttpStatusCode, string, HttpResponse?, AnthropicApiException>
    > ErrorCodeExceptions = new()
    {
        [(400, "already_member")] = (statusCode, responseBody, response) =>
            new AnthropicAlreadyMemberException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "available_tools_limit_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicAvailableToolsLimitExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "cannot_invite_emails_with_unverified_domains")] = (
            statusCode,
            responseBody,
            response
        ) =>
            new AnthropicCannotInviteEmailsWithUnverifiedDomainsException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "cannot_remove_last_member")] = (statusCode, responseBody, response) =>
            new AnthropicCannotRemoveLastMemberException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "cannot_sign_out_primary_owner")] = (statusCode, responseBody, response) =>
            new AnthropicBetaCannotSignOutPrimaryOwnerException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "cannot_sign_out_self")] = (statusCode, responseBody, response) =>
            new AnthropicBetaCannotSignOutSelfException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "claude_code_key_creator_not_member")] = (statusCode, responseBody, response) =>
            new AnthropicClaudeCodeKeyCreatorNotMemberException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "claude_code_version_too_old")] = (statusCode, responseBody, response) =>
            new AnthropicClaudeCodeVersionTooOldException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "cmek_key_disabled")] = (statusCode, responseBody, response) =>
            new AnthropicCmekKeyDisabledException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "cmek_key_network_blocked")] = (statusCode, responseBody, response) =>
            new AnthropicCmekKeyNetworkBlockedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_block_ambiguous")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionBlockAmbiguousException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_block_misplaced")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionBlockMisplacedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_content_mismatch")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionContentMismatchException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_incomplete_turn")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionIncompleteTurnException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_nothing_to_summarize")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionNothingToSummarizeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_signature_invalid")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionSignatureInvalidException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_too_many_tool_references")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionTooManyToolReferencesException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "compaction_tool_changes_mismatch")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionToolChangesMismatchException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "email_domain_not_allowed")] = (statusCode, responseBody, response) =>
            new AnthropicEmailDomainNotAllowedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "environment_archived")] = (statusCode, responseBody, response) =>
            new AnthropicBetaEnvironmentArchivedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "external_key_in_workspace_policy")] = (statusCode, responseBody, response) =>
            new AnthropicExternalKeyInWorkspacePolicyException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "external_key_validation_failed")] = (statusCode, responseBody, response) =>
            new AnthropicExternalKeyValidationFailedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "external_key_validation_timed_out")] = (statusCode, responseBody, response) =>
            new AnthropicExternalKeyValidationTimedOutException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "file_not_downloadable")] = (statusCode, responseBody, response) =>
            new AnthropicFileNotDownloadableException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "invalid_config_type_change")] = (statusCode, responseBody, response) =>
            new AnthropicBetaInvalidConfigTypeChangeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "invalid_metadata")] = (statusCode, responseBody, response) =>
            new AnthropicBetaInvalidMetadataException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "invite_already_exists")] = (statusCode, responseBody, response) =>
            new AnthropicInviteAlreadyExistsException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "key_profile_mismatch")] = (statusCode, responseBody, response) =>
            new AnthropicKeyProfileMismatchException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "org_api_key_limit_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicOrgApiKeyLimitExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "org_member_limit_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicOrgMemberLimitExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "organization_not_enrolled_in_beta")] = (statusCode, responseBody, response) =>
            new AnthropicBetaOrganizationNotEnrolledInBetaException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "organization_on_hold")] = (statusCode, responseBody, response) =>
            new AnthropicOrganizationOnHoldException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "organization_type_not_supported")] = (statusCode, responseBody, response) =>
            new AnthropicOrganizationTypeNotSupportedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "rbac_group_grants_owner_access")] = (statusCode, responseBody, response) =>
            new AnthropicRbacGroupGrantsOwnerAccessException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "rbac_group_owner_access_unconfirmed")] = (statusCode, responseBody, response) =>
            new AnthropicRbacGroupOwnerAccessUnconfirmedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "request_body_encoding_invalid")] = (statusCode, responseBody, response) =>
            new AnthropicRequestBodyEncodingInvalidException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "request_body_encoding_unsupported")] = (statusCode, responseBody, response) =>
            new AnthropicRequestBodyEncodingUnsupportedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "scan_failed")] = (statusCode, responseBody, response) =>
            new AnthropicBetaScanFailedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "slack_channel_set_up_settings_refused")] = (statusCode, responseBody, response) =>
            new AnthropicBetaSlackChannelSetUpSettingsRefusedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "storage_quota_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicStorageQuotaExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "thread_already_continued")] = (statusCode, responseBody, response) =>
            new AnthropicThreadAlreadyContinuedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "thread_continue_in_flight")] = (statusCode, responseBody, response) =>
            new AnthropicThreadContinueInFlightException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "thread_fingerprint_mismatch")] = (statusCode, responseBody, response) =>
            new AnthropicThreadFingerprintMismatchException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "thread_unsupported_request")] = (statusCode, responseBody, response) =>
            new AnthropicThreadUnsupportedRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "tool_name_conflict")] = (statusCode, responseBody, response) =>
            new AnthropicToolNameConflictException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "tool_reference_unresolved")] = (statusCode, responseBody, response) =>
            new AnthropicToolReferenceUnresolvedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "unsupported_charset")] = (statusCode, responseBody, response) =>
            new AnthropicBetaUnsupportedCharsetException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "user_profile_not_found")] = (statusCode, responseBody, response) =>
            new AnthropicUserProfileNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "workspace_api_key_limit_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicWorkspaceApiKeyLimitExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "workspace_member_limit_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicWorkspaceMemberLimitExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(400, "workspace_policy_violation")] = (statusCode, responseBody, response) =>
            new AnthropicWorkspacePolicyViolationException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "api_key_scope_missing")] = (statusCode, responseBody, response) =>
            new AnthropicBetaApiKeyScopeMissingException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "billing_frozen")] = (statusCode, responseBody, response) =>
            new AnthropicBetaBillingFrozenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "cannot_sign_out_managed_member")] = (statusCode, responseBody, response) =>
            new AnthropicBetaCannotSignOutManagedMemberException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "cannot_sign_out_membership_admin")] = (statusCode, responseBody, response) =>
            new AnthropicBetaCannotSignOutMembershipAdminException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "cannot_sign_out_owner")] = (statusCode, responseBody, response) =>
            new AnthropicBetaCannotSignOutOwnerException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "cannot_sign_out_privileged_member")] = (statusCode, responseBody, response) =>
            new AnthropicBetaCannotSignOutPrivilegedMemberException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "claude_tag_writes_not_enabled")] = (statusCode, responseBody, response) =>
            new AnthropicBetaClaudeTagWritesNotEnabledException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "compliance_configuration_restricted")] = (statusCode, responseBody, response) =>
            new AnthropicBetaComplianceConfigurationRestrictedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "environment_create_disabled")] = (statusCode, responseBody, response) =>
            new AnthropicBetaEnvironmentCreateDisabledException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "environment_update_disabled")] = (statusCode, responseBody, response) =>
            new AnthropicBetaEnvironmentUpdateDisabledException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "organization_level_scoped_api_key_required")] = (
            statusCode,
            responseBody,
            response
        ) =>
            new AnthropicBetaOrganizationLevelScopedApiKeyRequiredException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(403, "spend_limits_admin_api_writes_not_enabled")] = (
            statusCode,
            responseBody,
            response
        ) =>
            new AnthropicBetaSpendLimitsAdminApiWritesNotEnabledException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(404, "environment_not_found")] = (statusCode, responseBody, response) =>
            new AnthropicBetaEnvironmentNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(404, "file_expired")] = (statusCode, responseBody, response) =>
            new AnthropicFileExpiredException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(404, "slack_channel_set_up_environment_not_found")] = (
            statusCode,
            responseBody,
            response
        ) =>
            new AnthropicBetaSlackChannelSetUpEnvironmentNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(404, "thread_not_found")] = (statusCode, responseBody, response) =>
            new AnthropicThreadNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "concurrent_membership_change")] = (statusCode, responseBody, response) =>
            new AnthropicConcurrentMembershipChangeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "external_key_changed")] = (statusCode, responseBody, response) =>
            new AnthropicExternalKeyChangedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "plugin_name_taken")] = (statusCode, responseBody, response) =>
            new AnthropicBetaPluginNameTakenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "scan_pending")] = (statusCode, responseBody, response) =>
            new AnthropicBetaScanPendingException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "skill_name_taken")] = (statusCode, responseBody, response) =>
            new AnthropicBetaSkillNameTakenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "skill_read_blocked_undecryptable")] = (statusCode, responseBody, response) =>
            new AnthropicSkillReadBlockedUndecryptableException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(409, "slack_channel_set_up_settings_conflict")] = (statusCode, responseBody, response) =>
            new AnthropicBetaSlackChannelSetUpSettingsConflictException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(412, "heartbeat_precondition_failed")] = (statusCode, responseBody, response) =>
            new AnthropicBetaHeartbeatPreconditionFailedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(413, "request_body_too_large_after_decoding")] = (statusCode, responseBody, response) =>
            new AnthropicRequestBodyTooLargeAfterDecodingException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(429, "enforced_spend_limit_reached")] = (statusCode, responseBody, response) =>
            new AnthropicEnforcedSpendLimitReachedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(429, "ramp_limit_exceeded")] = (statusCode, responseBody, response) =>
            new AnthropicRampLimitExceededException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(503, "cmek_context_unavailable")] = (statusCode, responseBody, response) =>
            new AnthropicCmekContextUnavailableException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(503, "cmek_key_unreachable")] = (statusCode, responseBody, response) =>
            new AnthropicCmekKeyUnreachableException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(503, "registration_pending")] = (statusCode, responseBody, response) =>
            new AnthropicBetaRegistrationPendingException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        [(529, "compaction_unavailable")] = (statusCode, responseBody, response) =>
            new AnthropicCompactionUnavailableException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
    };

    public static AnthropicApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    ) => CreateApiException(statusCode, responseBody, null);

    internal static AnthropicApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody,
        HttpResponse? response
    )
    {
        var errorCode = WrappedJsonSerializer.GetNullableClassProperty<string>(
            WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    WrappedJsonSerializer.ParseOrDefault(responseBody),
                    "error"
                ) ?? default,
                "details"
            ) ?? default,
            "error_code"
        );
        if (ErrorCodeExceptions.TryGetValue(((int)statusCode, errorCode), out var create))
        {
            return create(statusCode, responseBody, response);
        }

        return (int)statusCode switch
        {
            400 => new AnthropicBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            401 => new AnthropicUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            403 => new AnthropicForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            404 => new AnthropicNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            408 => new AnthropicRequestTimeoutException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            409 => new AnthropicConflictException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            412 => new AnthropicPreconditionFailedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            413 => new AnthropicContentTooLargeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            422 => new AnthropicUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            429 => new AnthropicRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            431 => new AnthropicRequestHeaderFieldsTooLargeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            499 => new AnthropicClientClosedRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            501 => new AnthropicNotImplementedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            503 => new AnthropicServiceUnavailableException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            504 => new AnthropicGatewayTimeoutException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            529 => new AnthropicOverloadedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            >= 400 and <= 499 => new Anthropic4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            >= 500 and <= 599 => new Anthropic5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
            _ => new AnthropicUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
            },
        };
    }

    internal static ErrorType? ExtractErrorType(string jsonBody)
    {
        try
        {
            using var doc = JsonDocument.Parse(jsonBody);
            if (
                doc.RootElement.ValueKind == JsonValueKind.Object
                && doc.RootElement.TryGetProperty("error", out var errorElement)
                && errorElement.ValueKind == JsonValueKind.Object
                && errorElement.TryGetProperty("type", out var typeElement)
                && typeElement.ValueKind == JsonValueKind.String
            )
            {
                var result = typeElement.Deserialize<ErrorType>();
                return Enum.IsDefined(typeof(ErrorType), result) ? result : null;
            }
        }
        catch (JsonException)
        {
            // Response body isn't valid JSON — leave ErrorType as null
        }
        return null;
    }
}
