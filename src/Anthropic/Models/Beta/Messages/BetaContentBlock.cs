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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaTextBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaThinkingBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaRedactedThinkingBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaToolUseBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaServerToolUseBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
                ref reader,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
                ref reader,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlock>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaMCPToolUseBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaMCPToolResultBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockVariants::BetaContainerUploadBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
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
