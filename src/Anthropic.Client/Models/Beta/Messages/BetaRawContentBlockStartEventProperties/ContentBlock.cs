using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;

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

    public JsonElement? Input
    {
        get
        {
            return Match<JsonElement?>(
                betaText: (_) => null,
                betaThinking: (_) => null,
                betaRedactedThinking: (_) => null,
                betaToolUse: (x) => x.Input,
                betaServerToolUse: (x) => x.Input,
                betaWebSearchToolResult: (_) => null,
                betaWebFetchToolResult: (_) => null,
                betaCodeExecutionToolResult: (_) => null,
                betaBashCodeExecutionToolResult: (_) => null,
                betaTextEditorCodeExecutionToolResult: (_) => null,
                betaMCPToolUse: (x) => x.Input,
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
        Action<BetaTextBlock> betaText,
        Action<BetaThinkingBlock> betaThinking,
        Action<BetaRedactedThinkingBlock> betaRedactedThinking,
        Action<BetaToolUseBlock> betaToolUse,
        Action<BetaServerToolUseBlock> betaServerToolUse,
        Action<BetaWebSearchToolResultBlock> betaWebSearchToolResult,
        Action<BetaWebFetchToolResultBlock> betaWebFetchToolResult,
        Action<BetaCodeExecutionToolResultBlock> betaCodeExecutionToolResult,
        Action<BetaBashCodeExecutionToolResultBlock> betaBashCodeExecutionToolResult,
        Action<BetaTextEditorCodeExecutionToolResultBlock> betaTextEditorCodeExecutionToolResult,
        Action<BetaMCPToolUseBlock> betaMCPToolUse,
        Action<BetaMCPToolResultBlock> betaMCPToolResult,
        Action<BetaContainerUploadBlock> betaContainerUpload
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
        Func<BetaTextBlock, T> betaText,
        Func<BetaThinkingBlock, T> betaThinking,
        Func<BetaRedactedThinkingBlock, T> betaRedactedThinking,
        Func<BetaToolUseBlock, T> betaToolUse,
        Func<BetaServerToolUseBlock, T> betaServerToolUse,
        Func<BetaWebSearchToolResultBlock, T> betaWebSearchToolResult,
        Func<BetaWebFetchToolResultBlock, T> betaWebFetchToolResult,
        Func<BetaCodeExecutionToolResultBlock, T> betaCodeExecutionToolResult,
        Func<BetaBashCodeExecutionToolResultBlock, T> betaBashCodeExecutionToolResult,
        Func<BetaTextEditorCodeExecutionToolResultBlock, T> betaTextEditorCodeExecutionToolResult,
        Func<BetaMCPToolUseBlock, T> betaMCPToolUse,
        Func<BetaMCPToolResultBlock, T> betaMCPToolResult,
        Func<BetaContainerUploadBlock, T> betaContainerUpload
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

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
                        return new ContentBlock(deserialized);
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
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
