using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// What is particular to one kind of review item.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewItemDetailsConverter))]
public record class BetaComplianceReviewItemDetails : ModelBase
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

    public ApiEnum<string, BetaComplianceReviewItemDetailsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaComplianceReviewMessageDetails _ => BetaComplianceReviewItemDetailsType.Message,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaComplianceReviewItemDetailsType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaComplianceReviewItemDetails(
        BetaComplianceReviewMessageDetails value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewItemDetails(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewMessageDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMessage(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewMessageDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMessage([NotNullWhen(true)] out BetaComplianceReviewMessageDetails? value)
    {
        value = this.Value as BetaComplianceReviewMessageDetails;
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
    ///     (BetaComplianceReviewMessageDetails value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<BetaComplianceReviewMessageDetails> message)
    {
        switch (this.Value)
        {
            case BetaComplianceReviewMessageDetails value:
                message(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceReviewItemDetails"
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
    ///     (BetaComplianceReviewMessageDetails value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<BetaComplianceReviewMessageDetails, T> message)
    {
        return this.Value switch
        {
            BetaComplianceReviewMessageDetails value => message(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceReviewItemDetails"
            ),
        };
    }

    public static implicit operator BetaComplianceReviewItemDetails(
        BetaComplianceReviewMessageDetails value
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
                "Data did not match any variant of BetaComplianceReviewItemDetails"
            );
        }
        this.Switch((message) => message.Validate());
    }

    public virtual bool Equals(BetaComplianceReviewItemDetails? other) =>
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
            BetaComplianceReviewMessageDetails _ => 0,
            _ => -1,
        };
    }
}

sealed class BetaComplianceReviewItemDetailsConverter
    : JsonConverter<BetaComplianceReviewItemDetails>
{
    public override BetaComplianceReviewItemDetails? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceReviewMessageDetails>(
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
                return new BetaComplianceReviewItemDetails(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewItemDetails value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaComplianceReviewItemDetailsTypeConverter))]
public enum BetaComplianceReviewItemDetailsType
{
    Message = 2124159056,
}

sealed class BetaComplianceReviewItemDetailsTypeConverter
    : JsonConverter<BetaComplianceReviewItemDetailsType>
{
    public override BetaComplianceReviewItemDetailsType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message" => BetaComplianceReviewItemDetailsType.Message,
            _ => (BetaComplianceReviewItemDetailsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewItemDetailsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewItemDetailsType.Message => "message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
