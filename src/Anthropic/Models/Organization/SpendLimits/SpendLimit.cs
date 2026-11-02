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
/// A configured spend limit: a cap on metered spend for one scope and period.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpendLimit, SpendLimitFromRaw>))]
public sealed record class SpendLimit : JsonModel
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
    /// (`organization` limit); `amount` is kept and applies again when it's switched
    /// back on. Always `true` for other limits.
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
    /// What the limit applies to. A tagged union on `type`; each variant carries
    /// the identifier for its scope.
    /// </summary>
    public required Scope Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Scope>("scope");
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

    public SpendLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("spend_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimit(SpendLimit spendLimit)
        : base(spendLimit) { }
#pragma warning restore CS8618

    public SpendLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("spend_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitFromRaw.FromRawUnchecked"/>
    public static SpendLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendLimitFromRaw : IFromRawJson<SpendLimit>
{
    /// <inheritdoc/>
    public SpendLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpendLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// What the limit applies to. A tagged union on `type`; each variant carries the
/// identifier for its scope.
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public record class Scope : ModelBase
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

    public ApiEnum<string, ScopeType> Type
    {
        get
        {
            return this.Value switch
            {
                SpendLimitUserScope _ => ScopeType.User,
                SpendLimitSeatTierScope _ => ScopeType.SeatTier,
                SpendLimitRbacGroupScope _ => ScopeType.RbacGroup,
                SpendLimitOrganizationServiceScope _ => ScopeType.OrganizationService,
                SpendLimitOrganizationScope _ => ScopeType.Organization,
                SpendLimitWorkspaceScope _ => ScopeType.Workspace,
                SpendLimitUsageTierScope _ => ScopeType.UsageTier,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, ScopeType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public Scope(SpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(SpendLimitSeatTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(SpendLimitRbacGroupScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(SpendLimitOrganizationServiceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(SpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(SpendLimitWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(SpendLimitUsageTierScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(JsonElement element)
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
                throw new AnthropicInvalidDataException("Data did not match any variant of Scope");
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
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Scope"),
        };
    }

    public static implicit operator Scope(SpendLimitUserScope value) => new(value);

    public static implicit operator Scope(SpendLimitSeatTierScope value) => new(value);

    public static implicit operator Scope(SpendLimitRbacGroupScope value) => new(value);

    public static implicit operator Scope(SpendLimitOrganizationServiceScope value) => new(value);

    public static implicit operator Scope(SpendLimitOrganizationScope value) => new(value);

    public static implicit operator Scope(SpendLimitWorkspaceScope value) => new(value);

    public static implicit operator Scope(SpendLimitUsageTierScope value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Scope");
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

    public virtual bool Equals(Scope? other) =>
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

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope? Read(
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
                return new Scope(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ScopeTypeConverter))]
public enum ScopeType
{
    User,
    SeatTier,
    RbacGroup,
    OrganizationService,
    Organization,
    Workspace,
    UsageTier,
}

sealed class ScopeTypeConverter : JsonConverter<ScopeType>
{
    public override ScopeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => ScopeType.User,
            "seat_tier" => ScopeType.SeatTier,
            "rbac_group" => ScopeType.RbacGroup,
            "organization_service" => ScopeType.OrganizationService,
            "organization" => ScopeType.Organization,
            "workspace" => ScopeType.Workspace,
            "usage_tier" => ScopeType.UsageTier,
            _ => (ScopeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScopeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScopeType.User => "user",
                ScopeType.SeatTier => "seat_tier",
                ScopeType.RbacGroup => "rbac_group",
                ScopeType.OrganizationService => "organization_service",
                ScopeType.Organization => "organization",
                ScopeType.Workspace => "workspace",
                ScopeType.UsageTier => "usage_tier",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
