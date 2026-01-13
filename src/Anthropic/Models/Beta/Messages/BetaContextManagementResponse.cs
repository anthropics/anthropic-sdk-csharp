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
    typeof(JsonModelConverter<BetaContextManagementResponse, BetaContextManagementResponseFromRaw>)
)]
public sealed record class BetaContextManagementResponse : JsonModel
{
    /// <summary>
    /// List of context management edits that were applied.
    /// </summary>
    public required IReadOnlyList<AppliedEdit> AppliedEdits
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<AppliedEdit>>("applied_edits"); }
        init
        {
            this._rawData.Set<ImmutableArray<AppliedEdit>>(
                "applied_edits",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AppliedEdits)
        {
            item.Validate();
        }
    }

    public BetaContextManagementResponse() { }

    public BetaContextManagementResponse(
        BetaContextManagementResponse betaContextManagementResponse
    )
        : base(betaContextManagementResponse) { }

    public BetaContextManagementResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContextManagementResponseFromRaw.FromRawUnchecked"/>
    public static BetaContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaContextManagementResponse(List<AppliedEdit> appliedEdits)
        : this()
    {
        this.AppliedEdits = appliedEdits;
    }
}

class BetaContextManagementResponseFromRaw : IFromRawJson<BetaContextManagementResponse>
{
    /// <inheritdoc/>
    public BetaContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContextManagementResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AppliedEditConverter))]
public record class AppliedEdit : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public long ClearedInputTokens
    {
        get
        {
            return Match(
                betaClearToolUses20250919EditResponse: (x) => x.ClearedInputTokens,
                betaClearThinking20251015EditResponse: (x) => x.ClearedInputTokens
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaClearToolUses20250919EditResponse: (x) => x.Type,
                betaClearThinking20251015EditResponse: (x) => x.Type
            );
        }
    }

    public AppliedEdit(BetaClearToolUses20250919EditResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AppliedEdit(BetaClearThinking20251015EditResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AppliedEdit(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClearToolUses20250919EditResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaClearToolUses20250919EditResponse(out var value)) {
    ///     // `value` is of type `BetaClearToolUses20250919EditResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaClearToolUses20250919EditResponse(
        [NotNullWhen(true)] out BetaClearToolUses20250919EditResponse? value
    )
    {
        value = this.Value as BetaClearToolUses20250919EditResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClearThinking20251015EditResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaClearThinking20251015EditResponse(out var value)) {
    ///     // `value` is of type `BetaClearThinking20251015EditResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaClearThinking20251015EditResponse(
        [NotNullWhen(true)] out BetaClearThinking20251015EditResponse? value
    )
    {
        value = this.Value as BetaClearThinking20251015EditResponse;
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
    ///     (BetaClearToolUses20250919EditResponse value) => {...},
    ///     (BetaClearThinking20251015EditResponse value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaClearToolUses20250919EditResponse> betaClearToolUses20250919EditResponse,
        System::Action<BetaClearThinking20251015EditResponse> betaClearThinking20251015EditResponse
    )
    {
        switch (this.Value)
        {
            case BetaClearToolUses20250919EditResponse value:
                betaClearToolUses20250919EditResponse(value);
                break;
            case BetaClearThinking20251015EditResponse value:
                betaClearThinking20251015EditResponse(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of AppliedEdit"
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
    ///     (BetaClearToolUses20250919EditResponse value) => {...},
    ///     (BetaClearThinking20251015EditResponse value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaClearToolUses20250919EditResponse,
            T
        > betaClearToolUses20250919EditResponse,
        System::Func<BetaClearThinking20251015EditResponse, T> betaClearThinking20251015EditResponse
    )
    {
        return this.Value switch
        {
            BetaClearToolUses20250919EditResponse value => betaClearToolUses20250919EditResponse(
                value
            ),
            BetaClearThinking20251015EditResponse value => betaClearThinking20251015EditResponse(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of AppliedEdit"
            ),
        };
    }

    public static implicit operator AppliedEdit(BetaClearToolUses20250919EditResponse value) =>
        new(value);

    public static implicit operator AppliedEdit(BetaClearThinking20251015EditResponse value) =>
        new(value);

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
                "Data did not match any variant of AppliedEdit"
            );
        }
        this.Switch(
            (betaClearToolUses20250919EditResponse) =>
                betaClearToolUses20250919EditResponse.Validate(),
            (betaClearThinking20251015EditResponse) =>
                betaClearThinking20251015EditResponse.Validate()
        );
    }

    public virtual bool Equals(AppliedEdit? other)
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

sealed class AppliedEditConverter : JsonConverter<AppliedEdit>
{
    public override AppliedEdit? Read(
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
            case "clear_tool_uses_20250919":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClearToolUses20250919EditResponse>(
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
            case "clear_thinking_20251015":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClearThinking20251015EditResponse>(
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
                return new AppliedEdit(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliedEdit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
