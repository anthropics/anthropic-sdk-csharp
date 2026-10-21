using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The next step on this enforcement action: `verify` means the end user can clear
/// the action by passing an identity check. More values may be added; read a value
/// you do not recognize as `null`.
/// </summary>
[JsonConverter(typeof(UserProfileEnforcementActionNextStepConverter))]
public enum UserProfileEnforcementActionNextStep
{
    Verify,
}

sealed class UserProfileEnforcementActionNextStepConverter
    : JsonConverter<UserProfileEnforcementActionNextStep>
{
    public override UserProfileEnforcementActionNextStep Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "verify" => UserProfileEnforcementActionNextStep.Verify,
            _ => (UserProfileEnforcementActionNextStep)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileEnforcementActionNextStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileEnforcementActionNextStep.Verify => "verify",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
