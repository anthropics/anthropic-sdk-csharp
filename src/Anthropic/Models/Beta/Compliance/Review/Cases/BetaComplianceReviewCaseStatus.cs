using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// The status of a review case.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewCaseStatusConverter))]
public record class BetaComplianceReviewCaseStatus : ModelBase
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

    public ApiEnum<string, BetaComplianceReviewCaseStatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaComplianceReviewCaseOpen _ => BetaComplianceReviewCaseStatusType.Open,
                BetaComplianceReviewCaseClosed _ => BetaComplianceReviewCaseStatusType.Closed,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaComplianceReviewCaseStatusType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaComplianceReviewCaseStatus(
        BetaComplianceReviewCaseOpen value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewCaseStatus(
        BetaComplianceReviewCaseClosed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewCaseStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewCaseOpen"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOpen(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewCaseOpen`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOpen([NotNullWhen(true)] out BetaComplianceReviewCaseOpen? value)
    {
        value = this.Value as BetaComplianceReviewCaseOpen;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewCaseClosed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClosed(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewCaseClosed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClosed([NotNullWhen(true)] out BetaComplianceReviewCaseClosed? value)
    {
        value = this.Value as BetaComplianceReviewCaseClosed;
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
    ///     (BetaComplianceReviewCaseOpen value) =&gt; {...},
    ///     (BetaComplianceReviewCaseClosed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaComplianceReviewCaseOpen> open,
        System::Action<BetaComplianceReviewCaseClosed> closed
    )
    {
        switch (this.Value)
        {
            case BetaComplianceReviewCaseOpen value:
                open(value);
                break;
            case BetaComplianceReviewCaseClosed value:
                closed(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceReviewCaseStatus"
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
    ///     (BetaComplianceReviewCaseOpen value) =&gt; {...},
    ///     (BetaComplianceReviewCaseClosed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaComplianceReviewCaseOpen, T> open,
        System::Func<BetaComplianceReviewCaseClosed, T> closed
    )
    {
        return this.Value switch
        {
            BetaComplianceReviewCaseOpen value => open(value),
            BetaComplianceReviewCaseClosed value => closed(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceReviewCaseStatus"
            ),
        };
    }

    public static implicit operator BetaComplianceReviewCaseStatus(
        BetaComplianceReviewCaseOpen value
    ) => new(value);

    public static implicit operator BetaComplianceReviewCaseStatus(
        BetaComplianceReviewCaseClosed value
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
                "Data did not match any variant of BetaComplianceReviewCaseStatus"
            );
        }
        this.Switch((open) => open.Validate(), (closed) => closed.Validate());
    }

    public virtual bool Equals(BetaComplianceReviewCaseStatus? other) =>
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
            BetaComplianceReviewCaseOpen _ => 0,
            BetaComplianceReviewCaseClosed _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaComplianceReviewCaseStatusConverter : JsonConverter<BetaComplianceReviewCaseStatus>
{
    public override BetaComplianceReviewCaseStatus? Read(
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
            case "open":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCaseOpen>(
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
            case "closed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCaseClosed>(
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
                return new BetaComplianceReviewCaseStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewCaseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaComplianceReviewCaseStatusTypeConverter))]
public enum BetaComplianceReviewCaseStatusType
{
    Open = 452966999,
    Closed = 24219560,
}

sealed class BetaComplianceReviewCaseStatusTypeConverter
    : JsonConverter<BetaComplianceReviewCaseStatusType>
{
    public override BetaComplianceReviewCaseStatusType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => BetaComplianceReviewCaseStatusType.Open,
            "closed" => BetaComplianceReviewCaseStatusType.Closed,
            _ => (BetaComplianceReviewCaseStatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewCaseStatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewCaseStatusType.Open => "open",
                BetaComplianceReviewCaseStatusType.Closed => "closed",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
