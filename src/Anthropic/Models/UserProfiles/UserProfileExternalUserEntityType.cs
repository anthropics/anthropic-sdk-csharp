using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// What kind of entity the profile represents, as the platform states it: `individual`,
/// `business`, `non_profit` or `government`.
/// </summary>
[JsonConverter(typeof(UserProfileExternalUserEntityTypeConverter))]
public enum UserProfileExternalUserEntityType
{
    Individual,
    Business,
    NonProfit,
    Government,
}

sealed class UserProfileExternalUserEntityTypeConverter
    : JsonConverter<UserProfileExternalUserEntityType>
{
    public override UserProfileExternalUserEntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => UserProfileExternalUserEntityType.Individual,
            "business" => UserProfileExternalUserEntityType.Business,
            "non_profit" => UserProfileExternalUserEntityType.NonProfit,
            "government" => UserProfileExternalUserEntityType.Government,
            _ => (UserProfileExternalUserEntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileExternalUserEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileExternalUserEntityType.Individual => "individual",
                UserProfileExternalUserEntityType.Business => "business",
                UserProfileExternalUserEntityType.NonProfit => "non_profit",
                UserProfileExternalUserEntityType.Government => "government",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
