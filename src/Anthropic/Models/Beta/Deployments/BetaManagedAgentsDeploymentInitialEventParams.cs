using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// An event sent to a session immediately after it is created. Supports `user.message`,
/// `user.define_outcome`, and `system.message`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsDeploymentInitialEventParamsConverter))]
public record class BetaManagedAgentsDeploymentInitialEventParams : ModelBase
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

    public BetaManagedAgentsDeploymentInitialEventParams(
        BetaManagedAgentsUserMessageEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentInitialEventParams(
        BetaManagedAgentsUserDefineOutcomeEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentInitialEventParams(
        BetaManagedAgentsSystemMessageEventParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentInitialEventParams(JsonElement element)
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
    /// type <see cref="BetaManagedAgentsUserDefineOutcomeEventParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserDefineOutcome(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserDefineOutcomeEventParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserDefineOutcome(
        [NotNullWhen(true)] out BetaManagedAgentsUserDefineOutcomeEventParams? value
    )
    {
        value = this.Value as BetaManagedAgentsUserDefineOutcomeEventParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSystemMessageEventParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSystemMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSystemMessageEventParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystemMessage(
        [NotNullWhen(true)] out BetaManagedAgentsSystemMessageEventParams? value
    )
    {
        value = this.Value as BetaManagedAgentsSystemMessageEventParams;
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
    ///     (BetaManagedAgentsUserDefineOutcomeEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsSystemMessageEventParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUserMessageEventParams> userMessage,
        System::Action<BetaManagedAgentsUserDefineOutcomeEventParams> userDefineOutcome,
        System::Action<BetaManagedAgentsSystemMessageEventParams> systemMessage
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUserMessageEventParams value:
                userMessage(value);
                break;
            case BetaManagedAgentsUserDefineOutcomeEventParams value:
                userDefineOutcome(value);
                break;
            case BetaManagedAgentsSystemMessageEventParams value:
                systemMessage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsDeploymentInitialEventParams"
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
    ///     (BetaManagedAgentsUserDefineOutcomeEventParams value) =&gt; {...},
    ///     (BetaManagedAgentsSystemMessageEventParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUserMessageEventParams, T> userMessage,
        System::Func<BetaManagedAgentsUserDefineOutcomeEventParams, T> userDefineOutcome,
        System::Func<BetaManagedAgentsSystemMessageEventParams, T> systemMessage
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUserMessageEventParams value => userMessage(value),
            BetaManagedAgentsUserDefineOutcomeEventParams value => userDefineOutcome(value),
            BetaManagedAgentsSystemMessageEventParams value => systemMessage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsDeploymentInitialEventParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsDeploymentInitialEventParams(
        BetaManagedAgentsUserMessageEventParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentInitialEventParams(
        BetaManagedAgentsUserDefineOutcomeEventParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentInitialEventParams(
        BetaManagedAgentsSystemMessageEventParams value
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
                "Data did not match any variant of BetaManagedAgentsDeploymentInitialEventParams"
            );
        }
        this.Switch(
            (userMessage) => userMessage.Validate(),
            (userDefineOutcome) => userDefineOutcome.Validate(),
            (systemMessage) => systemMessage.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsDeploymentInitialEventParams? other) =>
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
            BetaManagedAgentsUserDefineOutcomeEventParams _ => 1,
            BetaManagedAgentsSystemMessageEventParams _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsDeploymentInitialEventParamsConverter
    : JsonConverter<BetaManagedAgentsDeploymentInitialEventParams>
{
    public override BetaManagedAgentsDeploymentInitialEventParams? Read(
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
            case "user.define_outcome":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEventParams>(
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
            case "system.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEventParams>(
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
                return new BetaManagedAgentsDeploymentInitialEventParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentInitialEventParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
