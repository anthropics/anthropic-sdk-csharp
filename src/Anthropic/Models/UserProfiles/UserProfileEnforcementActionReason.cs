using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// Why Anthropic placed this enforcement action: `unsupported_region`, `fraud_or_abuse`,
/// `high_harm`, `usage_policy_violation`, `account_compromise` or `unspecified`.
/// More values may be added; read a value you do not recognize as `unspecified`.
/// </summary>
[JsonConverter(typeof(UserProfileEnforcementActionReasonConverter))]
public enum UserProfileEnforcementActionReason
{
    UnsupportedRegion,
    FraudOrAbuse,
    HighHarm,
    UsagePolicyViolation,
    AccountCompromise,
    Unspecified,
}

sealed class UserProfileEnforcementActionReasonConverter
    : JsonConverter<UserProfileEnforcementActionReason>
{
    public override UserProfileEnforcementActionReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unsupported_region" => UserProfileEnforcementActionReason.UnsupportedRegion,
            "fraud_or_abuse" => UserProfileEnforcementActionReason.FraudOrAbuse,
            "high_harm" => UserProfileEnforcementActionReason.HighHarm,
            "usage_policy_violation" => UserProfileEnforcementActionReason.UsagePolicyViolation,
            "account_compromise" => UserProfileEnforcementActionReason.AccountCompromise,
            "unspecified" => UserProfileEnforcementActionReason.Unspecified,
            _ => (UserProfileEnforcementActionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileEnforcementActionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileEnforcementActionReason.UnsupportedRegion => "unsupported_region",
                UserProfileEnforcementActionReason.FraudOrAbuse => "fraud_or_abuse",
                UserProfileEnforcementActionReason.HighHarm => "high_harm",
                UserProfileEnforcementActionReason.UsagePolicyViolation => "usage_policy_violation",
                UserProfileEnforcementActionReason.AccountCompromise => "account_compromise",
                UserProfileEnforcementActionReason.Unspecified => "unspecified",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
