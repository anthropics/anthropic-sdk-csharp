using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A user message sent to the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeploymentUserMessageEvent,
        BetaManagedAgentsDeploymentUserMessageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeploymentUserMessageEvent : JsonModel
{
    /// <summary>
    /// Array of content blocks for the user message.
    /// </summary>
    public required IReadOnlyList<Content> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Content>>("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Content>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user.message")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeploymentUserMessageEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("user.message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeploymentUserMessageEvent(
        BetaManagedAgentsDeploymentUserMessageEvent betaManagedAgentsDeploymentUserMessageEvent
    )
        : base(betaManagedAgentsDeploymentUserMessageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeploymentUserMessageEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user.message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeploymentUserMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeploymentUserMessageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeploymentUserMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsDeploymentUserMessageEvent(IReadOnlyList<Content> content)
        : this()
    {
        this.Content = content;
    }
}

class BetaManagedAgentsDeploymentUserMessageEventFromRaw
    : IFromRawJson<BetaManagedAgentsDeploymentUserMessageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeploymentUserMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeploymentUserMessageEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Content block in a user message. Can be `text`, `image`, or `document`.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
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

    public ApiEnum<string, ContentType> Type
    {
        get
        {
            return this.Value switch
            {
                Events::BetaManagedAgentsTextBlock _ => ContentType.Text,
                Events::BetaManagedAgentsImageBlock _ => ContentType.Image,
                Events::BetaManagedAgentsDocumentBlock _ => ContentType.Document,
                Events::BetaManagedAgentsRedactedBlock _ => ContentType.Redacted,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, ContentType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public Content(Events::BetaManagedAgentsTextBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(Events::BetaManagedAgentsImageBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(Events::BetaManagedAgentsDocumentBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(Events::BetaManagedAgentsRedactedBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTextBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTextBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsTextBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsTextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsImageBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsImageBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsImageBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsImageBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsImageBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsImageBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsDocumentBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsDocumentBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsDocumentBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsDocumentBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsDocumentBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsDocumentBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsRedactedBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsRedactedBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsRedactedBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsRedactedBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsRedactedBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsRedactedBlock;
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
    ///     (Events::BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsDocumentBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsRedactedBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Events::BetaManagedAgentsTextBlock> betaManagedAgentsTextBlock,
        Action<Events::BetaManagedAgentsImageBlock> betaManagedAgentsImageBlock,
        Action<Events::BetaManagedAgentsDocumentBlock> betaManagedAgentsDocumentBlock,
        Action<Events::BetaManagedAgentsRedactedBlock> betaManagedAgentsRedactedBlock
    )
    {
        switch (this.Value)
        {
            case Events::BetaManagedAgentsTextBlock value:
                betaManagedAgentsTextBlock(value);
                break;
            case Events::BetaManagedAgentsImageBlock value:
                betaManagedAgentsImageBlock(value);
                break;
            case Events::BetaManagedAgentsDocumentBlock value:
                betaManagedAgentsDocumentBlock(value);
                break;
            case Events::BetaManagedAgentsRedactedBlock value:
                betaManagedAgentsRedactedBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
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
    ///     (Events::BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsDocumentBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsRedactedBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Events::BetaManagedAgentsTextBlock, T> betaManagedAgentsTextBlock,
        Func<Events::BetaManagedAgentsImageBlock, T> betaManagedAgentsImageBlock,
        Func<Events::BetaManagedAgentsDocumentBlock, T> betaManagedAgentsDocumentBlock,
        Func<Events::BetaManagedAgentsRedactedBlock, T> betaManagedAgentsRedactedBlock
    )
    {
        return this.Value switch
        {
            Events::BetaManagedAgentsTextBlock value => betaManagedAgentsTextBlock(value),
            Events::BetaManagedAgentsImageBlock value => betaManagedAgentsImageBlock(value),
            Events::BetaManagedAgentsDocumentBlock value => betaManagedAgentsDocumentBlock(value),
            Events::BetaManagedAgentsRedactedBlock value => betaManagedAgentsRedactedBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public static implicit operator Content(Events::BetaManagedAgentsTextBlock value) => new(value);

    public static implicit operator Content(Events::BetaManagedAgentsImageBlock value) =>
        new(value);

    public static implicit operator Content(Events::BetaManagedAgentsDocumentBlock value) =>
        new(value);

    public static implicit operator Content(Events::BetaManagedAgentsRedactedBlock value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Content");
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsImageBlock) => betaManagedAgentsImageBlock.Validate(),
            (betaManagedAgentsDocumentBlock) => betaManagedAgentsDocumentBlock.Validate(),
            (betaManagedAgentsRedactedBlock) => betaManagedAgentsRedactedBlock.Validate()
        );
    }

    public virtual bool Equals(Content? other) =>
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
            Events::BetaManagedAgentsTextBlock _ => 0,
            Events::BetaManagedAgentsImageBlock _ => 1,
            Events::BetaManagedAgentsDocumentBlock _ => 2,
            Events::BetaManagedAgentsRedactedBlock _ => 3,
            _ => -1,
        };
    }
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
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
            case "text":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsTextBlock>(
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
            case "image":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsImageBlock>(
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
            case "document":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsDocumentBlock>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsRedactedBlock>(
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
                return new Content(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ContentTypeConverter))]
public enum ContentType
{
    Text,
    Image,
    Document,
    Redacted,
}

sealed class ContentTypeConverter : JsonConverter<ContentType>
{
    public override ContentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ContentType.Text,
            "image" => ContentType.Image,
            "document" => ContentType.Document,
            "redacted" => ContentType.Redacted,
            _ => (ContentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContentType.Text => "text",
                ContentType.Image => "image",
                ContentType.Document => "document",
                ContentType.Redacted => "redacted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
