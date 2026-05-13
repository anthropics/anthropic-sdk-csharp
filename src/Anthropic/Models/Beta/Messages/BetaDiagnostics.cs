using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Response envelope for request-level diagnostics. Present (possibly null) whenever
/// the caller supplied `diagnostics` on the request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDiagnostics, BetaDiagnosticsFromRaw>))]
public sealed record class BetaDiagnostics : JsonModel
{
    /// <summary>
    /// Explains why the prompt cache could not fully reuse the prefix from the request
    /// identified by `diagnostics.previous_message_id`. `null` means diagnosis is
    /// still pending — the response was serialized before the background comparison completed.
    /// </summary>
    public required CacheMissReason? CacheMissReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheMissReason>("cache_miss_reason");
        }
        init { this._rawData.Set("cache_miss_reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheMissReason?.Validate();
    }

    public BetaDiagnostics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDiagnostics(BetaDiagnostics betaDiagnostics)
        : base(betaDiagnostics) { }
#pragma warning restore CS8618

    public BetaDiagnostics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDiagnostics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDiagnosticsFromRaw.FromRawUnchecked"/>
    public static BetaDiagnostics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDiagnostics(CacheMissReason? cacheMissReason)
        : this()
    {
        this.CacheMissReason = cacheMissReason;
    }
}

class BetaDiagnosticsFromRaw : IFromRawJson<BetaDiagnostics>
{
    /// <inheritdoc/>
    public BetaDiagnostics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDiagnostics.FromRawUnchecked(rawData);
}

