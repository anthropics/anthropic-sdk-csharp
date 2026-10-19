using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// A user profile's status in a program. Each program's `status` field says what
/// the values mean there.
/// </summary>
[JsonConverter(typeof(UserProfileProgramStatusConverter))]
public enum UserProfileProgramStatus
{
    /// <summary>
    /// The profile is in the program.
    /// </summary>
    Active,

    /// <summary>
    /// The profile is not in the program yet, and something is still awaited.
    /// </summary>
    Pending,

    /// <summary>
    /// The profile is not in the program and nothing is awaited: Anthropic has declined,
    /// or has withdrawn an earlier approval.
    /// </summary>
    Rejected,
}

sealed class UserProfileProgramStatusConverter : JsonConverter<UserProfileProgramStatus>
{
    public override UserProfileProgramStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => UserProfileProgramStatus.Active,
            "pending" => UserProfileProgramStatus.Pending,
            "rejected" => UserProfileProgramStatus.Rejected,
            _ => (UserProfileProgramStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileProgramStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileProgramStatus.Active => "active",
                UserProfileProgramStatus.Pending => "pending",
                UserProfileProgramStatus.Rejected => "rejected",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
