using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Where to act: either a viewport coordinate or an element reference.
/// </summary>
[JsonConverter(typeof(BetaBrowserClickTargetConverter))]
public record class BetaBrowserClickTarget : ModelBase
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
                BetaBrowserCoordinateTarget x => x.Type,
                BetaBrowserRefTarget x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaBrowserClickTarget(BetaBrowserCoordinateTarget value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserClickTarget(BetaBrowserRefTarget value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserClickTarget(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserCoordinateTarget"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoordinate(out var value)) {
    ///     // `value` is of type `BetaBrowserCoordinateTarget`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoordinate([NotNullWhen(true)] out BetaBrowserCoordinateTarget? value)
    {
        value = this.Value as BetaBrowserCoordinateTarget;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserRefTarget"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRef(out var value)) {
    ///     // `value` is of type `BetaBrowserRefTarget`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRef([NotNullWhen(true)] out BetaBrowserRefTarget? value)
    {
        value = this.Value as BetaBrowserRefTarget;
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
    ///     (BetaBrowserCoordinateTarget value) =&gt; {...},
    ///     (BetaBrowserRefTarget value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBrowserCoordinateTarget> coordinate,
        System::Action<BetaBrowserRefTarget> ref_
    )
    {
        switch (this.Value)
        {
            case BetaBrowserCoordinateTarget value:
                coordinate(value);
                break;
            case BetaBrowserRefTarget value:
                ref_(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaBrowserClickTarget"
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
    ///     (BetaBrowserCoordinateTarget value) =&gt; {...},
    ///     (BetaBrowserRefTarget value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBrowserCoordinateTarget, T> coordinate,
        System::Func<BetaBrowserRefTarget, T> ref_
    )
    {
        return this.Value switch
        {
            BetaBrowserCoordinateTarget value => coordinate(value),
            BetaBrowserRefTarget value => ref_(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaBrowserClickTarget"
            ),
        };
    }

    public static implicit operator BetaBrowserClickTarget(BetaBrowserCoordinateTarget value) =>
        new(value);

    public static implicit operator BetaBrowserClickTarget(BetaBrowserRefTarget value) =>
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
                "Data did not match any variant of BetaBrowserClickTarget"
            );
        }
        this.Switch((coordinate) => coordinate.Validate(), (ref_) => ref_.Validate());
    }

    public virtual bool Equals(BetaBrowserClickTarget? other) =>
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
            BetaBrowserCoordinateTarget _ => 0,
            BetaBrowserRefTarget _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaBrowserClickTargetConverter : JsonConverter<BetaBrowserClickTarget>
{
    public override BetaBrowserClickTarget? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserCoordinateTarget>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserRefTarget>(
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
                return new BetaBrowserClickTarget(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBrowserClickTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
