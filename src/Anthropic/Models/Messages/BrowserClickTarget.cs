using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Where to act: either a viewport coordinate or an element reference.
/// </summary>
[JsonConverter(typeof(BrowserClickTargetConverter))]
public record class BrowserClickTarget : ModelBase
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
            return this.Value switch
            {
                BrowserCoordinateTarget x => x.Type,
                BrowserRefTarget x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BrowserClickTarget(BrowserCoordinateTarget value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserClickTarget(BrowserRefTarget value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserClickTarget(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserCoordinateTarget"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoordinate(out var value)) {
    ///     // `value` is of type `BrowserCoordinateTarget`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoordinate([NotNullWhen(true)] out BrowserCoordinateTarget? value)
    {
        value = this.Value as BrowserCoordinateTarget;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserRefTarget"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRef(out var value)) {
    ///     // `value` is of type `BrowserRefTarget`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRef([NotNullWhen(true)] out BrowserRefTarget? value)
    {
        value = this.Value as BrowserRefTarget;
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
    ///     (BrowserCoordinateTarget value) =&gt; {...},
    ///     (BrowserRefTarget value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BrowserCoordinateTarget> coordinate,
        System::Action<BrowserRefTarget> ref_
    )
    {
        switch (this.Value)
        {
            case BrowserCoordinateTarget value:
                coordinate(value);
                break;
            case BrowserRefTarget value:
                ref_(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BrowserClickTarget"
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
    ///     (BrowserCoordinateTarget value) =&gt; {...},
    ///     (BrowserRefTarget value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BrowserCoordinateTarget, T> coordinate,
        System::Func<BrowserRefTarget, T> ref_
    )
    {
        return this.Value switch
        {
            BrowserCoordinateTarget value => coordinate(value),
            BrowserRefTarget value => ref_(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BrowserClickTarget"
            ),
        };
    }

    public static implicit operator BrowserClickTarget(BrowserCoordinateTarget value) => new(value);

    public static implicit operator BrowserClickTarget(BrowserRefTarget value) => new(value);

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
                "Data did not match any variant of BrowserClickTarget"
            );
        }
        this.Switch((coordinate) => coordinate.Validate(), (ref_) => ref_.Validate());
    }

    public virtual bool Equals(BrowserClickTarget? other) =>
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
            BrowserCoordinateTarget _ => 0,
            BrowserRefTarget _ => 1,
            _ => -1,
        };
    }
}

sealed class BrowserClickTargetConverter : JsonConverter<BrowserClickTarget>
{
    public override BrowserClickTarget? Read(
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
            case "coordinate":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BrowserCoordinateTarget>(
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
            case "ref":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BrowserRefTarget>(
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
                return new BrowserClickTarget(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrowserClickTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
