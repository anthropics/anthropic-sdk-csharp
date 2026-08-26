using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

/// <summary>
/// CMEK external key config belonging to the caller's organization.
///
/// <para>Configs are organization-scoped. Workspaces attach to a config; once any
/// workspace references it, the provider fields become effectively immutable (existing
/// encrypted data needs the config for decrypt).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaExternalKey, BetaExternalKeyFromRaw>))]
public sealed record class BetaExternalKey : JsonModel
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
    public required BetaExternalKeyProviderConfig ProviderConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaExternalKeyProviderConfig>("provider_config");
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

    public BetaExternalKey()
    {
        this.Type = JsonSerializer.SerializeToElement("external_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalKey(BetaExternalKey betaExternalKey)
        : base(betaExternalKey) { }
#pragma warning restore CS8618

    public BetaExternalKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalKeyFromRaw.FromRawUnchecked"/>
    public static BetaExternalKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalKeyFromRaw : IFromRawJson<BetaExternalKey>
{
    /// <inheritdoc/>
    public BetaExternalKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaExternalKey.FromRawUnchecked(rawData);
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
            return Match(
                betaExternalKeyAttached: (x) => x.Type,
                betaExternalKeyUnattached: (x) => x.Type
            );
        }
    }

    public Attachment(BetaExternalKeyAttachedAttachment value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Attachment(BetaExternalKeyUnattachedAttachment value, JsonElement? element = null)
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
    /// type <see cref="BetaExternalKeyAttachedAttachment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaExternalKeyAttached(out var value)) {
    ///     // `value` is of type `BetaExternalKeyAttachedAttachment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaExternalKeyAttached(
        [NotNullWhen(true)] out BetaExternalKeyAttachedAttachment? value
    )
    {
        value = this.Value as BetaExternalKeyAttachedAttachment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaExternalKeyUnattachedAttachment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaExternalKeyUnattached(out var value)) {
    ///     // `value` is of type `BetaExternalKeyUnattachedAttachment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaExternalKeyUnattached(
        [NotNullWhen(true)] out BetaExternalKeyUnattachedAttachment? value
    )
    {
        value = this.Value as BetaExternalKeyUnattachedAttachment;
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
    ///     (BetaExternalKeyAttachedAttachment value) =&gt; {...},
    ///     (BetaExternalKeyUnattachedAttachment value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaExternalKeyAttachedAttachment> betaExternalKeyAttached,
        Action<BetaExternalKeyUnattachedAttachment> betaExternalKeyUnattached
    )
    {
        switch (this.Value)
        {
            case BetaExternalKeyAttachedAttachment value:
                betaExternalKeyAttached(value);
                break;
            case BetaExternalKeyUnattachedAttachment value:
                betaExternalKeyUnattached(value);
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
    ///     (BetaExternalKeyAttachedAttachment value) =&gt; {...},
    ///     (BetaExternalKeyUnattachedAttachment value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaExternalKeyAttachedAttachment, T> betaExternalKeyAttached,
        Func<BetaExternalKeyUnattachedAttachment, T> betaExternalKeyUnattached
    )
    {
        return this.Value switch
        {
            BetaExternalKeyAttachedAttachment value => betaExternalKeyAttached(value),
            BetaExternalKeyUnattachedAttachment value => betaExternalKeyUnattached(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Attachment"
            ),
        };
    }

    public static implicit operator Attachment(BetaExternalKeyAttachedAttachment value) =>
        new(value);

    public static implicit operator Attachment(BetaExternalKeyUnattachedAttachment value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Attachment");
        }
        this.Switch(
            (betaExternalKeyAttached) => betaExternalKeyAttached.Validate(),
            (betaExternalKeyUnattached) => betaExternalKeyUnattached.Validate()
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
            BetaExternalKeyAttachedAttachment _ => 0,
            BetaExternalKeyUnattachedAttachment _ => 1,
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaExternalKeyAttachedAttachment>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaExternalKeyUnattachedAttachment>(
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
[JsonConverter(typeof(BetaExternalKeyProviderConfigConverter))]
public record class BetaExternalKeyProviderConfig : ModelBase
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
                betaAzureExternalKey: (x) => x.Type
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
                betaAzureExternalKey: (x) => x.KeyName
            );
        }
    }

    public BetaExternalKeyProviderConfig(
        BetaAwsExternalKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaExternalKeyProviderConfig(
        BetaGcpExternalKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaExternalKeyProviderConfig(
        BetaAzureExternalKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaExternalKeyProviderConfig(JsonElement element)
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
    /// type <see cref="BetaAzureExternalKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAzureExternalKey(out var value)) {
    ///     // `value` is of type `BetaAzureExternalKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAzureExternalKey(
        [NotNullWhen(true)] out BetaAzureExternalKeyConfig? value
    )
    {
        value = this.Value as BetaAzureExternalKeyConfig;
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
    ///     (BetaAzureExternalKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaAwsExternalKeyConfig> betaAwsExternalKey,
        Action<BetaGcpExternalKeyConfig> betaGcpExternalKey,
        Action<BetaAzureExternalKeyConfig> betaAzureExternalKey
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
            case BetaAzureExternalKeyConfig value:
                betaAzureExternalKey(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaExternalKeyProviderConfig"
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
    ///     (BetaAzureExternalKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaAwsExternalKeyConfig, T> betaAwsExternalKey,
        Func<BetaGcpExternalKeyConfig, T> betaGcpExternalKey,
        Func<BetaAzureExternalKeyConfig, T> betaAzureExternalKey
    )
    {
        return this.Value switch
        {
            BetaAwsExternalKeyConfig value => betaAwsExternalKey(value),
            BetaGcpExternalKeyConfig value => betaGcpExternalKey(value),
            BetaAzureExternalKeyConfig value => betaAzureExternalKey(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaExternalKeyProviderConfig"
            ),
        };
    }

    public static implicit operator BetaExternalKeyProviderConfig(BetaAwsExternalKeyConfig value) =>
        new(value);

    public static implicit operator BetaExternalKeyProviderConfig(BetaGcpExternalKeyConfig value) =>
        new(value);

    public static implicit operator BetaExternalKeyProviderConfig(
        BetaAzureExternalKeyConfig value
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
                "Data did not match any variant of BetaExternalKeyProviderConfig"
            );
        }
        this.Switch(
            (betaAwsExternalKey) => betaAwsExternalKey.Validate(),
            (betaGcpExternalKey) => betaGcpExternalKey.Validate(),
            (betaAzureExternalKey) => betaAzureExternalKey.Validate()
        );
    }

    public virtual bool Equals(BetaExternalKeyProviderConfig? other) =>
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
            BetaAzureExternalKeyConfig _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaExternalKeyProviderConfigConverter : JsonConverter<BetaExternalKeyProviderConfig>
{
    public override BetaExternalKeyProviderConfig? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaAzureExternalKeyConfig>(
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
                return new BetaExternalKeyProviderConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaExternalKeyProviderConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
