using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// Set a spend limit.
///
/// <para>Upsert keyed on (scope, period): setting a limit that already exists overwrites
/// it in place. A Claude Enterprise organization sets `user` limits. Its seat-tier,
/// group, and organization-level defaults are configured in claude.ai. A Claude
/// Console organization sets `organization` and `workspace` limits, which are monthly
/// and always carry an amount. Setting those limits is in an early access preview.
/// To request access, contact your Anthropic account team.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpendLimitSetParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Limit amount as a non-negative integer decimal string in the minor unit of
    /// the organization's billing currency (cents for USD): "50000" is $500.00. `null`
    /// sets an explicit no-limit override for this scope and `period` only — each
    /// period resolves independently, so caps for other periods still apply.
    /// </summary>
    public required string? Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// What the limit applies to. Claude Enterprise organizations set `user` limits.
    /// Claude Console organizations set `organization` and `workspace` limits. Any
    /// other combination returns 400. Setting `organization` and `workspace` limits
    /// through the API is in an early access preview. To request access, contact
    /// your Anthropic account team.
    /// </summary>
    public required Scope Scope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Scope>("scope");
        }
        init { this._rawBodyData.Set("scope", value); }
    }

    public ApiEnum<string, BetaSpendLimitPeriod>? Period
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BetaSpendLimitPeriod>>(
                "period"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("period");
                return;
            }

            this._rawBodyData.Set("period", value);
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public SpendLimitSetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitSetParams(SpendLimitSetParams spendLimitSetParams)
        : base(spendLimitSetParams)
    {
        this._rawBodyData = new(spendLimitSetParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SpendLimitSetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitSetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SpendLimitSetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SpendLimitSetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/spend_limits"
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// What the limit applies to. Claude Enterprise organizations set `user` limits.
/// Claude Console organizations set `organization` and `workspace` limits. Any other
/// combination returns 400. Setting `organization` and `workspace` limits through
/// the API is in an early access preview. To request access, contact your Anthropic
/// account team.
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

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaSpendLimitUserScope x => x.Type,
                BetaSpendLimitOrganizationScope x => x.Type,
                BetaSpendLimitWorkspaceScope x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Scope(BetaSpendLimitUserScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(BetaSpendLimitOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(BetaSpendLimitWorkspaceScope value, JsonElement? element = null)
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
    ///     (BetaSpendLimitOrganizationScope value) =&gt; {...},
    ///     (BetaSpendLimitWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserScope> betaSpendLimitUser,
        Action<BetaSpendLimitOrganizationScope> betaSpendLimitOrganization,
        Action<BetaSpendLimitWorkspaceScope> betaSpendLimitWorkspace
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserScope value:
                betaSpendLimitUser(value);
                break;
            case BetaSpendLimitOrganizationScope value:
                betaSpendLimitOrganization(value);
                break;
            case BetaSpendLimitWorkspaceScope value:
                betaSpendLimitWorkspace(value);
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
    ///     (BetaSpendLimitUserScope value) =&gt; {...},
    ///     (BetaSpendLimitOrganizationScope value) =&gt; {...},
    ///     (BetaSpendLimitWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserScope, T> betaSpendLimitUser,
        Func<BetaSpendLimitOrganizationScope, T> betaSpendLimitOrganization,
        Func<BetaSpendLimitWorkspaceScope, T> betaSpendLimitWorkspace
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserScope value => betaSpendLimitUser(value),
            BetaSpendLimitOrganizationScope value => betaSpendLimitOrganization(value),
            BetaSpendLimitWorkspaceScope value => betaSpendLimitWorkspace(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Scope"),
        };
    }

    public static implicit operator Scope(BetaSpendLimitUserScope value) => new(value);

    public static implicit operator Scope(BetaSpendLimitOrganizationScope value) => new(value);

    public static implicit operator Scope(BetaSpendLimitWorkspaceScope value) => new(value);

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
            (betaSpendLimitUser) => betaSpendLimitUser.Validate(),
            (betaSpendLimitOrganization) => betaSpendLimitOrganization.Validate(),
            (betaSpendLimitWorkspace) => betaSpendLimitWorkspace.Validate()
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
            BetaSpendLimitUserScope _ => 0,
            BetaSpendLimitOrganizationScope _ => 1,
            BetaSpendLimitWorkspaceScope _ => 2,
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
                return new Scope(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
