using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

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
            if (!this._properties.TryGetValue("content_block", out JsonElement element))
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
            this._properties["content_block"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Index
    {
        get
        {
            if (!this._properties.TryGetValue("index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'index' cannot be null",
                    new System::ArgumentOutOfRangeException("index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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

    public BetaRawContentBlockStartEvent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockStartEvent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaRawContentBlockStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(ContentBlockConverter))]
public record class ContentBlock
{
    public object Value { get; private init; }

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
                betaMCPToolUse: (_) => null,
                betaMCPToolResult: (x) => x.ToolUseID,
                betaContainerUpload: (_) => null
            );
        }
    }

    public ContentBlock(BetaTextBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaThinkingBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaRedactedThinkingBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaToolUseBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaServerToolUseBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaWebSearchToolResultBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaWebFetchToolResultBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaCodeExecutionToolResultBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaBashCodeExecutionToolResultBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaTextEditorCodeExecutionToolResultBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaMCPToolUseBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaMCPToolResultBlock value)
    {
        Value = value;
    }

    public ContentBlock(BetaContainerUploadBlock value)
    {
        Value = value;
    }

    ContentBlock(UnknownVariant value)
    {
        Value = value;
    }

    public static ContentBlock CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public static implicit operator ContentBlock(BetaMCPToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaMCPToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaContainerUploadBlock value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "thinking":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaThinkingBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "redacted_thinking":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRedactedThinkingBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaToolUseBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "server_tool_use":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaServerToolUseBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "web_search_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaWebSearchToolResultBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "web_fetch_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaWebFetchToolResultBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "code_execution_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCodeExecutionToolResultBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bash_code_execution_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

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
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaBashCodeExecutionToolResultBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "text_editor_code_execution_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

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
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextEditorCodeExecutionToolResultBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "mcp_tool_use":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMCPToolUseBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "mcp_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMCPToolResultBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "container_upload":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaContainerUploadBlock'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
