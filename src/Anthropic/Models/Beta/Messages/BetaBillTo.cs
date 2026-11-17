using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Who is billed for a request.
/// </summary>
[JsonConverter(typeof(BetaBillToConverter))]
public enum BetaBillTo
{
    Self,
    UserProfile,
}

sealed class BetaBillToConverter : JsonConverter<BetaBillTo>
{
    public override BetaBillTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "self" => BetaBillTo.Self,
            "user_profile" => BetaBillTo.UserProfile,
            _ => (BetaBillTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBillTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaBillTo.Self => "self",
                BetaBillTo.UserProfile => "user_profile",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
