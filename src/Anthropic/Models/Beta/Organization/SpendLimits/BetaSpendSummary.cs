using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// Per-member effective-limit report row (`GET /spend_limits/effective`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSpendSummary, BetaSpendSummaryFromRaw>))]
public sealed record class BetaSpendSummary : JsonModel
{
    public required Actor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Actor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    /// <summary>
    /// Effective limit amount as a non-negative integer decimal string in the minor
    /// unit of `currency` (cents for USD). `null` means no limit applies for this
    /// row's `period` — each period resolves independently, so another period may
    /// still cap this member.
    /// </summary>
    public required string? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 code of the organization's billing currency; the unit for `amount`
    /// and `period_to_date_spend`.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Period this row's effective limit and spend are reported for.
    /// </summary>
    public required ApiEnum<string, BetaSpendLimitPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaSpendLimitPeriod>>("period");
        }
        init { this._rawData.Set("period", value); }
    }

    /// <summary>
    /// The member's spend so far in the current period, as a non-negative decimal
    /// string in the minor unit of `currency` (cents for USD). May carry fractional
    /// minor units up to three decimal places (e.g. `"12050.5"`) — metered usage
    /// is not rounded to whole cents. Reads as `"0"` when the spend reading is temporarily unavailable.
    /// </summary>
    public required string PeriodToDateSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("period_to_date_spend");
        }
        init { this._rawData.Set("period_to_date_spend", value); }
    }

    public required BetaSpendSummaryScope Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaSpendSummaryScope>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    public required Source Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Source>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required string SpendLimitID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("spend_limit_id");
        }
        init { this._rawData.Set("spend_limit_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Actor.Validate();
        _ = this.Amount;
        _ = this.Currency;
        this.Period.Validate();
        _ = this.PeriodToDateSpend;
        this.Scope.Validate();
        this.Source.Validate();
        _ = this.SpendLimitID;
    }

    public BetaSpendSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendSummary(BetaSpendSummary betaSpendSummary)
        : base(betaSpendSummary) { }
#pragma warning restore CS8618

    public BetaSpendSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendSummaryFromRaw.FromRawUnchecked"/>
    public static BetaSpendSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendSummaryFromRaw : IFromRawJson<BetaSpendSummary>
{
    /// <inheritdoc/>
    public BetaSpendSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSpendSummary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActorConverter))]
public record class Actor : ModelBase
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
            return this.Value switch
            {
                BetaSpendLimitUserActor x => x.Type,
                BetaSpendLimitScopedApiKeyActor x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Actor(BetaSpendLimitUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Actor(BetaSpendLimitScopedApiKeyActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Actor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitUser(out var value)) {
    ///     // `value` is of type `BetaSpendLimitUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitUser([NotNullWhen(true)] out BetaSpendLimitUserActor? value)
    {
        value = this.Value as BetaSpendLimitUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitScopedApiKeyActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitScopedApiKey(out var value)) {
    ///     // `value` is of type `BetaSpendLimitScopedApiKeyActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitScopedApiKey(
        [NotNullWhen(true)] out BetaSpendLimitScopedApiKeyActor? value
    )
    {
        value = this.Value as BetaSpendLimitScopedApiKeyActor;
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserActor> betaSpendLimitUser,
        Action<BetaSpendLimitScopedApiKeyActor> betaSpendLimitScopedApiKey
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserActor value:
                betaSpendLimitUser(value);
                break;
            case BetaSpendLimitScopedApiKeyActor value:
                betaSpendLimitScopedApiKey(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Actor");
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserActor, T> betaSpendLimitUser,
        Func<BetaSpendLimitScopedApiKeyActor, T> betaSpendLimitScopedApiKey
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserActor value => betaSpendLimitUser(value),
            BetaSpendLimitScopedApiKeyActor value => betaSpendLimitScopedApiKey(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Actor"),
        };
    }

    public static implicit operator Actor(BetaSpendLimitUserActor value) => new(value);

    public static implicit operator Actor(BetaSpendLimitScopedApiKeyActor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Actor");
        }
        this.Switch(
            (betaSpendLimitUser) => betaSpendLimitUser.Validate(),
            (betaSpendLimitScopedApiKey) => betaSpendLimitScopedApiKey.Validate()
        );
    }

    public virtual bool Equals(Actor? other) =>
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
            BetaSpendLimitUserActor _ => 0,
            BetaSpendLimitScopedApiKeyActor _ => 1,
            _ => -1,
        };
    }
}

