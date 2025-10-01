using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Files.DeletedFileProperties;

/// <summary>
/// Deleted object type.
///
/// For file deletion, this is always `"file_deleted"`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FileDeleted,
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
            "file_deleted" => DeletedFileProperties.Type.FileDeleted,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeletedFileProperties.Type.FileDeleted => "file_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
