using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ComplianceSettings;

/// <summary>
/// Update your organization's Compliance Settings.
///
/// <para>Setting `state` to `enabled` turns on the Compliance API and begins capturing
/// organization activity events. Setting it to `disabled` turns both off. `state`
/// reflects whether the Compliance API is enabled.</para>
///
/// <para>A request that sets `state` to its current value succeeds and leaves the
/// resource unchanged. A `disabled` request stays in effect until a later `enabled`
/// request or the organization's next provisioning action that enables Access Transparency:
/// enabling Access Transparency also enables the Compliance API, which serves its
/// activity events, so such provisioning (including re-runs) re-enables the Compliance
/// API even after a `disabled` request. Automated provisioning never disables compliance settings.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ComplianceSettingUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Desired state. Accepts the string shorthand "enabled" or "disabled" in place
    /// of the object form; the response always returns the canonical object form.
    /// </summary>
    public required State State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<State>("state");
        }
        init { this._rawBodyData.Set("state", value); }
    }

    public ComplianceSettingUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceSettingUpdateParams(
        ComplianceSettingUpdateParams complianceSettingUpdateParams
    )
        : base(complianceSettingUpdateParams)
    {
        this._rawBodyData = new(complianceSettingUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ComplianceSettingUpdateParams(
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
    ComplianceSettingUpdateParams(
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
    public static ComplianceSettingUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(ComplianceSettingUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/compliance_settings"
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
/// Desired state. Accepts the string shorthand "enabled" or "disabled" in place of
/// the object form; the response always returns the canonical object form.
/// </summary>
[JsonConverter(typeof(StateConverter))]
public record class State : ModelBase
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
                BetaComplianceSettingsStateEnabledParam x => x.Type,
                BetaComplianceSettingsStateDisabledParam x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public State(BetaComplianceSettingsStateEnabledParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public State(BetaComplianceSettingsStateDisabledParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public State(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceSettingsStateEnabledParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaComplianceSettingsStateEnabledParam(out var value)) {
    ///     // `value` is of type `BetaComplianceSettingsStateEnabledParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaComplianceSettingsStateEnabledParam(
        [NotNullWhen(true)] out BetaComplianceSettingsStateEnabledParam? value
    )
    {
        value = this.Value as BetaComplianceSettingsStateEnabledParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceSettingsStateDisabledParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaComplianceSettingsStateDisabledParam(out var value)) {
    ///     // `value` is of type `BetaComplianceSettingsStateDisabledParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaComplianceSettingsStateDisabledParam(
        [NotNullWhen(true)] out BetaComplianceSettingsStateDisabledParam? value
    )
    {
        value = this.Value as BetaComplianceSettingsStateDisabledParam;
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
    ///     (BetaComplianceSettingsStateEnabledParam value) =&gt; {...},
    ///     (BetaComplianceSettingsStateDisabledParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaComplianceSettingsStateEnabledParam> betaComplianceSettingsStateEnabledParam,
        Action<BetaComplianceSettingsStateDisabledParam> betaComplianceSettingsStateDisabledParam
    )
    {
        switch (this.Value)
        {
            case BetaComplianceSettingsStateEnabledParam value:
                betaComplianceSettingsStateEnabledParam(value);
                break;
            case BetaComplianceSettingsStateDisabledParam value:
                betaComplianceSettingsStateDisabledParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of State");
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
    ///     (BetaComplianceSettingsStateEnabledParam value) =&gt; {...},
    ///     (BetaComplianceSettingsStateDisabledParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaComplianceSettingsStateEnabledParam, T> betaComplianceSettingsStateEnabledParam,
        Func<BetaComplianceSettingsStateDisabledParam, T> betaComplianceSettingsStateDisabledParam
    )
    {
        return this.Value switch
        {
            BetaComplianceSettingsStateEnabledParam value =>
                betaComplianceSettingsStateEnabledParam(value),
            BetaComplianceSettingsStateDisabledParam value =>
                betaComplianceSettingsStateDisabledParam(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of State"),
        };
    }

    public static implicit operator State(BetaComplianceSettingsStateEnabledParam value) =>
        new(value);

    public static implicit operator State(BetaComplianceSettingsStateDisabledParam value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of State");
        }
        this.Switch(
            (betaComplianceSettingsStateEnabledParam) =>
                betaComplianceSettingsStateEnabledParam.Validate(),
            (betaComplianceSettingsStateDisabledParam) =>
                betaComplianceSettingsStateDisabledParam.Validate()
        );
    }

    public virtual bool Equals(State? other) =>
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
            BetaComplianceSettingsStateEnabledParam _ => 0,
            BetaComplianceSettingsStateDisabledParam _ => 1,
            _ => -1,
        };
    }
}

sealed class StateConverter : JsonConverter<State>
{
    public override State? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceSettingsStateEnabledParam>(
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
            case "disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceSettingsStateDisabledParam>(
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
                return new State(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
