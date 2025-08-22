using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaContentBlockVariants = Anthropic.Models.Beta.Messages.BetaContentBlockVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(BetaContentBlockConverter))]
public abstract record class BetaContentBlock
{
    internal BetaContentBlock() { }

    public static implicit operator BetaContentBlock(BetaTextBlock value) =>
        new BetaContentBlockVariants::BetaTextBlock(value);

    public static implicit operator BetaContentBlock(BetaThinkingBlock value) =>
        new BetaContentBlockVariants::BetaThinkingBlock(value);

    public static implicit operator BetaContentBlock(BetaRedactedThinkingBlock value) =>
        new BetaContentBlockVariants::BetaRedactedThinkingBlock(value);

    public static implicit operator BetaContentBlock(BetaToolUseBlock value) =>
        new BetaContentBlockVariants::BetaToolUseBlock(value);

    public static implicit operator BetaContentBlock(BetaServerToolUseBlock value) =>
        new BetaContentBlockVariants::BetaServerToolUseBlock(value);

    public static implicit operator BetaContentBlock(BetaWebSearchToolResultBlock value) =>
        new BetaContentBlockVariants::BetaWebSearchToolResultBlock(value);

    public static implicit operator BetaContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new BetaContentBlockVariants::BetaCodeExecutionToolResultBlock(value);

    public static implicit operator BetaContentBlock(BetaMCPToolUseBlock value) =>
        new BetaContentBlockVariants::BetaMCPToolUseBlock(value);

    public static implicit operator BetaContentBlock(BetaMCPToolResultBlock value) =>
        new BetaContentBlockVariants::BetaMCPToolResultBlock(value);

    public static implicit operator BetaContentBlock(BetaContainerUploadBlock value) =>
        new BetaContentBlockVariants::BetaContainerUploadBlock(value);

