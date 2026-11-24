using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// The stored copy of one call.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewMessageContentConverter))]
public record class BetaComplianceReviewMessageContent : ModelBase
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

    public ApiEnum<string, BetaComplianceReviewMessageContentType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaComplianceReviewCreateMessageContent _ =>
                    BetaComplianceReviewMessageContentType.CreateMessage,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaComplianceReviewMessageContentType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaComplianceReviewMessageContent(
        BetaComplianceReviewCreateMessageContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewMessageContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewCreateMessageContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreate(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewCreateMessageContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreate(
        [NotNullWhen(true)] out BetaComplianceReviewCreateMessageContent? value
    )
    {
        value = this.Value as BetaComplianceReviewCreateMessageContent;
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
    ///     (BetaComplianceReviewCreateMessageContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<BetaComplianceReviewCreateMessageContent> create)
    {
        switch (this.Value)
        {
            case BetaComplianceReviewCreateMessageContent value:
                create(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceReviewMessageContent"
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
    ///     (BetaComplianceReviewCreateMessageContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<BetaComplianceReviewCreateMessageContent, T> create)
    {
        return this.Value switch
        {
            BetaComplianceReviewCreateMessageContent value => create(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceReviewMessageContent"
            ),
        };
    }

    public static implicit operator BetaComplianceReviewMessageContent(
        BetaComplianceReviewCreateMessageContent value
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
                "Data did not match any variant of BetaComplianceReviewMessageContent"
            );
        }
        this.Switch((create) => create.Validate());
    }

    public virtual bool Equals(BetaComplianceReviewMessageContent? other) =>
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
            BetaComplianceReviewCreateMessageContent _ => 0,
            _ => -1,
        };
    }
}

sealed class BetaComplianceReviewMessageContentConverter
    : JsonConverter<BetaComplianceReviewMessageContent>
{
    public override BetaComplianceReviewMessageContent? Read(
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
            case "create_message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceReviewCreateMessageContent>(
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
                return new BetaComplianceReviewMessageContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewMessageContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaComplianceReviewMessageContentTypeConverter))]
public enum BetaComplianceReviewMessageContentType
{
    CreateMessage = 496944901,
}

sealed class BetaComplianceReviewMessageContentTypeConverter
    : JsonConverter<BetaComplianceReviewMessageContentType>
{
    public override BetaComplianceReviewMessageContentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_message" => BetaComplianceReviewMessageContentType.CreateMessage,
            _ => (BetaComplianceReviewMessageContentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewMessageContentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewMessageContentType.CreateMessage => "create_message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
