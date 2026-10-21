using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The direction that a list of user profiles is sorted in.
/// </summary>
[JsonConverter(typeof(UserProfileListOrderConverter))]
public enum UserProfileListOrder
{
    /// <summary>
    /// Oldest first when `order_by` is `created_at`, or names in ascending order
    /// when `order_by` is `name`.
    /// </summary>
    Asc,

    /// <summary>
    /// Newest first when `order_by` is `created_at`, or names in descending order
    /// when `order_by` is `name`. This is the default.
    /// </summary>
    Desc,
}

sealed class UserProfileListOrderConverter : JsonConverter<UserProfileListOrder>
{
    public override UserProfileListOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => UserProfileListOrder.Asc,
            "desc" => UserProfileListOrder.Desc,
            _ => (UserProfileListOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileListOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileListOrder.Asc => "asc",
                UserProfileListOrder.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
