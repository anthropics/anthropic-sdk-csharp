using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

[JsonConverter(
    typeof(JsonModelConverter<DataResidencyCreateConfig, DataResidencyCreateConfigFromRaw>)
)]
public sealed record class DataResidencyCreateConfig : JsonModel
{
    /// <summary>
    /// Permitted inference geo values. Defaults to 'unrestricted' if omitted, which
    /// allows all geos. Use the string 'unrestricted' to allow all geos, or a list
    /// of specific geos.
    /// </summary>
    public DataResidencyCreateConfigAllowedInferenceGeos? AllowedInferenceGeos
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataResidencyCreateConfigAllowedInferenceGeos>(
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
    public ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo>? DefaultInferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo>
            >("default_inference_geo");
        }
        init { this._rawData.Set("default_inference_geo", value); }
    }

    /// <summary>
    /// Geographic region for workspace data storage. Immutable after creation. Defaults
    /// to 'us' if omitted.
    /// </summary>
    public ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo>? WorkspaceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo>
            >("workspace_geo");
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

    public DataResidencyCreateConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataResidencyCreateConfig(DataResidencyCreateConfig dataResidencyCreateConfig)
        : base(dataResidencyCreateConfig) { }
#pragma warning restore CS8618

    public DataResidencyCreateConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataResidencyCreateConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataResidencyCreateConfigFromRaw.FromRawUnchecked"/>
    public static DataResidencyCreateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataResidencyCreateConfigFromRaw : IFromRawJson<DataResidencyCreateConfig>
{
    /// <inheritdoc/>
    public DataResidencyCreateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataResidencyCreateConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Permitted inference geo values. Defaults to 'unrestricted' if omitted, which
/// allows all geos. Use the string 'unrestricted' to allow all geos, or a list of
/// specific geos.
/// </summary>
[JsonConverter(typeof(DataResidencyCreateConfigAllowedInferenceGeosConverter))]
public record class DataResidencyCreateConfigAllowedInferenceGeos : ModelBase
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

    public DataResidencyCreateConfigAllowedInferenceGeos(
        IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public DataResidencyCreateConfigAllowedInferenceGeos(
        DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DataResidencyCreateConfigAllowedInferenceGeos(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ApiEnum&lt;string, AllowedInferenceGeo&gt;</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGeos(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ApiEnum&lt;string, AllowedInferenceGeo&gt;&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGeos(
        [NotNullWhen(true)] out IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>>? value
    )
    {
        value = this.Value as IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DataResidencyCreateConfigAllowedInferenceGeosUnrestricted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnrestricted(out var value)) {
    ///     // `value` is of type `DataResidencyCreateConfigAllowedInferenceGeosUnrestricted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnrestricted(
        [NotNullWhen(true)] out DataResidencyCreateConfigAllowedInferenceGeosUnrestricted? value
    )
    {
        value = this.Value as DataResidencyCreateConfigAllowedInferenceGeosUnrestricted;
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
    ///     (IReadOnlyList&lt;ApiEnum&lt;string, AllowedInferenceGeo&gt;&gt; value) =&gt; {...},
    ///     (DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>>> geos,
        Action<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted> unrestricted
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>> value:
                geos(value);
                break;
            case DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value:
                unrestricted(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of DataResidencyCreateConfigAllowedInferenceGeos"
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
    ///     (IReadOnlyList&lt;ApiEnum&lt;string, AllowedInferenceGeo&gt;&gt; value) =&gt; {...},
    ///     (DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>>, T> geos,
        Func<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted, T> unrestricted
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>> value => geos(value),
            DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value => unrestricted(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of DataResidencyCreateConfigAllowedInferenceGeos"
            ),
        };
    }

    public static implicit operator DataResidencyCreateConfigAllowedInferenceGeos(
        List<ApiEnum<string, AllowedInferenceGeo>> value
    ) => new((IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>>)value);

    public static implicit operator DataResidencyCreateConfigAllowedInferenceGeos(
        DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value
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
                "Data did not match any variant of DataResidencyCreateConfigAllowedInferenceGeos"
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

    public virtual bool Equals(DataResidencyCreateConfigAllowedInferenceGeos? other) =>
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
            IReadOnlyList<ApiEnum<string, AllowedInferenceGeo>> _ => 0,
            DataResidencyCreateConfigAllowedInferenceGeosUnrestricted _ => 1,
            _ => -1,
        };
    }
}

sealed class DataResidencyCreateConfigAllowedInferenceGeosConverter
    : JsonConverter<DataResidencyCreateConfigAllowedInferenceGeos?>
{
    public override DataResidencyCreateConfigAllowedInferenceGeos? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
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
                List<ApiEnum<string, AllowedInferenceGeo>>
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
        DataResidencyCreateConfigAllowedInferenceGeos? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(DataResidencyCreateConfigAllowedInferenceGeosUnrestrictedConverter))]
public record class DataResidencyCreateConfigAllowedInferenceGeosUnrestricted
{
    public JsonElement Element { get; private init; }

    public DataResidencyCreateConfigAllowedInferenceGeosUnrestricted()
    {
        Element = JsonSerializer.SerializeToElement("unrestricted");
    }

    internal DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(JsonElement element)
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
        if (this != new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted())
        {
            throw new AnthropicInvalidDataException(
                "Invalid value given for 'DataResidencyCreateConfigAllowedInferenceGeosUnrestricted'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(DataResidencyCreateConfigAllowedInferenceGeosUnrestricted? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class DataResidencyCreateConfigAllowedInferenceGeosUnrestrictedConverter
    : JsonConverter<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>
{
    public override DataResidencyCreateConfigAllowedInferenceGeosUnrestricted? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataResidencyCreateConfigAllowedInferenceGeosUnrestricted value,
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
[JsonConverter(typeof(DataResidencyCreateConfigDefaultInferenceGeoConverter))]
public enum DataResidencyCreateConfigDefaultInferenceGeo
{
    Global,
    Us,
}

sealed class DataResidencyCreateConfigDefaultInferenceGeoConverter
    : JsonConverter<DataResidencyCreateConfigDefaultInferenceGeo>
{
    public override DataResidencyCreateConfigDefaultInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => DataResidencyCreateConfigDefaultInferenceGeo.Global,
            "us" => DataResidencyCreateConfigDefaultInferenceGeo.Us,
            _ => (DataResidencyCreateConfigDefaultInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataResidencyCreateConfigDefaultInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataResidencyCreateConfigDefaultInferenceGeo.Global => "global",
                DataResidencyCreateConfigDefaultInferenceGeo.Us => "us",
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
[JsonConverter(typeof(DataResidencyCreateConfigWorkspaceGeoConverter))]
public enum DataResidencyCreateConfigWorkspaceGeo
{
    Us,
}

sealed class DataResidencyCreateConfigWorkspaceGeoConverter
    : JsonConverter<DataResidencyCreateConfigWorkspaceGeo>
{
    public override DataResidencyCreateConfigWorkspaceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us" => DataResidencyCreateConfigWorkspaceGeo.Us,
            _ => (DataResidencyCreateConfigWorkspaceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataResidencyCreateConfigWorkspaceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataResidencyCreateConfigWorkspaceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
