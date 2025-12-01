using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<BetaClearToolUses20250919Edit, BetaClearToolUses20250919EditFromRaw>)
)]
public sealed record class BetaClearToolUses20250919Edit : ModelBase
{
    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum number of tokens that must be cleared when triggered. Context will
    /// only be modified if at least this many tokens can be removed.
    /// </summary>
    public BetaInputTokensClearAtLeast? ClearAtLeast
    {
        get
        {
            if (!this._rawData.TryGetValue("clear_at_least", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaInputTokensClearAtLeast?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["clear_at_least"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
    /// </summary>
    public ClearToolInputs? ClearToolInputs
    {
        get
        {
            if (!this._rawData.TryGetValue("clear_tool_inputs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ClearToolInputs?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["clear_tool_inputs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tool names whose uses are preserved from clearing
    /// </summary>
    public IReadOnlyList<string>? ExcludeTools
    {
        get
        {
            if (!this._rawData.TryGetValue("exclude_tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exclude_tools"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of tool uses to retain in the conversation
    /// </summary>
    public BetaToolUsesKeep? Keep
    {
        get
        {
            if (!this._rawData.TryGetValue("keep", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaToolUsesKeep?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["keep"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Condition that triggers the context management strategy
    /// </summary>
    public Trigger? Trigger
    {
        get
        {
            if (!this._rawData.TryGetValue("trigger", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Trigger?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["trigger"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.ClearAtLeast?.Validate();
        this.ClearToolInputs?.Validate();
        _ = this.ExcludeTools;
        this.Keep?.Validate();
        this.Trigger?.Validate();
    }

    public BetaClearToolUses20250919Edit()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

    public BetaClearToolUses20250919Edit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearToolUses20250919Edit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaClearToolUses20250919Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClearToolUses20250919EditFromRaw : IFromRaw<BetaClearToolUses20250919Edit>
{
    public BetaClearToolUses20250919Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClearToolUses20250919Edit.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
/// </summary>
[JsonConverter(typeof(ClearToolInputsConverter))]
public record class ClearToolInputs
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClearToolInputs(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ClearToolInputs(IReadOnlyList<string> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public ClearToolInputs(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    public void Switch(System::Action<bool> @bool, System::Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case bool value:
                @bool(value);
                break;
            case List<string> value:
                strings(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ClearToolInputs"
                );
        }
    }

    public T Match<T>(System::Func<bool, T> @bool, System::Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            bool value => @bool(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            ),
        };
    }

    public static implicit operator ClearToolInputs(bool value) => new(value);

    public static implicit operator ClearToolInputs(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            );
        }
    }

    public virtual bool Equals(ClearToolInputs? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ClearToolInputsConverter : JsonConverter<ClearToolInputs?>
{
    public override ClearToolInputs? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClearToolInputs? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Condition that triggers the context management strategy
/// </summary>
[JsonConverter(typeof(TriggerConverter))]
public record class Trigger
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(betaInputTokens: (x) => x.Type, betaToolUses: (x) => x.Type); }
    }

    public long Value1
    {
        get { return Match(betaInputTokens: (x) => x.Value, betaToolUses: (x) => x.Value); }
    }

    public Trigger(BetaInputTokensTrigger value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Trigger(BetaToolUsesTrigger value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Trigger(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaInputTokens([NotNullWhen(true)] out BetaInputTokensTrigger? value)
    {
        value = this.Value as BetaInputTokensTrigger;
        return value != null;
    }

    public bool TryPickBetaToolUses([NotNullWhen(true)] out BetaToolUsesTrigger? value)
    {
        value = this.Value as BetaToolUsesTrigger;
        return value != null;
    }

    public void Switch(
        System::Action<BetaInputTokensTrigger> betaInputTokens,
        System::Action<BetaToolUsesTrigger> betaToolUses
    )
    {
        switch (this.Value)
        {
            case BetaInputTokensTrigger value:
                betaInputTokens(value);
                break;
            case BetaToolUsesTrigger value:
                betaToolUses(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Trigger"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaInputTokensTrigger, T> betaInputTokens,
        System::Func<BetaToolUsesTrigger, T> betaToolUses
    )
    {
        return this.Value switch
        {
            BetaInputTokensTrigger value => betaInputTokens(value),
            BetaToolUsesTrigger value => betaToolUses(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Trigger"
            ),
        };
    }

    public static implicit operator Trigger(BetaInputTokensTrigger value) => new(value);

    public static implicit operator Trigger(BetaToolUsesTrigger value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Trigger");
        }
    }

    public virtual bool Equals(Trigger? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class TriggerConverter : JsonConverter<Trigger>
{
    public override Trigger? Read(
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
            case "input_tokens":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInputTokensTrigger>(
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
            case "tool_uses":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUsesTrigger>(
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
                return new Trigger(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Trigger value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
