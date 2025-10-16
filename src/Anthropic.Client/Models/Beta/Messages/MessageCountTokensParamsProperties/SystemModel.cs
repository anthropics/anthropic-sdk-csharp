using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.MessageCountTokensParamsProperties;

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(SystemModelConverter))]
public record class SystemModel
{
    public object Value { get; private init; }

    public SystemModel(string value)
    {
        Value = value;
    }

    public SystemModel(List<BetaTextBlockParam> value)
    {
        Value = value;
    }

    SystemModel(UnknownVariant value)
    {
        Value = value;
    }

    public static SystemModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaTextBlockParams([NotNullWhen(true)] out List<BetaTextBlockParam>? value)
    {
        value = this.Value as List<BetaTextBlockParam>;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<List<BetaTextBlockParam>> betaTextBlockParams)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaTextBlockParam> value:
                betaTextBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of SystemModel"
                );
        }
    }

    public T Match<T>(
        Func<string, T> @string,
        Func<List<BetaTextBlockParam>, T> betaTextBlockParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            List<BetaTextBlockParam> value => betaTextBlockParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemModel"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                return new SystemModel(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SystemModel(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaTextBlockParam>'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
