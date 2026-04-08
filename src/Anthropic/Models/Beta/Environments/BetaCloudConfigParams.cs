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
/// Request params for `cloud` environment configuration.
///
/// <para>Fields default to null; on update, omitted fields preserve the existing value.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCloudConfigParams, BetaCloudConfigParamsFromRaw>))]
public sealed record class BetaCloudConfigParams : JsonModel
{
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

    /// <summary>
    /// Network configuration policy. Omit on update to preserve the existing value.
    /// </summary>
    public BetaCloudConfigParamsNetworking? Networking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCloudConfigParamsNetworking>("networking");
        }
        init { this._rawData.Set("networking", value); }
    }

    /// <summary>
    /// Specify packages (and optionally their versions) available in this environment.
    ///
    /// <para>When versioning, use the version semantics relevant for the package
    /// manager, e.g. for `pip` use `package==1.0.0`. You are responsible for validating
    /// the package and version exist. Unversioned installs the latest.</para>
    /// </summary>
    public BetaPackagesParams? Packages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaPackagesParams>("packages");
        }
        init { this._rawData.Set("packages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("cloud")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Networking?.Validate();
        this.Packages?.Validate();
    }

    public BetaCloudConfigParams()
    {
        this.Type = JsonSerializer.SerializeToElement("cloud");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCloudConfigParams(BetaCloudConfigParams betaCloudConfigParams)
        : base(betaCloudConfigParams) { }
#pragma warning restore CS8618

    public BetaCloudConfigParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("cloud");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCloudConfigParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCloudConfigParamsFromRaw.FromRawUnchecked"/>
    public static BetaCloudConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCloudConfigParamsFromRaw : IFromRawJson<BetaCloudConfigParams>
{
    /// <inheritdoc/>
    public BetaCloudConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCloudConfigParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Network configuration policy. Omit on update to preserve the existing value.
/// </summary>
[JsonConverter(typeof(BetaCloudConfigParamsNetworkingConverter))]
public record class BetaCloudConfigParamsNetworking : ModelBase
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
                betaUnrestrictedNetwork: (x) => x.Type,
                betaLimitedNetworkParams: (x) => x.Type
            );
        }
    }

    public BetaCloudConfigParamsNetworking(
        BetaUnrestrictedNetwork value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCloudConfigParamsNetworking(
        BetaLimitedNetworkParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCloudConfigParamsNetworking(JsonElement element)
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
    /// type <see cref="BetaLimitedNetworkParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaLimitedNetworkParams(out var value)) {
    ///     // `value` is of type `BetaLimitedNetworkParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaLimitedNetworkParams(
        [NotNullWhen(true)] out BetaLimitedNetworkParams? value
    )
    {
        value = this.Value as BetaLimitedNetworkParams;
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
    ///     (BetaLimitedNetworkParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaUnrestrictedNetwork> betaUnrestrictedNetwork,
        System::Action<BetaLimitedNetworkParams> betaLimitedNetworkParams
    )
    {
        switch (this.Value)
        {
            case BetaUnrestrictedNetwork value:
                betaUnrestrictedNetwork(value);
                break;
            case BetaLimitedNetworkParams value:
                betaLimitedNetworkParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCloudConfigParamsNetworking"
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
    ///     (BetaLimitedNetworkParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaUnrestrictedNetwork, T> betaUnrestrictedNetwork,
        System::Func<BetaLimitedNetworkParams, T> betaLimitedNetworkParams
    )
    {
        return this.Value switch
        {
            BetaUnrestrictedNetwork value => betaUnrestrictedNetwork(value),
            BetaLimitedNetworkParams value => betaLimitedNetworkParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCloudConfigParamsNetworking"
            ),
        };
    }

    public static implicit operator BetaCloudConfigParamsNetworking(
        BetaUnrestrictedNetwork value
    ) => new(value);

    public static implicit operator BetaCloudConfigParamsNetworking(
        BetaLimitedNetworkParams value
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
                "Data did not match any variant of BetaCloudConfigParamsNetworking"
            );
        }
        this.Switch(
            (betaUnrestrictedNetwork) => betaUnrestrictedNetwork.Validate(),
            (betaLimitedNetworkParams) => betaLimitedNetworkParams.Validate()
        );
    }

    public virtual bool Equals(BetaCloudConfigParamsNetworking? other) =>
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
            BetaLimitedNetworkParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaCloudConfigParamsNetworkingConverter
    : JsonConverter<BetaCloudConfigParamsNetworking?>
{
    public override BetaCloudConfigParamsNetworking? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaLimitedNetworkParams>(
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
                return new BetaCloudConfigParamsNetworking(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCloudConfigParamsNetworking? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