    public bool TryPickText([NotNullWhen(true)] out BetaTextBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaTextBlock)?.Value;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaThinkingBlock)?.Value;
        return value != null;
    }

    public bool TryPickRedactedThinking([NotNullWhen(true)] out BetaRedactedThinkingBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaRedactedThinkingBlock)?.Value;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaServerToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlock? value
    )
    {
        value = (this as BetaContentBlockVariants::BetaWebSearchToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlock? value
    )
    {
        value = (this as BetaContentBlockVariants::BetaCodeExecutionToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaMCPToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickMCPToolResult([NotNullWhen(true)] out BetaMCPToolResultBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaMCPToolResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlock? value)
    {
        value = (this as BetaContentBlockVariants::BetaContainerUploadBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaContentBlockVariants::BetaTextBlock> text,
        Action<BetaContentBlockVariants::BetaThinkingBlock> thinking,
        Action<BetaContentBlockVariants::BetaRedactedThinkingBlock> redactedThinking,
        Action<BetaContentBlockVariants::BetaToolUseBlock> toolUse,
        Action<BetaContentBlockVariants::BetaServerToolUseBlock> serverToolUse,
        Action<BetaContentBlockVariants::BetaWebSearchToolResultBlock> webSearchToolResult,
        Action<BetaContentBlockVariants::BetaCodeExecutionToolResultBlock> codeExecutionToolResult,
        Action<BetaContentBlockVariants::BetaMCPToolUseBlock> mcpToolUse,
        Action<BetaContentBlockVariants::BetaMCPToolResultBlock> mcpToolResult,
        Action<BetaContentBlockVariants::BetaContainerUploadBlock> containerUpload
    )
    {
        switch (this)
        {
            case BetaContentBlockVariants::BetaTextBlock inner:
                text(inner);
                break;
            case BetaContentBlockVariants::BetaThinkingBlock inner:
                thinking(inner);
                break;
            case BetaContentBlockVariants::BetaRedactedThinkingBlock inner:
                redactedThinking(inner);
                break;
            case BetaContentBlockVariants::BetaToolUseBlock inner:
                toolUse(inner);
                break;
            case BetaContentBlockVariants::BetaServerToolUseBlock inner:
                serverToolUse(inner);
                break;
            case BetaContentBlockVariants::BetaWebSearchToolResultBlock inner:
                webSearchToolResult(inner);
                break;
            case BetaContentBlockVariants::BetaCodeExecutionToolResultBlock inner:
                codeExecutionToolResult(inner);
                break;
            case BetaContentBlockVariants::BetaMCPToolUseBlock inner:
                mcpToolUse(inner);
                break;
            case BetaContentBlockVariants::BetaMCPToolResultBlock inner:
                mcpToolResult(inner);
                break;
            case BetaContentBlockVariants::BetaContainerUploadBlock inner:
                containerUpload(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaContentBlockVariants::BetaTextBlock, T> text,
        Func<BetaContentBlockVariants::BetaThinkingBlock, T> thinking,
        Func<BetaContentBlockVariants::BetaRedactedThinkingBlock, T> redactedThinking,
        Func<BetaContentBlockVariants::BetaToolUseBlock, T> toolUse,
        Func<BetaContentBlockVariants::BetaServerToolUseBlock, T> serverToolUse,
        Func<BetaContentBlockVariants::BetaWebSearchToolResultBlock, T> webSearchToolResult,
        Func<BetaContentBlockVariants::BetaCodeExecutionToolResultBlock, T> codeExecutionToolResult,
        Func<BetaContentBlockVariants::BetaMCPToolUseBlock, T> mcpToolUse,
        Func<BetaContentBlockVariants::BetaMCPToolResultBlock, T> mcpToolResult,
        Func<BetaContentBlockVariants::BetaContainerUploadBlock, T> containerUpload
    )
    {
        return this switch
        {
            BetaContentBlockVariants::BetaTextBlock inner => text(inner),
            BetaContentBlockVariants::BetaThinkingBlock inner => thinking(inner),
            BetaContentBlockVariants::BetaRedactedThinkingBlock inner => redactedThinking(inner),
            BetaContentBlockVariants::BetaToolUseBlock inner => toolUse(inner),
            BetaContentBlockVariants::BetaServerToolUseBlock inner => serverToolUse(inner),
            BetaContentBlockVariants::BetaWebSearchToolResultBlock inner => webSearchToolResult(
                inner
            ),
            BetaContentBlockVariants::BetaCodeExecutionToolResultBlock inner =>
                codeExecutionToolResult(inner),
            BetaContentBlockVariants::BetaMCPToolUseBlock inner => mcpToolUse(inner),
            BetaContentBlockVariants::BetaMCPToolResultBlock inner => mcpToolResult(inner),
            BetaContentBlockVariants::BetaContainerUploadBlock inner => containerUpload(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaContentBlockConverter : JsonConverter<BetaContentBlock>
{
    public override BetaContentBlock? Read(
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
                        return new BetaContentBlockVariants::BetaTextBlock(deserialized);
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
                        return new BetaContentBlockVariants::BetaThinkingBlock(deserialized);
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
                        return new BetaContentBlockVariants::BetaRedactedThinkingBlock(
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
            case "tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaContentBlockVariants::BetaToolUseBlock(deserialized);
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
                        return new BetaContentBlockVariants::BetaServerToolUseBlock(deserialized);
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
                        return new BetaContentBlockVariants::BetaWebSearchToolResultBlock(
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
                        return new BetaContentBlockVariants::BetaCodeExecutionToolResultBlock(
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
                        return new BetaContentBlockVariants::BetaMCPToolUseBlock(deserialized);
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
                        return new BetaContentBlockVariants::BetaMCPToolResultBlock(deserialized);
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
                        return new BetaContentBlockVariants::BetaContainerUploadBlock(deserialized);
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
        BetaContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaContentBlockVariants::BetaTextBlock(var text) => text,
            BetaContentBlockVariants::BetaThinkingBlock(var thinking) => thinking,
            BetaContentBlockVariants::BetaRedactedThinkingBlock(var redactedThinking) =>
                redactedThinking,
            BetaContentBlockVariants::BetaToolUseBlock(var toolUse) => toolUse,
            BetaContentBlockVariants::BetaServerToolUseBlock(var serverToolUse) => serverToolUse,
            BetaContentBlockVariants::BetaWebSearchToolResultBlock(var webSearchToolResult) =>
                webSearchToolResult,
            BetaContentBlockVariants::BetaCodeExecutionToolResultBlock(
                var codeExecutionToolResult
            ) => codeExecutionToolResult,
            BetaContentBlockVariants::BetaMCPToolUseBlock(var mcpToolUse) => mcpToolUse,
            BetaContentBlockVariants::BetaMCPToolResultBlock(var mcpToolResult) => mcpToolResult,
            BetaContentBlockVariants::BetaContainerUploadBlock(var containerUpload) =>
                containerUpload,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
