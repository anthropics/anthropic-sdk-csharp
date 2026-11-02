using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

/// <summary>
/// Per-member effective-limit report row (`GET /spend_limits/effective`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpendSummary, SpendSummaryFromRaw>))]
public sealed record class SpendSummary : JsonModel
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
    public required ApiEnum<string, SpendLimitPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SpendLimitPeriod>>("period");
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

    public required SpendSummaryScope Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SpendSummaryScope>("scope");
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

    public SpendSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendSummary(SpendSummary spendSummary)
        : base(spendSummary) { }
#pragma warning restore CS8618

    public SpendSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendSummaryFromRaw.FromRawUnchecked"/>
    public static SpendSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendSummaryFromRaw : IFromRawJson<SpendSummary>
{
    /// <inheritdoc/>
    public SpendSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpendSummary.FromRawUnchecked(rawData);
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

    public ApiEnum<string, ActorType> Type
    {
        get
        {
            return this.Value switch
            {
                SpendLimitUserActor _ => ActorType.UserActor,
                SpendLimitScopedApiKeyActor _ => ActorType.ScopedApiKeyActor,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, ActorType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public Actor(SpendLimitUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Actor(SpendLimitScopedApiKeyActor value, JsonElement? element = null)
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
    /// type <see cref="SpendLimitUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitUser(out var value)) {
    ///     // `value` is of type `SpendLimitUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitUser([NotNullWhen(true)] out SpendLimitUserActor? value)
    {
        value = this.Value as SpendLimitUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitScopedApiKeyActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitScopedApiKey(out var value)) {
    ///     // `value` is of type `SpendLimitScopedApiKeyActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitScopedApiKey(
        [NotNullWhen(true)] out SpendLimitScopedApiKeyActor? value
    )
    {
        value = this.Value as SpendLimitScopedApiKeyActor;
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
    ///     (SpendLimitUserActor value) =&gt; {...},
    ///     (SpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SpendLimitUserActor> spendLimitUser,
        Action<SpendLimitScopedApiKeyActor> spendLimitScopedApiKey
    )
    {
        switch (this.Value)
        {
            case SpendLimitUserActor value:
                spendLimitUser(value);
                break;
            case SpendLimitScopedApiKeyActor value:
                spendLimitScopedApiKey(value);
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
    ///     (SpendLimitUserActor value) =&gt; {...},
    ///     (SpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SpendLimitUserActor, T> spendLimitUser,
        Func<SpendLimitScopedApiKeyActor, T> spendLimitScopedApiKey
    )
    {
        return this.Value switch
        {
            SpendLimitUserActor value => spendLimitUser(value),
            SpendLimitScopedApiKeyActor value => spendLimitScopedApiKey(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Actor"),
        };
    }

    public static implicit operator Actor(SpendLimitUserActor value) => new(value);

    public static implicit operator Actor(SpendLimitScopedApiKeyActor value) => new(value);

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
            (spendLimitUser) => spendLimitUser.Validate(),
            (spendLimitScopedApiKey) => spendLimitScopedApiKey.Validate()
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
            SpendLimitUserActor _ => 0,
            SpendLimitScopedApiKeyActor _ => 1,
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitUserActor>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitScopedApiKeyActor>(
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

[JsonConverter(typeof(ActorTypeConverter))]
public enum ActorType
{
    UserActor,
    ScopedApiKeyActor,
}

sealed class ActorTypeConverter : JsonConverter<ActorType>
{
    public override ActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => ActorType.UserActor,
            "scoped_api_key_actor" => ActorType.ScopedApiKeyActor,
            _ => (ActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActorType.UserActor => "user_actor",
                ActorType.ScopedApiKeyActor => "scoped_api_key_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SpendSummaryScopeConverter))]
public record class SpendSummaryScope : ModelBase
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

    public ApiEnum<string, SpendSummaryScopeType> Type
    {
        get
        {
            return this.Value switch
            {
                SpendLimitUserScope _ => SpendSummaryScopeType.User,
                SpendLimitSeatTierScope _ => SpendSummaryScopeType.SeatTier,
                SpendLimitRbacGroupScope _ => SpendSummaryScopeType.RbacGroup,
                SpendLimitOrganizationServiceScope _ => SpendSummaryScopeType.OrganizationService,
                SpendLimitOrganizationScope _ => SpendSummaryScopeType.Organization,
                SpendLimitWorkspaceScope _ => SpendSummaryScopeType.Workspace,
                SpendLimitUsageTierScope _ => SpendSummaryScopeType.UsageTier,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, SpendSummaryScopeType>
                >(this.Json, "type"),
            };
        }
    }

    public SpendSummaryScope(SpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(SpendLimitSeatTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(SpendLimitRbacGroupScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(SpendLimitOrganizationServiceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(SpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(SpendLimitWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(SpendLimitUsageTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendSummaryScope(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitUserScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitUser(out var value)) {
    ///     // `value` is of type `SpendLimitUserScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitUser([NotNullWhen(true)] out SpendLimitUserScope? value)
    {
        value = this.Value as SpendLimitUserScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitSeatTierScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitSeatTier(out var value)) {
    ///     // `value` is of type `SpendLimitSeatTierScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitSeatTier([NotNullWhen(true)] out SpendLimitSeatTierScope? value)
    {
        value = this.Value as SpendLimitSeatTierScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitRbacGroupScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitRbacGroup(out var value)) {
    ///     // `value` is of type `SpendLimitRbacGroupScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitRbacGroup([NotNullWhen(true)] out SpendLimitRbacGroupScope? value)
    {
        value = this.Value as SpendLimitRbacGroupScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitOrganizationServiceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitOrganizationService(out var value)) {
    ///     // `value` is of type `SpendLimitOrganizationServiceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitOrganizationService(
        [NotNullWhen(true)] out SpendLimitOrganizationServiceScope? value
    )
    {
        value = this.Value as SpendLimitOrganizationServiceScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitOrganizationScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitOrganization(out var value)) {
    ///     // `value` is of type `SpendLimitOrganizationScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitOrganization(
        [NotNullWhen(true)] out SpendLimitOrganizationScope? value
    )
    {
        value = this.Value as SpendLimitOrganizationScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitWorkspaceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitWorkspace(out var value)) {
    ///     // `value` is of type `SpendLimitWorkspaceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitWorkspace([NotNullWhen(true)] out SpendLimitWorkspaceScope? value)
    {
        value = this.Value as SpendLimitWorkspaceScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitUsageTierScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitUsageTier(out var value)) {
    ///     // `value` is of type `SpendLimitUsageTierScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitUsageTier([NotNullWhen(true)] out SpendLimitUsageTierScope? value)
    {
        value = this.Value as SpendLimitUsageTierScope;
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
    ///     (SpendLimitUserScope value) =&gt; {...},
    ///     (SpendLimitSeatTierScope value) =&gt; {...},
    ///     (SpendLimitRbacGroupScope value) =&gt; {...},
    ///     (SpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (SpendLimitOrganizationScope value) =&gt; {...},
    ///     (SpendLimitWorkspaceScope value) =&gt; {...},
    ///     (SpendLimitUsageTierScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SpendLimitUserScope> spendLimitUser,
        Action<SpendLimitSeatTierScope> spendLimitSeatTier,
        Action<SpendLimitRbacGroupScope> spendLimitRbacGroup,
        Action<SpendLimitOrganizationServiceScope> spendLimitOrganizationService,
        Action<SpendLimitOrganizationScope> spendLimitOrganization,
        Action<SpendLimitWorkspaceScope> spendLimitWorkspace,
        Action<SpendLimitUsageTierScope> spendLimitUsageTier
    )
    {
        switch (this.Value)
        {
            case SpendLimitUserScope value:
                spendLimitUser(value);
                break;
            case SpendLimitSeatTierScope value:
                spendLimitSeatTier(value);
                break;
            case SpendLimitRbacGroupScope value:
                spendLimitRbacGroup(value);
                break;
            case SpendLimitOrganizationServiceScope value:
                spendLimitOrganizationService(value);
                break;
            case SpendLimitOrganizationScope value:
                spendLimitOrganization(value);
                break;
            case SpendLimitWorkspaceScope value:
                spendLimitWorkspace(value);
                break;
            case SpendLimitUsageTierScope value:
                spendLimitUsageTier(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of SpendSummaryScope"
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
    ///     (SpendLimitUserScope value) =&gt; {...},
    ///     (SpendLimitSeatTierScope value) =&gt; {...},
    ///     (SpendLimitRbacGroupScope value) =&gt; {...},
    ///     (SpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (SpendLimitOrganizationScope value) =&gt; {...},
    ///     (SpendLimitWorkspaceScope value) =&gt; {...},
    ///     (SpendLimitUsageTierScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SpendLimitUserScope, T> spendLimitUser,
        Func<SpendLimitSeatTierScope, T> spendLimitSeatTier,
        Func<SpendLimitRbacGroupScope, T> spendLimitRbacGroup,
        Func<SpendLimitOrganizationServiceScope, T> spendLimitOrganizationService,
        Func<SpendLimitOrganizationScope, T> spendLimitOrganization,
        Func<SpendLimitWorkspaceScope, T> spendLimitWorkspace,
        Func<SpendLimitUsageTierScope, T> spendLimitUsageTier
    )
    {
        return this.Value switch
        {
            SpendLimitUserScope value => spendLimitUser(value),
            SpendLimitSeatTierScope value => spendLimitSeatTier(value),
            SpendLimitRbacGroupScope value => spendLimitRbacGroup(value),
            SpendLimitOrganizationServiceScope value => spendLimitOrganizationService(value),
            SpendLimitOrganizationScope value => spendLimitOrganization(value),
            SpendLimitWorkspaceScope value => spendLimitWorkspace(value),
            SpendLimitUsageTierScope value => spendLimitUsageTier(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SpendSummaryScope"
            ),
        };
    }

    public static implicit operator SpendSummaryScope(SpendLimitUserScope value) => new(value);

    public static implicit operator SpendSummaryScope(SpendLimitSeatTierScope value) => new(value);

    public static implicit operator SpendSummaryScope(SpendLimitRbacGroupScope value) => new(value);

    public static implicit operator SpendSummaryScope(SpendLimitOrganizationServiceScope value) =>
        new(value);

    public static implicit operator SpendSummaryScope(SpendLimitOrganizationScope value) =>
        new(value);

    public static implicit operator SpendSummaryScope(SpendLimitWorkspaceScope value) => new(value);

    public static implicit operator SpendSummaryScope(SpendLimitUsageTierScope value) => new(value);

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
                "Data did not match any variant of SpendSummaryScope"
            );
        }
        this.Switch(
            (spendLimitUser) => spendLimitUser.Validate(),
            (spendLimitSeatTier) => spendLimitSeatTier.Validate(),
            (spendLimitRbacGroup) => spendLimitRbacGroup.Validate(),
            (spendLimitOrganizationService) => spendLimitOrganizationService.Validate(),
            (spendLimitOrganization) => spendLimitOrganization.Validate(),
            (spendLimitWorkspace) => spendLimitWorkspace.Validate(),
            (spendLimitUsageTier) => spendLimitUsageTier.Validate()
        );
    }

    public virtual bool Equals(SpendSummaryScope? other) =>
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
            SpendLimitUserScope _ => 0,
            SpendLimitSeatTierScope _ => 1,
            SpendLimitRbacGroupScope _ => 2,
            SpendLimitOrganizationServiceScope _ => 3,
            SpendLimitOrganizationScope _ => 4,
            SpendLimitWorkspaceScope _ => 5,
            SpendLimitUsageTierScope _ => 6,
            _ => -1,
        };
    }
}

sealed class SpendSummaryScopeConverter : JsonConverter<SpendSummaryScope>
{
    public override SpendSummaryScope? Read(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitUserScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitSeatTierScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitRbacGroupScope>(
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
                        JsonSerializer.Deserialize<SpendLimitOrganizationServiceScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitOrganizationScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitWorkspaceScope>(
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
            case "usage_tier":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SpendLimitUsageTierScope>(
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
                return new SpendSummaryScope(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpendSummaryScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SpendSummaryScopeTypeConverter))]
public enum SpendSummaryScopeType
{
    User,
    SeatTier,
    RbacGroup,
    OrganizationService,
    Organization,
    Workspace,
    UsageTier,
}

sealed class SpendSummaryScopeTypeConverter : JsonConverter<SpendSummaryScopeType>
{
    public override SpendSummaryScopeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => SpendSummaryScopeType.User,
            "seat_tier" => SpendSummaryScopeType.SeatTier,
            "rbac_group" => SpendSummaryScopeType.RbacGroup,
            "organization_service" => SpendSummaryScopeType.OrganizationService,
            "organization" => SpendSummaryScopeType.Organization,
            "workspace" => SpendSummaryScopeType.Workspace,
            "usage_tier" => SpendSummaryScopeType.UsageTier,
            _ => (SpendSummaryScopeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpendSummaryScopeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpendSummaryScopeType.User => "user",
                SpendSummaryScopeType.SeatTier => "seat_tier",
                SpendSummaryScopeType.RbacGroup => "rbac_group",
                SpendSummaryScopeType.OrganizationService => "organization_service",
                SpendSummaryScopeType.Organization => "organization",
                SpendSummaryScopeType.Workspace => "workspace",
                SpendSummaryScopeType.UsageTier => "usage_tier",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
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

    public ApiEnum<string, SourceType> Type
    {
        get
        {
            return this.Value switch
            {
                SpendLimitUserScope _ => SourceType.User,
                SpendLimitSeatTierScope _ => SourceType.SeatTier,
                SpendLimitRbacGroupScope _ => SourceType.RbacGroup,
                SpendLimitOrganizationServiceScope _ => SourceType.OrganizationService,
                SpendLimitOrganizationScope _ => SourceType.Organization,
                SpendLimitWorkspaceScope _ => SourceType.Workspace,
                SpendLimitUsageTierScope _ => SourceType.UsageTier,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, SourceType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public Source(SpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(SpendLimitSeatTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(SpendLimitRbacGroupScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(SpendLimitOrganizationServiceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(SpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(SpendLimitWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(SpendLimitUsageTierScope value, JsonElement? element = null)
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
    /// type <see cref="SpendLimitUserScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitUserScope(out var value)) {
    ///     // `value` is of type `SpendLimitUserScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitUserScope([NotNullWhen(true)] out SpendLimitUserScope? value)
    {
        value = this.Value as SpendLimitUserScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitSeatTierScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitSeatTierScope(out var value)) {
    ///     // `value` is of type `SpendLimitSeatTierScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitSeatTierScope(
        [NotNullWhen(true)] out SpendLimitSeatTierScope? value
    )
    {
        value = this.Value as SpendLimitSeatTierScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitRbacGroupScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitRbacGroupScope(out var value)) {
    ///     // `value` is of type `SpendLimitRbacGroupScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitRbacGroupScope(
        [NotNullWhen(true)] out SpendLimitRbacGroupScope? value
    )
    {
        value = this.Value as SpendLimitRbacGroupScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitOrganizationServiceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitOrganizationServiceScope(out var value)) {
    ///     // `value` is of type `SpendLimitOrganizationServiceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitOrganizationServiceScope(
        [NotNullWhen(true)] out SpendLimitOrganizationServiceScope? value
    )
    {
        value = this.Value as SpendLimitOrganizationServiceScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitOrganizationScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitOrganizationScope(out var value)) {
    ///     // `value` is of type `SpendLimitOrganizationScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitOrganizationScope(
        [NotNullWhen(true)] out SpendLimitOrganizationScope? value
    )
    {
        value = this.Value as SpendLimitOrganizationScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitWorkspaceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitWorkspaceScope(out var value)) {
    ///     // `value` is of type `SpendLimitWorkspaceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitWorkspaceScope(
        [NotNullWhen(true)] out SpendLimitWorkspaceScope? value
    )
    {
        value = this.Value as SpendLimitWorkspaceScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitUsageTierScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpendLimitUsageTierScope(out var value)) {
    ///     // `value` is of type `SpendLimitUsageTierScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpendLimitUsageTierScope(
        [NotNullWhen(true)] out SpendLimitUsageTierScope? value
    )
    {
        value = this.Value as SpendLimitUsageTierScope;
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
    ///     (SpendLimitUserScope value) =&gt; {...},
    ///     (SpendLimitSeatTierScope value) =&gt; {...},
    ///     (SpendLimitRbacGroupScope value) =&gt; {...},
    ///     (SpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (SpendLimitOrganizationScope value) =&gt; {...},
    ///     (SpendLimitWorkspaceScope value) =&gt; {...},
    ///     (SpendLimitUsageTierScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SpendLimitUserScope> spendLimitUserScope,
        Action<SpendLimitSeatTierScope> spendLimitSeatTierScope,
        Action<SpendLimitRbacGroupScope> spendLimitRbacGroupScope,
        Action<SpendLimitOrganizationServiceScope> spendLimitOrganizationServiceScope,
        Action<SpendLimitOrganizationScope> spendLimitOrganizationScope,
        Action<SpendLimitWorkspaceScope> spendLimitWorkspaceScope,
        Action<SpendLimitUsageTierScope> spendLimitUsageTierScope
    )
    {
        switch (this.Value)
        {
            case SpendLimitUserScope value:
                spendLimitUserScope(value);
                break;
            case SpendLimitSeatTierScope value:
                spendLimitSeatTierScope(value);
                break;
            case SpendLimitRbacGroupScope value:
                spendLimitRbacGroupScope(value);
                break;
            case SpendLimitOrganizationServiceScope value:
                spendLimitOrganizationServiceScope(value);
                break;
            case SpendLimitOrganizationScope value:
                spendLimitOrganizationScope(value);
                break;
            case SpendLimitWorkspaceScope value:
                spendLimitWorkspaceScope(value);
                break;
            case SpendLimitUsageTierScope value:
                spendLimitUsageTierScope(value);
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
    ///     (SpendLimitUserScope value) =&gt; {...},
    ///     (SpendLimitSeatTierScope value) =&gt; {...},
    ///     (SpendLimitRbacGroupScope value) =&gt; {...},
    ///     (SpendLimitOrganizationServiceScope value) =&gt; {...},
    ///     (SpendLimitOrganizationScope value) =&gt; {...},
    ///     (SpendLimitWorkspaceScope value) =&gt; {...},
    ///     (SpendLimitUsageTierScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SpendLimitUserScope, T> spendLimitUserScope,
        Func<SpendLimitSeatTierScope, T> spendLimitSeatTierScope,
        Func<SpendLimitRbacGroupScope, T> spendLimitRbacGroupScope,
        Func<SpendLimitOrganizationServiceScope, T> spendLimitOrganizationServiceScope,
        Func<SpendLimitOrganizationScope, T> spendLimitOrganizationScope,
        Func<SpendLimitWorkspaceScope, T> spendLimitWorkspaceScope,
        Func<SpendLimitUsageTierScope, T> spendLimitUsageTierScope
    )
    {
        return this.Value switch
        {
            SpendLimitUserScope value => spendLimitUserScope(value),
            SpendLimitSeatTierScope value => spendLimitSeatTierScope(value),
            SpendLimitRbacGroupScope value => spendLimitRbacGroupScope(value),
            SpendLimitOrganizationServiceScope value => spendLimitOrganizationServiceScope(value),
            SpendLimitOrganizationScope value => spendLimitOrganizationScope(value),
            SpendLimitWorkspaceScope value => spendLimitWorkspaceScope(value),
            SpendLimitUsageTierScope value => spendLimitUsageTierScope(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public static implicit operator Source(SpendLimitUserScope value) => new(value);

    public static implicit operator Source(SpendLimitSeatTierScope value) => new(value);

    public static implicit operator Source(SpendLimitRbacGroupScope value) => new(value);

    public static implicit operator Source(SpendLimitOrganizationServiceScope value) => new(value);

    public static implicit operator Source(SpendLimitOrganizationScope value) => new(value);

    public static implicit operator Source(SpendLimitWorkspaceScope value) => new(value);

    public static implicit operator Source(SpendLimitUsageTierScope value) => new(value);

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
            (spendLimitUserScope) => spendLimitUserScope.Validate(),
            (spendLimitSeatTierScope) => spendLimitSeatTierScope.Validate(),
            (spendLimitRbacGroupScope) => spendLimitRbacGroupScope.Validate(),
            (spendLimitOrganizationServiceScope) => spendLimitOrganizationServiceScope.Validate(),
            (spendLimitOrganizationScope) => spendLimitOrganizationScope.Validate(),
            (spendLimitWorkspaceScope) => spendLimitWorkspaceScope.Validate(),
            (spendLimitUsageTierScope) => spendLimitUsageTierScope.Validate()
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
            SpendLimitUserScope _ => 0,
            SpendLimitSeatTierScope _ => 1,
            SpendLimitRbacGroupScope _ => 2,
            SpendLimitOrganizationServiceScope _ => 3,
            SpendLimitOrganizationScope _ => 4,
            SpendLimitWorkspaceScope _ => 5,
            SpendLimitUsageTierScope _ => 6,
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitUserScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitSeatTierScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitRbacGroupScope>(
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
                        JsonSerializer.Deserialize<SpendLimitOrganizationServiceScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitOrganizationScope>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitWorkspaceScope>(
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
            case "usage_tier":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SpendLimitUsageTierScope>(
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

[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    User,
    SeatTier,
    RbacGroup,
    OrganizationService,
    Organization,
    Workspace,
    UsageTier,
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => SourceType.User,
            "seat_tier" => SourceType.SeatTier,
            "rbac_group" => SourceType.RbacGroup,
            "organization_service" => SourceType.OrganizationService,
            "organization" => SourceType.Organization,
            "workspace" => SourceType.Workspace,
            "usage_tier" => SourceType.UsageTier,
            _ => (SourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceType.User => "user",
                SourceType.SeatTier => "seat_tier",
                SourceType.RbacGroup => "rbac_group",
                SourceType.OrganizationService => "organization_service",
                SourceType.Organization => "organization",
                SourceType.Workspace => "workspace",
                SourceType.UsageTier => "usage_tier",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
