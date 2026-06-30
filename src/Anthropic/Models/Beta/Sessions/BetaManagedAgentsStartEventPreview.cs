using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

[JsonConverter(typeof(BetaManagedAgentsStartEventPreviewConverter))]
public record class BetaManagedAgentsStartEventPreview : ModelBase
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

    public string ID
    {
        get { return Match(agentMessage: (x) => x.ID, agentThinking: (x) => x.ID); }
    }

    public BetaManagedAgentsStartEventPreview(
        BetaManagedAgentsAgentMessagePreview value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStartEventPreview(
        BetaManagedAgentsAgentThinkingPreview value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStartEventPreview(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentMessagePreview"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMessagePreview`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMessage(
        [NotNullWhen(true)] out BetaManagedAgentsAgentMessagePreview? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentMessagePreview;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentThinkingPreview"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentThinking(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThinkingPreview`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThinking(
        [NotNullWhen(true)] out BetaManagedAgentsAgentThinkingPreview? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentThinkingPreview;
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
    ///     (BetaManagedAgentsAgentMessagePreview value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThinkingPreview value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAgentMessagePreview> agentMessage,
        System::Action<BetaManagedAgentsAgentThinkingPreview> agentThinking
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAgentMessagePreview value:
                agentMessage(value);
                break;
            case BetaManagedAgentsAgentThinkingPreview value:
                agentThinking(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsStartEventPreview"
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
    ///     (BetaManagedAgentsAgentMessagePreview value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThinkingPreview value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAgentMessagePreview, T> agentMessage,
        System::Func<BetaManagedAgentsAgentThinkingPreview, T> agentThinking
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAgentMessagePreview value => agentMessage(value),
            BetaManagedAgentsAgentThinkingPreview value => agentThinking(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsStartEventPreview"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsStartEventPreview(
        BetaManagedAgentsAgentMessagePreview value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStartEventPreview(
        BetaManagedAgentsAgentThinkingPreview value
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
                "Data did not match any variant of BetaManagedAgentsStartEventPreview"
            );
        }
        this.Switch(
            (agentMessage) => agentMessage.Validate(),
            (agentThinking) => agentThinking.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsStartEventPreview? other) =>
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
            BetaManagedAgentsAgentMessagePreview _ => 0,
            BetaManagedAgentsAgentThinkingPreview _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsStartEventPreviewConverter
    : JsonConverter<BetaManagedAgentsStartEventPreview>
{
    public override BetaManagedAgentsStartEventPreview? Read(
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
            case "agent.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentMessagePreview>(
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
            case "agent.thinking":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentThinkingPreview>(
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
                return new BetaManagedAgentsStartEventPreview(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsStartEventPreview value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
