using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(BrowserScrollDirectionConverter))]
public enum BrowserScrollDirection
{
    Up,
    Down,
    Left,
    Right,
}

sealed class BrowserScrollDirectionConverter : JsonConverter<BrowserScrollDirection>
{
    public override BrowserScrollDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "up" => BrowserScrollDirection.Up,
            "down" => BrowserScrollDirection.Down,
            "left" => BrowserScrollDirection.Left,
            "right" => BrowserScrollDirection.Right,
            _ => (BrowserScrollDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrowserScrollDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BrowserScrollDirection.Up => "up",
                BrowserScrollDirection.Down => "down",
                BrowserScrollDirection.Left => "left",
                BrowserScrollDirection.Right => "right",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
