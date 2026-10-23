using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Server-held conversation state (a Thread). `{"type": "create"}` asks the server
/// to hold this conversation's state under the response's `id`; `{"type": "continue",
/// "previous_message_id": ...}` resumes from a previous response so only the new
/// turn's messages are sent. The response shape is unchanged.
/// </summary>
[JsonConverter(typeof(BetaMessageThreadParamConverter))]
public record class BetaMessageThreadParam : ModelBase
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

    public ApiEnum<string, BetaMessageThreadParamType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaThreadCreateParams _ => BetaMessageThreadParamType.Create,
                BetaThreadContinueParams _ => BetaMessageThreadParamType.Continue,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaMessageThreadParamType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaMessageThreadParam(BetaThreadCreateParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMessageThreadParam(BetaThreadContinueParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMessageThreadParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThreadCreateParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadCreateParams(out var value)) {
    ///     // `value` is of type `BetaThreadCreateParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadCreateParams([NotNullWhen(true)] out BetaThreadCreateParams? value)
    {
        value = this.Value as BetaThreadCreateParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThreadContinueParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadContinueParams(out var value)) {
    ///     // `value` is of type `BetaThreadContinueParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadContinueParams([NotNullWhen(true)] out BetaThreadContinueParams? value)
    {
        value = this.Value as BetaThreadContinueParams;
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
    ///     (BetaThreadCreateParams value) =&gt; {...},
    ///     (BetaThreadContinueParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaThreadCreateParams> threadCreateParams,
        System::Action<BetaThreadContinueParams> threadContinueParams
    )
    {
        switch (this.Value)
        {
            case BetaThreadCreateParams value:
                threadCreateParams(value);
                break;
            case BetaThreadContinueParams value:
                threadContinueParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaMessageThreadParam"
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
    ///     (BetaThreadCreateParams value) =&gt; {...},
    ///     (BetaThreadContinueParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaThreadCreateParams, T> threadCreateParams,
        System::Func<BetaThreadContinueParams, T> threadContinueParams
    )
    {
        return this.Value switch
        {
            BetaThreadCreateParams value => threadCreateParams(value),
            BetaThreadContinueParams value => threadContinueParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageThreadParam"
            ),
        };
    }

    public static implicit operator BetaMessageThreadParam(BetaThreadCreateParams value) =>
        new(value);

    public static implicit operator BetaMessageThreadParam(BetaThreadContinueParams value) =>
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
                "Data did not match any variant of BetaMessageThreadParam"
            );
        }
        this.Switch(
            (threadCreateParams) => threadCreateParams.Validate(),
            (threadContinueParams) => threadContinueParams.Validate()
        );
    }

    public virtual bool Equals(BetaMessageThreadParam? other) =>
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
            BetaThreadCreateParams _ => 0,
            BetaThreadContinueParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaMessageThreadParamConverter : JsonConverter<BetaMessageThreadParam?>
{
    public override BetaMessageThreadParam? Read(
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
            case "create":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThreadCreateParams>(
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
            case "continue":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThreadContinueParams>(
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
                return new BetaMessageThreadParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMessageThreadParam? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(BetaMessageThreadParamTypeConverter))]
public enum BetaMessageThreadParamType
{
    Create,
    Continue,
}

sealed class BetaMessageThreadParamTypeConverter : JsonConverter<BetaMessageThreadParamType>
{
    public override BetaMessageThreadParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create" => BetaMessageThreadParamType.Create,
            "continue" => BetaMessageThreadParamType.Continue,
            _ => (BetaMessageThreadParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMessageThreadParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaMessageThreadParamType.Create => "create",
                BetaMessageThreadParamType.Continue => "continue",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
