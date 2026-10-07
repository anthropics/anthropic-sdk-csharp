using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ComputerScrollDirectionConverter))]
public enum ComputerScrollDirection
{
    Up,
    Down,
    Left,
    Right,
}

sealed class ComputerScrollDirectionConverter : JsonConverter<ComputerScrollDirection>
{
    public override ComputerScrollDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "up" => ComputerScrollDirection.Up,
            "down" => ComputerScrollDirection.Down,
            "left" => ComputerScrollDirection.Left,
            "right" => ComputerScrollDirection.Right,
            _ => (ComputerScrollDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComputerScrollDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ComputerScrollDirection.Up => "up",
                ComputerScrollDirection.Down => "down",
                ComputerScrollDirection.Left => "left",
                ComputerScrollDirection.Right => "right",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
