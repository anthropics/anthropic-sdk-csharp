using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Union type for event parameters that can be sent to a session.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsEventParamsConverter))]
public record class BetaManagedAgentsEventParams : ModelBase
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

    public BetaManagedAgentsEventParams(
        BetaManagedAgentsUserMessageEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsEventParams(
        BetaManagedAgentsUserInterruptEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsEventParams(
        BetaManagedAgentsUserToolConfirmationEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsEventParams(
        BetaManagedAgentsUserCustomToolResultEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsEventParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserMessageEventParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserMessageEventParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserMessage(
        [NotNullWhen(true)] out BetaManagedAgentsUserMessageEventParams? value
    )
    {
        value = this.Value as BetaManagedAgentsUserMessageEventParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserInterruptEventParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserInterrupt(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserInterruptEventParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserInterrupt(
        [NotNullWhen(true)] out BetaManagedAgentsUserInterruptEventParams? value
    )
    {
        value = this.Value as BetaManagedAgentsUserInterruptEventParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserToolConfirmationEventParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserToolConfirmation(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserToolConfirmationEventParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserToolConfirmation(
        [NotNullWhen(true)] out BetaManagedAgentsUserToolConfirmationEventParams? value
    )
    {
        value = this.Value as BetaManagedAgentsUserToolConfirmationEventParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserCustomToolResultEventParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserCustomToolResult(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserCustomToolResultEventParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserCustomToolResult(
        [NotNullWhen(true)] out BetaManagedAgentsUserCustomToolResultEventParams? value
    )
    {
        value = this.Value as BetaManagedAgentsUserCustomToolResultEventParams;
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
    ///     (BetaManagedAgentsUserMessageEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsUserInterruptEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolConfirmationEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsUserCustomToolResultEventParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUserMessageEventParams> userMessage,
        System::Action<BetaManagedAgentsUserInterruptEventParams> userInterrupt,
        System::Action<BetaManagedAgentsUserToolConfirmationEventParams> userToolConfirmation,
        System::Action<BetaManagedAgentsUserCustomToolResultEventParams> userCustomToolResult
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUserMessageEventParams value:
                userMessage(value);
                break;
            case BetaManagedAgentsUserInterruptEventParams value:
                userInterrupt(value);
                break;
            case BetaManagedAgentsUserToolConfirmationEventParams value:
                userToolConfirmation(value);
                break;
            case BetaManagedAgentsUserCustomToolResultEventParams value:
                userCustomToolResult(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsEventParams"
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
    ///     (BetaManagedAgentsUserMessageEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsUserInterruptEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolConfirmationEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsUserCustomToolResultEventParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUserMessageEventParams, T> userMessage,
        System::Func<BetaManagedAgentsUserInterruptEventParams, T> userInterrupt,
        System::Func<BetaManagedAgentsUserToolConfirmationEventParams, T> userToolConfirmation,
        System::Func<BetaManagedAgentsUserCustomToolResultEventParams, T> userCustomToolResult
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUserMessageEventParams value => userMessage(value),
            BetaManagedAgentsUserInterruptEventParams value => userInterrupt(value),
            BetaManagedAgentsUserToolConfirmationEventParams value => userToolConfirmation(value),
            BetaManagedAgentsUserCustomToolResultEventParams value => userCustomToolResult(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsEventParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsEventParams(
        BetaManagedAgentsUserMessageEventParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsEventParams(
        BetaManagedAgentsUserInterruptEventParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsEventParams(
        BetaManagedAgentsUserToolConfirmationEventParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsEventParams(
        BetaManagedAgentsUserCustomToolResultEventParams value
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
                "Data did not match any variant of BetaManagedAgentsEventParams"
            );
        }
        this.Switch(
            (userMessage) => userMessage.Validate(),
            (userInterrupt) => userInterrupt.Validate(),
            (userToolConfirmation) => userToolConfirmation.Validate(),
            (userCustomToolResult) => userCustomToolResult.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsEventParams? other) =>
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
            BetaManagedAgentsUserMessageEventParams _ => 0,
            BetaManagedAgentsUserInterruptEventParams _ => 1,
            BetaManagedAgentsUserToolConfirmationEventParams _ => 2,
            BetaManagedAgentsUserCustomToolResultEventParams _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsEventParamsConverter : JsonConverter<BetaManagedAgentsEventParams>
{
    public override BetaManagedAgentsEventParams? Read(
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
            case "user.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParams>(
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
            case "user.interrupt":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserInterruptEventParams>(
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
            case "user.tool_confirmation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEventParams>(
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
            case "user.custom_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventParams>(
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
                return new BetaManagedAgentsEventParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEventParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
