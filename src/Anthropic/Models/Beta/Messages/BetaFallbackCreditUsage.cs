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
/// Outcome of the ``fallback_credit_token`` presented on this request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFallbackCreditUsage, BetaFallbackCreditUsageFromRaw>))]
public sealed record class BetaFallbackCreditUsage : JsonModel
{
    /// <summary>
    /// Whether the fallback-credit reprice was applied to this response's billing.
    ///
    /// <para>A union discriminated on `type`. `redeemed`: the retry is billed as
    /// if the conversation had been on the retry model all along — including when
    /// the resulting shift is zero because there was nothing to move. `not_applied`:
    /// no reprice was applied; the arm's `reason` says why.</para>
    /// </summary>
    public required Status Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Status>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public BetaFallbackCreditUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackCreditUsage(BetaFallbackCreditUsage betaFallbackCreditUsage)
        : base(betaFallbackCreditUsage) { }
#pragma warning restore CS8618

    public BetaFallbackCreditUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackCreditUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackCreditUsageFromRaw.FromRawUnchecked"/>
    public static BetaFallbackCreditUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFallbackCreditUsage(Status status)
        : this()
    {
        this.Status = status;
    }
}

class BetaFallbackCreditUsageFromRaw : IFromRawJson<BetaFallbackCreditUsage>
{
    /// <inheritdoc/>
    public BetaFallbackCreditUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackCreditUsage.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the fallback-credit reprice was applied to this response's billing.
///
/// <para>A union discriminated on `type`. `redeemed`: the retry is billed as if
/// the conversation had been on the retry model all along — including when the resulting
/// shift is zero because there was nothing to move. `not_applied`: no reprice was
/// applied; the arm's `reason` says why.</para>
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public record class Status : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                betaFallbackCreditRedeemed: (x) => x.Type,
                betaFallbackCreditNotApplied: (x) => x.Type
            );
        }
    }

    public Status(BetaFallbackCreditRedeemed value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Status(BetaFallbackCreditNotApplied value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Status(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaFallbackCreditRedeemed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaFallbackCreditRedeemed(out var value)) {
    ///     // `value` is of type `BetaFallbackCreditRedeemed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaFallbackCreditRedeemed(
        [NotNullWhen(true)] out BetaFallbackCreditRedeemed? value
    )
    {
        value = this.Value as BetaFallbackCreditRedeemed;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaFallbackCreditNotApplied"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaFallbackCreditNotApplied(out var value)) {
    ///     // `value` is of type `BetaFallbackCreditNotApplied`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaFallbackCreditNotApplied(
        [NotNullWhen(true)] out BetaFallbackCreditNotApplied? value
    )
    {
        value = this.Value as BetaFallbackCreditNotApplied;
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
    ///     (BetaFallbackCreditRedeemed value) =&gt; {...},
    ///     (BetaFallbackCreditNotApplied value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaFallbackCreditRedeemed> betaFallbackCreditRedeemed,
        System::Action<BetaFallbackCreditNotApplied> betaFallbackCreditNotApplied
    )
    {
        switch (this.Value)
        {
            case BetaFallbackCreditRedeemed value:
                betaFallbackCreditRedeemed(value);
                break;
            case BetaFallbackCreditNotApplied value:
                betaFallbackCreditNotApplied(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Status");
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
    ///     (BetaFallbackCreditRedeemed value) =&gt; {...},
    ///     (BetaFallbackCreditNotApplied value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaFallbackCreditRedeemed, T> betaFallbackCreditRedeemed,
        System::Func<BetaFallbackCreditNotApplied, T> betaFallbackCreditNotApplied
    )
    {
        return this.Value switch
        {
            BetaFallbackCreditRedeemed value => betaFallbackCreditRedeemed(value),
            BetaFallbackCreditNotApplied value => betaFallbackCreditNotApplied(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Status"
            ),
        };
    }

    public static implicit operator Status(BetaFallbackCreditRedeemed value) => new(value);

    public static implicit operator Status(BetaFallbackCreditNotApplied value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Status");
        }
        this.Switch(
            (betaFallbackCreditRedeemed) => betaFallbackCreditRedeemed.Validate(),
            (betaFallbackCreditNotApplied) => betaFallbackCreditNotApplied.Validate()
        );
    }

    public virtual bool Equals(Status? other) =>
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
            BetaFallbackCreditRedeemed _ => 0,
            BetaFallbackCreditNotApplied _ => 1,
            _ => -1,
        };
    }
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status? Read(
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
            case "redeemed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditRedeemed>(
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
            case "not_applied":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditNotApplied>(
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
                return new Status(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
