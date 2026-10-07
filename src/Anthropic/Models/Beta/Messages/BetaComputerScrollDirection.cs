using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaComputerScrollDirectionConverter))]
public enum BetaComputerScrollDirection
{
    Up,
    Down,
    Left,
    Right,
}

sealed class BetaComputerScrollDirectionConverter : JsonConverter<BetaComputerScrollDirection>
{
    public override BetaComputerScrollDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "up" => BetaComputerScrollDirection.Up,
            "down" => BetaComputerScrollDirection.Down,
            "left" => BetaComputerScrollDirection.Left,
            "right" => BetaComputerScrollDirection.Right,
            _ => (BetaComputerScrollDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComputerScrollDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComputerScrollDirection.Up => "up",
                BetaComputerScrollDirection.Down => "down",
                BetaComputerScrollDirection.Left => "left",
                BetaComputerScrollDirection.Right => "right",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
