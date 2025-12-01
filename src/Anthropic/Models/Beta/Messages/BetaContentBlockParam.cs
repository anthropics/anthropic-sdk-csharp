using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(BetaContentBlockParamConverter))]
public record class BetaContentBlockParam
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
                image: (x) => x.Type,
                requestDocumentBlock: (x) => x.Type,
                searchResult: (x) => x.Type,
                thinking: (x) => x.Type,
                redactedThinking: (x) => x.Type,
                toolUse: (x) => x.Type,
                toolResult: (x) => x.Type,
                serverToolUse: (x) => x.Type,
                webSearchToolResult: (x) => x.Type,
                webFetchToolResult: (x) => x.Type,
                codeExecutionToolResult: (x) => x.Type,
                bashCodeExecutionToolResult: (x) => x.Type,
                textEditorCodeExecutionToolResult: (x) => x.Type,
                toolSearchToolResult: (x) => x.Type,
                mcpToolUse: (x) => x.Type,
                requestMCPToolResult: (x) => x.Type,
                containerUpload: (x) => x.Type
            );
        }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                text: (x) => x.CacheControl,
                image: (x) => x.CacheControl,
                requestDocumentBlock: (x) => x.CacheControl,
                searchResult: (x) => x.CacheControl,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.CacheControl,
                toolResult: (x) => x.CacheControl,
                serverToolUse: (x) => x.CacheControl,
                webSearchToolResult: (x) => x.CacheControl,
                webFetchToolResult: (x) => x.CacheControl,
                codeExecutionToolResult: (x) => x.CacheControl,
                bashCodeExecutionToolResult: (x) => x.CacheControl,
                textEditorCodeExecutionToolResult: (x) => x.CacheControl,
                toolSearchToolResult: (x) => x.CacheControl,
                mcpToolUse: (x) => x.CacheControl,
                requestMCPToolResult: (x) => x.CacheControl,
                containerUpload: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                requestDocumentBlock: (x) => x.Title,
                searchResult: (x) => x.Title,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                toolResult: (_) => null,
                serverToolUse: (_) => null,
                webSearchToolResult: (_) => null,
                webFetchToolResult: (_) => null,
                codeExecutionToolResult: (_) => null,
                bashCodeExecutionToolResult: (_) => null,
                textEditorCodeExecutionToolResult: (_) => null,
                toolSearchToolResult: (_) => null,
                mcpToolUse: (_) => null,
                requestMCPToolResult: (_) => null,
                containerUpload: (_) => null
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                requestDocumentBlock: (_) => null,
                searchResult: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.ID,
                toolResult: (_) => null,
                serverToolUse: (x) => x.ID,
                webSearchToolResult: (_) => null,
                webFetchToolResult: (_) => null,
                codeExecutionToolResult: (_) => null,
                bashCodeExecutionToolResult: (_) => null,
                textEditorCodeExecutionToolResult: (_) => null,
                toolSearchToolResult: (_) => null,
                mcpToolUse: (x) => x.ID,
                requestMCPToolResult: (_) => null,
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
                image: (_) => null,
                requestDocumentBlock: (_) => null,
                searchResult: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                toolResult: (x) => x.ToolUseID,
                serverToolUse: (_) => null,
                webSearchToolResult: (x) => x.ToolUseID,
                webFetchToolResult: (x) => x.ToolUseID,
                codeExecutionToolResult: (x) => x.ToolUseID,
                bashCodeExecutionToolResult: (x) => x.ToolUseID,
                textEditorCodeExecutionToolResult: (x) => x.ToolUseID,
                toolSearchToolResult: (x) => x.ToolUseID,
                mcpToolUse: (_) => null,
                requestMCPToolResult: (x) => x.ToolUseID,
                containerUpload: (_) => null
            );
        }
    }

    public bool? IsError
    {
        get
        {
            return Match<bool?>(
                text: (_) => null,
                image: (_) => null,
                requestDocumentBlock: (_) => null,
                searchResult: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                toolResult: (x) => x.IsError,
                serverToolUse: (_) => null,
                webSearchToolResult: (_) => null,
                webFetchToolResult: (_) => null,
                codeExecutionToolResult: (_) => null,
                bashCodeExecutionToolResult: (_) => null,
                textEditorCodeExecutionToolResult: (_) => null,
                toolSearchToolResult: (_) => null,
                mcpToolUse: (_) => null,
                requestMCPToolResult: (x) => x.IsError,
                containerUpload: (_) => null
            );
        }
    }

    public BetaContentBlockParam(BetaTextBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaImageBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaRequestDocumentBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaSearchResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaThinkingBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaRedactedThinkingBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaToolUseBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaToolResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaServerToolUseBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaWebSearchToolResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaWebFetchToolResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(
        BetaBashCodeExecutionToolResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(
        BetaTextEditorCodeExecutionToolResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaToolSearchToolResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaMCPToolUseBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaRequestMCPToolResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(BetaContainerUploadBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlockParam(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickText([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = this.Value as BetaTextBlockParam;
        return value != null;
    }

    public bool TryPickImage([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = this.Value as BetaImageBlockParam;
        return value != null;
    }

    public bool TryPickRequestDocumentBlock([NotNullWhen(true)] out BetaRequestDocumentBlock? value)
    {
        value = this.Value as BetaRequestDocumentBlock;
        return value != null;
    }

    public bool TryPickSearchResult([NotNullWhen(true)] out BetaSearchResultBlockParam? value)
    {
        value = this.Value as BetaSearchResultBlockParam;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingBlockParam? value)
    {
        value = this.Value as BetaThinkingBlockParam;
        return value != null;
    }

    public bool TryPickRedactedThinking(
        [NotNullWhen(true)] out BetaRedactedThinkingBlockParam? value
    )
    {
        value = this.Value as BetaRedactedThinkingBlockParam;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out BetaToolUseBlockParam? value)
    {
        value = this.Value as BetaToolUseBlockParam;
        return value != null;
    }

    public bool TryPickToolResult([NotNullWhen(true)] out BetaToolResultBlockParam? value)
    {
        value = this.Value as BetaToolResultBlockParam;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlockParam? value)
    {
        value = this.Value as BetaServerToolUseBlockParam;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlockParam? value
    )
    {
        value = this.Value as BetaWebSearchToolResultBlockParam;
        return value != null;
    }

    public bool TryPickWebFetchToolResult(
        [NotNullWhen(true)] out BetaWebFetchToolResultBlockParam? value
    )
    {
        value = this.Value as BetaWebFetchToolResultBlockParam;
        return value != null;
    }

    public bool TryPickCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlockParam? value
    )
    {
        value = this.Value as BetaCodeExecutionToolResultBlockParam;
        return value != null;
    }

    public bool TryPickBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultBlockParam? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultBlockParam;
        return value != null;
    }

    public bool TryPickTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultBlockParam;
        return value != null;
    }

    public bool TryPickToolSearchToolResult(
        [NotNullWhen(true)] out BetaToolSearchToolResultBlockParam? value
    )
    {
        value = this.Value as BetaToolSearchToolResultBlockParam;
        return value != null;
    }

    public bool TryPickMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlockParam? value)
    {
        value = this.Value as BetaMCPToolUseBlockParam;
        return value != null;
    }

    public bool TryPickRequestMCPToolResult(
        [NotNullWhen(true)] out BetaRequestMCPToolResultBlockParam? value
    )
    {
        value = this.Value as BetaRequestMCPToolResultBlockParam;
        return value != null;
    }

    public bool TryPickContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlockParam? value)
    {
        value = this.Value as BetaContainerUploadBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextBlockParam> text,
        System::Action<BetaImageBlockParam> image,
        System::Action<BetaRequestDocumentBlock> requestDocumentBlock,
        System::Action<BetaSearchResultBlockParam> searchResult,
        System::Action<BetaThinkingBlockParam> thinking,
        System::Action<BetaRedactedThinkingBlockParam> redactedThinking,
        System::Action<BetaToolUseBlockParam> toolUse,
        System::Action<BetaToolResultBlockParam> toolResult,
        System::Action<BetaServerToolUseBlockParam> serverToolUse,
        System::Action<BetaWebSearchToolResultBlockParam> webSearchToolResult,
        System::Action<BetaWebFetchToolResultBlockParam> webFetchToolResult,
        System::Action<BetaCodeExecutionToolResultBlockParam> codeExecutionToolResult,
        System::Action<BetaBashCodeExecutionToolResultBlockParam> bashCodeExecutionToolResult,
        System::Action<BetaTextEditorCodeExecutionToolResultBlockParam> textEditorCodeExecutionToolResult,
        System::Action<BetaToolSearchToolResultBlockParam> toolSearchToolResult,
        System::Action<BetaMCPToolUseBlockParam> mcpToolUse,
        System::Action<BetaRequestMCPToolResultBlockParam> requestMCPToolResult,
        System::Action<BetaContainerUploadBlockParam> containerUpload
    )
    {
        switch (this.Value)
        {
            case BetaTextBlockParam value:
                text(value);
                break;
            case BetaImageBlockParam value:
                image(value);
                break;
            case BetaRequestDocumentBlock value:
                requestDocumentBlock(value);
                break;
            case BetaSearchResultBlockParam value:
                searchResult(value);
                break;
            case BetaThinkingBlockParam value:
                thinking(value);
                break;
            case BetaRedactedThinkingBlockParam value:
                redactedThinking(value);
                break;
            case BetaToolUseBlockParam value:
                toolUse(value);
                break;
            case BetaToolResultBlockParam value:
                toolResult(value);
                break;
            case BetaServerToolUseBlockParam value:
                serverToolUse(value);
                break;
            case BetaWebSearchToolResultBlockParam value:
                webSearchToolResult(value);
                break;
            case BetaWebFetchToolResultBlockParam value:
                webFetchToolResult(value);
                break;
            case BetaCodeExecutionToolResultBlockParam value:
                codeExecutionToolResult(value);
                break;
            case BetaBashCodeExecutionToolResultBlockParam value:
                bashCodeExecutionToolResult(value);
                break;
            case BetaTextEditorCodeExecutionToolResultBlockParam value:
                textEditorCodeExecutionToolResult(value);
                break;
            case BetaToolSearchToolResultBlockParam value:
                toolSearchToolResult(value);
                break;
            case BetaMCPToolUseBlockParam value:
                mcpToolUse(value);
                break;
            case BetaRequestMCPToolResultBlockParam value:
                requestMCPToolResult(value);
                break;
            case BetaContainerUploadBlockParam value:
                containerUpload(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlockParam"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaTextBlockParam, T> text,
        System::Func<BetaImageBlockParam, T> image,
        System::Func<BetaRequestDocumentBlock, T> requestDocumentBlock,
        System::Func<BetaSearchResultBlockParam, T> searchResult,
        System::Func<BetaThinkingBlockParam, T> thinking,
        System::Func<BetaRedactedThinkingBlockParam, T> redactedThinking,
        System::Func<BetaToolUseBlockParam, T> toolUse,
        System::Func<BetaToolResultBlockParam, T> toolResult,
        System::Func<BetaServerToolUseBlockParam, T> serverToolUse,
        System::Func<BetaWebSearchToolResultBlockParam, T> webSearchToolResult,
        System::Func<BetaWebFetchToolResultBlockParam, T> webFetchToolResult,
        System::Func<BetaCodeExecutionToolResultBlockParam, T> codeExecutionToolResult,
        System::Func<BetaBashCodeExecutionToolResultBlockParam, T> bashCodeExecutionToolResult,
        System::Func<
            BetaTextEditorCodeExecutionToolResultBlockParam,
            T
        > textEditorCodeExecutionToolResult,
        System::Func<BetaToolSearchToolResultBlockParam, T> toolSearchToolResult,
        System::Func<BetaMCPToolUseBlockParam, T> mcpToolUse,
        System::Func<BetaRequestMCPToolResultBlockParam, T> requestMCPToolResult,
        System::Func<BetaContainerUploadBlockParam, T> containerUpload
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => text(value),
            BetaImageBlockParam value => image(value),
            BetaRequestDocumentBlock value => requestDocumentBlock(value),
            BetaSearchResultBlockParam value => searchResult(value),
            BetaThinkingBlockParam value => thinking(value),
            BetaRedactedThinkingBlockParam value => redactedThinking(value),
            BetaToolUseBlockParam value => toolUse(value),
            BetaToolResultBlockParam value => toolResult(value),
            BetaServerToolUseBlockParam value => serverToolUse(value),
            BetaWebSearchToolResultBlockParam value => webSearchToolResult(value),
            BetaWebFetchToolResultBlockParam value => webFetchToolResult(value),
            BetaCodeExecutionToolResultBlockParam value => codeExecutionToolResult(value),
            BetaBashCodeExecutionToolResultBlockParam value => bashCodeExecutionToolResult(value),
            BetaTextEditorCodeExecutionToolResultBlockParam value =>
                textEditorCodeExecutionToolResult(value),
            BetaToolSearchToolResultBlockParam value => toolSearchToolResult(value),
            BetaMCPToolUseBlockParam value => mcpToolUse(value),
            BetaRequestMCPToolResultBlockParam value => requestMCPToolResult(value),
            BetaContainerUploadBlockParam value => containerUpload(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockParam"
            ),
        };
    }

    public static implicit operator BetaContentBlockParam(BetaTextBlockParam value) => new(value);

    public static implicit operator BetaContentBlockParam(BetaImageBlockParam value) => new(value);

    public static implicit operator BetaContentBlockParam(BetaRequestDocumentBlock value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(BetaSearchResultBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(BetaThinkingBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(BetaRedactedThinkingBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(BetaToolUseBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(BetaToolResultBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(BetaServerToolUseBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(
        BetaWebSearchToolResultBlockParam value
    ) => new(value);

    public static implicit operator BetaContentBlockParam(BetaWebFetchToolResultBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value
    ) => new(value);

    public static implicit operator BetaContentBlockParam(
        BetaBashCodeExecutionToolResultBlockParam value
    ) => new(value);

    public static implicit operator BetaContentBlockParam(
        BetaTextEditorCodeExecutionToolResultBlockParam value
    ) => new(value);

    public static implicit operator BetaContentBlockParam(
        BetaToolSearchToolResultBlockParam value
    ) => new(value);

    public static implicit operator BetaContentBlockParam(BetaMCPToolUseBlockParam value) =>
        new(value);

    public static implicit operator BetaContentBlockParam(
        BetaRequestMCPToolResultBlockParam value
    ) => new(value);

    public static implicit operator BetaContentBlockParam(BetaContainerUploadBlockParam value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockParam"
            );
        }
    }

    public virtual bool Equals(BetaContentBlockParam? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaContentBlockParamConverter : JsonConverter<BetaContentBlockParam>
{
    public override BetaContentBlockParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
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
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
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
            case "document":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
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
            case "search_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
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
            case "thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlockParam>(
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
            case "redacted_thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlockParam>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlockParam>(
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
            case "tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(
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
            case "server_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParam>(
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
                        JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlockParam>(
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
                        JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaToolSearchToolResultBlockParam>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlockParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRequestMCPToolResultBlockParam>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlockParam>(
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
                return new BetaContentBlockParam(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
