using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(
    typeof(JsonModelConverter<BetaDataResidencyCreateConfig, BetaDataResidencyCreateConfigFromRaw>)
)]
public sealed record class BetaDataResidencyCreateConfig : JsonModel
{
    /// <summary>
    /// Permitted inference geo values. Defaults to 'unrestricted' if omitted, which
    /// allows all geos. Use the string 'unrestricted' to allow all geos, or a list
    /// of specific geos.
    /// </summary>
    public BetaDataResidencyCreateConfigAllowedInferenceGeos? AllowedInferenceGeos
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaDataResidencyCreateConfigAllowedInferenceGeos>(
                "allowed_inference_geos"
            );
        }
        init { this._rawData.Set("allowed_inference_geos", value); }
    }

    /// <summary>
    /// Default inference geo applied when requests omit the parameter. Defaults
    /// to 'global' if omitted. Must be a member of `allowed_inference_geos` unless
    /// `allowed_inference_geos` is `"unrestricted"`.
    /// </summary>
    public ApiEnum<string, DefaultInferenceGeo>? DefaultInferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DefaultInferenceGeo>>(
                "default_inference_geo"
            );
        }
        init { this._rawData.Set("default_inference_geo", value); }
    }

    /// <summary>
    /// Geographic region for workspace data storage. Immutable after creation. Defaults
    /// to 'us' if omitted.
    /// </summary>
    public ApiEnum<string, WorkspaceGeo>? WorkspaceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WorkspaceGeo>>("workspace_geo");
        }
        init { this._rawData.Set("workspace_geo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowedInferenceGeos?.Validate();
        this.DefaultInferenceGeo?.Validate();
        this.WorkspaceGeo?.Validate();
    }

    public BetaDataResidencyCreateConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDataResidencyCreateConfig(
        BetaDataResidencyCreateConfig betaDataResidencyCreateConfig
    )
        : base(betaDataResidencyCreateConfig) { }
#pragma warning restore CS8618

    public BetaDataResidencyCreateConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDataResidencyCreateConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDataResidencyCreateConfigFromRaw.FromRawUnchecked"/>
    public static BetaDataResidencyCreateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDataResidencyCreateConfigFromRaw : IFromRawJson<BetaDataResidencyCreateConfig>
{
    /// <inheritdoc/>
    public BetaDataResidencyCreateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDataResidencyCreateConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Permitted inference geo values. Defaults to 'unrestricted' if omitted, which
/// allows all geos. Use the string 'unrestricted' to allow all geos, or a list of
/// specific geos.
/// </summary>
[JsonConverter(typeof(BetaDataResidencyCreateConfigAllowedInferenceGeosConverter))]
public record class BetaDataResidencyCreateConfigAllowedInferenceGeos : ModelBase
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

    public BetaDataResidencyCreateConfigAllowedInferenceGeos(
        IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public BetaDataResidencyCreateConfigAllowedInferenceGeos(
        BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaDataResidencyCreateConfigAllowedInferenceGeos(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ApiEnum&lt;string, BetaAllowedInferenceGeo&gt;</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGeos(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ApiEnum&lt;string, BetaAllowedInferenceGeo&gt;&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGeos(
        [NotNullWhen(true)] out IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>? value
    )
    {
        value = this.Value as IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnrestricted(out var value)) {
    ///     // `value` is of type `BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnrestricted(
        [NotNullWhen(true)] out BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted? value
    )
    {
        value = this.Value as BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted;
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
    ///     (IReadOnlyList&lt;ApiEnum&lt;string, BetaAllowedInferenceGeo&gt;&gt; value) =&gt; {...},
    ///     (BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>> geos,
        Action<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted> unrestricted
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> value:
                geos(value);
                break;
            case BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value:
                unrestricted(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaDataResidencyCreateConfigAllowedInferenceGeos"
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
    ///     (IReadOnlyList&lt;ApiEnum&lt;string, BetaAllowedInferenceGeo&gt;&gt; value) =&gt; {...},
    ///     (BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>, T> geos,
        Func<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted, T> unrestricted
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> value => geos(value),
            BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value => unrestricted(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaDataResidencyCreateConfigAllowedInferenceGeos"
            ),
        };
    }

    public static implicit operator BetaDataResidencyCreateConfigAllowedInferenceGeos(
        List<ApiEnum<string, BetaAllowedInferenceGeo>> value
    ) => new((IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>)value);

    public static implicit operator BetaDataResidencyCreateConfigAllowedInferenceGeos(
        BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value
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
                "Data did not match any variant of BetaDataResidencyCreateConfigAllowedInferenceGeos"
            );
        }
        this.Switch(
            (geos) =>
            {
                foreach (var item in geos)
                {
                    item.Validate();
                }
            },
            (unrestricted) => unrestricted.Validate()
        );
    }

    public virtual bool Equals(BetaDataResidencyCreateConfigAllowedInferenceGeos? other) =>
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
            IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> _ => 0,
            BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaDataResidencyCreateConfigAllowedInferenceGeosConverter
    : JsonConverter<BetaDataResidencyCreateConfigAllowedInferenceGeos?>
{
    public override BetaDataResidencyCreateConfigAllowedInferenceGeos? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ApiEnum<string, BetaAllowedInferenceGeo>>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDataResidencyCreateConfigAllowedInferenceGeos? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestrictedConverter))]
public record class BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted
{
    public JsonElement Element { get; private init; }

    public BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted()
    {
        Element = JsonSerializer.SerializeToElement("unrestricted");
    }

    internal BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted())
        {
            throw new AnthropicInvalidDataException(
                "Invalid value given for 'BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestrictedConverter
    : JsonConverter<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>
{
    public override BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Default inference geo applied when requests omit the parameter. Defaults to 'global'
/// if omitted. Must be a member of `allowed_inference_geos` unless `allowed_inference_geos`
/// is `"unrestricted"`.
/// </summary>
[JsonConverter(typeof(DefaultInferenceGeoConverter))]
public enum DefaultInferenceGeo
{
    Global,
    Us,
}

sealed class DefaultInferenceGeoConverter : JsonConverter<DefaultInferenceGeo>
{
    public override DefaultInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => DefaultInferenceGeo.Global,
            "us" => DefaultInferenceGeo.Us,
            _ => (DefaultInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DefaultInferenceGeo.Global => "global",
                DefaultInferenceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Geographic region for workspace data storage. Immutable after creation. Defaults
/// to 'us' if omitted.
/// </summary>
[JsonConverter(typeof(WorkspaceGeoConverter))]
public enum WorkspaceGeo
{
    Us,
}

sealed class WorkspaceGeoConverter : JsonConverter<WorkspaceGeo>
{
    public override WorkspaceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us" => WorkspaceGeo.Us,
            _ => (WorkspaceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkspaceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkspaceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
