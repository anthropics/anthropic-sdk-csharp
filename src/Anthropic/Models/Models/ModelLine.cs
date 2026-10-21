using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Models;

/// <summary>
/// A Claude model line, such as `opus` or `sonnet`. More lines may be added as new values.
/// </summary>
[JsonConverter(typeof(ModelLineConverter))]
public enum ModelLine
{
    Haiku,
    Sonnet,
    Opus,
    Fable,
    Mythos,
}

sealed class ModelLineConverter : JsonConverter<ModelLine>
{
    public override ModelLine Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "haiku" => ModelLine.Haiku,
            "sonnet" => ModelLine.Sonnet,
            "opus" => ModelLine.Opus,
            "fable" => ModelLine.Fable,
            "mythos" => ModelLine.Mythos,
            _ => (ModelLine)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelLine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelLine.Haiku => "haiku",
                ModelLine.Sonnet => "sonnet",
                ModelLine.Opus => "opus",
                ModelLine.Fable => "fable",
                ModelLine.Mythos => "mythos",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
