using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// An event sent to a session immediately after it is created. Supports `user.message`,
/// `user.define_outcome`, and `system.message`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsDeploymentInitialEventConverter))]
public record class BetaManagedAgentsDeploymentInitialEvent : ModelBase
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

    public BetaManagedAgentsDeploymentInitialEvent(
        BetaManagedAgentsDeploymentUserMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentInitialEvent(
        BetaManagedAgentsDeploymentUserDefineOutcomeEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentInitialEvent(
        BetaManagedAgentsDeploymentSystemMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentInitialEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsDeploymentUserMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsDeploymentUserMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserMessage(
        [NotNullWhen(true)] out BetaManagedAgentsDeploymentUserMessageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsDeploymentUserMessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsDeploymentUserDefineOutcomeEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserDefineOutcome(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsDeploymentUserDefineOutcomeEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserDefineOutcome(
        [NotNullWhen(true)] out BetaManagedAgentsDeploymentUserDefineOutcomeEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsDeploymentUserDefineOutcomeEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsDeploymentSystemMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSystemMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsDeploymentSystemMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystemMessage(
        [NotNullWhen(true)] out BetaManagedAgentsDeploymentSystemMessageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsDeploymentSystemMessageEvent;
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
    ///     (BetaManagedAgentsDeploymentUserMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsDeploymentUserDefineOutcomeEvent value) =&gt; {...},
    ///     (BetaManagedAgentsDeploymentSystemMessageEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsDeploymentUserMessageEvent> userMessage,
        System::Action<BetaManagedAgentsDeploymentUserDefineOutcomeEvent> userDefineOutcome,
        System::Action<BetaManagedAgentsDeploymentSystemMessageEvent> systemMessage
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsDeploymentUserMessageEvent value:
                userMessage(value);
                break;
            case BetaManagedAgentsDeploymentUserDefineOutcomeEvent value:
                userDefineOutcome(value);
                break;
            case BetaManagedAgentsDeploymentSystemMessageEvent value:
                systemMessage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsDeploymentInitialEvent"
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
    ///     (BetaManagedAgentsDeploymentUserMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsDeploymentUserDefineOutcomeEvent value) =&gt; {...},
    ///     (BetaManagedAgentsDeploymentSystemMessageEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsDeploymentUserMessageEvent, T> userMessage,
        System::Func<BetaManagedAgentsDeploymentUserDefineOutcomeEvent, T> userDefineOutcome,
        System::Func<BetaManagedAgentsDeploymentSystemMessageEvent, T> systemMessage
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsDeploymentUserMessageEvent value => userMessage(value),
            BetaManagedAgentsDeploymentUserDefineOutcomeEvent value => userDefineOutcome(value),
            BetaManagedAgentsDeploymentSystemMessageEvent value => systemMessage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsDeploymentInitialEvent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsDeploymentInitialEvent(
        BetaManagedAgentsDeploymentUserMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentInitialEvent(
        BetaManagedAgentsDeploymentUserDefineOutcomeEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentInitialEvent(
        BetaManagedAgentsDeploymentSystemMessageEvent value
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
                "Data did not match any variant of BetaManagedAgentsDeploymentInitialEvent"
            );
        }
        this.Switch(
            (userMessage) => userMessage.Validate(),
            (userDefineOutcome) => userDefineOutcome.Validate(),
            (systemMessage) => systemMessage.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsDeploymentInitialEvent? other) =>
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
            BetaManagedAgentsDeploymentUserMessageEvent _ => 0,
            BetaManagedAgentsDeploymentUserDefineOutcomeEvent _ => 1,
            BetaManagedAgentsDeploymentSystemMessageEvent _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsDeploymentInitialEventConverter
    : JsonConverter<BetaManagedAgentsDeploymentInitialEvent>
{
    public override BetaManagedAgentsDeploymentInitialEvent? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserMessageEvent>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserDefineOutcomeEvent>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsDeploymentSystemMessageEvent>(
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
                return new BetaManagedAgentsDeploymentInitialEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentInitialEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
