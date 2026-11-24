using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// Why a review item is readable.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewReadReasonConverter))]
public record class BetaComplianceReviewReadReason : ModelBase
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

    public ApiEnum<string, BetaComplianceReviewReadReasonType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaComplianceReviewSafeguardsReason _ =>
                    BetaComplianceReviewReadReasonType.SafeguardsReview,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaComplianceReviewReadReasonType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaComplianceReviewReadReason(
        BetaComplianceReviewSafeguardsReason value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewReadReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewSafeguardsReason"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSafeguards(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewSafeguardsReason`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSafeguards(
        [NotNullWhen(true)] out BetaComplianceReviewSafeguardsReason? value
    )
    {
        value = this.Value as BetaComplianceReviewSafeguardsReason;
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
    ///     (BetaComplianceReviewSafeguardsReason value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<BetaComplianceReviewSafeguardsReason> safeguards)
    {
        switch (this.Value)
        {
            case BetaComplianceReviewSafeguardsReason value:
                safeguards(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceReviewReadReason"
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
    ///     (BetaComplianceReviewSafeguardsReason value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<BetaComplianceReviewSafeguardsReason, T> safeguards)
    {
        return this.Value switch
        {
            BetaComplianceReviewSafeguardsReason value => safeguards(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceReviewReadReason"
            ),
        };
    }

    public static implicit operator BetaComplianceReviewReadReason(
        BetaComplianceReviewSafeguardsReason value
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
                "Data did not match any variant of BetaComplianceReviewReadReason"
            );
        }
        this.Switch((safeguards) => safeguards.Validate());
    }

    public virtual bool Equals(BetaComplianceReviewReadReason? other) =>
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
            BetaComplianceReviewSafeguardsReason _ => 0,
            _ => -1,
        };
    }
}

sealed class BetaComplianceReviewReadReasonConverter : JsonConverter<BetaComplianceReviewReadReason>
{
    public override BetaComplianceReviewReadReason? Read(
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
            case "safeguards_review":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceReviewSafeguardsReason>(
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
                return new BetaComplianceReviewReadReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewReadReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaComplianceReviewReadReasonTypeConverter))]
public enum BetaComplianceReviewReadReasonType
{
    SafeguardsReview = 748035249,
}

sealed class BetaComplianceReviewReadReasonTypeConverter
    : JsonConverter<BetaComplianceReviewReadReasonType>
{
    public override BetaComplianceReviewReadReasonType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "safeguards_review" => BetaComplianceReviewReadReasonType.SafeguardsReview,
            _ => (BetaComplianceReviewReadReasonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewReadReasonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewReadReasonType.SafeguardsReview => "safeguards_review",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