sealed class ActorConverter : JsonConverter<Actor>
{
    public override Actor? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserActor>(
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
            case "scoped_api_key_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScopedApiKeyActor>(
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
                return new Actor(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Actor value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaSpendSummaryScopeConverter))]
public record class BetaSpendSummaryScope : ModelBase
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
            return this.Value switch
            {
                BetaSpendLimitUserScope x => x.Type,
                BetaSpendLimitSeatTierScope x => x.Type,
                BetaSpendLimitRbacGroupScope x => x.Type,
                BetaSpendLimitOrganizationServiceScope x => x.Type,
                BetaSpendLimitOrganizationScope x => x.Type,
                BetaSpendLimitWorkspaceScope x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaSpendSummaryScope(BetaSpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendSummaryScope(BetaSpendLimitSeatTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendSummaryScope(BetaSpendLimitRbacGroupScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendSummaryScope(
        BetaSpendLimitOrganizationServiceScope value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendSummaryScope(BetaSpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendSummaryScope(BetaSpendLimitWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendSummaryScope(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitUserScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitUser(out var value)) {
    ///     // `value` is of type `BetaSpendLimitUserScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitUser([NotNullWhen(true)] out BetaSpendLimitUserScope? value)
    {
        value = this.Value as BetaSpendLimitUserScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitSeatTierScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitSeatTier(out var value)) {
    ///     // `value` is of type `BetaSpendLimitSeatTierScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitSeatTier(
        [NotNullWhen(true)] out BetaSpendLimitSeatTierScope? value
    )
    {
        value = this.Value as BetaSpendLimitSeatTierScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitRbacGroupScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitRbacGroup(out var value)) {
    ///     // `value` is of type `BetaSpendLimitRbacGroupScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitRbacGroup(
        [NotNullWhen(true)] out BetaSpendLimitRbacGroupScope? value
    )
    {
        value = this.Value as BetaSpendLimitRbacGroupScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitOrganizationServiceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitOrganizationService(out var value)) {
    ///     // `value` is of type `BetaSpendLimitOrganizationServiceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitOrganizationService(
        [NotNullWhen(true)] out BetaSpendLimitOrganizationServiceScope? value
    )
    {
        value = this.Value as BetaSpendLimitOrganizationServiceScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitOrganizationScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitOrganization(out var value)) {
    ///     // `value` is of type `BetaSpendLimitOrganizationScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitOrganization(
        [NotNullWhen(true)] out BetaSpendLimitOrganizationScope? value
    )
    {
        value = this.Value as BetaSpendLimitOrganizationScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitWorkspaceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitWorkspace(out var value)) {
    ///     // `value` is of type `BetaSpendLimitWorkspaceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitWorkspace(
        [NotNullWhen(true)] out BetaSpendLimitWorkspaceScope? value
    )
    {
        value = this.Value as BetaSpendLimitWorkspaceScope;
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
    ///     (BetaSpendLimitUserScope value) =&gt; {...},
    ///     (BetaSpendLimitSeatTierScope value) =&gt; {...},
    ///     (BetaSpendLimitRbacGroupScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationScope value) =&gt; {...},
    ///     (BetaSpendLimitWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserScope> betaSpendLimitUser,
        Action<BetaSpendLimitSeatTierScope> betaSpendLimitSeatTier,
        Action<BetaSpendLimitRbacGroupScope> betaSpendLimitRbacGroup,
        Action<BetaSpendLimitOrganizationServiceScope> betaSpendLimitOrganizationService,
        Action<BetaSpendLimitOrganizationScope> betaSpendLimitOrganization,
        Action<BetaSpendLimitWorkspaceScope> betaSpendLimitWorkspace
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserScope value:
                betaSpendLimitUser(value);
                break;
            case BetaSpendLimitSeatTierScope value:
                betaSpendLimitSeatTier(value);
                break;
            case BetaSpendLimitRbacGroupScope value:
                betaSpendLimitRbacGroup(value);
                break;
            case BetaSpendLimitOrganizationServiceScope value:
                betaSpendLimitOrganizationService(value);
                break;
            case BetaSpendLimitOrganizationScope value:
                betaSpendLimitOrganization(value);
                break;
            case BetaSpendLimitWorkspaceScope value:
                betaSpendLimitWorkspace(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaSpendSummaryScope"
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
    ///     (BetaSpendLimitUserScope value) =&gt; {...},
    ///     (BetaSpendLimitSeatTierScope value) =&gt; {...},
    ///     (BetaSpendLimitRbacGroupScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationScope value) =&gt; {...},
    ///     (BetaSpendLimitWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserScope, T> betaSpendLimitUser,
        Func<BetaSpendLimitSeatTierScope, T> betaSpendLimitSeatTier,
        Func<BetaSpendLimitRbacGroupScope, T> betaSpendLimitRbacGroup,
        Func<BetaSpendLimitOrganizationServiceScope, T> betaSpendLimitOrganizationService,
        Func<BetaSpendLimitOrganizationScope, T> betaSpendLimitOrganization,
        Func<BetaSpendLimitWorkspaceScope, T> betaSpendLimitWorkspace
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserScope value => betaSpendLimitUser(value),
            BetaSpendLimitSeatTierScope value => betaSpendLimitSeatTier(value),
            BetaSpendLimitRbacGroupScope value => betaSpendLimitRbacGroup(value),
            BetaSpendLimitOrganizationServiceScope value => betaSpendLimitOrganizationService(
                value
            ),
            BetaSpendLimitOrganizationScope value => betaSpendLimitOrganization(value),
            BetaSpendLimitWorkspaceScope value => betaSpendLimitWorkspace(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaSpendSummaryScope"
            ),
        };
    }

    public static implicit operator BetaSpendSummaryScope(BetaSpendLimitUserScope value) =>
        new(value);

    public static implicit operator BetaSpendSummaryScope(BetaSpendLimitSeatTierScope value) =>
        new(value);

    public static implicit operator BetaSpendSummaryScope(BetaSpendLimitRbacGroupScope value) =>
        new(value);

    public static implicit operator BetaSpendSummaryScope(
        BetaSpendLimitOrganizationServiceScope value
    ) => new(value);

    public static implicit operator BetaSpendSummaryScope(BetaSpendLimitOrganizationScope value) =>
        new(value);

    public static implicit operator BetaSpendSummaryScope(BetaSpendLimitWorkspaceScope value) =>
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
                "Data did not match any variant of BetaSpendSummaryScope"
            );
        }
        this.Switch(
            (betaSpendLimitUser) => betaSpendLimitUser.Validate(),
            (betaSpendLimitSeatTier) => betaSpendLimitSeatTier.Validate(),
            (betaSpendLimitRbacGroup) => betaSpendLimitRbacGroup.Validate(),
            (betaSpendLimitOrganizationService) => betaSpendLimitOrganizationService.Validate(),
            (betaSpendLimitOrganization) => betaSpendLimitOrganization.Validate(),
            (betaSpendLimitWorkspace) => betaSpendLimitWorkspace.Validate()
        );
    }

    public virtual bool Equals(BetaSpendSummaryScope? other) =>
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
            BetaSpendLimitUserScope _ => 0,
            BetaSpendLimitSeatTierScope _ => 1,
            BetaSpendLimitRbacGroupScope _ => 2,
            BetaSpendLimitOrganizationServiceScope _ => 3,
            BetaSpendLimitOrganizationScope _ => 4,
            BetaSpendLimitWorkspaceScope _ => 5,
            _ => -1,
        };
    }
}

sealed class BetaSpendSummaryScopeConverter : JsonConverter<BetaSpendSummaryScope>
{
    public override BetaSpendSummaryScope? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "user":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserScope>(
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
            case "seat_tier":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitSeatTierScope>(
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
            case "rbac_group":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitRbacGroupScope>(
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
            case "organization_service":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaSpendLimitOrganizationServiceScope>(
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
            case "organization":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitOrganizationScope>(
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
            case "workspace":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitWorkspaceScope>(
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
                return new BetaSpendSummaryScope(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSpendSummaryScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SourceConverter))]
public record class Source : ModelBase
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
            return this.Value switch
            {
                BetaSpendLimitUserScope x => x.Type,
                BetaSpendLimitSeatTierScope x => x.Type,
                BetaSpendLimitRbacGroupScope x => x.Type,
                BetaSpendLimitOrganizationServiceScope x => x.Type,
                BetaSpendLimitOrganizationScope x => x.Type,
                BetaSpendLimitWorkspaceScope x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Source(BetaSpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaSpendLimitSeatTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaSpendLimitRbacGroupScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaSpendLimitOrganizationServiceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaSpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaSpendLimitWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitUserScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitUserScope(out var value)) {
    ///     // `value` is of type `BetaSpendLimitUserScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitUserScope(
        [NotNullWhen(true)] out BetaSpendLimitUserScope? value
    )
    {
        value = this.Value as BetaSpendLimitUserScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitSeatTierScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitSeatTierScope(out var value)) {
    ///     // `value` is of type `BetaSpendLimitSeatTierScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitSeatTierScope(
        [NotNullWhen(true)] out BetaSpendLimitSeatTierScope? value
    )
    {
        value = this.Value as BetaSpendLimitSeatTierScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitRbacGroupScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitRbacGroupScope(out var value)) {
    ///     // `value` is of type `BetaSpendLimitRbacGroupScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitRbacGroupScope(
        [NotNullWhen(true)] out BetaSpendLimitRbacGroupScope? value
    )
    {
        value = this.Value as BetaSpendLimitRbacGroupScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitOrganizationServiceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitOrganizationServiceScope(out var value)) {
    ///     // `value` is of type `BetaSpendLimitOrganizationServiceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitOrganizationServiceScope(
        [NotNullWhen(true)] out BetaSpendLimitOrganizationServiceScope? value
    )
    {
        value = this.Value as BetaSpendLimitOrganizationServiceScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitOrganizationScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitOrganizationScope(out var value)) {
    ///     // `value` is of type `BetaSpendLimitOrganizationScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitOrganizationScope(
        [NotNullWhen(true)] out BetaSpendLimitOrganizationScope? value
    )
    {
        value = this.Value as BetaSpendLimitOrganizationScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitWorkspaceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitWorkspaceScope(out var value)) {
    ///     // `value` is of type `BetaSpendLimitWorkspaceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitWorkspaceScope(
        [NotNullWhen(true)] out BetaSpendLimitWorkspaceScope? value
    )
    {
        value = this.Value as BetaSpendLimitWorkspaceScope;
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
    ///     (BetaSpendLimitUserScope value) =&gt; {...},
    ///     (BetaSpendLimitSeatTierScope value) =&gt; {...},
    ///     (BetaSpendLimitRbacGroupScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationScope value) =&gt; {...},
    ///     (BetaSpendLimitWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserScope> betaSpendLimitUserScope,
        Action<BetaSpendLimitSeatTierScope> betaSpendLimitSeatTierScope,
        Action<BetaSpendLimitRbacGroupScope> betaSpendLimitRbacGroupScope,
        Action<BetaSpendLimitOrganizationServiceScope> betaSpendLimitOrganizationServiceScope,
        Action<BetaSpendLimitOrganizationScope> betaSpendLimitOrganizationScope,
        Action<BetaSpendLimitWorkspaceScope> betaSpendLimitWorkspaceScope
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserScope value:
                betaSpendLimitUserScope(value);
                break;
            case BetaSpendLimitSeatTierScope value:
                betaSpendLimitSeatTierScope(value);
                break;
            case BetaSpendLimitRbacGroupScope value:
                betaSpendLimitRbacGroupScope(value);
                break;
            case BetaSpendLimitOrganizationServiceScope value:
                betaSpendLimitOrganizationServiceScope(value);
                break;
            case BetaSpendLimitOrganizationScope value:
                betaSpendLimitOrganizationScope(value);
                break;
            case BetaSpendLimitWorkspaceScope value:
                betaSpendLimitWorkspaceScope(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
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
    ///     (BetaSpendLimitUserScope value) =&gt; {...},
    ///     (BetaSpendLimitSeatTierScope value) =&gt; {...},
    ///     (BetaSpendLimitRbacGroupScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationScope value) =&gt; {...},
    ///     (BetaSpendLimitWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserScope, T> betaSpendLimitUserScope,
        Func<BetaSpendLimitSeatTierScope, T> betaSpendLimitSeatTierScope,
        Func<BetaSpendLimitRbacGroupScope, T> betaSpendLimitRbacGroupScope,
        Func<BetaSpendLimitOrganizationServiceScope, T> betaSpendLimitOrganizationServiceScope,
        Func<BetaSpendLimitOrganizationScope, T> betaSpendLimitOrganizationScope,
        Func<BetaSpendLimitWorkspaceScope, T> betaSpendLimitWorkspaceScope
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserScope value => betaSpendLimitUserScope(value),
            BetaSpendLimitSeatTierScope value => betaSpendLimitSeatTierScope(value),
            BetaSpendLimitRbacGroupScope value => betaSpendLimitRbacGroupScope(value),
            BetaSpendLimitOrganizationServiceScope value => betaSpendLimitOrganizationServiceScope(
                value
            ),
            BetaSpendLimitOrganizationScope value => betaSpendLimitOrganizationScope(value),
            BetaSpendLimitWorkspaceScope value => betaSpendLimitWorkspaceScope(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public static implicit operator Source(BetaSpendLimitUserScope value) => new(value);

    public static implicit operator Source(BetaSpendLimitSeatTierScope value) => new(value);

    public static implicit operator Source(BetaSpendLimitRbacGroupScope value) => new(value);

    public static implicit operator Source(BetaSpendLimitOrganizationServiceScope value) =>
        new(value);

    public static implicit operator Source(BetaSpendLimitOrganizationScope value) => new(value);

    public static implicit operator Source(BetaSpendLimitWorkspaceScope value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
        this.Switch(
            (betaSpendLimitUserScope) => betaSpendLimitUserScope.Validate(),
            (betaSpendLimitSeatTierScope) => betaSpendLimitSeatTierScope.Validate(),
            (betaSpendLimitRbacGroupScope) => betaSpendLimitRbacGroupScope.Validate(),
            (betaSpendLimitOrganizationServiceScope) =>
                betaSpendLimitOrganizationServiceScope.Validate(),
            (betaSpendLimitOrganizationScope) => betaSpendLimitOrganizationScope.Validate(),
            (betaSpendLimitWorkspaceScope) => betaSpendLimitWorkspaceScope.Validate()
        );
    }

    public virtual bool Equals(Source? other) =>
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
            BetaSpendLimitUserScope _ => 0,
            BetaSpendLimitSeatTierScope _ => 1,
            BetaSpendLimitRbacGroupScope _ => 2,
            BetaSpendLimitOrganizationServiceScope _ => 3,
            BetaSpendLimitOrganizationScope _ => 4,
            BetaSpendLimitWorkspaceScope _ => 5,
            _ => -1,
        };
    }
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "user":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserScope>(
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
            case "seat_tier":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitSeatTierScope>(
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
            case "rbac_group":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitRbacGroupScope>(
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
            case "organization_service":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaSpendLimitOrganizationServiceScope>(
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
            case "organization":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitOrganizationScope>(
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
            case "workspace":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitWorkspaceScope>(
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
                return new Source(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