/// <summary>
/// Explains why the prompt cache could not fully reuse the prefix from the request
/// identified by `diagnostics.previous_message_id`. `null` means diagnosis is still
/// pending — the response was serialized before the background comparison completed.
/// </summary>
[JsonConverter(typeof(CacheMissReasonConverter))]
public record class CacheMissReason : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? CacheMissedInputTokens
    {
        get
        {
            return Match<long?>(
                betaCacheMissModelChanged: (x) => x.CacheMissedInputTokens,
                betaCacheMissSystemChanged: (x) => x.CacheMissedInputTokens,
                betaCacheMissToolsChanged: (x) => x.CacheMissedInputTokens,
                betaCacheMissMessagesChanged: (x) => x.CacheMissedInputTokens,
                betaCacheMissPreviousMessageNotFound: (_) => null,
                betaCacheMissUnavailable: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaCacheMissModelChanged: (x) => x.Type,
                betaCacheMissSystemChanged: (x) => x.Type,
                betaCacheMissToolsChanged: (x) => x.Type,
                betaCacheMissMessagesChanged: (x) => x.Type,
                betaCacheMissPreviousMessageNotFound: (x) => x.Type,
                betaCacheMissUnavailable: (x) => x.Type
            );
        }
    }

    public CacheMissReason(BetaCacheMissModelChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(BetaCacheMissSystemChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(BetaCacheMissToolsChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(BetaCacheMissMessagesChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(BetaCacheMissPreviousMessageNotFound value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(BetaCacheMissUnavailable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCacheMissModelChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCacheMissModelChanged(out var value)) {
    ///     // `value` is of type `BetaCacheMissModelChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCacheMissModelChanged(
        [NotNullWhen(true)] out BetaCacheMissModelChanged? value
    )
    {
        value = this.Value as BetaCacheMissModelChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCacheMissSystemChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCacheMissSystemChanged(out var value)) {
    ///     // `value` is of type `BetaCacheMissSystemChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCacheMissSystemChanged(
        [NotNullWhen(true)] out BetaCacheMissSystemChanged? value
    )
    {
        value = this.Value as BetaCacheMissSystemChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCacheMissToolsChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCacheMissToolsChanged(out var value)) {
    ///     // `value` is of type `BetaCacheMissToolsChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCacheMissToolsChanged(
        [NotNullWhen(true)] out BetaCacheMissToolsChanged? value
    )
    {
        value = this.Value as BetaCacheMissToolsChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCacheMissMessagesChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCacheMissMessagesChanged(out var value)) {
    ///     // `value` is of type `BetaCacheMissMessagesChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCacheMissMessagesChanged(
        [NotNullWhen(true)] out BetaCacheMissMessagesChanged? value
    )
    {
        value = this.Value as BetaCacheMissMessagesChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCacheMissPreviousMessageNotFound"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCacheMissPreviousMessageNotFound(out var value)) {
    ///     // `value` is of type `BetaCacheMissPreviousMessageNotFound`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCacheMissPreviousMessageNotFound(
        [NotNullWhen(true)] out BetaCacheMissPreviousMessageNotFound? value
    )
    {
        value = this.Value as BetaCacheMissPreviousMessageNotFound;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCacheMissUnavailable"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCacheMissUnavailable(out var value)) {
    ///     // `value` is of type `BetaCacheMissUnavailable`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCacheMissUnavailable(
        [NotNullWhen(true)] out BetaCacheMissUnavailable? value
    )
    {
        value = this.Value as BetaCacheMissUnavailable;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (BetaCacheMissModelChanged value) =&gt; {...},
    ///     (BetaCacheMissSystemChanged value) =&gt; {...},
    ///     (BetaCacheMissToolsChanged value) =&gt; {...},
    ///     (BetaCacheMissMessagesChanged value) =&gt; {...},
    ///     (BetaCacheMissPreviousMessageNotFound value) =&gt; {...},
    ///     (BetaCacheMissUnavailable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCacheMissModelChanged> betaCacheMissModelChanged,
        System::Action<BetaCacheMissSystemChanged> betaCacheMissSystemChanged,
        System::Action<BetaCacheMissToolsChanged> betaCacheMissToolsChanged,
        System::Action<BetaCacheMissMessagesChanged> betaCacheMissMessagesChanged,
        System::Action<BetaCacheMissPreviousMessageNotFound> betaCacheMissPreviousMessageNotFound,
        System::Action<BetaCacheMissUnavailable> betaCacheMissUnavailable
    )
    {
        switch (this.Value)
        {
            case BetaCacheMissModelChanged value:
                betaCacheMissModelChanged(value);
                break;
            case BetaCacheMissSystemChanged value:
                betaCacheMissSystemChanged(value);
                break;
            case BetaCacheMissToolsChanged value:
                betaCacheMissToolsChanged(value);
                break;
            case BetaCacheMissMessagesChanged value:
                betaCacheMissMessagesChanged(value);
                break;
            case BetaCacheMissPreviousMessageNotFound value:
                betaCacheMissPreviousMessageNotFound(value);
                break;
            case BetaCacheMissUnavailable value:
                betaCacheMissUnavailable(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CacheMissReason"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (BetaCacheMissModelChanged value) =&gt; {...},
    ///     (BetaCacheMissSystemChanged value) =&gt; {...},
    ///     (BetaCacheMissToolsChanged value) =&gt; {...},
    ///     (BetaCacheMissMessagesChanged value) =&gt; {...},
    ///     (BetaCacheMissPreviousMessageNotFound value) =&gt; {...},
    ///     (BetaCacheMissUnavailable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCacheMissModelChanged, T> betaCacheMissModelChanged,
        System::Func<BetaCacheMissSystemChanged, T> betaCacheMissSystemChanged,
        System::Func<BetaCacheMissToolsChanged, T> betaCacheMissToolsChanged,
        System::Func<BetaCacheMissMessagesChanged, T> betaCacheMissMessagesChanged,
        System::Func<BetaCacheMissPreviousMessageNotFound, T> betaCacheMissPreviousMessageNotFound,
        System::Func<BetaCacheMissUnavailable, T> betaCacheMissUnavailable
    )
    {
        return this.Value switch
        {
            BetaCacheMissModelChanged value => betaCacheMissModelChanged(value),
            BetaCacheMissSystemChanged value => betaCacheMissSystemChanged(value),
            BetaCacheMissToolsChanged value => betaCacheMissToolsChanged(value),
            BetaCacheMissMessagesChanged value => betaCacheMissMessagesChanged(value),
            BetaCacheMissPreviousMessageNotFound value => betaCacheMissPreviousMessageNotFound(
                value
            ),
            BetaCacheMissUnavailable value => betaCacheMissUnavailable(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CacheMissReason"
            ),
        };
    }

    public static implicit operator CacheMissReason(BetaCacheMissModelChanged value) => new(value);

    public static implicit operator CacheMissReason(BetaCacheMissSystemChanged value) => new(value);

    public static implicit operator CacheMissReason(BetaCacheMissToolsChanged value) => new(value);

    public static implicit operator CacheMissReason(BetaCacheMissMessagesChanged value) =>
        new(value);

    public static implicit operator CacheMissReason(BetaCacheMissPreviousMessageNotFound value) =>
        new(value);

    public static implicit operator CacheMissReason(BetaCacheMissUnavailable value) => new(value);

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
                "Data did not match any variant of CacheMissReason"
            );
        }
        this.Switch(
            (betaCacheMissModelChanged) => betaCacheMissModelChanged.Validate(),
            (betaCacheMissSystemChanged) => betaCacheMissSystemChanged.Validate(),
            (betaCacheMissToolsChanged) => betaCacheMissToolsChanged.Validate(),
            (betaCacheMissMessagesChanged) => betaCacheMissMessagesChanged.Validate(),
            (betaCacheMissPreviousMessageNotFound) =>
                betaCacheMissPreviousMessageNotFound.Validate(),
            (betaCacheMissUnavailable) => betaCacheMissUnavailable.Validate()
        );
    }

    public virtual bool Equals(CacheMissReason? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaCacheMissModelChanged _ => 0,
            BetaCacheMissSystemChanged _ => 1,
            BetaCacheMissToolsChanged _ => 2,
            BetaCacheMissMessagesChanged _ => 3,
            BetaCacheMissPreviousMessageNotFound _ => 4,
            BetaCacheMissUnavailable _ => 5,
            _ => -1,
        };
    }
}

sealed class CacheMissReasonConverter : JsonConverter<CacheMissReason?>
{
    public override CacheMissReason? Read(
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
            case "model_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCacheMissModelChanged>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "system_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCacheMissSystemChanged>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tools_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCacheMissToolsChanged>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "messages_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCacheMissMessagesChanged>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "previous_message_not_found":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCacheMissPreviousMessageNotFound>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unavailable":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCacheMissUnavailable>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new CacheMissReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CacheMissReason? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
