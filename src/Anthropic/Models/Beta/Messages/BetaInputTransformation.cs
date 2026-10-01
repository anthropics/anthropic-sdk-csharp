using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// One entry of `input_transformations`: either a change the API made to the request's
/// input before showing it to the model, or a block that failed a binding check
/// and was still shown to the model unchanged. The `type` field says which.
/// </summary>
[JsonConverter(typeof(BetaInputTransformationConverter))]
public record class BetaInputTransformation : ModelBase
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

    public string Path
    {
        get
        {
            return this.Value switch
            {
                BetaThinkingDroppedInputTransformation x => x.Path,
                BetaThinkingMismatchAllowedInputTransformation x => x.Path,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "path"),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaThinkingDroppedInputTransformation x => x.Type,
                BetaThinkingMismatchAllowedInputTransformation x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaInputTransformation(
        BetaThinkingDroppedInputTransformation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaInputTransformation(
        BetaThinkingMismatchAllowedInputTransformation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaInputTransformation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingDroppedInputTransformation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinkingDropped(out var value)) {
    ///     // `value` is of type `BetaThinkingDroppedInputTransformation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinkingDropped(
        [NotNullWhen(true)] out BetaThinkingDroppedInputTransformation? value
    )
    {
        value = this.Value as BetaThinkingDroppedInputTransformation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingMismatchAllowedInputTransformation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinkingMismatchAllowed(out var value)) {
    ///     // `value` is of type `BetaThinkingMismatchAllowedInputTransformation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinkingMismatchAllowed(
        [NotNullWhen(true)] out BetaThinkingMismatchAllowedInputTransformation? value
    )
    {
        value = this.Value as BetaThinkingMismatchAllowedInputTransformation;
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
    ///     (BetaThinkingDroppedInputTransformation value) =&gt; {...},
    ///     (BetaThinkingMismatchAllowedInputTransformation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaThinkingDroppedInputTransformation> thinkingDropped,
        System::Action<BetaThinkingMismatchAllowedInputTransformation> thinkingMismatchAllowed
    )
    {
        switch (this.Value)
        {
            case BetaThinkingDroppedInputTransformation value:
                thinkingDropped(value);
                break;
            case BetaThinkingMismatchAllowedInputTransformation value:
                thinkingMismatchAllowed(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaInputTransformation"
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
    ///     (BetaThinkingDroppedInputTransformation value) =&gt; {...},
    ///     (BetaThinkingMismatchAllowedInputTransformation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaThinkingDroppedInputTransformation, T> thinkingDropped,
        System::Func<BetaThinkingMismatchAllowedInputTransformation, T> thinkingMismatchAllowed
    )
    {
        return this.Value switch
        {
            BetaThinkingDroppedInputTransformation value => thinkingDropped(value),
            BetaThinkingMismatchAllowedInputTransformation value => thinkingMismatchAllowed(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaInputTransformation"
            ),
        };
    }

    public static implicit operator BetaInputTransformation(
        BetaThinkingDroppedInputTransformation value
    ) => new(value);

    public static implicit operator BetaInputTransformation(
        BetaThinkingMismatchAllowedInputTransformation value
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
                "Data did not match any variant of BetaInputTransformation"
            );
        }
        this.Switch(
            (thinkingDropped) => thinkingDropped.Validate(),
            (thinkingMismatchAllowed) => thinkingMismatchAllowed.Validate()
        );
    }

    public virtual bool Equals(BetaInputTransformation? other) =>
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
            BetaThinkingDroppedInputTransformation _ => 0,
            BetaThinkingMismatchAllowedInputTransformation _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaInputTransformationConverter : JsonConverter<BetaInputTransformation>
{
    public override BetaInputTransformation? Read(
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
            case "thinking_dropped":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaThinkingDroppedInputTransformation>(
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
            case "thinking_mismatch_allowed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaThinkingMismatchAllowedInputTransformation>(
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
                return new BetaInputTransformation(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaInputTransformation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
