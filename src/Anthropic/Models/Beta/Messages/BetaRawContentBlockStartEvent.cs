using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRawContentBlockStartEvent>))]
public sealed record class BetaRawContentBlockStartEvent
    : ModelBase,
        IFromRaw<BetaRawContentBlockStartEvent>
{
    /// <summary>
    /// Response model for a file uploaded to the container.
    /// </summary>
    public required ContentBlock ContentBlock
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

            return JsonSerializer.Deserialize<ContentBlock>(element, ModelBase.SerializerOptions)
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

    public BetaRawContentBlockStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"");
    }

    public BetaRawContentBlockStartEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaRawContentBlockStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(ContentBlockConverter))]
public record class ContentBlock
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
                betaText: (x) => x.Type,
                betaThinking: (x) => x.Type,
                betaRedactedThinking: (x) => x.Type,
                betaToolUse: (x) => x.Type,
                betaServerToolUse: (x) => x.Type,
                betaWebSearchToolResult: (x) => x.Type,
                betaWebFetchToolResult: (x) => x.Type,
                betaCodeExecutionToolResult: (x) => x.Type,
                betaBashCodeExecutionToolResult: (x) => x.Type,
                betaTextEditorCodeExecutionToolResult: (x) => x.Type,
                betaToolSearchToolResult: (x) => x.Type,
                betaMCPToolUse: (x) => x.Type,
                betaMCPToolResult: (x) => x.Type,
                betaContainerUpload: (x) => x.Type
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                betaText: (_) => null,
                betaThinking: (_) => null,
                betaRedactedThinking: (_) => null,
                betaToolUse: (x) => x.ID,
                betaServerToolUse: (x) => x.ID,
                betaWebSearchToolResult: (_) => null,
                betaWebFetchToolResult: (_) => null,
                betaCodeExecutionToolResult: (_) => null,
                betaBashCodeExecutionToolResult: (_) => null,
                betaTextEditorCodeExecutionToolResult: (_) => null,
                betaToolSearchToolResult: (_) => null,
                betaMCPToolUse: (x) => x.ID,
                betaMCPToolResult: (_) => null,
                betaContainerUpload: (_) => null
            );
        }
    }

    public string? ToolUseID
    {
        get
        {
            return Match<string?>(
                betaText: (_) => null,
                betaThinking: (_) => null,
                betaRedactedThinking: (_) => null,
                betaToolUse: (_) => null,
                betaServerToolUse: (_) => null,
                betaWebSearchToolResult: (x) => x.ToolUseID,
                betaWebFetchToolResult: (x) => x.ToolUseID,
                betaCodeExecutionToolResult: (x) => x.ToolUseID,
                betaBashCodeExecutionToolResult: (x) => x.ToolUseID,
                betaTextEditorCodeExecutionToolResult: (x) => x.ToolUseID,
                betaToolSearchToolResult: (x) => x.ToolUseID,
                betaMCPToolUse: (_) => null,
                betaMCPToolResult: (x) => x.ToolUseID,
                betaContainerUpload: (_) => null
            );
        }
    }

    public ContentBlock(BetaTextBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaThinkingBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaRedactedThinkingBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaServerToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaWebSearchToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaWebFetchToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaCodeExecutionToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaBashCodeExecutionToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaTextEditorCodeExecutionToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaToolSearchToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaMCPToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaMCPToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(BetaContainerUploadBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ContentBlock(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaText([NotNullWhen(true)] out BetaTextBlock? value)
    {
        value = this.Value as BetaTextBlock;
        return value != null;
    }

    public bool TryPickBetaThinking([NotNullWhen(true)] out BetaThinkingBlock? value)
    {
        value = this.Value as BetaThinkingBlock;
        return value != null;
    }

    public bool TryPickBetaRedactedThinking(
        [NotNullWhen(true)] out BetaRedactedThinkingBlock? value
    )
    {
        value = this.Value as BetaRedactedThinkingBlock;
        return value != null;
    }

    public bool TryPickBetaToolUse([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = this.Value as BetaToolUseBlock;
        return value != null;
    }

    public bool TryPickBetaServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlock? value)
    {
        value = this.Value as BetaServerToolUseBlock;
        return value != null;
    }

    public bool TryPickBetaWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlock? value
    )
    {
        value = this.Value as BetaWebSearchToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaWebFetchToolResult(
        [NotNullWhen(true)] out BetaWebFetchToolResultBlock? value
    )
    {
        value = this.Value as BetaWebFetchToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaCodeExecutionToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaToolSearchToolResult(
        [NotNullWhen(true)] out BetaToolSearchToolResultBlock? value
    )
    {
        value = this.Value as BetaToolSearchToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlock? value)
    {
        value = this.Value as BetaMCPToolUseBlock;
        return value != null;
    }

    public bool TryPickBetaMCPToolResult([NotNullWhen(true)] out BetaMCPToolResultBlock? value)
    {
        value = this.Value as BetaMCPToolResultBlock;
        return value != null;
    }

    public bool TryPickBetaContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlock? value)
    {
        value = this.Value as BetaContainerUploadBlock;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextBlock> betaText,
        System::Action<BetaThinkingBlock> betaThinking,
        System::Action<BetaRedactedThinkingBlock> betaRedactedThinking,
        System::Action<BetaToolUseBlock> betaToolUse,
        System::Action<BetaServerToolUseBlock> betaServerToolUse,
        System::Action<BetaWebSearchToolResultBlock> betaWebSearchToolResult,
        System::Action<BetaWebFetchToolResultBlock> betaWebFetchToolResult,
        System::Action<BetaCodeExecutionToolResultBlock> betaCodeExecutionToolResult,
        System::Action<BetaBashCodeExecutionToolResultBlock> betaBashCodeExecutionToolResult,
        System::Action<BetaTextEditorCodeExecutionToolResultBlock> betaTextEditorCodeExecutionToolResult,
        System::Action<BetaToolSearchToolResultBlock> betaToolSearchToolResult,
        System::Action<BetaMCPToolUseBlock> betaMCPToolUse,
        System::Action<BetaMCPToolResultBlock> betaMCPToolResult,
        System::Action<BetaContainerUploadBlock> betaContainerUpload
    )
    {
        switch (this.Value)
        {
            case BetaTextBlock value:
                betaText(value);
                break;
            case BetaThinkingBlock value:
                betaThinking(value);
                break;
            case BetaRedactedThinkingBlock value:
                betaRedactedThinking(value);
                break;
            case BetaToolUseBlock value:
                betaToolUse(value);
                break;
            case BetaServerToolUseBlock value:
                betaServerToolUse(value);
                break;
            case BetaWebSearchToolResultBlock value:
                betaWebSearchToolResult(value);
                break;
            case BetaWebFetchToolResultBlock value:
                betaWebFetchToolResult(value);
                break;
            case BetaCodeExecutionToolResultBlock value:
                betaCodeExecutionToolResult(value);
                break;
            case BetaBashCodeExecutionToolResultBlock value:
                betaBashCodeExecutionToolResult(value);
                break;
            case BetaTextEditorCodeExecutionToolResultBlock value:
                betaTextEditorCodeExecutionToolResult(value);
                break;
            case BetaToolSearchToolResultBlock value:
                betaToolSearchToolResult(value);
                break;
            case BetaMCPToolUseBlock value:
                betaMCPToolUse(value);
                break;
            case BetaMCPToolResultBlock value:
                betaMCPToolResult(value);
                break;
            case BetaContainerUploadBlock value:
                betaContainerUpload(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlock"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaTextBlock, T> betaText,
        System::Func<BetaThinkingBlock, T> betaThinking,
        System::Func<BetaRedactedThinkingBlock, T> betaRedactedThinking,
        System::Func<BetaToolUseBlock, T> betaToolUse,
        System::Func<BetaServerToolUseBlock, T> betaServerToolUse,
        System::Func<BetaWebSearchToolResultBlock, T> betaWebSearchToolResult,
        System::Func<BetaWebFetchToolResultBlock, T> betaWebFetchToolResult,
        System::Func<BetaCodeExecutionToolResultBlock, T> betaCodeExecutionToolResult,
        System::Func<BetaBashCodeExecutionToolResultBlock, T> betaBashCodeExecutionToolResult,
        System::Func<
            BetaTextEditorCodeExecutionToolResultBlock,
            T
        > betaTextEditorCodeExecutionToolResult,
        System::Func<BetaToolSearchToolResultBlock, T> betaToolSearchToolResult,
        System::Func<BetaMCPToolUseBlock, T> betaMCPToolUse,
        System::Func<BetaMCPToolResultBlock, T> betaMCPToolResult,
        System::Func<BetaContainerUploadBlock, T> betaContainerUpload
    )
    {
        return this.Value switch
        {
            BetaTextBlock value => betaText(value),
            BetaThinkingBlock value => betaThinking(value),
            BetaRedactedThinkingBlock value => betaRedactedThinking(value),
            BetaToolUseBlock value => betaToolUse(value),
            BetaServerToolUseBlock value => betaServerToolUse(value),
            BetaWebSearchToolResultBlock value => betaWebSearchToolResult(value),
            BetaWebFetchToolResultBlock value => betaWebFetchToolResult(value),
            BetaCodeExecutionToolResultBlock value => betaCodeExecutionToolResult(value),
            BetaBashCodeExecutionToolResultBlock value => betaBashCodeExecutionToolResult(value),
            BetaTextEditorCodeExecutionToolResultBlock value =>
                betaTextEditorCodeExecutionToolResult(value),
            BetaToolSearchToolResultBlock value => betaToolSearchToolResult(value),
            BetaMCPToolUseBlock value => betaMCPToolUse(value),
            BetaMCPToolResultBlock value => betaMCPToolResult(value),
            BetaContainerUploadBlock value => betaContainerUpload(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            ),
        };
    }

    public static implicit operator ContentBlock(BetaTextBlock value) => new(value);

    public static implicit operator ContentBlock(BetaThinkingBlock value) => new(value);

    public static implicit operator ContentBlock(BetaRedactedThinkingBlock value) => new(value);

    public static implicit operator ContentBlock(BetaToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaServerToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaWebSearchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaWebFetchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator ContentBlock(BetaBashCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator ContentBlock(
        BetaTextEditorCodeExecutionToolResultBlock value
    ) => new(value);

    public static implicit operator ContentBlock(BetaToolSearchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaMCPToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaMCPToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaContainerUploadBlock value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            );
        }
    }
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
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
            case "web_fetch_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
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
            case "code_execution_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
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
            case "bash_code_execution_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlock>(
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
            case "text_editor_code_execution_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
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
            case "tool_search_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlock>(
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
            case "mcp_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlock>(
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
            case "mcp_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(
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
            case "container_upload":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlock>(
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
                return new ContentBlock(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
