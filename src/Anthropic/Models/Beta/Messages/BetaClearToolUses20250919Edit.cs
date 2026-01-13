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
    typeof(JsonModelConverter<BetaClearToolUses20250919Edit, BetaClearToolUses20250919EditFromRaw>)
)]
public sealed record class BetaClearToolUses20250919Edit : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Minimum number of tokens that must be cleared when triggered. Context will
    /// only be modified if at least this many tokens can be removed.
    /// </summary>
    public BetaInputTokensClearAtLeast? ClearAtLeast
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaInputTokensClearAtLeast>("clear_at_least");
        }
        init { this._rawData.Set("clear_at_least", value); }
    }

    /// <summary>
    /// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
    /// </summary>
    public ClearToolInputs? ClearToolInputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClearToolInputs>("clear_tool_inputs");
        }
        init { this._rawData.Set("clear_tool_inputs", value); }
    }

    /// <summary>
    /// Tool names whose uses are preserved from clearing
    /// </summary>
    public IReadOnlyList<string>? ExcludeTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("exclude_tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "exclude_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaToolUsesKeep>("keep");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("keep", value);
        }
    }

    /// <summary>
    /// Condition that triggers the context management strategy
    /// </summary>
    public Trigger? Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Trigger>("trigger");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trigger", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("clear_tool_uses_20250919")
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
        this.Type = JsonSerializer.SerializeToElement("clear_tool_uses_20250919");
    }

    public BetaClearToolUses20250919Edit(
        BetaClearToolUses20250919Edit betaClearToolUses20250919Edit
    )
        : base(betaClearToolUses20250919Edit) { }

    public BetaClearToolUses20250919Edit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("clear_tool_uses_20250919");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearToolUses20250919Edit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClearToolUses20250919EditFromRaw.FromRawUnchecked"/>
    public static BetaClearToolUses20250919Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClearToolUses20250919EditFromRaw : IFromRawJson<BetaClearToolUses20250919Edit>
{
    /// <inheritdoc/>
    public BetaClearToolUses20250919Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClearToolUses20250919Edit.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
/// </summary>
[JsonConverter(typeof(ClearToolInputsConverter))]
public record class ClearToolInputs : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ClearToolInputs(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClearToolInputs(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ClearToolInputs(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<string>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<string>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (bool value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<bool> @bool, System::Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ClearToolInputs"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (bool value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
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

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ClearToolInputsConverter : JsonConverter<ClearToolInputs?>
{
    public override ClearToolInputs? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
public record class Trigger : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(betaInputTokens: (x) => x.Type, betaToolUses: (x) => x.Type); }
    }

    public long Value1
    {
        get { return Match(betaInputTokens: (x) => x.Value, betaToolUses: (x) => x.Value); }
    }

    public Trigger(BetaInputTokensTrigger value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Trigger(BetaToolUsesTrigger value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Trigger(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaInputTokensTrigger"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaInputTokens(out var value)) {
    ///     // `value` is of type `BetaInputTokensTrigger`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaInputTokens([NotNullWhen(true)] out BetaInputTokensTrigger? value)
    {
        value = this.Value as BetaInputTokensTrigger;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolUsesTrigger"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolUses(out var value)) {
    ///     // `value` is of type `BetaToolUsesTrigger`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolUses([NotNullWhen(true)] out BetaToolUsesTrigger? value)
    {
        value = this.Value as BetaToolUsesTrigger;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaInputTokensTrigger value) => {...},
    ///     (BetaToolUsesTrigger value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaInputTokensTrigger value) => {...},
    ///     (BetaToolUsesTrigger value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Trigger");
        }
        this.Switch(
            (betaInputTokens) => betaInputTokens.Validate(),
            (betaToolUses) => betaToolUses.Validate()
        );
    }

    public virtual bool Equals(Trigger? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class TriggerConverter : JsonConverter<Trigger>
{
    public override Trigger? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
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
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_uses":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUsesTrigger>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Trigger(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Trigger value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
