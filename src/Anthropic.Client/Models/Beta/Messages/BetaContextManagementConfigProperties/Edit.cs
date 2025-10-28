using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaContextManagementConfigProperties;

[JsonConverter(typeof(EditConverter))]
public record class Edit
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaClearToolUses20250919: (x) => x.Type,
                betaClearThinking20251015: (x) => x.Type
            );
        }
    }

    public Edit(BetaClearToolUses20250919Edit value)
    {
        Value = value;
    }

    public Edit(BetaClearThinking20251015Edit value)
    {
        Value = value;
    }

    Edit(UnknownVariant value)
    {
        Value = value;
    }

    public static Edit CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaClearToolUses20250919(
        [NotNullWhen(true)] out BetaClearToolUses20250919Edit? value
    )
    {
        value = this.Value as BetaClearToolUses20250919Edit;
        return value != null;
    }

    public bool TryPickBetaClearThinking20251015(
        [NotNullWhen(true)] out BetaClearThinking20251015Edit? value
    )
    {
        value = this.Value as BetaClearThinking20251015Edit;
        return value != null;
    }

    public void Switch(
        Action<BetaClearToolUses20250919Edit> betaClearToolUses20250919,
        Action<BetaClearThinking20251015Edit> betaClearThinking20251015
    )
    {
        switch (this.Value)
        {
            case BetaClearToolUses20250919Edit value:
                betaClearToolUses20250919(value);
                break;
            case BetaClearThinking20251015Edit value:
                betaClearThinking20251015(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Edit");
        }
    }

    public T Match<T>(
        Func<BetaClearToolUses20250919Edit, T> betaClearToolUses20250919,
        Func<BetaClearThinking20251015Edit, T> betaClearThinking20251015
    )
    {
        return this.Value switch
        {
            BetaClearToolUses20250919Edit value => betaClearToolUses20250919(value),
            BetaClearThinking20251015Edit value => betaClearThinking20251015(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Edit"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Edit");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class EditConverter : JsonConverter<Edit>
{
    public override Edit? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "clear_tool_uses_20250919":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Edit(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaClearToolUses20250919Edit'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "clear_thinking_20251015":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015Edit>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Edit(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaClearThinking20251015Edit'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Edit value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
