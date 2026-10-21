using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaBrowserScrollDirectionConverter))]
public enum BetaBrowserScrollDirection
{
    Up,
    Down,
    Left,
    Right,
}

sealed class BetaBrowserScrollDirectionConverter : JsonConverter<BetaBrowserScrollDirection>
{
    public override BetaBrowserScrollDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "up" => BetaBrowserScrollDirection.Up,
            "down" => BetaBrowserScrollDirection.Down,
            "left" => BetaBrowserScrollDirection.Left,
            "right" => BetaBrowserScrollDirection.Right,
            _ => (BetaBrowserScrollDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBrowserScrollDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaBrowserScrollDirection.Up => "up",
                BetaBrowserScrollDirection.Down => "down",
                BetaBrowserScrollDirection.Left => "left",
                BetaBrowserScrollDirection.Right => "right",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
