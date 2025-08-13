using System.Collections.Generic;
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
        new BetaContentBlockVariants::BetaTextBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaThinkingBlock value) =>
        new BetaContentBlockVariants::BetaThinkingBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaRedactedThinkingBlock value) =>
        new BetaContentBlockVariants::BetaRedactedThinkingBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaToolUseBlock value) =>
        new BetaContentBlockVariants::BetaToolUseBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaServerToolUseBlock value) =>
        new BetaContentBlockVariants::BetaServerToolUseBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaWebSearchToolResultBlock value) =>
        new BetaContentBlockVariants::BetaWebSearchToolResultBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new BetaContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaMCPToolUseBlock value) =>
        new BetaContentBlockVariants::BetaMCPToolUseBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaMCPToolResultBlock value) =>
        new BetaContentBlockVariants::BetaMCPToolResultBlockVariant(value);

    public static implicit operator BetaContentBlock(BetaContainerUploadBlock value) =>
        new BetaContentBlockVariants::BetaContainerUploadBlockVariant(value);

    public abstract void Validate();
}

sealed class BetaContentBlockConverter : JsonConverter<BetaContentBlock>
{
    public override BetaContentBlock? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new BetaContentBlockVariants::BetaTextBlockVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaContentBlockVariants::BetaThinkingBlockVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaRedactedThinkingBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaContentBlockVariants::BetaToolUseBlockVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaServerToolUseBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaWebSearchToolResultBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaMCPToolUseBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaMCPToolResultBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaContentBlockVariants::BetaContainerUploadBlockVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
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
            BetaContentBlockVariants::BetaTextBlockVariant(var betaTextBlock) => betaTextBlock,
            BetaContentBlockVariants::BetaThinkingBlockVariant(var betaThinkingBlock) =>
                betaThinkingBlock,
            BetaContentBlockVariants::BetaRedactedThinkingBlockVariant(
                var betaRedactedThinkingBlock
            ) => betaRedactedThinkingBlock,
            BetaContentBlockVariants::BetaToolUseBlockVariant(var betaToolUseBlock) =>
                betaToolUseBlock,
            BetaContentBlockVariants::BetaServerToolUseBlockVariant(var betaServerToolUseBlock) =>
                betaServerToolUseBlock,
            BetaContentBlockVariants::BetaWebSearchToolResultBlockVariant(
                var betaWebSearchToolResultBlock
            ) => betaWebSearchToolResultBlock,
            BetaContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(
                var betaCodeExecutionToolResultBlock
            ) => betaCodeExecutionToolResultBlock,
            BetaContentBlockVariants::BetaMCPToolUseBlockVariant(var betaMCPToolUseBlock) =>
                betaMCPToolUseBlock,
            BetaContentBlockVariants::BetaMCPToolResultBlockVariant(var betaMCPToolResultBlock) =>
                betaMCPToolResultBlock,
            BetaContentBlockVariants::BetaContainerUploadBlockVariant(
                var betaContainerUploadBlock
            ) => betaContainerUploadBlock,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
