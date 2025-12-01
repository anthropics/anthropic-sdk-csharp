using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawContentBlockStartEvent, RawContentBlockStartEventFromRaw>))]
public sealed record class RawContentBlockStartEvent : ModelBase
{
    public required RawContentBlockStartEventContentBlock ContentBlock
    {
        get
        {
            if (!this._rawData.TryGetValue("content_block", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content_block' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "content_block",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'content_block' cannot be null",
                    new System::ArgumentNullException("content_block")
                );
        }
        init
        {
            this._rawData["content_block"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Index
    {
        get
        {
            if (!this._rawData.TryGetValue("index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'index' cannot be null",
                    new System::ArgumentOutOfRangeException("index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ContentBlock.Validate();
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RawContentBlockStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"");
    }

    public RawContentBlockStartEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawContentBlockStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static RawContentBlockStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RawContentBlockStartEventFromRaw : IFromRaw<RawContentBlockStartEvent>
{
    public RawContentBlockStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RawContentBlockStartEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RawContentBlockStartEventContentBlockConverter))]
public record class RawContentBlockStartEventContentBlock
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                thinking: (x) => x.Type,
                redactedThinking: (x) => x.Type,
                toolUse: (x) => x.Type,
                serverToolUse: (x) => x.Type,
                webSearchToolResult: (x) => x.Type
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.ID,
                serverToolUse: (x) => x.ID,
                webSearchToolResult: (_) => null
            );
        }
    }

    public RawContentBlockStartEventContentBlock(TextBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockStartEventContentBlock(ThinkingBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockStartEventContentBlock(
        RedactedThinkingBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockStartEventContentBlock(ToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockStartEventContentBlock(ServerToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockStartEventContentBlock(
        WebSearchToolResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockStartEventContentBlock(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickText([NotNullWhen(true)] out TextBlock? value)
    {
        value = this.Value as TextBlock;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out ThinkingBlock? value)
    {
        value = this.Value as ThinkingBlock;
        return value != null;
    }

    public bool TryPickRedactedThinking([NotNullWhen(true)] out RedactedThinkingBlock? value)
    {
        value = this.Value as RedactedThinkingBlock;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out ToolUseBlock? value)
    {
        value = this.Value as ToolUseBlock;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out ServerToolUseBlock? value)
    {
        value = this.Value as ServerToolUseBlock;
        return value != null;
    }

    public bool TryPickWebSearchToolResult([NotNullWhen(true)] out WebSearchToolResultBlock? value)
    {
        value = this.Value as WebSearchToolResultBlock;
        return value != null;
    }

    public void Switch(
        System::Action<TextBlock> text,
        System::Action<ThinkingBlock> thinking,
        System::Action<RedactedThinkingBlock> redactedThinking,
        System::Action<ToolUseBlock> toolUse,
        System::Action<ServerToolUseBlock> serverToolUse,
        System::Action<WebSearchToolResultBlock> webSearchToolResult
    )
    {
        switch (this.Value)
        {
            case TextBlock value:
                text(value);
                break;
            case ThinkingBlock value:
                thinking(value);
                break;
            case RedactedThinkingBlock value:
                redactedThinking(value);
                break;
            case ToolUseBlock value:
                toolUse(value);
                break;
            case ServerToolUseBlock value:
                serverToolUse(value);
                break;
            case WebSearchToolResultBlock value:
                webSearchToolResult(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of RawContentBlockStartEventContentBlock"
                );
        }
    }

    public T Match<T>(
        System::Func<TextBlock, T> text,
        System::Func<ThinkingBlock, T> thinking,
        System::Func<RedactedThinkingBlock, T> redactedThinking,
        System::Func<ToolUseBlock, T> toolUse,
        System::Func<ServerToolUseBlock, T> serverToolUse,
        System::Func<WebSearchToolResultBlock, T> webSearchToolResult
    )
    {
        return this.Value switch
        {
            TextBlock value => text(value),
            ThinkingBlock value => thinking(value),
            RedactedThinkingBlock value => redactedThinking(value),
            ToolUseBlock value => toolUse(value),
            ServerToolUseBlock value => serverToolUse(value),
            WebSearchToolResultBlock value => webSearchToolResult(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawContentBlockStartEventContentBlock"
            ),
        };
    }

    public static implicit operator RawContentBlockStartEventContentBlock(TextBlock value) =>
        new(value);

    public static implicit operator RawContentBlockStartEventContentBlock(ThinkingBlock value) =>
        new(value);

    public static implicit operator RawContentBlockStartEventContentBlock(
        RedactedThinkingBlock value
    ) => new(value);

    public static implicit operator RawContentBlockStartEventContentBlock(ToolUseBlock value) =>
        new(value);

    public static implicit operator RawContentBlockStartEventContentBlock(
        ServerToolUseBlock value
    ) => new(value);

    public static implicit operator RawContentBlockStartEventContentBlock(
        WebSearchToolResultBlock value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawContentBlockStartEventContentBlock"
            );
        }
    }

    public virtual bool Equals(RawContentBlockStartEventContentBlock? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class RawContentBlockStartEventContentBlockConverter
    : JsonConverter<RawContentBlockStartEventContentBlock>
{
    public override RawContentBlockStartEventContentBlock? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<TextBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "redacted_thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "server_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "web_search_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new RawContentBlockStartEventContentBlock(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        RawContentBlockStartEventContentBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
