using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// A storage bucket in the organization's own cloud account. Anthropic writes inference
/// data to it from each Workspace it is attached to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaExternalStorage, BetaExternalStorageFromRaw>))]
public sealed record class BetaExternalStorage : JsonModel
{
    /// <summary>
    /// The External Storage ID, which starts with `estrg_`. Through Claude Platform
    /// on AWS, storage whose `provider_config.type` is `aws` has its bucket ARN
    /// as its ID instead: `arn:&lt;partition&gt;:s3:::&lt;bucket_name&gt;`, where
    /// `&lt;partition&gt;` is the partition of the bucket's region.
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

    public required BetaExternalStorageProviderConfig ProviderConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaExternalStorageProviderConfig>(
                "provider_config"
            );
        }
        init { this._rawData.Set("provider_config", value); }
    }

    /// <summary>
    /// The version of Anthropic's setup template whose IAM role names this storage
    /// was found to use at activation. Null if no version was recorded, as for storage
    /// not yet activated or not on S3.
    /// </summary>
    public required string? SetupTemplateVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("setup_template_version");
        }
        init { this._rawData.Set("setup_template_version", value); }
    }

    public required Status Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Status>("status");
        }
        init { this._rawData.Set("status", value); }
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

    /// <summary>
    /// The user profile the storage is bound to, or null.
    /// </summary>
    public required string? UserProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_profile_id");
        }
        init { this._rawData.Set("user_profile_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        this.ProviderConfig.Validate();
        _ = this.SetupTemplateVersion;
        this.Status.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("external_storage")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.UserProfileID;
    }

    public BetaExternalStorage()
    {
        this.Type = JsonSerializer.SerializeToElement("external_storage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalStorage(BetaExternalStorage betaExternalStorage)
        : base(betaExternalStorage) { }
#pragma warning restore CS8618

    public BetaExternalStorage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_storage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalStorage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalStorageFromRaw.FromRawUnchecked"/>
    public static BetaExternalStorage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalStorageFromRaw : IFromRawJson<BetaExternalStorage>
{
    /// <inheritdoc/>
    public BetaExternalStorage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaExternalStorage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaExternalStorageProviderConfigConverter))]
public record class BetaExternalStorageProviderConfig : ModelBase
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
                BetaAwsExternalStorageConfig x => x.BucketName,
                BetaGcpExternalStorageConfig x => x.BucketName,
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
                BetaAwsExternalStorageConfig x => x.Region,
                BetaGcpExternalStorageConfig x => x.Region,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "region"),
            };
        }
    }

    public ApiEnum<string, BetaExternalStorageProviderConfigType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaAwsExternalStorageConfig _ => BetaExternalStorageProviderConfigType.Aws,
                BetaGcpExternalStorageConfig _ => BetaExternalStorageProviderConfigType.Gcp,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaExternalStorageProviderConfigType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaExternalStorageProviderConfig(
        BetaAwsExternalStorageConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaExternalStorageProviderConfig(
        BetaGcpExternalStorageConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaExternalStorageProviderConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAwsExternalStorageConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAwsExternalStorage(out var value)) {
    ///     // `value` is of type `BetaAwsExternalStorageConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAwsExternalStorage(
        [NotNullWhen(true)] out BetaAwsExternalStorageConfig? value
    )
    {
        value = this.Value as BetaAwsExternalStorageConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGcpExternalStorageConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaGcpExternalStorage(out var value)) {
    ///     // `value` is of type `BetaGcpExternalStorageConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaGcpExternalStorage(
        [NotNullWhen(true)] out BetaGcpExternalStorageConfig? value
    )
    {
        value = this.Value as BetaGcpExternalStorageConfig;
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
    ///     (BetaAwsExternalStorageConfig value) =&gt; {...},
    ///     (BetaGcpExternalStorageConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaAwsExternalStorageConfig> betaAwsExternalStorage,
        Action<BetaGcpExternalStorageConfig> betaGcpExternalStorage
    )
    {
        switch (this.Value)
        {
            case BetaAwsExternalStorageConfig value:
                betaAwsExternalStorage(value);
                break;
            case BetaGcpExternalStorageConfig value:
                betaGcpExternalStorage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaExternalStorageProviderConfig"
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
    ///     (BetaAwsExternalStorageConfig value) =&gt; {...},
    ///     (BetaGcpExternalStorageConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaAwsExternalStorageConfig, T> betaAwsExternalStorage,
        Func<BetaGcpExternalStorageConfig, T> betaGcpExternalStorage
    )
    {
        return this.Value switch
        {
            BetaAwsExternalStorageConfig value => betaAwsExternalStorage(value),
            BetaGcpExternalStorageConfig value => betaGcpExternalStorage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaExternalStorageProviderConfig"
            ),
        };
    }

    public static implicit operator BetaExternalStorageProviderConfig(
        BetaAwsExternalStorageConfig value
    ) => new(value);

    public static implicit operator BetaExternalStorageProviderConfig(
        BetaGcpExternalStorageConfig value
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
                "Data did not match any variant of BetaExternalStorageProviderConfig"
            );
        }
        this.Switch(
            (betaAwsExternalStorage) => betaAwsExternalStorage.Validate(),
            (betaGcpExternalStorage) => betaGcpExternalStorage.Validate()
        );
    }

    public virtual bool Equals(BetaExternalStorageProviderConfig? other) =>
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
            BetaAwsExternalStorageConfig _ => 0,
            BetaGcpExternalStorageConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaExternalStorageProviderConfigConverter
    : JsonConverter<BetaExternalStorageProviderConfig>
{
    public override BetaExternalStorageProviderConfig? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaAwsExternalStorageConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaGcpExternalStorageConfig>(
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
                return new BetaExternalStorageProviderConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaExternalStorageProviderConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaExternalStorageProviderConfigTypeConverter))]
