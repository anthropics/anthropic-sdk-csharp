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
/// `cloud` environment configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCloudConfig, BetaCloudConfigFromRaw>))]
public sealed record class BetaCloudConfig : JsonModel
{
    /// <summary>
    /// Network configuration policy.
    /// </summary>
    public required Networking Networking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Networking>("networking");
        }
        init { this._rawData.Set("networking", value); }
    }

    /// <summary>
    /// Package manager configuration.
    /// </summary>
    public required BetaPackages Packages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaPackages>("packages");
        }
        init { this._rawData.Set("packages", value); }
    }

    /// <summary>
    /// Environment type
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Networking.Validate();
        this.Packages.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("cloud")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCloudConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("cloud");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCloudConfig(BetaCloudConfig betaCloudConfig)
        : base(betaCloudConfig) { }
#pragma warning restore CS8618

    public BetaCloudConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("cloud");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCloudConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCloudConfigFromRaw.FromRawUnchecked"/>
    public static BetaCloudConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCloudConfigFromRaw : IFromRawJson<BetaCloudConfig>
{
    /// <inheritdoc/>
    public BetaCloudConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCloudConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Network configuration policy.
/// </summary>
[JsonConverter(typeof(NetworkingConverter))]
public record class Networking : ModelBase
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
            return Match(betaUnrestrictedNetwork: (x) => x.Type, betaLimitedNetwork: (x) => x.Type);
        }
    }

    public Networking(BetaUnrestrictedNetwork value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Networking(BetaLimitedNetwork value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Networking(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaUnrestrictedNetwork"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaUnrestrictedNetwork(out var value)) {
    ///     // `value` is of type `BetaUnrestrictedNetwork`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaUnrestrictedNetwork(
        [NotNullWhen(true)] out BetaUnrestrictedNetwork? value
    )
    {
        value = this.Value as BetaUnrestrictedNetwork;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaLimitedNetwork"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaLimitedNetwork(out var value)) {
    ///     // `value` is of type `BetaLimitedNetwork`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaLimitedNetwork([NotNullWhen(true)] out BetaLimitedNetwork? value)
    {
        value = this.Value as BetaLimitedNetwork;
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
    ///     (BetaUnrestrictedNetwork value) =&gt; {...},
    ///     (BetaLimitedNetwork value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaUnrestrictedNetwork> betaUnrestrictedNetwork,
        System::Action<BetaLimitedNetwork> betaLimitedNetwork
    )
    {
        switch (this.Value)
        {
            case BetaUnrestrictedNetwork value:
                betaUnrestrictedNetwork(value);
                break;
            case BetaLimitedNetwork value:
                betaLimitedNetwork(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Networking"
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
    ///     (BetaUnrestrictedNetwork value) =&gt; {...},
    ///     (BetaLimitedNetwork value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaUnrestrictedNetwork, T> betaUnrestrictedNetwork,
        System::Func<BetaLimitedNetwork, T> betaLimitedNetwork
    )
    {
        return this.Value switch
        {
            BetaUnrestrictedNetwork value => betaUnrestrictedNetwork(value),
            BetaLimitedNetwork value => betaLimitedNetwork(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Networking"
            ),
        };
    }

    public static implicit operator Networking(BetaUnrestrictedNetwork value) => new(value);

    public static implicit operator Networking(BetaLimitedNetwork value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Networking");
        }
        this.Switch(
            (betaUnrestrictedNetwork) => betaUnrestrictedNetwork.Validate(),
            (betaLimitedNetwork) => betaLimitedNetwork.Validate()
        );
    }

    public virtual bool Equals(Networking? other) =>
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
            BetaUnrestrictedNetwork _ => 0,
            BetaLimitedNetwork _ => 1,
            _ => -1,
        };
    }
}

sealed class NetworkingConverter : JsonConverter<Networking>
{
    public override Networking? Read(
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
            case "unrestricted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaUnrestrictedNetwork>(
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
            case "limited":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaLimitedNetwork>(
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
                return new Networking(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Networking value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
