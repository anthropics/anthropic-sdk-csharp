using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(ContentBlockConverter))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(Messages::BetaTextBlock value) =>
        new ContentBlockVariants::BetaTextBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaThinkingBlock value) =>
        new ContentBlockVariants::BetaThinkingBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaRedactedThinkingBlock value) =>
        new ContentBlockVariants::BetaRedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaToolUseBlock value) =>
        new ContentBlockVariants::BetaToolUseBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaServerToolUseBlock value) =>
        new ContentBlockVariants::BetaServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaWebSearchToolResultBlock value) =>
        new ContentBlockVariants::BetaWebSearchToolResultBlockVariant(value);

    public static implicit operator ContentBlock(
        Messages::BetaCodeExecutionToolResultBlock value
    ) => new ContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaMCPToolUseBlock value) =>
        new ContentBlockVariants::BetaMCPToolUseBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaMCPToolResultBlock value) =>
        new ContentBlockVariants::BetaMCPToolResultBlockVariant(value);

    public static implicit operator ContentBlock(Messages::BetaContainerUploadBlock value) =>
        new ContentBlockVariants::BetaContainerUploadBlockVariant(value);

    public abstract void Validate();
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaTextBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaTextBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaThinkingBlockVariant(deserialized);
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
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::BetaRedactedThinkingBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaRedactedThinkingBlockVariant(
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
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaToolUseBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaServerToolUseBlockVariant(
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
                        JsonSerializer.Deserialize<Messages::BetaWebSearchToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaWebSearchToolResultBlockVariant(
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
                        JsonSerializer.Deserialize<Messages::BetaCodeExecutionToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(
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
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaMCPToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaMCPToolUseBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaMCPToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaMCPToolResultBlockVariant(
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
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::BetaContainerUploadBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::BetaContainerUploadBlockVariant(
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
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockVariants::BetaTextBlockVariant(var betaTextBlock) => betaTextBlock,
            ContentBlockVariants::BetaThinkingBlockVariant(var betaThinkingBlock) =>
                betaThinkingBlock,
            ContentBlockVariants::BetaRedactedThinkingBlockVariant(var betaRedactedThinkingBlock) =>
                betaRedactedThinkingBlock,
            ContentBlockVariants::BetaToolUseBlockVariant(var betaToolUseBlock) => betaToolUseBlock,
            ContentBlockVariants::BetaServerToolUseBlockVariant(var betaServerToolUseBlock) =>
                betaServerToolUseBlock,
            ContentBlockVariants::BetaWebSearchToolResultBlockVariant(
                var betaWebSearchToolResultBlock
            ) => betaWebSearchToolResultBlock,
            ContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(
                var betaCodeExecutionToolResultBlock
            ) => betaCodeExecutionToolResultBlock,
            ContentBlockVariants::BetaMCPToolUseBlockVariant(var betaMCPToolUseBlock) =>
                betaMCPToolUseBlock,
            ContentBlockVariants::BetaMCPToolResultBlockVariant(var betaMCPToolResultBlock) =>
                betaMCPToolResultBlock,
            ContentBlockVariants::BetaContainerUploadBlockVariant(var betaContainerUploadBlock) =>
                betaContainerUploadBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
