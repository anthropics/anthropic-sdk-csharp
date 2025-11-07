using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaContextManagementConfig>))]
public sealed record class BetaContextManagementConfig
    : ModelBase,
        IFromRaw<BetaContextManagementConfig>
{
    /// <summary>
    /// List of context management edits to apply
    /// </summary>
    public List<Edit>? Edits
    {
        get
        {
            if (!this._properties.TryGetValue("edits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Edit>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["edits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Edits ?? [])
        {
            item.Validate();
        }
    }

    public BetaContextManagementConfig() { }

    public BetaContextManagementConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaContextManagementConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

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
        System::Action<BetaClearToolUses20250919Edit> betaClearToolUses20250919,
        System::Action<BetaClearThinking20251015Edit> betaClearThinking20251015
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
        System::Func<BetaClearToolUses20250919Edit, T> betaClearToolUses20250919,
        System::Func<BetaClearThinking20251015Edit, T> betaClearThinking20251015
    )
    {
        return this.Value switch
        {
            BetaClearToolUses20250919Edit value => betaClearToolUses20250919(value),
            BetaClearThinking20251015Edit value => betaClearThinking20251015(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Edit"),
        };
    }

    public static implicit operator Edit(BetaClearToolUses20250919Edit value) => new(value);

    public static implicit operator Edit(BetaClearThinking20251015Edit value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Edit");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class EditConverter : JsonConverter<Edit>
{
    public override Edit? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaClearToolUses20250919Edit'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaClearThinking20251015Edit'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
