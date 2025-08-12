using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Messages;
using SystemVariants = Anthropic.Models.Messages.MessageCreateParamsProperties.SystemVariants;

namespace Anthropic.Models.Messages.MessageCreateParamsProperties;

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.anthropic.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(SystemConverter))]
public abstract record class System
{
    internal System() { }

    public static implicit operator System(string value) => new SystemVariants::String(value);

    public static implicit operator System(List<Messages::TextBlockParam> value) =>
        new SystemVariants::TextBlockParams(value);

    public abstract void Validate();
}

sealed class SystemConverter : JsonConverter<System>
{
    public override System? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new SystemVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Messages::TextBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SystemVariants::TextBlockParams(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, System value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            SystemVariants::String(var string1) => string1,
            SystemVariants::TextBlockParams(var textBlockParams) => textBlockParams,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
