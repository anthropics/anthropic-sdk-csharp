using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaContentBlockParamVariants = Anthropic.Client.Models.Beta.Messages.BetaContentBlockParamVariants;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(BetaContentBlockParamConverter))]
public abstract record class BetaContentBlockParam
{
    internal BetaContentBlockParam() { }

    public static implicit operator BetaContentBlockParam(BetaTextBlockParam value) =>
        new BetaContentBlockParamVariants::BetaTextBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaImageBlockParam value) =>
        new BetaContentBlockParamVariants::BetaImageBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaRequestDocumentBlock value) =>
        new BetaContentBlockParamVariants::BetaRequestDocumentBlock(value);

    public static implicit operator BetaContentBlockParam(BetaSearchResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaSearchResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaThinkingBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaRedactedThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolUseBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaToolResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaServerToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaServerToolUseBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaWebSearchToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaWebFetchToolResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaBashCodeExecutionToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaTextEditorCodeExecutionToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaMCPToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaMCPToolUseBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaRequestMCPToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaContainerUploadBlockParam value) =>
        new BetaContentBlockParamVariants::BetaContainerUploadBlockParam(value);

    public bool TryPickText([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaTextBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickImage([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaImageBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickRequestDocumentBlock([NotNullWhen(true)] out BetaRequestDocumentBlock? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaRequestDocumentBlock)?.Value;
        return value != null;
    }

    public bool TryPickSearchResult([NotNullWhen(true)] out BetaSearchResultBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaSearchResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaThinkingBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickRedactedThinking(
        [NotNullWhen(true)] out BetaRedactedThinkingBlockParam? value
    )
    {
        value = (this as BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out BetaToolUseBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaToolUseBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickToolResult([NotNullWhen(true)] out BetaToolResultBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaToolResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaServerToolUseBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlockParam? value
    )
    {
        value = (this as BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickWebFetchToolResult(
        [NotNullWhen(true)] out BetaWebFetchToolResultBlockParam? value
    )
    {
        value = (this as BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlockParam? value
    )
    {
        value = (
            this as BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam
        )?.Value;
        return value != null;
    }

    public bool TryPickBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultBlockParam? value
    )
    {
        value = (
            this as BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam
        )?.Value;
        return value != null;
    }

    public bool TryPickTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultBlockParam? value
    )
    {
        value = (
            this as BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam
        )?.Value;
        return value != null;
    }

    public bool TryPickMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaMCPToolUseBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickRequestMCPToolResult(
        [NotNullWhen(true)] out BetaRequestMCPToolResultBlockParam? value
    )
    {
        value = (this as BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlockParam? value)
    {
        value = (this as BetaContentBlockParamVariants::BetaContainerUploadBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaContentBlockParamVariants::BetaTextBlockParam> text,
        Action<BetaContentBlockParamVariants::BetaImageBlockParam> image,
        Action<BetaContentBlockParamVariants::BetaRequestDocumentBlock> requestDocumentBlock,
        Action<BetaContentBlockParamVariants::BetaSearchResultBlockParam> searchResult,
        Action<BetaContentBlockParamVariants::BetaThinkingBlockParam> thinking,
        Action<BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam> redactedThinking,
        Action<BetaContentBlockParamVariants::BetaToolUseBlockParam> toolUse,
        Action<BetaContentBlockParamVariants::BetaToolResultBlockParam> toolResult,
        Action<BetaContentBlockParamVariants::BetaServerToolUseBlockParam> serverToolUse,
        Action<BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam> webSearchToolResult,
        Action<BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam> webFetchToolResult,
        Action<BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam> codeExecutionToolResult,
        Action<BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam> bashCodeExecutionToolResult,
        Action<BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam> textEditorCodeExecutionToolResult,
        Action<BetaContentBlockParamVariants::BetaMCPToolUseBlockParam> mcpToolUse,
        Action<BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam> requestMCPToolResult,
        Action<BetaContentBlockParamVariants::BetaContainerUploadBlockParam> containerUpload
    )
    {
        switch (this)
        {
            case BetaContentBlockParamVariants::BetaTextBlockParam inner:
                text(inner);
                break;
            case BetaContentBlockParamVariants::BetaImageBlockParam inner:
                image(inner);
                break;
            case BetaContentBlockParamVariants::BetaRequestDocumentBlock inner:
                requestDocumentBlock(inner);
                break;
            case BetaContentBlockParamVariants::BetaSearchResultBlockParam inner:
                searchResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaThinkingBlockParam inner:
                thinking(inner);
                break;
            case BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam inner:
                redactedThinking(inner);
                break;
            case BetaContentBlockParamVariants::BetaToolUseBlockParam inner:
                toolUse(inner);
                break;
            case BetaContentBlockParamVariants::BetaToolResultBlockParam inner:
                toolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaServerToolUseBlockParam inner:
                serverToolUse(inner);
                break;
            case BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam inner:
                webSearchToolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam inner:
                webFetchToolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam inner:
                codeExecutionToolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam inner:
                bashCodeExecutionToolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam inner:
                textEditorCodeExecutionToolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaMCPToolUseBlockParam inner:
                mcpToolUse(inner);
                break;
            case BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam inner:
                requestMCPToolResult(inner);
                break;
            case BetaContentBlockParamVariants::BetaContainerUploadBlockParam inner:
                containerUpload(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaContentBlockParamVariants::BetaTextBlockParam, T> text,
        Func<BetaContentBlockParamVariants::BetaImageBlockParam, T> image,
        Func<BetaContentBlockParamVariants::BetaRequestDocumentBlock, T> requestDocumentBlock,
        Func<BetaContentBlockParamVariants::BetaSearchResultBlockParam, T> searchResult,
        Func<BetaContentBlockParamVariants::BetaThinkingBlockParam, T> thinking,
        Func<BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam, T> redactedThinking,
        Func<BetaContentBlockParamVariants::BetaToolUseBlockParam, T> toolUse,
        Func<BetaContentBlockParamVariants::BetaToolResultBlockParam, T> toolResult,
        Func<BetaContentBlockParamVariants::BetaServerToolUseBlockParam, T> serverToolUse,
        Func<
            BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam,
            T
        > webSearchToolResult,
        Func<BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam, T> webFetchToolResult,
        Func<
            BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam,
            T
        > codeExecutionToolResult,
        Func<
            BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam,
            T
        > bashCodeExecutionToolResult,
        Func<
            BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam,
            T
        > textEditorCodeExecutionToolResult,
        Func<BetaContentBlockParamVariants::BetaMCPToolUseBlockParam, T> mcpToolUse,
        Func<
            BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam,
            T
        > requestMCPToolResult,
        Func<BetaContentBlockParamVariants::BetaContainerUploadBlockParam, T> containerUpload
    )
    {
        return this switch
        {
            BetaContentBlockParamVariants::BetaTextBlockParam inner => text(inner),
            BetaContentBlockParamVariants::BetaImageBlockParam inner => image(inner),
            BetaContentBlockParamVariants::BetaRequestDocumentBlock inner => requestDocumentBlock(
                inner
            ),
            BetaContentBlockParamVariants::BetaSearchResultBlockParam inner => searchResult(inner),
            BetaContentBlockParamVariants::BetaThinkingBlockParam inner => thinking(inner),
            BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam inner => redactedThinking(
                inner
            ),
            BetaContentBlockParamVariants::BetaToolUseBlockParam inner => toolUse(inner),
            BetaContentBlockParamVariants::BetaToolResultBlockParam inner => toolResult(inner),
            BetaContentBlockParamVariants::BetaServerToolUseBlockParam inner => serverToolUse(
                inner
            ),
            BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam inner =>
                webSearchToolResult(inner),
            BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam inner =>
                webFetchToolResult(inner),
            BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam inner =>
                codeExecutionToolResult(inner),
            BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam inner =>
                bashCodeExecutionToolResult(inner),
            BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam inner =>
                textEditorCodeExecutionToolResult(inner),
            BetaContentBlockParamVariants::BetaMCPToolUseBlockParam inner => mcpToolUse(inner),
            BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam inner =>
                requestMCPToolResult(inner),
            BetaContentBlockParamVariants::BetaContainerUploadBlockParam inner => containerUpload(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaContentBlockParamConverter : JsonConverter<BetaContentBlockParam>
{
    public override BetaContentBlockParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaTextBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaImageBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "document":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaRequestDocumentBlock(
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
            case "search_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaSearchResultBlockParam(
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
            case "thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaThinkingBlockParam(
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
            case "redacted_thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaToolUseBlockParam(
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
            case "tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaToolResultBlockParam(
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
            case "server_tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaServerToolUseBlockParam(
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
            case "web_search_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam(
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
            case "web_fetch_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam(
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
                        JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlockParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam(
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
                        JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaMCPToolUseBlockParam(
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
            case "mcp_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRequestMCPToolResultBlockParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam(
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
            case "container_upload":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockParamVariants::BetaContainerUploadBlockParam(
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
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaContentBlockParamVariants::BetaTextBlockParam(var text) => text,
            BetaContentBlockParamVariants::BetaImageBlockParam(var image) => image,
            BetaContentBlockParamVariants::BetaRequestDocumentBlock(var requestDocumentBlock) =>
                requestDocumentBlock,
            BetaContentBlockParamVariants::BetaSearchResultBlockParam(var searchResult) =>
                searchResult,
            BetaContentBlockParamVariants::BetaThinkingBlockParam(var thinking) => thinking,
            BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam(var redactedThinking) =>
                redactedThinking,
            BetaContentBlockParamVariants::BetaToolUseBlockParam(var toolUse) => toolUse,
            BetaContentBlockParamVariants::BetaToolResultBlockParam(var toolResult) => toolResult,
            BetaContentBlockParamVariants::BetaServerToolUseBlockParam(var serverToolUse) =>
                serverToolUse,
            BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam(
                var webSearchToolResult
            ) => webSearchToolResult,
            BetaContentBlockParamVariants::BetaWebFetchToolResultBlockParam(
                var webFetchToolResult
            ) => webFetchToolResult,
            BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam(
                var codeExecutionToolResult
            ) => codeExecutionToolResult,
            BetaContentBlockParamVariants::BetaBashCodeExecutionToolResultBlockParam(
                var bashCodeExecutionToolResult
            ) => bashCodeExecutionToolResult,
            BetaContentBlockParamVariants::BetaTextEditorCodeExecutionToolResultBlockParam(
                var textEditorCodeExecutionToolResult
            ) => textEditorCodeExecutionToolResult,
            BetaContentBlockParamVariants::BetaMCPToolUseBlockParam(var mcpToolUse) => mcpToolUse,
            BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam(
                var requestMCPToolResult
            ) => requestMCPToolResult,
            BetaContentBlockParamVariants::BetaContainerUploadBlockParam(var containerUpload) =>
                containerUpload,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
