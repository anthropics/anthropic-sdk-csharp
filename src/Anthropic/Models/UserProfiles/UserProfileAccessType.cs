using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// How the platform uses the API on behalf of the entity this profile represents.
/// `application`: the platform sells a product that uses the API behind the scenes,
/// and the profile represents an individual end-user of that product. `passthrough`:
/// the platform resells raw inference, and the profile identifies the resold-to company.
/// </summary>
[JsonConverter(typeof(UserProfileAccessTypeConverter))]
public enum UserProfileAccessType
{
    /// <summary>
    /// The user profile represents an individual end-user of a product that the
    /// platform builds on the API. New profiles get this value by default.
    /// </summary>
    Application,

    /// <summary>
    /// The user profile represents a company that the platform resells Claude access to.
    /// </summary>
    Passthrough,
}

sealed class UserProfileAccessTypeConverter : JsonConverter<UserProfileAccessType>
{
    public override UserProfileAccessType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "application" => UserProfileAccessType.Application,
            "passthrough" => UserProfileAccessType.Passthrough,
            _ => (UserProfileAccessType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileAccessType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileAccessType.Application => "application",
                UserProfileAccessType.Passthrough => "passthrough",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
