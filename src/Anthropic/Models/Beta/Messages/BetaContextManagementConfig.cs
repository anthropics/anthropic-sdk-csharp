using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<BetaContextManagementConfig, BetaContextManagementConfigFromRaw>)
)]
public sealed record class BetaContextManagementConfig : ModelBase
{
    /// <summary>
    /// List of context management edits to apply
    /// </summary>
    public List<Edit>? Edits
    {
        get
        {
            if (!this._rawData.TryGetValue("edits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Edit>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["edits"] = JsonSerializer.SerializeToElement(
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

    public BetaContextManagementConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaContextManagementConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaContextManagementConfigFromRaw : IFromRaw<BetaContextManagementConfig>
{
    public BetaContextManagementConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContextManagementConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EditConverter))]
public record class Edit
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public Edit(BetaClearToolUses20250919Edit value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Edit(BetaClearThinking20251015Edit value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Edit(JsonElement json)
    {
        this._json = json;
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
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Edit");
        }
    }
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "clear_thinking_20251015":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015Edit>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new Edit(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Edit value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
