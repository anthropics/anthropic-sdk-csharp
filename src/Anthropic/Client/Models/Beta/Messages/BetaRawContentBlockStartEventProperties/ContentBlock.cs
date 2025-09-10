using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Client.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(ContentBlockConverter))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(BetaTextBlock value) =>
        new ContentBlockVariants::BetaTextBlock(value);

    public static implicit operator ContentBlock(BetaThinkingBlock value) =>
        new ContentBlockVariants::BetaThinkingBlock(value);

    public static implicit operator ContentBlock(BetaRedactedThinkingBlock value) =>
        new ContentBlockVariants::BetaRedactedThinkingBlock(value);

    public static implicit operator ContentBlock(BetaToolUseBlock value) =>
        new ContentBlockVariants::BetaToolUseBlock(value);

    public static implicit operator ContentBlock(BetaServerToolUseBlock value) =>
        new ContentBlockVariants::BetaServerToolUseBlock(value);

    public static implicit operator ContentBlock(BetaWebSearchToolResultBlock value) =>
        new ContentBlockVariants::BetaWebSearchToolResultBlock(value);

    public static implicit operator ContentBlock(BetaWebFetchToolResultBlock value) =>
        new ContentBlockVariants::BetaWebFetchToolResultBlock(value);

    public static implicit operator ContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new ContentBlockVariants::BetaCodeExecutionToolResultBlock(value);

    public static implicit operator ContentBlock(BetaBashCodeExecutionToolResultBlock value) =>
        new ContentBlockVariants::BetaBashCodeExecutionToolResultBlock(value);

    public static implicit operator ContentBlock(
        BetaTextEditorCodeExecutionToolResultBlock value
    ) => new ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock(value);

    public static implicit operator ContentBlock(BetaMCPToolUseBlock value) =>
        new ContentBlockVariants::BetaMCPToolUseBlock(value);

    public static implicit operator ContentBlock(BetaMCPToolResultBlock value) =>
        new ContentBlockVariants::BetaMCPToolResultBlock(value);

    public static implicit operator ContentBlock(BetaContainerUploadBlock value) =>
        new ContentBlockVariants::BetaContainerUploadBlock(value);

    public bool TryPickBetaText([NotNullWhen(true)] out BetaTextBlock? value)
    {
        value = (this as ContentBlockVariants::BetaTextBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaThinking([NotNullWhen(true)] out BetaThinkingBlock? value)
    {
        value = (this as ContentBlockVariants::BetaThinkingBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaRedactedThinking(
        [NotNullWhen(true)] out BetaRedactedThinkingBlock? value
    )
    {
        value = (this as ContentBlockVariants::BetaRedactedThinkingBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolUse([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = (this as ContentBlockVariants::BetaToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlock? value)
    {
        value = (this as ContentBlockVariants::BetaServerToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlock? value
    )
    {
        value = (this as ContentBlockVariants::BetaWebSearchToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebFetchToolResult(
        [NotNullWhen(true)] out BetaWebFetchToolResultBlock? value
    )
    {
        value = (this as ContentBlockVariants::BetaWebFetchToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlock? value
    )
    {
        value = (this as ContentBlockVariants::BetaCodeExecutionToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultBlock? value
    )
    {
        value = (this as ContentBlockVariants::BetaBashCodeExecutionToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultBlock? value
    )
    {
        value = (this as ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlock? value)
    {
        value = (this as ContentBlockVariants::BetaMCPToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaMCPToolResult([NotNullWhen(true)] out BetaMCPToolResultBlock? value)
    {
        value = (this as ContentBlockVariants::BetaMCPToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlock? value)
    {
        value = (this as ContentBlockVariants::BetaContainerUploadBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentBlockVariants::BetaTextBlock> betaText,
        Action<ContentBlockVariants::BetaThinkingBlock> betaThinking,
        Action<ContentBlockVariants::BetaRedactedThinkingBlock> betaRedactedThinking,
        Action<ContentBlockVariants::BetaToolUseBlock> betaToolUse,
        Action<ContentBlockVariants::BetaServerToolUseBlock> betaServerToolUse,
        Action<ContentBlockVariants::BetaWebSearchToolResultBlock> betaWebSearchToolResult,
        Action<ContentBlockVariants::BetaWebFetchToolResultBlock> betaWebFetchToolResult,
        Action<ContentBlockVariants::BetaCodeExecutionToolResultBlock> betaCodeExecutionToolResult,
        Action<ContentBlockVariants::BetaBashCodeExecutionToolResultBlock> betaBashCodeExecutionToolResult,
        Action<ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock> betaTextEditorCodeExecutionToolResult,
        Action<ContentBlockVariants::BetaMCPToolUseBlock> betaMCPToolUse,
        Action<ContentBlockVariants::BetaMCPToolResultBlock> betaMCPToolResult,
        Action<ContentBlockVariants::BetaContainerUploadBlock> betaContainerUpload
    )
    {
        switch (this)
        {
            case ContentBlockVariants::BetaTextBlock inner:
                betaText(inner);
                break;
            case ContentBlockVariants::BetaThinkingBlock inner:
                betaThinking(inner);
                break;
            case ContentBlockVariants::BetaRedactedThinkingBlock inner:
                betaRedactedThinking(inner);
                break;
            case ContentBlockVariants::BetaToolUseBlock inner:
                betaToolUse(inner);
                break;
            case ContentBlockVariants::BetaServerToolUseBlock inner:
                betaServerToolUse(inner);
                break;
            case ContentBlockVariants::BetaWebSearchToolResultBlock inner:
                betaWebSearchToolResult(inner);
                break;
            case ContentBlockVariants::BetaWebFetchToolResultBlock inner:
                betaWebFetchToolResult(inner);
                break;
            case ContentBlockVariants::BetaCodeExecutionToolResultBlock inner:
                betaCodeExecutionToolResult(inner);
                break;
            case ContentBlockVariants::BetaBashCodeExecutionToolResultBlock inner:
                betaBashCodeExecutionToolResult(inner);
                break;
            case ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock inner:
                betaTextEditorCodeExecutionToolResult(inner);
                break;
            case ContentBlockVariants::BetaMCPToolUseBlock inner:
                betaMCPToolUse(inner);
                break;
            case ContentBlockVariants::BetaMCPToolResultBlock inner:
                betaMCPToolResult(inner);
                break;
            case ContentBlockVariants::BetaContainerUploadBlock inner:
                betaContainerUpload(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ContentBlockVariants::BetaTextBlock, T> betaText,
        Func<ContentBlockVariants::BetaThinkingBlock, T> betaThinking,
        Func<ContentBlockVariants::BetaRedactedThinkingBlock, T> betaRedactedThinking,
        Func<ContentBlockVariants::BetaToolUseBlock, T> betaToolUse,
        Func<ContentBlockVariants::BetaServerToolUseBlock, T> betaServerToolUse,
        Func<ContentBlockVariants::BetaWebSearchToolResultBlock, T> betaWebSearchToolResult,
        Func<ContentBlockVariants::BetaWebFetchToolResultBlock, T> betaWebFetchToolResult,
        Func<ContentBlockVariants::BetaCodeExecutionToolResultBlock, T> betaCodeExecutionToolResult,
        Func<
            ContentBlockVariants::BetaBashCodeExecutionToolResultBlock,
            T
        > betaBashCodeExecutionToolResult,
        Func<
            ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock,
            T
        > betaTextEditorCodeExecutionToolResult,
        Func<ContentBlockVariants::BetaMCPToolUseBlock, T> betaMCPToolUse,
        Func<ContentBlockVariants::BetaMCPToolResultBlock, T> betaMCPToolResult,
        Func<ContentBlockVariants::BetaContainerUploadBlock, T> betaContainerUpload
    )
    {
        return this switch
        {
            ContentBlockVariants::BetaTextBlock inner => betaText(inner),
            ContentBlockVariants::BetaThinkingBlock inner => betaThinking(inner),
            ContentBlockVariants::BetaRedactedThinkingBlock inner => betaRedactedThinking(inner),
            ContentBlockVariants::BetaToolUseBlock inner => betaToolUse(inner),
            ContentBlockVariants::BetaServerToolUseBlock inner => betaServerToolUse(inner),
            ContentBlockVariants::BetaWebSearchToolResultBlock inner => betaWebSearchToolResult(
                inner
            ),
            ContentBlockVariants::BetaWebFetchToolResultBlock inner => betaWebFetchToolResult(
                inner
            ),
            ContentBlockVariants::BetaCodeExecutionToolResultBlock inner =>
                betaCodeExecutionToolResult(inner),
            ContentBlockVariants::BetaBashCodeExecutionToolResultBlock inner =>
                betaBashCodeExecutionToolResult(inner),
            ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock inner =>
                betaTextEditorCodeExecutionToolResult(inner),
            ContentBlockVariants::BetaMCPToolUseBlock inner => betaMCPToolUse(inner),
            ContentBlockVariants::BetaMCPToolResultBlock inner => betaMCPToolResult(inner),
            ContentBlockVariants::BetaContainerUploadBlock inner => betaContainerUpload(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaTextBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaThinkingBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "redacted_thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaRedactedThinkingBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaToolUseBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "server_tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaServerToolUseBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "web_search_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaWebSearchToolResultBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "web_fetch_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaWebFetchToolResultBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "code_execution_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaCodeExecutionToolResultBlock(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "bash_code_execution_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaBashCodeExecutionToolResultBlock(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "text_editor_code_execution_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "mcp_tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaMCPToolUseBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "mcp_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaMCPToolResultBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "container_upload":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaContainerUploadBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockVariants::BetaTextBlock(var betaText) => betaText,
            ContentBlockVariants::BetaThinkingBlock(var betaThinking) => betaThinking,
            ContentBlockVariants::BetaRedactedThinkingBlock(var betaRedactedThinking) =>
                betaRedactedThinking,
            ContentBlockVariants::BetaToolUseBlock(var betaToolUse) => betaToolUse,
            ContentBlockVariants::BetaServerToolUseBlock(var betaServerToolUse) =>
                betaServerToolUse,
            ContentBlockVariants::BetaWebSearchToolResultBlock(var betaWebSearchToolResult) =>
                betaWebSearchToolResult,
            ContentBlockVariants::BetaWebFetchToolResultBlock(var betaWebFetchToolResult) =>
                betaWebFetchToolResult,
            ContentBlockVariants::BetaCodeExecutionToolResultBlock(
                var betaCodeExecutionToolResult
            ) => betaCodeExecutionToolResult,
            ContentBlockVariants::BetaBashCodeExecutionToolResultBlock(
                var betaBashCodeExecutionToolResult
            ) => betaBashCodeExecutionToolResult,
            ContentBlockVariants::BetaTextEditorCodeExecutionToolResultBlock(
                var betaTextEditorCodeExecutionToolResult
            ) => betaTextEditorCodeExecutionToolResult,
            ContentBlockVariants::BetaMCPToolUseBlock(var betaMCPToolUse) => betaMCPToolUse,
            ContentBlockVariants::BetaMCPToolResultBlock(var betaMCPToolResult) =>
                betaMCPToolResult,
            ContentBlockVariants::BetaContainerUploadBlock(var betaContainerUpload) =>
                betaContainerUpload,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
