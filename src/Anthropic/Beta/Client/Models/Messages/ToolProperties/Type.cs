using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Beta.Client.Models.Messages.ToolProperties;

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Custom,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => ToolProperties.Type.Custom,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolProperties.Type.Custom => "custom",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
