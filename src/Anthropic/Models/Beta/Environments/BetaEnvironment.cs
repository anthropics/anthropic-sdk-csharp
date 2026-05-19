using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Unified Environment resource for both cloud and self-hosted environments.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaEnvironment, BetaEnvironmentFromRaw>))]
public sealed record class BetaEnvironment : JsonModel
{
    /// <summary>
    /// Environment identifier (e.g., 'env_...')
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
    /// RFC 3339 timestamp when environment was archived, or null if not archived
    /// </summary>
    public required string? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Environment configuration (either Anthropic Cloud or self-hosted)
    /// </summary>
    public required BetaEnvironmentConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaEnvironmentConfig>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp when environment was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// User-provided description for the environment
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// User-provided metadata key-value pairs
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Human-readable name for the environment
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The type of object (always 'environment')
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
    /// RFC 3339 timestamp when environment was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// The visibility scope for this environment. 'organization' means visible to
    /// all accounts. 'account' means visible only to the owning account.
    /// </summary>
    public ApiEnum<string, BetaEnvironmentScope>? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaEnvironmentScope>>("scope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scope", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        this.Config.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("environment")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        this.Scope?.Validate();
    }

    public BetaEnvironment()
    {
        this.Type = JsonSerializer.SerializeToElement("environment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironment(BetaEnvironment betaEnvironment)
        : base(betaEnvironment) { }
#pragma warning restore CS8618

    public BetaEnvironment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("environment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentFromRaw.FromRawUnchecked"/>
    public static BetaEnvironment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentFromRaw : IFromRawJson<BetaEnvironment>
{
    /// <inheritdoc/>
    public BetaEnvironment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaEnvironment.FromRawUnchecked(rawData);
}

/// <summary>
/// Environment configuration (either Anthropic Cloud or self-hosted)
/// </summary>
[JsonConverter(typeof(BetaEnvironmentConfigConverter))]
public record class BetaEnvironmentConfig : ModelBase
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
        get { return Match(betaCloud: (x) => x.Type, betaSelfHosted: (x) => x.Type); }
    }

    public BetaEnvironmentConfig(BetaCloudConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaEnvironmentConfig(BetaSelfHostedConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaEnvironmentConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCloudConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCloud(out var value)) {
    ///     // `value` is of type `BetaCloudConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCloud([NotNullWhen(true)] out BetaCloudConfig? value)
    {
        value = this.Value as BetaCloudConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSelfHostedConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSelfHosted(out var value)) {
    ///     // `value` is of type `BetaSelfHostedConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSelfHosted([NotNullWhen(true)] out BetaSelfHostedConfig? value)
    {
        value = this.Value as BetaSelfHostedConfig;
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
    ///     (BetaCloudConfig value) =&gt; {...},
    ///     (BetaSelfHostedConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCloudConfig> betaCloud,
        System::Action<BetaSelfHostedConfig> betaSelfHosted
    )
    {
        switch (this.Value)
        {
            case BetaCloudConfig value:
                betaCloud(value);
                break;
            case BetaSelfHostedConfig value:
                betaSelfHosted(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaEnvironmentConfig"
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
    ///     (BetaCloudConfig value) =&gt; {...},
    ///     (BetaSelfHostedConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCloudConfig, T> betaCloud,
        System::Func<BetaSelfHostedConfig, T> betaSelfHosted
    )
    {
        return this.Value switch
        {
            BetaCloudConfig value => betaCloud(value),
            BetaSelfHostedConfig value => betaSelfHosted(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaEnvironmentConfig"
            ),
        };
    }

    public static implicit operator BetaEnvironmentConfig(BetaCloudConfig value) => new(value);

    public static implicit operator BetaEnvironmentConfig(BetaSelfHostedConfig value) => new(value);

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
                "Data did not match any variant of BetaEnvironmentConfig"
            );
        }
        this.Switch(
            (betaCloud) => betaCloud.Validate(),
            (betaSelfHosted) => betaSelfHosted.Validate()
        );
    }

    public virtual bool Equals(BetaEnvironmentConfig? other) =>
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
            BetaCloudConfig _ => 0,
            BetaSelfHostedConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaEnvironmentConfigConverter : JsonConverter<BetaEnvironmentConfig>
{
    public override BetaEnvironmentConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            case "cloud":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCloudConfig>(
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
            case "self_hosted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSelfHostedConfig>(
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
                return new BetaEnvironmentConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaEnvironmentConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// The visibility scope for this environment. 'organization' means visible to all
/// accounts. 'account' means visible only to the owning account.
/// </summary>
[JsonConverter(typeof(BetaEnvironmentScopeConverter))]
public enum BetaEnvironmentScope
{
    Organization,
    Account,
}

sealed class BetaEnvironmentScopeConverter : JsonConverter<BetaEnvironmentScope>
{
    public override BetaEnvironmentScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => BetaEnvironmentScope.Organization,
            "account" => BetaEnvironmentScope.Account,
            _ => (BetaEnvironmentScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaEnvironmentScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaEnvironmentScope.Organization => "organization",
                BetaEnvironmentScope.Account => "account",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
