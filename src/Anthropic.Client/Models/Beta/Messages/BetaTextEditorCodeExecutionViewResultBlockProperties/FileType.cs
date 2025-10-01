using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionViewResultBlockProperties;

[JsonConverter(typeof(FileTypeConverter))]
public enum FileType
{
    Text,
    Image,
    PDF,
}

sealed class FileTypeConverter : JsonConverter<FileType>
{
    public override FileType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FileType.Text,
            "image" => FileType.Image,
            "pdf" => FileType.PDF,
            _ => (FileType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileType.Text => "text",
                FileType.Image => "image",
                FileType.PDF => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
