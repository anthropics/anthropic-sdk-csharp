using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// Sort field for listing user profiles: `created_at` (default) or `name` (case-insensitive;
/// profiles without a name sort last).
/// </summary>
[JsonConverter(typeof(UserProfileListOrderByConverter))]
public enum UserProfileListOrderBy
{
    /// <summary>
    /// Sort by when each user profile was created. This is the default.
    /// </summary>
    CreatedAt,

    /// <summary>
    /// Sort by `name`, ignoring the case of ASCII letters. Profiles without a name
    /// come last in either direction.
    /// </summary>
    Name,
}

sealed class UserProfileListOrderByConverter : JsonConverter<UserProfileListOrderBy>
{
    public override UserProfileListOrderBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at" => UserProfileListOrderBy.CreatedAt,
            "name" => UserProfileListOrderBy.Name,
            _ => (UserProfileListOrderBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileListOrderBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileListOrderBy.CreatedAt => "created_at",
                UserProfileListOrderBy.Name => "name",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
