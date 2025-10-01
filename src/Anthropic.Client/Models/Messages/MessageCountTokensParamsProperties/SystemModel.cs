using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using SystemVariants = Anthropic.Client.Models.Messages.MessageCountTokensParamsProperties.SystemVariants;

namespace Anthropic.Client.Models.Messages.MessageCountTokensParamsProperties;

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.anthropic.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(SystemModelConverter))]
public abstract record class SystemModel
{
    internal SystemModel() { }

    public static implicit operator SystemModel(string value) => new SystemVariants::String(value);

    public static implicit operator SystemModel(List<TextBlockParam> value) =>
        new SystemVariants::TextBlockParams(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as SystemVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickTextBlockParams([NotNullWhen(true)] out List<TextBlockParam>? value)
    {
        value = (this as SystemVariants::TextBlockParams)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SystemVariants::String> @string,
        Action<SystemVariants::TextBlockParams> textBlockParams
    )
    {
        switch (this)
        {
            case SystemVariants::String inner:
                @string(inner);
                break;
            case SystemVariants::TextBlockParams inner:
                textBlockParams(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of SystemModel"
                );
        }
    }

    public T Match<T>(
        Func<SystemVariants::String, T> @string,
        Func<SystemVariants::TextBlockParams, T> textBlockParams
    )
    {
        return this switch
        {
            SystemVariants::String inner => @string(inner),
            SystemVariants::TextBlockParams inner => textBlockParams(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemModel"
            ),
        };
    }

    public abstract void Validate();
}

sealed class SystemModelConverter : JsonConverter<SystemModel>
{
    public override SystemModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

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
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant SystemVariants::String",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<TextBlockParam>>(
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
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant SystemVariants::TextBlockParams",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SystemModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            SystemVariants::String(var @string) => @string,
            SystemVariants::TextBlockParams(var textBlockParams) => textBlockParams,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemModel"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
