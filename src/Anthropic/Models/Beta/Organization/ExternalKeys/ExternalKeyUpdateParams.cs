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

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

/// <summary>
/// Partially update an external key config. Omitted fields are left unchanged.
///
/// <para>`display_name` is always editable. `geo` and `provider_config` cannot be
/// changed once any workspace references this config, because previously encrypted
/// data requires the original key identity to decrypt.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalKeyUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ExternalKeyID { get; init; }

    /// <summary>
    /// Human-friendly display name.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("display_name");
        }
        init { this._rawBodyData.Set("display_name", value); }
    }

    /// <summary>
    /// Data residency geo. Only `us` is supported.
    /// </summary>
    public ApiEnum<string, ExternalKeyUpdateParamsGeo>? Geo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExternalKeyUpdateParamsGeo>>(
                "geo"
            );
        }
        init { this._rawBodyData.Set("geo", value); }
    }

    /// <summary>
    /// KMS provider identity and auth coordinates.
    /// </summary>
    public ExternalKeyUpdateParamsProviderConfig? ProviderConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ExternalKeyUpdateParamsProviderConfig>(
                "provider_config"
            );
        }
        init { this._rawBodyData.Set("provider_config", value); }
    }

    public ExternalKeyUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyUpdateParams(ExternalKeyUpdateParams externalKeyUpdateParams)
        : base(externalKeyUpdateParams)
    {
        this.ExternalKeyID = externalKeyUpdateParams.ExternalKeyID;

        this._rawBodyData = new(externalKeyUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExternalKeyUpdateParams(
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
    ExternalKeyUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string externalKeyID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ExternalKeyID = externalKeyID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExternalKeyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string externalKeyID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            externalKeyID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ExternalKeyID"] = JsonSerializer.SerializeToElement(this.ExternalKeyID),
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

    public virtual bool Equals(ExternalKeyUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ExternalKeyID?.Equals(other.ExternalKeyID) ?? other.ExternalKeyID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/organizations/external_keys/{0}", this.ExternalKeyID)
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
/// Data residency geo. Only `us` is supported.
/// </summary>
[JsonConverter(typeof(ExternalKeyUpdateParamsGeoConverter))]
public enum ExternalKeyUpdateParamsGeo
{
    Us,
}

sealed class ExternalKeyUpdateParamsGeoConverter : JsonConverter<ExternalKeyUpdateParamsGeo>
{
    public override ExternalKeyUpdateParamsGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us" => ExternalKeyUpdateParamsGeo.Us,
            _ => (ExternalKeyUpdateParamsGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalKeyUpdateParamsGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalKeyUpdateParamsGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// KMS provider identity and auth coordinates.
/// </summary>
[JsonConverter(typeof(ExternalKeyUpdateParamsProviderConfigConverter))]
public record class ExternalKeyUpdateParamsProviderConfig : ModelBase
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
                betaAwsExternalKey: (x) => x.Type,
                betaGcpExternalKey: (x) => x.Type,
                betaAzureExternalKeyConfigParam: (x) => x.Type
            );
        }
    }

    public string? KeyName
    {
        get
        {
            return Match<string?>(
                betaAwsExternalKey: (_) => null,
                betaGcpExternalKey: (x) => x.KeyName,
                betaAzureExternalKeyConfigParam: (x) => x.KeyName
            );
        }
    }

    public ExternalKeyUpdateParamsProviderConfig(
        BetaAwsExternalKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExternalKeyUpdateParamsProviderConfig(
        BetaGcpExternalKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExternalKeyUpdateParamsProviderConfig(
        BetaAzureExternalKeyConfigParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExternalKeyUpdateParamsProviderConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAwsExternalKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAwsExternalKey(out var value)) {
    ///     // `value` is of type `BetaAwsExternalKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAwsExternalKey([NotNullWhen(true)] out BetaAwsExternalKeyConfig? value)
    {
        value = this.Value as BetaAwsExternalKeyConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGcpExternalKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaGcpExternalKey(out var value)) {
    ///     // `value` is of type `BetaGcpExternalKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaGcpExternalKey([NotNullWhen(true)] out BetaGcpExternalKeyConfig? value)
    {
        value = this.Value as BetaGcpExternalKeyConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAzureExternalKeyConfigParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAzureExternalKeyConfigParam(out var value)) {
    ///     // `value` is of type `BetaAzureExternalKeyConfigParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAzureExternalKeyConfigParam(
        [NotNullWhen(true)] out BetaAzureExternalKeyConfigParam? value
    )
    {
        value = this.Value as BetaAzureExternalKeyConfigParam;
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
    ///     (BetaAwsExternalKeyConfig value) =&gt; {...},
    ///     (BetaGcpExternalKeyConfig value) =&gt; {...},
    ///     (BetaAzureExternalKeyConfigParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaAwsExternalKeyConfig> betaAwsExternalKey,
        Action<BetaGcpExternalKeyConfig> betaGcpExternalKey,
        Action<BetaAzureExternalKeyConfigParam> betaAzureExternalKeyConfigParam
    )
    {
        switch (this.Value)
        {
            case BetaAwsExternalKeyConfig value:
                betaAwsExternalKey(value);
                break;
            case BetaGcpExternalKeyConfig value:
                betaGcpExternalKey(value);
                break;
            case BetaAzureExternalKeyConfigParam value:
                betaAzureExternalKeyConfigParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ExternalKeyUpdateParamsProviderConfig"
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
    ///     (BetaAwsExternalKeyConfig value) =&gt; {...},
    ///     (BetaGcpExternalKeyConfig value) =&gt; {...},
    ///     (BetaAzureExternalKeyConfigParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaAwsExternalKeyConfig, T> betaAwsExternalKey,
        Func<BetaGcpExternalKeyConfig, T> betaGcpExternalKey,
        Func<BetaAzureExternalKeyConfigParam, T> betaAzureExternalKeyConfigParam
    )
    {
        return this.Value switch
        {
            BetaAwsExternalKeyConfig value => betaAwsExternalKey(value),
            BetaGcpExternalKeyConfig value => betaGcpExternalKey(value),
            BetaAzureExternalKeyConfigParam value => betaAzureExternalKeyConfigParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ExternalKeyUpdateParamsProviderConfig"
            ),
        };
    }

    public static implicit operator ExternalKeyUpdateParamsProviderConfig(
        BetaAwsExternalKeyConfig value
    ) => new(value);

    public static implicit operator ExternalKeyUpdateParamsProviderConfig(
        BetaGcpExternalKeyConfig value
    ) => new(value);

    public static implicit operator ExternalKeyUpdateParamsProviderConfig(
        BetaAzureExternalKeyConfigParam value
    ) => new(value);

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
                "Data did not match any variant of ExternalKeyUpdateParamsProviderConfig"
            );
        }
        this.Switch(
            (betaAwsExternalKey) => betaAwsExternalKey.Validate(),
            (betaGcpExternalKey) => betaGcpExternalKey.Validate(),
            (betaAzureExternalKeyConfigParam) => betaAzureExternalKeyConfigParam.Validate()
        );
    }

    public virtual bool Equals(ExternalKeyUpdateParamsProviderConfig? other) =>
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
            BetaAwsExternalKeyConfig _ => 0,
            BetaGcpExternalKeyConfig _ => 1,
            BetaAzureExternalKeyConfigParam _ => 2,
            _ => -1,
        };
    }
}

sealed class ExternalKeyUpdateParamsProviderConfigConverter
    : JsonConverter<ExternalKeyUpdateParamsProviderConfig?>
{
    public override ExternalKeyUpdateParamsProviderConfig? Read(
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
            case "aws":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAwsExternalKeyConfig>(
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
            case "gcp":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaGcpExternalKeyConfig>(
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
            case "azure":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAzureExternalKeyConfigParam>(
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
                return new ExternalKeyUpdateParamsProviderConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalKeyUpdateParamsProviderConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
