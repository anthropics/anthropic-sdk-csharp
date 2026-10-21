using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// A Claude model line, such as `opus` or `sonnet`. More lines may be added as new values.
/// </summary>
[JsonConverter(typeof(BetaModelLineConverter))]
public enum BetaModelLine
{
    Haiku,
    Sonnet,
    Opus,
    Fable,
    Mythos,
}

sealed class BetaModelLineConverter : JsonConverter<BetaModelLine>
{
    public override BetaModelLine Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "haiku" => BetaModelLine.Haiku,
            "sonnet" => BetaModelLine.Sonnet,
            "opus" => BetaModelLine.Opus,
            "fable" => BetaModelLine.Fable,
            "mythos" => BetaModelLine.Mythos,
            _ => (BetaModelLine)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaModelLine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaModelLine.Haiku => "haiku",
                BetaModelLine.Sonnet => "sonnet",
                BetaModelLine.Opus => "opus",
                BetaModelLine.Fable => "fable",
                BetaModelLine.Mythos => "mythos",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
