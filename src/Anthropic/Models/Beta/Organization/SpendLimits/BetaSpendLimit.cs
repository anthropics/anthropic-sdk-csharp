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
/// A configured spend limit: a cap on metered spend for one scope and period.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSpendLimit, BetaSpendLimitFromRaw>))]
public sealed record class BetaSpendLimit : JsonModel
{
    /// <summary>
    /// Unique tagged ID of the spend limit (`spl_...`).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Limit amount as a non-negative integer decimal string in the minor unit of
    /// `currency` (cents for USD): "50000" is $500.00. `null` means no numeric cap
    /// is configured at this scope — see the effective report for whether a limit applies.
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
    /// RFC 3339 datetime at which the spend limit was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// ISO 4217 code of the organization's billing currency; the unit for `amount`.
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
    /// Read-only. `false` when extra usage is switched off for this organization
    /// (`organization` limit) or for this member (`user` limit); `amount` is kept
    /// and applies again when it's switched back on. Always `true` for other limits.
    /// </summary>
    public required bool IsEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_enabled");
        }
        init { this._rawData.Set("is_enabled", value); }
    }

    /// <summary>
    /// Length of the window the limit resets over. `amount` caps spend within each period.
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
    /// What the limit applies to. A tagged union on `type`; each variant carries
    /// the identifier for its scope.
    /// </summary>
    public required BetaSpendLimitScope Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaSpendLimitScope>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <summary>
    /// Object type. Always `spend_limit`.
    /// </summary>
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
    /// RFC 3339 datetime at which the spend limit was last modified.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.IsEnabled;
        this.Period.Validate();
        this.Scope.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("spend_limit")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaSpendLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("spend_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimit(BetaSpendLimit betaSpendLimit)
        : base(betaSpendLimit) { }
#pragma warning restore CS8618

    public BetaSpendLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("spend_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendLimitFromRaw : IFromRawJson<BetaSpendLimit>
{
    /// <inheritdoc/>
    public BetaSpendLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSpendLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// What the limit applies to. A tagged union on `type`; each variant carries the
/// identifier for its scope.
/// </summary>
[JsonConverter(typeof(BetaSpendLimitScopeConverter))]
public record class BetaSpendLimitScope : ModelBase
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

    public BetaSpendLimitScope(BetaSpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitScope(BetaSpendLimitSeatTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitScope(BetaSpendLimitRbacGroupScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitScope(
        BetaSpendLimitOrganizationServiceScope value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitScope(BetaSpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitScope(BetaSpendLimitWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitScope(JsonElement element)
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
                    "Data did not match any variant of BetaSpendLimitScope"
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
                "Data did not match any variant of BetaSpendLimitScope"
            ),
        };
    }

    public static implicit operator BetaSpendLimitScope(BetaSpendLimitUserScope value) =>
        new(value);

    public static implicit operator BetaSpendLimitScope(BetaSpendLimitSeatTierScope value) =>
        new(value);

    public static implicit operator BetaSpendLimitScope(BetaSpendLimitRbacGroupScope value) =>
        new(value);

    public static implicit operator BetaSpendLimitScope(
        BetaSpendLimitOrganizationServiceScope value
    ) => new(value);

    public static implicit operator BetaSpendLimitScope(BetaSpendLimitOrganizationScope value) =>
        new(value);

    public static implicit operator BetaSpendLimitScope(BetaSpendLimitWorkspaceScope value) =>
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
                "Data did not match any variant of BetaSpendLimitScope"
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

    public virtual bool Equals(BetaSpendLimitScope? other) =>
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

sealed class BetaSpendLimitScopeConverter : JsonConverter<BetaSpendLimitScope>
{
    public override BetaSpendLimitScope? Read(
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
                return new BetaSpendLimitScope(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSpendLimitScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
