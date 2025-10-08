using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(BetaContentBlockConverter))]
public record class BetaContentBlock
{
    public object Value { get; private init; }

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
                webSearchToolResult: (x) => x.Type,
                webFetchToolResult: (x) => x.Type,
                codeExecutionToolResult: (x) => x.Type,
                bashCodeExecutionToolResult: (x) => x.Type,
                textEditorCodeExecutionToolResult: (x) => x.Type,
                mcpToolUse: (x) => x.Type,
                mcpToolResult: (x) => x.Type,
                containerUpload: (x) => x.Type
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
                webSearchToolResult: (_) => null,
                webFetchToolResult: (_) => null,
                codeExecutionToolResult: (_) => null,
                bashCodeExecutionToolResult: (_) => null,
                textEditorCodeExecutionToolResult: (_) => null,
                mcpToolUse: (x) => x.ID,
                mcpToolResult: (_) => null,
                containerUpload: (_) => null
            );
        }
    }

    public JsonElement? Input
    {
        get
        {
            return Match<JsonElement?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.Input,
                serverToolUse: (x) => x.Input,
                webSearchToolResult: (_) => null,
                webFetchToolResult: (_) => null,
                codeExecutionToolResult: (_) => null,
                bashCodeExecutionToolResult: (_) => null,
                textEditorCodeExecutionToolResult: (_) => null,
                mcpToolUse: (x) => x.Input,
                mcpToolResult: (_) => null,
                containerUpload: (_) => null
            );
        }
    }

    public string? ToolUseID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                serverToolUse: (_) => null,
                webSearchToolResult: (x) => x.ToolUseID,
                webFetchToolResult: (x) => x.ToolUseID,
                codeExecutionToolResult: (x) => x.ToolUseID,
                bashCodeExecutionToolResult: (x) => x.ToolUseID,
                textEditorCodeExecutionToolResult: (x) => x.ToolUseID,
                mcpToolUse: (_) => null,
                mcpToolResult: (x) => x.ToolUseID,
                containerUpload: (_) => null
            );
        }
    }

    public BetaContentBlock(BetaTextBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaThinkingBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaRedactedThinkingBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaToolUseBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaServerToolUseBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaWebSearchToolResultBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaWebFetchToolResultBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaCodeExecutionToolResultBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaBashCodeExecutionToolResultBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaTextEditorCodeExecutionToolResultBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaMCPToolUseBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaMCPToolResultBlock value)
    {
        Value = value;
    }

    public BetaContentBlock(BetaContainerUploadBlock value)
    {
        Value = value;
    }

    BetaContentBlock(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaContentBlock CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickText([NotNullWhen(true)] out BetaTextBlock? value)
    {
        value = this.Value as BetaTextBlock;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingBlock? value)
    {
        value = this.Value as BetaThinkingBlock;
        return value != null;
    }

    public bool TryPickRedactedThinking([NotNullWhen(true)] out BetaRedactedThinkingBlock? value)
    {
        value = this.Value as BetaRedactedThinkingBlock;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = this.Value as BetaToolUseBlock;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlock? value)
    {
        value = this.Value as BetaServerToolUseBlock;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlock? value
    )
    {
        value = this.Value as BetaWebSearchToolResultBlock;
        return value != null;
    }

    public bool TryPickWebFetchToolResult(
        [NotNullWhen(true)] out BetaWebFetchToolResultBlock? value
    )
    {
        value = this.Value as BetaWebFetchToolResultBlock;
        return value != null;
    }

    public bool TryPickCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaCodeExecutionToolResultBlock;
        return value != null;
    }

    public bool TryPickBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultBlock;
        return value != null;
    }

    public bool TryPickTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultBlock;
        return value != null;
    }

    public bool TryPickMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlock? value)
    {
        value = this.Value as BetaMCPToolUseBlock;
        return value != null;
    }

    public bool TryPickMCPToolResult([NotNullWhen(true)] out BetaMCPToolResultBlock? value)
    {
        value = this.Value as BetaMCPToolResultBlock;
        return value != null;
    }

    public bool TryPickContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlock? value)
    {
        value = this.Value as BetaContainerUploadBlock;
        return value != null;
    }

    public void Switch(
        Action<BetaTextBlock> text,
        Action<BetaThinkingBlock> thinking,
        Action<BetaRedactedThinkingBlock> redactedThinking,
        Action<BetaToolUseBlock> toolUse,
        Action<BetaServerToolUseBlock> serverToolUse,
        Action<BetaWebSearchToolResultBlock> webSearchToolResult,
        Action<BetaWebFetchToolResultBlock> webFetchToolResult,
        Action<BetaCodeExecutionToolResultBlock> codeExecutionToolResult,
        Action<BetaBashCodeExecutionToolResultBlock> bashCodeExecutionToolResult,
        Action<BetaTextEditorCodeExecutionToolResultBlock> textEditorCodeExecutionToolResult,
        Action<BetaMCPToolUseBlock> mcpToolUse,
        Action<BetaMCPToolResultBlock> mcpToolResult,
        Action<BetaContainerUploadBlock> containerUpload
    )
    {
        switch (this.Value)
        {
            case BetaTextBlock value:
                text(value);
                break;
            case BetaThinkingBlock value:
                thinking(value);
                break;
            case BetaRedactedThinkingBlock value:
                redactedThinking(value);
                break;
            case BetaToolUseBlock value:
                toolUse(value);
                break;
            case BetaServerToolUseBlock value:
                serverToolUse(value);
                break;
            case BetaWebSearchToolResultBlock value:
                webSearchToolResult(value);
                break;
            case BetaWebFetchToolResultBlock value:
                webFetchToolResult(value);
                break;
            case BetaCodeExecutionToolResultBlock value:
                codeExecutionToolResult(value);
                break;
            case BetaBashCodeExecutionToolResultBlock value:
                bashCodeExecutionToolResult(value);
                break;
            case BetaTextEditorCodeExecutionToolResultBlock value:
                textEditorCodeExecutionToolResult(value);
                break;
            case BetaMCPToolUseBlock value:
                mcpToolUse(value);
                break;
            case BetaMCPToolResultBlock value:
                mcpToolResult(value);
                break;
            case BetaContainerUploadBlock value:
                containerUpload(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlock"
                );
        }
    }

    public T Match<T>(
        Func<BetaTextBlock, T> text,
        Func<BetaThinkingBlock, T> thinking,
        Func<BetaRedactedThinkingBlock, T> redactedThinking,
        Func<BetaToolUseBlock, T> toolUse,
        Func<BetaServerToolUseBlock, T> serverToolUse,
        Func<BetaWebSearchToolResultBlock, T> webSearchToolResult,
        Func<BetaWebFetchToolResultBlock, T> webFetchToolResult,
        Func<BetaCodeExecutionToolResultBlock, T> codeExecutionToolResult,
        Func<BetaBashCodeExecutionToolResultBlock, T> bashCodeExecutionToolResult,
        Func<BetaTextEditorCodeExecutionToolResultBlock, T> textEditorCodeExecutionToolResult,
        Func<BetaMCPToolUseBlock, T> mcpToolUse,
        Func<BetaMCPToolResultBlock, T> mcpToolResult,
        Func<BetaContainerUploadBlock, T> containerUpload
    )
    {
        return this.Value switch
        {
            BetaTextBlock value => text(value),
            BetaThinkingBlock value => thinking(value),
            BetaRedactedThinkingBlock value => redactedThinking(value),
            BetaToolUseBlock value => toolUse(value),
            BetaServerToolUseBlock value => serverToolUse(value),
            BetaWebSearchToolResultBlock value => webSearchToolResult(value),
            BetaWebFetchToolResultBlock value => webFetchToolResult(value),
            BetaCodeExecutionToolResultBlock value => codeExecutionToolResult(value),
            BetaBashCodeExecutionToolResultBlock value => bashCodeExecutionToolResult(value),
            BetaTextEditorCodeExecutionToolResultBlock value => textEditorCodeExecutionToolResult(
                value
            ),
            BetaMCPToolUseBlock value => mcpToolUse(value),
            BetaMCPToolResultBlock value => mcpToolResult(value),
            BetaContainerUploadBlock value => containerUpload(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlock"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlock"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaThinkingBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRedactedThinkingBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaToolUseBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaServerToolUseBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaWebSearchToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaWebFetchToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCodeExecutionToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaBashCodeExecutionToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextEditorCodeExecutionToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMCPToolUseBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMCPToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new BetaContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaContainerUploadBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
        BetaContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
