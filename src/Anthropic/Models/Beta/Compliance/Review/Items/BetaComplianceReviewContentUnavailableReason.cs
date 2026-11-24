using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// Why a message's content isn't returned.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewContentUnavailableReasonConverter))]
public record class BetaComplianceReviewContentUnavailableReason : ModelBase
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

    public ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaComplianceReviewContentNotCaptured _ =>
                    BetaComplianceReviewContentUnavailableReasonType.NotCaptured,
                BetaComplianceReviewStoredCopyUnavailable _ =>
                    BetaComplianceReviewContentUnavailableReasonType.StoredCopyUnavailable,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaComplianceReviewContentUnavailableReason(
        BetaComplianceReviewContentNotCaptured value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewContentUnavailableReason(
        BetaComplianceReviewStoredCopyUnavailable value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewContentUnavailableReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewContentNotCaptured"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotCaptured(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewContentNotCaptured`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotCaptured(
        [NotNullWhen(true)] out BetaComplianceReviewContentNotCaptured? value
    )
    {
        value = this.Value as BetaComplianceReviewContentNotCaptured;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewStoredCopyUnavailable"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStoredCopyUnavailable(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewStoredCopyUnavailable`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStoredCopyUnavailable(
        [NotNullWhen(true)] out BetaComplianceReviewStoredCopyUnavailable? value
    )
    {
        value = this.Value as BetaComplianceReviewStoredCopyUnavailable;
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
    ///     (BetaComplianceReviewContentNotCaptured value) =&gt; {...},
    ///     (BetaComplianceReviewStoredCopyUnavailable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaComplianceReviewContentNotCaptured> notCaptured,
        Action<BetaComplianceReviewStoredCopyUnavailable> storedCopyUnavailable
    )
    {
        switch (this.Value)
        {
            case BetaComplianceReviewContentNotCaptured value:
                notCaptured(value);
                break;
            case BetaComplianceReviewStoredCopyUnavailable value:
                storedCopyUnavailable(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceReviewContentUnavailableReason"
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
    ///     (BetaComplianceReviewContentNotCaptured value) =&gt; {...},
    ///     (BetaComplianceReviewStoredCopyUnavailable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaComplianceReviewContentNotCaptured, T> notCaptured,
        Func<BetaComplianceReviewStoredCopyUnavailable, T> storedCopyUnavailable
    )
    {
        return this.Value switch
        {
            BetaComplianceReviewContentNotCaptured value => notCaptured(value),
            BetaComplianceReviewStoredCopyUnavailable value => storedCopyUnavailable(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceReviewContentUnavailableReason"
            ),
        };
    }

    public static implicit operator BetaComplianceReviewContentUnavailableReason(
        BetaComplianceReviewContentNotCaptured value
    ) => new(value);

    public static implicit operator BetaComplianceReviewContentUnavailableReason(
        BetaComplianceReviewStoredCopyUnavailable value
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
                "Data did not match any variant of BetaComplianceReviewContentUnavailableReason"
            );
        }
        this.Switch(
            (notCaptured) => notCaptured.Validate(),
            (storedCopyUnavailable) => storedCopyUnavailable.Validate()
        );
    }

    public virtual bool Equals(BetaComplianceReviewContentUnavailableReason? other) =>
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
            BetaComplianceReviewContentNotCaptured _ => 0,
            BetaComplianceReviewStoredCopyUnavailable _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaComplianceReviewContentUnavailableReasonConverter
    : JsonConverter<BetaComplianceReviewContentUnavailableReason>
{
    public override BetaComplianceReviewContentUnavailableReason? Read(
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
            case "not_captured":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceReviewContentNotCaptured>(
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
            case "stored_copy_unavailable":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceReviewStoredCopyUnavailable>(
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
                return new BetaComplianceReviewContentUnavailableReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewContentUnavailableReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaComplianceReviewContentUnavailableReasonTypeConverter))]
public enum BetaComplianceReviewContentUnavailableReasonType
{
    NotCaptured = 656959855,
    StoredCopyUnavailable = 618452559,
}

sealed class BetaComplianceReviewContentUnavailableReasonTypeConverter
    : JsonConverter<BetaComplianceReviewContentUnavailableReasonType>
{
    public override BetaComplianceReviewContentUnavailableReasonType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_captured" => BetaComplianceReviewContentUnavailableReasonType.NotCaptured,
            "stored_copy_unavailable" =>
                BetaComplianceReviewContentUnavailableReasonType.StoredCopyUnavailable,
            _ => (BetaComplianceReviewContentUnavailableReasonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewContentUnavailableReasonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewContentUnavailableReasonType.NotCaptured => "not_captured",
                BetaComplianceReviewContentUnavailableReasonType.StoredCopyUnavailable =>
                    "stored_copy_unavailable",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
