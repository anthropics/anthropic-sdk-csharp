using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// CMEK external key config belonging to the caller's organization.
///
/// <para>Configs are organization-scoped. Workspaces attach to a config; once any
/// workspace references it, the provider fields become effectively immutable (existing
/// encrypted data needs the config for decrypt).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExternalKey, ExternalKeyFromRaw>))]
public sealed record class ExternalKey : JsonModel
{
    /// <summary>
    /// Identifier of the external key config. A tagged ID prefixed `ekey_`, or —
    /// for organizations on the Claude Platform on AWS — the AWS KMS key ARN.
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
    /// Whether any workspace uses this config to encrypt its data — counting live
    /// and archived workspaces (an archived workspace's data remains encrypted under
    /// the config), excluding deleted ones. Only an attached config is used by the
    /// encryption path; an `unattached` config is inert and can be deleted.
    /// </summary>
    public required Attachment Attachment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attachment>("attachment");
        }
        init { this._rawData.Set("attachment", value); }
    }

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
    /// Human-friendly display name. Null if none was set.
    /// </summary>
    public required string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// Data residency geo. Selects which regional validator handles this key's encrypt/decrypt roundtrips.
    /// </summary>
    public required string Geo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("geo");
        }
        init { this._rawData.Set("geo", value); }
    }

    /// <summary>
    /// KMS provider identity and auth coordinates.
    /// </summary>
    public required ExternalKeyProviderConfig ProviderConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExternalKeyProviderConfig>("provider_config");
        }
        init { this._rawData.Set("provider_config", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

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
        this.Attachment.Validate();
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Geo;
        this.ProviderConfig.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("external_key")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public ExternalKey()
    {
        this.Type = JsonSerializer.SerializeToElement("external_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKey(ExternalKey externalKey)
        : base(externalKey) { }
#pragma warning restore CS8618

    public ExternalKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyFromRaw.FromRawUnchecked"/>
    public static ExternalKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyFromRaw : IFromRawJson<ExternalKey>
{
    /// <inheritdoc/>
    public ExternalKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExternalKey.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether any workspace uses this config to encrypt its data — counting live and
/// archived workspaces (an archived workspace's data remains encrypted under the
/// config), excluding deleted ones. Only an attached config is used by the encryption
/// path; an `unattached` config is inert and can be deleted.
/// </summary>
[JsonConverter(typeof(AttachmentConverter))]
public record class Attachment : ModelBase
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
                ExternalKeyAttachedAttachment x => x.Type,
                ExternalKeyUnattachedAttachment x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Attachment(ExternalKeyAttachedAttachment value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Attachment(ExternalKeyUnattachedAttachment value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Attachment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExternalKeyAttachedAttachment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternalKeyAttached(out var value)) {
    ///     // `value` is of type `ExternalKeyAttachedAttachment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternalKeyAttached(
        [NotNullWhen(true)] out ExternalKeyAttachedAttachment? value
    )
    {
        value = this.Value as ExternalKeyAttachedAttachment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExternalKeyUnattachedAttachment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternalKeyUnattached(out var value)) {
    ///     // `value` is of type `ExternalKeyUnattachedAttachment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternalKeyUnattached(
        [NotNullWhen(true)] out ExternalKeyUnattachedAttachment? value
    )
    {
        value = this.Value as ExternalKeyUnattachedAttachment;
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
    ///     (ExternalKeyAttachedAttachment value) =&gt; {...},
    ///     (ExternalKeyUnattachedAttachment value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ExternalKeyAttachedAttachment> externalKeyAttached,
        Action<ExternalKeyUnattachedAttachment> externalKeyUnattached
    )
    {
        switch (this.Value)
        {
            case ExternalKeyAttachedAttachment value:
                externalKeyAttached(value);
                break;
            case ExternalKeyUnattachedAttachment value:
                externalKeyUnattached(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Attachment"
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
    ///     (ExternalKeyAttachedAttachment value) =&gt; {...},
    ///     (ExternalKeyUnattachedAttachment value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ExternalKeyAttachedAttachment, T> externalKeyAttached,
        Func<ExternalKeyUnattachedAttachment, T> externalKeyUnattached
    )
    {
        return this.Value switch
        {
            ExternalKeyAttachedAttachment value => externalKeyAttached(value),
            ExternalKeyUnattachedAttachment value => externalKeyUnattached(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Attachment"
            ),
        };
    }

    public static implicit operator Attachment(ExternalKeyAttachedAttachment value) => new(value);

    public static implicit operator Attachment(ExternalKeyUnattachedAttachment value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Attachment");
        }
        this.Switch(
            (externalKeyAttached) => externalKeyAttached.Validate(),
            (externalKeyUnattached) => externalKeyUnattached.Validate()
        );
    }

    public virtual bool Equals(Attachment? other) =>
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
            ExternalKeyAttachedAttachment _ => 0,
            ExternalKeyUnattachedAttachment _ => 1,
            _ => -1,
        };
    }
}

sealed class AttachmentConverter : JsonConverter<Attachment>
{
    public override Attachment? Read(
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
            case "attached":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExternalKeyAttachedAttachment>(
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
            case "unattached":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExternalKeyUnattachedAttachment>(
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
                return new Attachment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Attachment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// KMS provider identity and auth coordinates.
/// </summary>
[JsonConverter(typeof(ExternalKeyProviderConfigConverter))]
public record class ExternalKeyProviderConfig : ModelBase
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
                AwsExternalKeyConfig x => x.Type,
                GcpExternalKeyConfig x => x.Type,
                AzureExternalKeyConfig x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public string? KeyName
    {
        get
        {
            return this.Value switch
            {
                AwsExternalKeyConfig _ => null,
                GcpExternalKeyConfig x => x.KeyName,
                AzureExternalKeyConfig x => x.KeyName,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "key_name"),
            };
        }
    }

    public ExternalKeyProviderConfig(AwsExternalKeyConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExternalKeyProviderConfig(GcpExternalKeyConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExternalKeyProviderConfig(AzureExternalKeyConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExternalKeyProviderConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AwsExternalKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAwsExternalKey(out var value)) {
    ///     // `value` is of type `AwsExternalKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAwsExternalKey([NotNullWhen(true)] out AwsExternalKeyConfig? value)
    {
        value = this.Value as AwsExternalKeyConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GcpExternalKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGcpExternalKey(out var value)) {
    ///     // `value` is of type `GcpExternalKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGcpExternalKey([NotNullWhen(true)] out GcpExternalKeyConfig? value)
    {
        value = this.Value as GcpExternalKeyConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AzureExternalKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureExternalKey(out var value)) {
    ///     // `value` is of type `AzureExternalKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureExternalKey([NotNullWhen(true)] out AzureExternalKeyConfig? value)
    {
        value = this.Value as AzureExternalKeyConfig;
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
    ///     (AwsExternalKeyConfig value) =&gt; {...},
    ///     (GcpExternalKeyConfig value) =&gt; {...},
    ///     (AzureExternalKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<AwsExternalKeyConfig> awsExternalKey,
        Action<GcpExternalKeyConfig> gcpExternalKey,
        Action<AzureExternalKeyConfig> azureExternalKey
    )
    {
        switch (this.Value)
        {
            case AwsExternalKeyConfig value:
                awsExternalKey(value);
                break;
            case GcpExternalKeyConfig value:
                gcpExternalKey(value);
                break;
            case AzureExternalKeyConfig value:
                azureExternalKey(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ExternalKeyProviderConfig"
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
    ///     (AwsExternalKeyConfig value) =&gt; {...},
    ///     (GcpExternalKeyConfig value) =&gt; {...},
    ///     (AzureExternalKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<AwsExternalKeyConfig, T> awsExternalKey,
        Func<GcpExternalKeyConfig, T> gcpExternalKey,
        Func<AzureExternalKeyConfig, T> azureExternalKey
    )
    {
        return this.Value switch
        {
            AwsExternalKeyConfig value => awsExternalKey(value),
            GcpExternalKeyConfig value => gcpExternalKey(value),
            AzureExternalKeyConfig value => azureExternalKey(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ExternalKeyProviderConfig"
            ),
        };
    }

    public static implicit operator ExternalKeyProviderConfig(AwsExternalKeyConfig value) =>
        new(value);

    public static implicit operator ExternalKeyProviderConfig(GcpExternalKeyConfig value) =>
        new(value);

    public static implicit operator ExternalKeyProviderConfig(AzureExternalKeyConfig value) =>
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
                "Data did not match any variant of ExternalKeyProviderConfig"
            );
        }
        this.Switch(
            (awsExternalKey) => awsExternalKey.Validate(),
            (gcpExternalKey) => gcpExternalKey.Validate(),
            (azureExternalKey) => azureExternalKey.Validate()
        );
    }

    public virtual bool Equals(ExternalKeyProviderConfig? other) =>
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
            AwsExternalKeyConfig _ => 0,
            GcpExternalKeyConfig _ => 1,
            AzureExternalKeyConfig _ => 2,
            _ => -1,
        };
    }
}

sealed class ExternalKeyProviderConfigConverter : JsonConverter<ExternalKeyProviderConfig>
{
    public override ExternalKeyProviderConfig? Read(
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
                    var deserialized = JsonSerializer.Deserialize<AwsExternalKeyConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<GcpExternalKeyConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<AzureExternalKeyConfig>(
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
                return new ExternalKeyProviderConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalKeyProviderConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
