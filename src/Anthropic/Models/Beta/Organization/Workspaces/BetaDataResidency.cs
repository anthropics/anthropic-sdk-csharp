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

[JsonConverter(typeof(JsonModelConverter<BetaDataResidency, BetaDataResidencyFromRaw>))]
public sealed record class BetaDataResidency : JsonModel
{
    /// <summary>
    /// Permitted inference geo values. 'unrestricted' means all geos are allowed.
    /// </summary>
    public required AllowedInferenceGeos AllowedInferenceGeos
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AllowedInferenceGeos>("allowed_inference_geos");
        }
        init { this._rawData.Set("allowed_inference_geos", value); }
    }

    /// <summary>
    /// Default inference geo applied when requests omit the parameter.
    /// </summary>
    public required ApiEnum<string, DefaultInferenceGeo> DefaultInferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DefaultInferenceGeo>>(
                "default_inference_geo"
            );
        }
        init { this._rawData.Set("default_inference_geo", value); }
    }

    /// <summary>
    /// Geographic region for workspace data storage. Immutable after creation.
    /// </summary>
    public required ApiEnum<string, WorkspaceGeo> WorkspaceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WorkspaceGeo>>("workspace_geo");
        }
        init { this._rawData.Set("workspace_geo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowedInferenceGeos.Validate();
        this.DefaultInferenceGeo.Validate();
        this.WorkspaceGeo.Validate();
    }

    public BetaDataResidency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDataResidency(BetaDataResidency betaDataResidency)
        : base(betaDataResidency) { }
#pragma warning restore CS8618

    public BetaDataResidency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDataResidency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDataResidencyFromRaw.FromRawUnchecked"/>
    public static BetaDataResidency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDataResidencyFromRaw : IFromRawJson<BetaDataResidency>
{
    /// <inheritdoc/>
    public BetaDataResidency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDataResidency.FromRawUnchecked(rawData);
}

/// <summary>
/// Permitted inference geo values. 'unrestricted' means all geos are allowed.
/// </summary>
[JsonConverter(typeof(AllowedInferenceGeosConverter))]
public record class AllowedInferenceGeos : ModelBase
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

    public AllowedInferenceGeos(
        IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public AllowedInferenceGeos(Unrestricted value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AllowedInferenceGeos(JsonElement element)
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
    /// type <see cref="Unrestricted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnrestricted(out var value)) {
    ///     // `value` is of type `Unrestricted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnrestricted([NotNullWhen(true)] out Unrestricted? value)
    {
        value = this.Value as Unrestricted;
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
    ///     (Unrestricted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>> geos,
        Action<Unrestricted> unrestricted
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> value:
                geos(value);
                break;
            case Unrestricted value:
                unrestricted(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of AllowedInferenceGeos"
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
    ///     (Unrestricted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>, T> geos,
        Func<Unrestricted, T> unrestricted
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>> value => geos(value),
            Unrestricted value => unrestricted(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of AllowedInferenceGeos"
            ),
        };
    }

    public static implicit operator AllowedInferenceGeos(
        List<ApiEnum<string, BetaAllowedInferenceGeo>> value
    ) => new((IReadOnlyList<ApiEnum<string, BetaAllowedInferenceGeo>>)value);

    public static implicit operator AllowedInferenceGeos(Unrestricted value) => new(value);

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
                "Data did not match any variant of AllowedInferenceGeos"
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

    public virtual bool Equals(AllowedInferenceGeos? other) =>
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
            Unrestricted _ => 1,
            _ => -1,
        };
    }
}

sealed class AllowedInferenceGeosConverter : JsonConverter<AllowedInferenceGeos>
{
    public override AllowedInferenceGeos? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Unrestricted>(element, options);
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
        AllowedInferenceGeos value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnrestrictedConverter))]
public record class Unrestricted
{
    public JsonElement Element { get; private init; }

    public Unrestricted()
    {
        Element = JsonSerializer.SerializeToElement("unrestricted");
    }

    internal Unrestricted(JsonElement element)
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
        if (this != new Unrestricted())
        {
            throw new AnthropicInvalidDataException("Invalid value given for 'Unrestricted'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Unrestricted? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UnrestrictedConverter : JsonConverter<Unrestricted>
{
    public override Unrestricted? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        Unrestricted value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Default inference geo applied when requests omit the parameter.
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
/// Geographic region for workspace data storage. Immutable after creation.
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
