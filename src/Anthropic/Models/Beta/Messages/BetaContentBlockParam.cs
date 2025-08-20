using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(BetaContentBlockParamConverter))]
public abstract record class BetaContentBlockParam
{
    internal BetaContentBlockParam() { }

    public static implicit operator BetaContentBlockParam(BetaTextBlockParam value) =>
        new BetaTextBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaImageBlockParam value) =>
        new BetaImageBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaRequestDocumentBlock value) =>
        new BetaRequestDocumentBlockVariant(value);

    public static implicit operator BetaContentBlockParam(BetaSearchResultBlockParam value) =>
        new BetaSearchResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaThinkingBlockParam value) =>
        new BetaThinkingBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaRedactedThinkingBlockParam value) =>
        new BetaRedactedThinkingBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaToolUseBlockParam value) =>
        new BetaToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaToolResultBlockParam value) =>
        new BetaToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaServerToolUseBlockParam value) =>
        new BetaServerToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaWebSearchToolResultBlockParam value
    ) => new BetaWebSearchToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value
    ) => new BetaCodeExecutionToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaMCPToolUseBlockParam value) =>
        new BetaMCPToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaRequestMCPToolResultBlockParam value
    ) => new BetaRequestMCPToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaContainerUploadBlockParam value) =>
        new BetaContainerUploadBlockParamVariant(value);

    public bool TryPickBetaTextBlockParamVariant([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = (this as BetaTextBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaImageBlockParamVariant(
        [NotNullWhen(true)] out BetaImageBlockParam? value
    )
    {
        value = (this as BetaImageBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRequestDocumentBlockVariant(
        [NotNullWhen(true)] out BetaRequestDocumentBlock? value
    )
    {
        value = (this as BetaRequestDocumentBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaSearchResultBlockParamVariant(
        [NotNullWhen(true)] out BetaSearchResultBlockParam? value
    )
    {
        value = (this as BetaSearchResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaThinkingBlockParamVariant(
        [NotNullWhen(true)] out BetaThinkingBlockParam? value
    )
    {
        value = (this as BetaThinkingBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRedactedThinkingBlockParamVariant(
        [NotNullWhen(true)] out BetaRedactedThinkingBlockParam? value
    )
    {
        value = (this as BetaRedactedThinkingBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolUseBlockParamVariant(
        [NotNullWhen(true)] out BetaToolUseBlockParam? value
    )
    {
        value = (this as BetaToolUseBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolResultBlockParamVariant(
        [NotNullWhen(true)] out BetaToolResultBlockParam? value
    )
    {
        value = (this as BetaToolResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaServerToolUseBlockParamVariant(
        [NotNullWhen(true)] out BetaServerToolUseBlockParam? value
    )
    {
        value = (this as BetaServerToolUseBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchToolResultBlockParamVariant(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlockParam? value
    )
    {
        value = (this as BetaWebSearchToolResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionToolResultBlockParamVariant(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlockParam? value
    )
    {
        value = (this as BetaCodeExecutionToolResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaMCPToolUseBlockParamVariant(
        [NotNullWhen(true)] out BetaMCPToolUseBlockParam? value
    )
    {
        value = (this as BetaMCPToolUseBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRequestMCPToolResultBlockParamVariant(
        [NotNullWhen(true)] out BetaRequestMCPToolResultBlockParam? value
    )
    {
        value = (this as BetaRequestMCPToolResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaContainerUploadBlockParamVariant(
        [NotNullWhen(true)] out BetaContainerUploadBlockParam? value
    )
    {
        value = (this as BetaContainerUploadBlockParamVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaTextBlockParamVariant> betaTextBlockParam,
        Action<BetaImageBlockParamVariant> betaImageBlockParam,
        Action<BetaRequestDocumentBlockVariant> betaRequestDocumentBlock,
        Action<BetaSearchResultBlockParamVariant> betaSearchResultBlockParam,
        Action<BetaThinkingBlockParamVariant> betaThinkingBlockParam,
        Action<BetaRedactedThinkingBlockParamVariant> betaRedactedThinkingBlockParam,
        Action<BetaToolUseBlockParamVariant> betaToolUseBlockParam,
        Action<BetaToolResultBlockParamVariant> betaToolResultBlockParam,
        Action<BetaServerToolUseBlockParamVariant> betaServerToolUseBlockParam,
        Action<BetaWebSearchToolResultBlockParamVariant> betaWebSearchToolResultBlockParam,
        Action<BetaCodeExecutionToolResultBlockParamVariant> betaCodeExecutionToolResultBlockParam,
        Action<BetaMCPToolUseBlockParamVariant> betaMCPToolUseBlockParam,
        Action<BetaRequestMCPToolResultBlockParamVariant> betaRequestMCPToolResultBlockParam,
        Action<BetaContainerUploadBlockParamVariant> betaContainerUploadBlockParam
    )
    {
        switch (this)
        {
            case BetaTextBlockParamVariant inner:
                betaTextBlockParam(inner);
                break;
            case BetaImageBlockParamVariant inner:
                betaImageBlockParam(inner);
                break;
            case BetaRequestDocumentBlockVariant inner:
                betaRequestDocumentBlock(inner);
                break;
            case BetaSearchResultBlockParamVariant inner:
                betaSearchResultBlockParam(inner);
                break;
            case BetaThinkingBlockParamVariant inner:
                betaThinkingBlockParam(inner);
                break;
            case BetaRedactedThinkingBlockParamVariant inner:
                betaRedactedThinkingBlockParam(inner);
                break;
            case BetaToolUseBlockParamVariant inner:
                betaToolUseBlockParam(inner);
                break;
            case BetaToolResultBlockParamVariant inner:
                betaToolResultBlockParam(inner);
                break;
            case BetaServerToolUseBlockParamVariant inner:
                betaServerToolUseBlockParam(inner);
                break;
            case BetaWebSearchToolResultBlockParamVariant inner:
                betaWebSearchToolResultBlockParam(inner);
                break;
            case BetaCodeExecutionToolResultBlockParamVariant inner:
                betaCodeExecutionToolResultBlockParam(inner);
                break;
            case BetaMCPToolUseBlockParamVariant inner:
                betaMCPToolUseBlockParam(inner);
                break;
            case BetaRequestMCPToolResultBlockParamVariant inner:
                betaRequestMCPToolResultBlockParam(inner);
                break;
            case BetaContainerUploadBlockParamVariant inner:
                betaContainerUploadBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaTextBlockParamVariant, T> betaTextBlockParam,
        Func<BetaImageBlockParamVariant, T> betaImageBlockParam,
        Func<BetaRequestDocumentBlockVariant, T> betaRequestDocumentBlock,
        Func<BetaSearchResultBlockParamVariant, T> betaSearchResultBlockParam,
        Func<BetaThinkingBlockParamVariant, T> betaThinkingBlockParam,
        Func<BetaRedactedThinkingBlockParamVariant, T> betaRedactedThinkingBlockParam,
        Func<BetaToolUseBlockParamVariant, T> betaToolUseBlockParam,
        Func<BetaToolResultBlockParamVariant, T> betaToolResultBlockParam,
        Func<BetaServerToolUseBlockParamVariant, T> betaServerToolUseBlockParam,
        Func<BetaWebSearchToolResultBlockParamVariant, T> betaWebSearchToolResultBlockParam,
        Func<BetaCodeExecutionToolResultBlockParamVariant, T> betaCodeExecutionToolResultBlockParam,
        Func<BetaMCPToolUseBlockParamVariant, T> betaMCPToolUseBlockParam,
        Func<BetaRequestMCPToolResultBlockParamVariant, T> betaRequestMCPToolResultBlockParam,
        Func<BetaContainerUploadBlockParamVariant, T> betaContainerUploadBlockParam
    )
    {
        return this switch
        {
            BetaTextBlockParamVariant inner => betaTextBlockParam(inner),
            BetaImageBlockParamVariant inner => betaImageBlockParam(inner),
            BetaRequestDocumentBlockVariant inner => betaRequestDocumentBlock(inner),
            BetaSearchResultBlockParamVariant inner => betaSearchResultBlockParam(inner),
            BetaThinkingBlockParamVariant inner => betaThinkingBlockParam(inner),
            BetaRedactedThinkingBlockParamVariant inner => betaRedactedThinkingBlockParam(inner),
            BetaToolUseBlockParamVariant inner => betaToolUseBlockParam(inner),
            BetaToolResultBlockParamVariant inner => betaToolResultBlockParam(inner),
            BetaServerToolUseBlockParamVariant inner => betaServerToolUseBlockParam(inner),
            BetaWebSearchToolResultBlockParamVariant inner => betaWebSearchToolResultBlockParam(
                inner
            ),
            BetaCodeExecutionToolResultBlockParamVariant inner =>
                betaCodeExecutionToolResultBlockParam(inner),
            BetaMCPToolUseBlockParamVariant inner => betaMCPToolUseBlockParam(inner),
            BetaRequestMCPToolResultBlockParamVariant inner => betaRequestMCPToolResultBlockParam(
                inner
            ),
            BetaContainerUploadBlockParamVariant inner => betaContainerUploadBlockParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaContentBlockParamConverter : JsonConverter<BetaContentBlockParam>
{
    public override BetaContentBlockParam? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                        return new BetaTextBlockParamVariant(deserialized);
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
                        return new BetaImageBlockParamVariant(deserialized);
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
                        return new BetaRequestDocumentBlockVariant(deserialized);
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
                        return new BetaSearchResultBlockParamVariant(deserialized);
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
                        return new BetaThinkingBlockParamVariant(deserialized);
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
                        return new BetaRedactedThinkingBlockParamVariant(deserialized);
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
                        return new BetaToolUseBlockParamVariant(deserialized);
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
                        return new BetaToolResultBlockParamVariant(deserialized);
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
                        return new BetaServerToolUseBlockParamVariant(deserialized);
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
                        return new BetaWebSearchToolResultBlockParamVariant(deserialized);
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
                        return new BetaCodeExecutionToolResultBlockParamVariant(deserialized);
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
                        return new BetaMCPToolUseBlockParamVariant(deserialized);
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
                        return new BetaRequestMCPToolResultBlockParamVariant(deserialized);
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
                        return new BetaContainerUploadBlockParamVariant(deserialized);
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
            BetaTextBlockParamVariant(var betaTextBlockParam) => betaTextBlockParam,
            BetaImageBlockParamVariant(var betaImageBlockParam) => betaImageBlockParam,
            BetaRequestDocumentBlockVariant(var betaRequestDocumentBlock) =>
                betaRequestDocumentBlock,
            BetaSearchResultBlockParamVariant(var betaSearchResultBlockParam) =>
                betaSearchResultBlockParam,
            BetaThinkingBlockParamVariant(var betaThinkingBlockParam) => betaThinkingBlockParam,
            BetaRedactedThinkingBlockParamVariant(var betaRedactedThinkingBlockParam) =>
                betaRedactedThinkingBlockParam,
            BetaToolUseBlockParamVariant(var betaToolUseBlockParam) => betaToolUseBlockParam,
            BetaToolResultBlockParamVariant(var betaToolResultBlockParam) =>
                betaToolResultBlockParam,
            BetaServerToolUseBlockParamVariant(var betaServerToolUseBlockParam) =>
                betaServerToolUseBlockParam,
            BetaWebSearchToolResultBlockParamVariant(var betaWebSearchToolResultBlockParam) =>
                betaWebSearchToolResultBlockParam,
            BetaCodeExecutionToolResultBlockParamVariant(
                var betaCodeExecutionToolResultBlockParam
            ) => betaCodeExecutionToolResultBlockParam,
            BetaMCPToolUseBlockParamVariant(var betaMCPToolUseBlockParam) =>
                betaMCPToolUseBlockParam,
            BetaRequestMCPToolResultBlockParamVariant(var betaRequestMCPToolResultBlockParam) =>
                betaRequestMCPToolResultBlockParam,
            BetaContainerUploadBlockParamVariant(var betaContainerUploadBlockParam) =>
                betaContainerUploadBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
