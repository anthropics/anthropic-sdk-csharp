using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(BetaStorageMemberParamConverter))]
public record class BetaStorageMemberParam : ModelBase
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

    public ApiEnum<string, BetaStorageMemberParamType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaInternalStorageParam _ => BetaStorageMemberParamType.Internal,
                BetaExternalStorageMemberParam _ => BetaStorageMemberParamType.External,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaStorageMemberParamType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaStorageMemberParam(BetaInternalStorageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaStorageMemberParam(BetaExternalStorageMemberParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaStorageMemberParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaInternalStorageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInternalStorage(out var value)) {
    ///     // `value` is of type `BetaInternalStorageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInternalStorage([NotNullWhen(true)] out BetaInternalStorageParam? value)
    {
        value = this.Value as BetaInternalStorageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaExternalStorageMemberParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternal(out var value)) {
    ///     // `value` is of type `BetaExternalStorageMemberParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternal([NotNullWhen(true)] out BetaExternalStorageMemberParam? value)
    {
        value = this.Value as BetaExternalStorageMemberParam;
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
    ///     (BetaInternalStorageParam value) =&gt; {...},
    ///     (BetaExternalStorageMemberParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaInternalStorageParam> internalStorage,
        System::Action<BetaExternalStorageMemberParam> external
    )
    {
        switch (this.Value)
        {
            case BetaInternalStorageParam value:
                internalStorage(value);
                break;
            case BetaExternalStorageMemberParam value:
                external(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaStorageMemberParam"
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
    ///     (BetaInternalStorageParam value) =&gt; {...},
    ///     (BetaExternalStorageMemberParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaInternalStorageParam, T> internalStorage,
        System::Func<BetaExternalStorageMemberParam, T> external
    )
    {
        return this.Value switch
        {
            BetaInternalStorageParam value => internalStorage(value),
            BetaExternalStorageMemberParam value => external(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaStorageMemberParam"
            ),
        };
    }

    public static implicit operator BetaStorageMemberParam(BetaInternalStorageParam value) =>
        new(value);

    public static implicit operator BetaStorageMemberParam(BetaExternalStorageMemberParam value) =>
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
                "Data did not match any variant of BetaStorageMemberParam"
            );
        }
        this.Switch(
            (internalStorage) => internalStorage.Validate(),
            (external) => external.Validate()
        );
    }

    public virtual bool Equals(BetaStorageMemberParam? other) =>
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
            BetaInternalStorageParam _ => 0,
            BetaExternalStorageMemberParam _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaStorageMemberParamConverter : JsonConverter<BetaStorageMemberParam>
{
    public override BetaStorageMemberParam? Read(
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
            case "internal":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInternalStorageParam>(
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
            case "external":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaExternalStorageMemberParam>(
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
                return new BetaStorageMemberParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaStorageMemberParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaStorageMemberParamTypeConverter))]
public enum BetaStorageMemberParamType
{
    Internal = 1356166642,
    External = 1996752248,
}

sealed class BetaStorageMemberParamTypeConverter : JsonConverter<BetaStorageMemberParamType>
{
    public override BetaStorageMemberParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal" => BetaStorageMemberParamType.Internal,
            "external" => BetaStorageMemberParamType.External,
            _ => (BetaStorageMemberParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaStorageMemberParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaStorageMemberParamType.Internal => "internal",
                BetaStorageMemberParamType.External => "external",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
