using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(BetaStorageMemberConverter))]
public record class BetaStorageMember : ModelBase
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

    public ApiEnum<string, BetaStorageMemberType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaInternalStorage _ => BetaStorageMemberType.Internal,
                BetaExternalStorageMember _ => BetaStorageMemberType.External,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaStorageMemberType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaStorageMember(BetaInternalStorage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaStorageMember(BetaExternalStorageMember value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaStorageMember(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaInternalStorage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInternalStorage(out var value)) {
    ///     // `value` is of type `BetaInternalStorage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInternalStorage([NotNullWhen(true)] out BetaInternalStorage? value)
    {
        value = this.Value as BetaInternalStorage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaExternalStorageMember"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternal(out var value)) {
    ///     // `value` is of type `BetaExternalStorageMember`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternal([NotNullWhen(true)] out BetaExternalStorageMember? value)
    {
        value = this.Value as BetaExternalStorageMember;
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
    ///     (BetaInternalStorage value) =&gt; {...},
    ///     (BetaExternalStorageMember value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaInternalStorage> internalStorage,
        System::Action<BetaExternalStorageMember> external
    )
    {
        switch (this.Value)
        {
            case BetaInternalStorage value:
                internalStorage(value);
                break;
            case BetaExternalStorageMember value:
                external(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaStorageMember"
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
    ///     (BetaInternalStorage value) =&gt; {...},
    ///     (BetaExternalStorageMember value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaInternalStorage, T> internalStorage,
        System::Func<BetaExternalStorageMember, T> external
    )
    {
        return this.Value switch
        {
            BetaInternalStorage value => internalStorage(value),
            BetaExternalStorageMember value => external(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaStorageMember"
            ),
        };
    }

    public static implicit operator BetaStorageMember(BetaInternalStorage value) => new(value);

    public static implicit operator BetaStorageMember(BetaExternalStorageMember value) =>
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
                "Data did not match any variant of BetaStorageMember"
            );
        }
        this.Switch(
            (internalStorage) => internalStorage.Validate(),
            (external) => external.Validate()
        );
    }

    public virtual bool Equals(BetaStorageMember? other) =>
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
            BetaInternalStorage _ => 0,
            BetaExternalStorageMember _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaStorageMemberConverter : JsonConverter<BetaStorageMember>
{
    public override BetaStorageMember? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaInternalStorage>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaExternalStorageMember>(
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
                return new BetaStorageMember(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaStorageMember value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaStorageMemberTypeConverter))]
public enum BetaStorageMemberType
{
    Internal = 1356166642,
    External = 1996752248,
}

sealed class BetaStorageMemberTypeConverter : JsonConverter<BetaStorageMemberType>
{
    public override BetaStorageMemberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal" => BetaStorageMemberType.Internal,
            "external" => BetaStorageMemberType.External,
            _ => (BetaStorageMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaStorageMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaStorageMemberType.Internal => "internal",
                BetaStorageMemberType.External => "external",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
