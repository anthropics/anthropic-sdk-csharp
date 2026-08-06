using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// An agent response event in the session conversation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentMessageEvent,
        BetaManagedAgentsAgentMessageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentMessageEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Array of text blocks comprising the agent response.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsAgentMessageEventContent> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsAgentMessageEventContent>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentMessageEventContent>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsAgentMessageEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentMessageEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsAgentMessageEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentMessageEvent(
        BetaManagedAgentsAgentMessageEvent betaManagedAgentsAgentMessageEvent
    )
        : base(betaManagedAgentsAgentMessageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentMessageEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentMessageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentMessageEventFromRaw : IFromRawJson<BetaManagedAgentsAgentMessageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentMessageEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Content block in an agent message.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentMessageEventContentConverter))]
public record class BetaManagedAgentsAgentMessageEventContent : ModelBase
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

    public BetaManagedAgentsAgentMessageEventContent(
        BetaManagedAgentsTextBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentMessageEventContent(
        BetaManagedAgentsRedactedBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentMessageEventContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTextBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTextBlock(
        [NotNullWhen(true)] out BetaManagedAgentsTextBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsTextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsRedactedBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsRedactedBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsRedactedBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsRedactedBlock(
        [NotNullWhen(true)] out BetaManagedAgentsRedactedBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsRedactedBlock;
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
    ///     (BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (BetaManagedAgentsRedactedBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTextBlock> betaManagedAgentsTextBlock,
        System::Action<BetaManagedAgentsRedactedBlock> betaManagedAgentsRedactedBlock
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTextBlock value:
                betaManagedAgentsTextBlock(value);
                break;
            case BetaManagedAgentsRedactedBlock value:
                betaManagedAgentsRedactedBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentMessageEventContent"
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
    ///     (BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (BetaManagedAgentsRedactedBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsTextBlock, T> betaManagedAgentsTextBlock,
        System::Func<BetaManagedAgentsRedactedBlock, T> betaManagedAgentsRedactedBlock
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTextBlock value => betaManagedAgentsTextBlock(value),
            BetaManagedAgentsRedactedBlock value => betaManagedAgentsRedactedBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentMessageEventContent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentMessageEventContent(
        BetaManagedAgentsTextBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentMessageEventContent(
        BetaManagedAgentsRedactedBlock value
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
                "Data did not match any variant of BetaManagedAgentsAgentMessageEventContent"
            );
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsRedactedBlock) => betaManagedAgentsRedactedBlock.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsAgentMessageEventContent? other) =>
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
            BetaManagedAgentsTextBlock _ => 0,
            BetaManagedAgentsRedactedBlock _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentMessageEventContentConverter
    : JsonConverter<BetaManagedAgentsAgentMessageEventContent>
{
    public override BetaManagedAgentsAgentMessageEventContent? Read(
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
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextBlock>(
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
            case "redacted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRedactedBlock>(
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
                return new BetaManagedAgentsAgentMessageEventContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentMessageEventContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsAgentMessageEventTypeConverter))]
public enum BetaManagedAgentsAgentMessageEventType
{
    AgentMessage,
}

sealed class BetaManagedAgentsAgentMessageEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentMessageEventType>
{
    public override BetaManagedAgentsAgentMessageEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.message" => BetaManagedAgentsAgentMessageEventType.AgentMessage,
            _ => (BetaManagedAgentsAgentMessageEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentMessageEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentMessageEventType.AgentMessage => "agent.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
