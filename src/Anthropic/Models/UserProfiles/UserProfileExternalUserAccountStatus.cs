using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The status of the entity's account on the platform, as the platform states it:
/// `active`; `suspended`, when the platform has restricted the account and may restore
/// it; or `blocked`, when the platform has barred it. It records the platform's decision
/// only. The statuses that Anthropic itself reports for the profile, such as its
/// status in a program, are Anthropic's decisions and do not change with it.
/// </summary>
[JsonConverter(typeof(UserProfileExternalUserAccountStatusConverter))]
public enum UserProfileExternalUserAccountStatus
{
    /// <summary>
    /// The platform has neither restricted nor barred the account of the entity
    /// that the user profile represents.
    /// </summary>
    Active,

    /// <summary>
    /// The platform has restricted the account of the entity that the user profile
    /// represents and may restore it.
    /// </summary>
    Suspended,

    /// <summary>
    /// The platform has barred the account of the entity that the user profile represents.
    /// </summary>
    Blocked,
}

sealed class UserProfileExternalUserAccountStatusConverter
    : JsonConverter<UserProfileExternalUserAccountStatus>
{
    public override UserProfileExternalUserAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => UserProfileExternalUserAccountStatus.Active,
            "suspended" => UserProfileExternalUserAccountStatus.Suspended,
            "blocked" => UserProfileExternalUserAccountStatus.Blocked,
            _ => (UserProfileExternalUserAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileExternalUserAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileExternalUserAccountStatus.Active => "active",
                UserProfileExternalUserAccountStatus.Suspended => "suspended",
                UserProfileExternalUserAccountStatus.Blocked => "blocked",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
