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
    public IReadOnlyList<Edit>? Edits
    {
        get { return ModelBase.GetNullableClass<List<Edit>>(this.RawData, "edits"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "edits", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Edits ?? [])
        {
            item.Validate();
        }
    }

    public BetaContextManagementConfig() { }

    public BetaContextManagementConfig(BetaContextManagementConfig betaContextManagementConfig)
        : base(betaContextManagementConfig) { }

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

    /// <inheritdoc cref="BetaContextManagementConfigFromRaw.FromRawUnchecked"/>
    public static BetaContextManagementConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaContextManagementConfigFromRaw : IFromRaw<BetaContextManagementConfig>
{
    /// <inheritdoc/>
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

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClearToolUses20250919Edit"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaClearToolUses20250919(out var value)) {
    ///     // `value` is of type `BetaClearToolUses20250919Edit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaClearToolUses20250919(
        [NotNullWhen(true)] out BetaClearToolUses20250919Edit? value
    )
    {
        value = this.Value as BetaClearToolUses20250919Edit;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClearThinking20251015Edit"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaClearThinking20251015(out var value)) {
    ///     // `value` is of type `BetaClearThinking20251015Edit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaClearThinking20251015(
        [NotNullWhen(true)] out BetaClearThinking20251015Edit? value
    )
    {
        value = this.Value as BetaClearThinking20251015Edit;
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
    ///     (BetaClearToolUses20250919Edit value) => {...},
    ///     (BetaClearThinking20251015Edit value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (BetaClearToolUses20250919Edit value) => {...},
    ///     (BetaClearThinking20251015Edit value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Edit");
        }
        this.Switch(
            (betaClearToolUses20250919) => betaClearToolUses20250919.Validate(),
            (betaClearThinking20251015) => betaClearThinking20251015.Validate()
        );
    }

    public virtual bool Equals(Edit? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
