using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaContentBlockParamVariants = Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(BetaContentBlockParamConverter))]
public abstract record class BetaContentBlockParam
{
    internal BetaContentBlockParam() { }

    public static implicit operator BetaContentBlockParam(BetaTextBlockParam value) =>
        new BetaContentBlockParamVariants::BetaTextBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaImageBlockParam value) =>
        new BetaContentBlockParamVariants::BetaImageBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaRequestDocumentBlock value) =>
        new BetaContentBlockParamVariants::BetaRequestDocumentBlockVariant(value);

    public static implicit operator BetaContentBlockParam(BetaSearchResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaSearchResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaThinkingBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaRedactedThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaRedactedThinkingBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaToolResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaServerToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaServerToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaWebSearchToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaMCPToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaMCPToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaRequestMCPToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaContainerUploadBlockParam value) =>
        new BetaContentBlockParamVariants::BetaContainerUploadBlockParamVariant(value);

    public abstract void Validate();
}

sealed class BetaContentBlockParamConverter : JsonConverter<BetaContentBlockParam>
{
    public override BetaContentBlockParam? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaTextBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaImageBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaRequestDocumentBlockVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaSearchResultBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaThinkingBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaThinkingBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaRedactedThinkingBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolUseBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaToolUseBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaToolResultBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaServerToolUseBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaMCPToolUseBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaRequestMCPToolResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaContentBlockParamVariants::BetaContainerUploadBlockParamVariant(
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

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaContentBlockParamVariants::BetaTextBlockParamVariant(var betaTextBlockParam) =>
                betaTextBlockParam,
            BetaContentBlockParamVariants::BetaImageBlockParamVariant(var betaImageBlockParam) =>
                betaImageBlockParam,
            BetaContentBlockParamVariants::BetaRequestDocumentBlockVariant(
                var betaRequestDocumentBlock
            ) => betaRequestDocumentBlock,
            BetaContentBlockParamVariants::BetaSearchResultBlockParamVariant(
                var betaSearchResultBlockParam
            ) => betaSearchResultBlockParam,
            BetaContentBlockParamVariants::BetaThinkingBlockParamVariant(
                var betaThinkingBlockParam
            ) => betaThinkingBlockParam,
            BetaContentBlockParamVariants::BetaRedactedThinkingBlockParamVariant(
                var betaRedactedThinkingBlockParam
            ) => betaRedactedThinkingBlockParam,
            BetaContentBlockParamVariants::BetaToolUseBlockParamVariant(
                var betaToolUseBlockParam
            ) => betaToolUseBlockParam,
            BetaContentBlockParamVariants::BetaToolResultBlockParamVariant(
                var betaToolResultBlockParam
            ) => betaToolResultBlockParam,
            BetaContentBlockParamVariants::BetaServerToolUseBlockParamVariant(
                var betaServerToolUseBlockParam
            ) => betaServerToolUseBlockParam,
            BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParamVariant(
                var betaWebSearchToolResultBlockParam
            ) => betaWebSearchToolResultBlockParam,
            BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParamVariant(
                var betaCodeExecutionToolResultBlockParam
            ) => betaCodeExecutionToolResultBlockParam,
            BetaContentBlockParamVariants::BetaMCPToolUseBlockParamVariant(
                var betaMCPToolUseBlockParam
            ) => betaMCPToolUseBlockParam,
            BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParamVariant(
                var betaRequestMCPToolResultBlockParam
            ) => betaRequestMCPToolResultBlockParam,
            BetaContentBlockParamVariants::BetaContainerUploadBlockParamVariant(
                var betaContainerUploadBlockParam
            ) => betaContainerUploadBlockParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
