using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaContentBlockVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(BetaContentBlockConverter))]
public abstract record class BetaContentBlock
{
    internal BetaContentBlock() { }

    public static implicit operator BetaContentBlock(BetaTextBlock value) =>
        new BetaTextBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaThinkingBlock value) =>
        new BetaThinkingBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaRedactedThinkingBlock value) =>
        new BetaRedactedThinkingBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaToolUseBlock value) =>
        new BetaToolUseBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaServerToolUseBlock value) =>
        new BetaServerToolUseBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaWebSearchToolResultBlock value) =>
        new BetaWebSearchToolResultBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new BetaCodeExecutionToolResultBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaMCPToolUseBlock value) =>
        new BetaMCPToolUseBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaMCPToolResultBlock value) =>
        new BetaMCPToolResultBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaContainerUploadBlock value) =>
        new BetaContainerUploadBlockVariant(value);

    public bool TryPickBetaTextBlockVariant([NotNullWhen(true)] out BetaTextBlock? value)
    {
        value = (this as BetaTextBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaThinkingBlockVariant([NotNullWhen(true)] out BetaThinkingBlock? value)
    {
        value = (this as BetaThinkingBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRedactedThinkingBlockVariant(
        [NotNullWhen(true)] out BetaRedactedThinkingBlock? value
    )
    {
        value = (this as BetaRedactedThinkingBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolUseBlockVariant([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = (this as BetaToolUseBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaServerToolUseBlockVariant(
        [NotNullWhen(true)] out BetaServerToolUseBlock? value
    )
    {
        value = (this as BetaServerToolUseBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchToolResultBlockVariant(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlock? value
    )
    {
        value = (this as BetaWebSearchToolResultBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionToolResultBlockVariant(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlock? value
    )
    {
        value = (this as BetaCodeExecutionToolResultBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaMCPToolUseBlockVariant(
        [NotNullWhen(true)] out BetaMCPToolUseBlock? value
    )
    {
        value = (this as BetaMCPToolUseBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaMCPToolResultBlockVariant(
        [NotNullWhen(true)] out BetaMCPToolResultBlock? value
    )
    {
        value = (this as BetaMCPToolResultBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaContainerUploadBlockVariant(
        [NotNullWhen(true)] out BetaContainerUploadBlock? value
    )
    {
        value = (this as BetaContainerUploadBlockVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaTextBlockVariant> betaTextBlock,
        Action<BetaThinkingBlockVariant> betaThinkingBlock,
        Action<BetaRedactedThinkingBlockVariant> betaRedactedThinkingBlock,
        Action<BetaToolUseBlockVariant> betaToolUseBlock,
        Action<BetaServerToolUseBlockVariant> betaServerToolUseBlock,
        Action<BetaWebSearchToolResultBlockVariant> betaWebSearchToolResultBlock,
        Action<BetaCodeExecutionToolResultBlockVariant> betaCodeExecutionToolResultBlock,
        Action<BetaMCPToolUseBlockVariant> betaMCPToolUseBlock,
        Action<BetaMCPToolResultBlockVariant> betaMCPToolResultBlock,
        Action<BetaContainerUploadBlockVariant> betaContainerUploadBlock
    )
    {
        switch (this)
        {
            case BetaTextBlockVariant inner:
                betaTextBlock(inner);
                break;
            case BetaThinkingBlockVariant inner:
                betaThinkingBlock(inner);
                break;
            case BetaRedactedThinkingBlockVariant inner:
                betaRedactedThinkingBlock(inner);
                break;
            case BetaToolUseBlockVariant inner:
                betaToolUseBlock(inner);
                break;
            case BetaServerToolUseBlockVariant inner:
                betaServerToolUseBlock(inner);
                break;
            case BetaWebSearchToolResultBlockVariant inner:
                betaWebSearchToolResultBlock(inner);
                break;
            case BetaCodeExecutionToolResultBlockVariant inner:
                betaCodeExecutionToolResultBlock(inner);
                break;
            case BetaMCPToolUseBlockVariant inner:
                betaMCPToolUseBlock(inner);
                break;
            case BetaMCPToolResultBlockVariant inner:
                betaMCPToolResultBlock(inner);
                break;
            case BetaContainerUploadBlockVariant inner:
                betaContainerUploadBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaTextBlockVariant, T> betaTextBlock,
        Func<BetaThinkingBlockVariant, T> betaThinkingBlock,
        Func<BetaRedactedThinkingBlockVariant, T> betaRedactedThinkingBlock,
        Func<BetaToolUseBlockVariant, T> betaToolUseBlock,
        Func<BetaServerToolUseBlockVariant, T> betaServerToolUseBlock,
        Func<BetaWebSearchToolResultBlockVariant, T> betaWebSearchToolResultBlock,
        Func<BetaCodeExecutionToolResultBlockVariant, T> betaCodeExecutionToolResultBlock,
        Func<BetaMCPToolUseBlockVariant, T> betaMCPToolUseBlock,
        Func<BetaMCPToolResultBlockVariant, T> betaMCPToolResultBlock,
        Func<BetaContainerUploadBlockVariant, T> betaContainerUploadBlock
    )
    {
        return this switch
        {
            BetaTextBlockVariant inner => betaTextBlock(inner),
            BetaThinkingBlockVariant inner => betaThinkingBlock(inner),
            BetaRedactedThinkingBlockVariant inner => betaRedactedThinkingBlock(inner),
            BetaToolUseBlockVariant inner => betaToolUseBlock(inner),
            BetaServerToolUseBlockVariant inner => betaServerToolUseBlock(inner),
            BetaWebSearchToolResultBlockVariant inner => betaWebSearchToolResultBlock(inner),
            BetaCodeExecutionToolResultBlockVariant inner => betaCodeExecutionToolResultBlock(
                inner
            ),
            BetaMCPToolUseBlockVariant inner => betaMCPToolUseBlock(inner),
            BetaMCPToolResultBlockVariant inner => betaMCPToolResultBlock(inner),
            BetaContainerUploadBlockVariant inner => betaContainerUploadBlock(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaContentBlockConverter : JsonConverter<BetaContentBlock>
{
    public override BetaContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaTextBlockVariant(deserialized);
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
                        return new BetaThinkingBlockVariant(deserialized);
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
                        return new BetaRedactedThinkingBlockVariant(deserialized);
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
                        return new BetaToolUseBlockVariant(deserialized);
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
                        return new BetaServerToolUseBlockVariant(deserialized);
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
                        return new BetaWebSearchToolResultBlockVariant(deserialized);
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
                        return new BetaCodeExecutionToolResultBlockVariant(deserialized);
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
                        return new BetaMCPToolUseBlockVariant(deserialized);
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
                        return new BetaMCPToolResultBlockVariant(deserialized);
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
                        return new BetaContainerUploadBlockVariant(deserialized);
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
            BetaTextBlockVariant(var betaTextBlock) => betaTextBlock,
            BetaThinkingBlockVariant(var betaThinkingBlock) => betaThinkingBlock,
            BetaRedactedThinkingBlockVariant(var betaRedactedThinkingBlock) =>
                betaRedactedThinkingBlock,
            BetaToolUseBlockVariant(var betaToolUseBlock) => betaToolUseBlock,
            BetaServerToolUseBlockVariant(var betaServerToolUseBlock) => betaServerToolUseBlock,
            BetaWebSearchToolResultBlockVariant(var betaWebSearchToolResultBlock) =>
                betaWebSearchToolResultBlock,
            BetaCodeExecutionToolResultBlockVariant(var betaCodeExecutionToolResultBlock) =>
                betaCodeExecutionToolResultBlock,
            BetaMCPToolUseBlockVariant(var betaMCPToolUseBlock) => betaMCPToolUseBlock,
            BetaMCPToolResultBlockVariant(var betaMCPToolResultBlock) => betaMCPToolResultBlock,
            BetaContainerUploadBlockVariant(var betaContainerUploadBlock) =>
                betaContainerUploadBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
