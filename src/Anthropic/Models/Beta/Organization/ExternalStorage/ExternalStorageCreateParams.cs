using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// Register a bucket in the organization's own cloud account. It is saved as `pending_configuration`
/// and verified when activated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalStorageCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required ProviderConfig ProviderConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ProviderConfig>("provider_config");
        }
        init { this._rawBodyData.Set("provider_config", value); }
    }

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
    /// The user profile to bind the storage to. It can't be changed later. The storage
    /// can be attached only to Workspaces with this profile, and the bucket's setup
    /// must name the same ID.
    /// </summary>
    public string? UserProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("user_profile_id");
        }
        init { this._rawBodyData.Set("user_profile_id", value); }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `efs-2026-10-01` in this header.
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

    public ExternalStorageCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalStorageCreateParams(ExternalStorageCreateParams externalStorageCreateParams)
        : base(externalStorageCreateParams)
    {
        this._rawBodyData = new(externalStorageCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExternalStorageCreateParams(
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
    ExternalStorageCreateParams(
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
    public static ExternalStorageCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ExternalStorageCreateParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/external_storage"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/external_storage";

    internal override HttpContent? BodyContent()
    {
        return ParamsBase.JsonBodyContent(this.RawBodyData);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        ExternalStorageService.AddDefaultHeaders(request);
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

[JsonConverter(typeof(ProviderConfigConverter))]
public record class ProviderConfig : ModelBase
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

    public string BucketName
    {
        get
        {
            return this.Value switch
            {
                BetaAwsExternalStorageConfigParam x => x.BucketName,
                BetaGcpExternalStorageConfigParam x => x.BucketName,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(
                    this.Json,
                    "bucket_name"
                ),
            };
        }
    }

    public string Region
    {
        get
        {
            return this.Value switch
            {
                BetaAwsExternalStorageConfigParam x => x.Region,
                BetaGcpExternalStorageConfigParam x => x.Region,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "region"),
            };
        }
    }

    public ApiEnum<string, ProviderConfigType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaAwsExternalStorageConfigParam _ => ProviderConfigType.Aws,
                BetaGcpExternalStorageConfigParam _ => ProviderConfigType.Gcp,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, ProviderConfigType>
                >(this.Json, "type"),
            };
        }
    }

    public ProviderConfig(BetaAwsExternalStorageConfigParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ProviderConfig(BetaGcpExternalStorageConfigParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ProviderConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAwsExternalStorageConfigParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAwsExternalStorageConfigParam(out var value)) {
    ///     // `value` is of type `BetaAwsExternalStorageConfigParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAwsExternalStorageConfigParam(
        [NotNullWhen(true)] out BetaAwsExternalStorageConfigParam? value
    )
    {
        value = this.Value as BetaAwsExternalStorageConfigParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGcpExternalStorageConfigParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaGcpExternalStorageConfigParam(out var value)) {
    ///     // `value` is of type `BetaGcpExternalStorageConfigParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaGcpExternalStorageConfigParam(
        [NotNullWhen(true)] out BetaGcpExternalStorageConfigParam? value
    )
    {
        value = this.Value as BetaGcpExternalStorageConfigParam;
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
    ///     (BetaAwsExternalStorageConfigParam value) =&gt; {...},
    ///     (BetaGcpExternalStorageConfigParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaAwsExternalStorageConfigParam> betaAwsExternalStorageConfigParam,
        Action<BetaGcpExternalStorageConfigParam> betaGcpExternalStorageConfigParam
    )
    {
        switch (this.Value)
        {
            case BetaAwsExternalStorageConfigParam value:
                betaAwsExternalStorageConfigParam(value);
                break;
            case BetaGcpExternalStorageConfigParam value:
                betaGcpExternalStorageConfigParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ProviderConfig"
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
    ///     (BetaAwsExternalStorageConfigParam value) =&gt; {...},
    ///     (BetaGcpExternalStorageConfigParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaAwsExternalStorageConfigParam, T> betaAwsExternalStorageConfigParam,
        Func<BetaGcpExternalStorageConfigParam, T> betaGcpExternalStorageConfigParam
    )
    {
        return this.Value switch
        {
            BetaAwsExternalStorageConfigParam value => betaAwsExternalStorageConfigParam(value),
            BetaGcpExternalStorageConfigParam value => betaGcpExternalStorageConfigParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ProviderConfig"
            ),
        };
    }

    public static implicit operator ProviderConfig(BetaAwsExternalStorageConfigParam value) =>
        new(value);

    public static implicit operator ProviderConfig(BetaGcpExternalStorageConfigParam value) =>
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
                "Data did not match any variant of ProviderConfig"
            );
        }
        this.Switch(
            (betaAwsExternalStorageConfigParam) => betaAwsExternalStorageConfigParam.Validate(),
            (betaGcpExternalStorageConfigParam) => betaGcpExternalStorageConfigParam.Validate()
        );
    }

    public virtual bool Equals(ProviderConfig? other) =>
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
            BetaAwsExternalStorageConfigParam _ => 0,
            BetaGcpExternalStorageConfigParam _ => 1,
            _ => -1,
        };
    }
}

sealed class ProviderConfigConverter : JsonConverter<ProviderConfig>
{
    public override ProviderConfig? Read(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaAwsExternalStorageConfigParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGcpExternalStorageConfigParam>(
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
                return new ProviderConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ProviderConfigTypeConverter))]
public enum ProviderConfigType
{
    Aws = 1206082585,
    Gcp = 1474161881,
}

sealed class ProviderConfigTypeConverter : JsonConverter<ProviderConfigType>
{
    public override ProviderConfigType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws" => ProviderConfigType.Aws,
            "gcp" => ProviderConfigType.Gcp,
            _ => (ProviderConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProviderConfigType.Aws => "aws",
                ProviderConfigType.Gcp => "gcp",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