public enum BetaExternalStorageProviderConfigType
{
    Aws = 1206082585,
    Gcp = 1474161881,
}

sealed class BetaExternalStorageProviderConfigTypeConverter
    : JsonConverter<BetaExternalStorageProviderConfigType>
{
    public override BetaExternalStorageProviderConfigType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws" => BetaExternalStorageProviderConfigType.Aws,
            "gcp" => BetaExternalStorageProviderConfigType.Gcp,
            _ => (BetaExternalStorageProviderConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaExternalStorageProviderConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaExternalStorageProviderConfigType.Aws => "aws",
                BetaExternalStorageProviderConfigType.Gcp => "gcp",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public record class Status : ModelBase
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

    public ApiEnum<string, StatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaPendingConfigurationExternalStorageStatus _ => StatusType.PendingConfiguration,
                BetaAvailableExternalStorageStatus _ => StatusType.Available,
                BetaActiveExternalStorageStatus _ => StatusType.Active,
                BetaDrainingExternalStorageStatus _ => StatusType.Draining,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, StatusType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public bool? Healthy
    {
        get
        {
            return this.Value switch
            {
                BetaPendingConfigurationExternalStorageStatus _ => null,
                BetaAvailableExternalStorageStatus x => x.Healthy,
                BetaActiveExternalStorageStatus x => x.Healthy,
                BetaDrainingExternalStorageStatus x => x.Healthy,
                _ => WrappedJsonSerializer.GetNullableStructProperty<bool>(this.Json, "healthy"),
            };
        }
    }

    public DateTimeOffset? LastCheckedAt
    {
        get
        {
            return this.Value switch
            {
                BetaPendingConfigurationExternalStorageStatus _ => null,
                BetaAvailableExternalStorageStatus x => x.LastCheckedAt,
                BetaActiveExternalStorageStatus x => x.LastCheckedAt,
                BetaDrainingExternalStorageStatus x => x.LastCheckedAt,
                _ => WrappedJsonSerializer.GetNullableStructProperty<DateTimeOffset>(
                    this.Json,
                    "last_checked_at"
                ),
            };
        }
    }

    public Status(BetaPendingConfigurationExternalStorageStatus value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Status(BetaAvailableExternalStorageStatus value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Status(BetaActiveExternalStorageStatus value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Status(BetaDrainingExternalStorageStatus value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Status(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPendingConfigurationExternalStorageStatus"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPendingConfigurationExternalStorage(out var value)) {
    ///     // `value` is of type `BetaPendingConfigurationExternalStorageStatus`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPendingConfigurationExternalStorage(
        [NotNullWhen(true)] out BetaPendingConfigurationExternalStorageStatus? value
    )
    {
        value = this.Value as BetaPendingConfigurationExternalStorageStatus;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAvailableExternalStorageStatus"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAvailableExternalStorage(out var value)) {
    ///     // `value` is of type `BetaAvailableExternalStorageStatus`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAvailableExternalStorage(
        [NotNullWhen(true)] out BetaAvailableExternalStorageStatus? value
    )
    {
        value = this.Value as BetaAvailableExternalStorageStatus;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaActiveExternalStorageStatus"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaActiveExternalStorage(out var value)) {
    ///     // `value` is of type `BetaActiveExternalStorageStatus`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaActiveExternalStorage(
        [NotNullWhen(true)] out BetaActiveExternalStorageStatus? value
    )
    {
        value = this.Value as BetaActiveExternalStorageStatus;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDrainingExternalStorageStatus"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaDrainingExternalStorage(out var value)) {
    ///     // `value` is of type `BetaDrainingExternalStorageStatus`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaDrainingExternalStorage(
        [NotNullWhen(true)] out BetaDrainingExternalStorageStatus? value
    )
    {
        value = this.Value as BetaDrainingExternalStorageStatus;
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
    ///     (BetaPendingConfigurationExternalStorageStatus value) =&gt; {...},
    ///     (BetaAvailableExternalStorageStatus value) =&gt; {...},
    ///     (BetaActiveExternalStorageStatus value) =&gt; {...},
    ///     (BetaDrainingExternalStorageStatus value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaPendingConfigurationExternalStorageStatus> betaPendingConfigurationExternalStorage,
        Action<BetaAvailableExternalStorageStatus> betaAvailableExternalStorage,
        Action<BetaActiveExternalStorageStatus> betaActiveExternalStorage,
        Action<BetaDrainingExternalStorageStatus> betaDrainingExternalStorage
    )
    {
        switch (this.Value)
        {
            case BetaPendingConfigurationExternalStorageStatus value:
                betaPendingConfigurationExternalStorage(value);
                break;
            case BetaAvailableExternalStorageStatus value:
                betaAvailableExternalStorage(value);
                break;
            case BetaActiveExternalStorageStatus value:
                betaActiveExternalStorage(value);
                break;
            case BetaDrainingExternalStorageStatus value:
                betaDrainingExternalStorage(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Status");
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
    ///     (BetaPendingConfigurationExternalStorageStatus value) =&gt; {...},
    ///     (BetaAvailableExternalStorageStatus value) =&gt; {...},
    ///     (BetaActiveExternalStorageStatus value) =&gt; {...},
    ///     (BetaDrainingExternalStorageStatus value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            BetaPendingConfigurationExternalStorageStatus,
            T
        > betaPendingConfigurationExternalStorage,
        Func<BetaAvailableExternalStorageStatus, T> betaAvailableExternalStorage,
        Func<BetaActiveExternalStorageStatus, T> betaActiveExternalStorage,
        Func<BetaDrainingExternalStorageStatus, T> betaDrainingExternalStorage
    )
    {
        return this.Value switch
        {
            BetaPendingConfigurationExternalStorageStatus value =>
                betaPendingConfigurationExternalStorage(value),
            BetaAvailableExternalStorageStatus value => betaAvailableExternalStorage(value),
            BetaActiveExternalStorageStatus value => betaActiveExternalStorage(value),
            BetaDrainingExternalStorageStatus value => betaDrainingExternalStorage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Status"
            ),
        };
    }

    public static implicit operator Status(BetaPendingConfigurationExternalStorageStatus value) =>
        new(value);

    public static implicit operator Status(BetaAvailableExternalStorageStatus value) => new(value);

    public static implicit operator Status(BetaActiveExternalStorageStatus value) => new(value);

    public static implicit operator Status(BetaDrainingExternalStorageStatus value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Status");
        }
        this.Switch(
            (betaPendingConfigurationExternalStorage) =>
                betaPendingConfigurationExternalStorage.Validate(),
            (betaAvailableExternalStorage) => betaAvailableExternalStorage.Validate(),
            (betaActiveExternalStorage) => betaActiveExternalStorage.Validate(),
            (betaDrainingExternalStorage) => betaDrainingExternalStorage.Validate()
        );
    }

    public virtual bool Equals(Status? other) =>
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
            BetaPendingConfigurationExternalStorageStatus _ => 0,
            BetaAvailableExternalStorageStatus _ => 1,
            BetaActiveExternalStorageStatus _ => 2,
            BetaDrainingExternalStorageStatus _ => 3,
            _ => -1,
        };
    }
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status? Read(
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
            case "pending_configuration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaPendingConfigurationExternalStorageStatus>(
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
            case "available":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaAvailableExternalStorageStatus>(
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
            case "active":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaActiveExternalStorageStatus>(
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
            case "draining":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaDrainingExternalStorageStatus>(
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
                return new Status(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(StatusTypeConverter))]
public enum StatusType
{
    PendingConfiguration = 1530210094,
    Available = 1169705318,
    Active = 1837619551,
    Draining = 55463168,
}

sealed class StatusTypeConverter : JsonConverter<StatusType>
{
    public override StatusType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_configuration" => StatusType.PendingConfiguration,
            "available" => StatusType.Available,
            "active" => StatusType.Active,
            "draining" => StatusType.Draining,
            _ => (StatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusType.PendingConfiguration => "pending_configuration",
                StatusType.Available => "available",
                StatusType.Active => "active",
                StatusType.Draining => "draining",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
