using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaClearToolUses20250919Edit>))]
public sealed record class BetaClearToolUses20250919Edit
    : ModelBase,
        IFromRaw<BetaClearToolUses20250919Edit>
{
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("clear_at_least", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaInputTokensClearAtLeast?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["clear_at_least"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("clear_tool_inputs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ClearToolInputs?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["clear_tool_inputs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tool names whose uses are preserved from clearing
    /// </summary>
    public List<string>? ExcludeTools
    {
        get
        {
            if (!this._properties.TryGetValue("exclude_tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["exclude_tools"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("keep", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaToolUsesKeep?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["keep"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("trigger", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Trigger?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["trigger"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Type;
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

    public BetaClearToolUses20250919Edit(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearToolUses20250919Edit(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaClearToolUses20250919Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
/// </summary>
[JsonConverter(typeof(ClearToolInputsConverter))]
public record class ClearToolInputs
{
    public object Value { get; private init; }

    public ClearToolInputs(bool value)
    {
        Value = value;
    }

    public ClearToolInputs(IReadOnlyList<string> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    ClearToolInputs(UnknownVariant value)
    {
        Value = value;
    }

    public static ClearToolInputs CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ClearToolInputsConverter : JsonConverter<ClearToolInputs?>
{
    public override ClearToolInputs? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            return new ClearToolInputs(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new ClearToolInputs(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<string>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClearToolInputs? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Condition that triggers the context management strategy
/// </summary>
[JsonConverter(typeof(TriggerConverter))]
public record class Trigger
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(betaInputTokens: (x) => x.Type, betaToolUses: (x) => x.Type); }
    }

    public long Value1
    {
        get { return Match(betaInputTokens: (x) => x.Value, betaToolUses: (x) => x.Value); }
    }

    public Trigger(BetaInputTokensTrigger value)
    {
        Value = value;
    }

    public Trigger(BetaToolUsesTrigger value)
    {
        Value = value;
    }

    Trigger(UnknownVariant value)
    {
        Value = value;
    }

    public static Trigger CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Trigger");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInputTokensTrigger>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Trigger(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaInputTokensTrigger'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tool_uses":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUsesTrigger>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Trigger(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaToolUsesTrigger'",
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

    public override void Write(Utf8JsonWriter writer, Trigger value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
