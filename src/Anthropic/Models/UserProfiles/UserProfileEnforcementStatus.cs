using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// Anthropic's enforcement status of this profile: `unrestricted`, `pending`, `restricted`
/// or `banned`. More values may be added; read a value you do not recognize as `restricted`.
/// </summary>
[JsonConverter(typeof(UserProfileEnforcementStatusConverter))]
public enum UserProfileEnforcementStatus
{
    Unrestricted,
    Pending,
    Restricted,
    Banned,
}

sealed class UserProfileEnforcementStatusConverter : JsonConverter<UserProfileEnforcementStatus>
{
    public override UserProfileEnforcementStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unrestricted" => UserProfileEnforcementStatus.Unrestricted,
            "pending" => UserProfileEnforcementStatus.Pending,
            "restricted" => UserProfileEnforcementStatus.Restricted,
            "banned" => UserProfileEnforcementStatus.Banned,
            _ => (UserProfileEnforcementStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileEnforcementStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileEnforcementStatus.Unrestricted => "unrestricted",
                UserProfileEnforcementStatus.Pending => "pending",
                UserProfileEnforcementStatus.Restricted => "restricted",
                UserProfileEnforcementStatus.Banned => "banned",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
