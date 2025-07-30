using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(BetaTextBlock value) =>
        new ContentBlockVariants::BetaTextBlockVariant(value);

    public static implicit operator ContentBlock(BetaThinkingBlock value) =>
        new ContentBlockVariants::BetaThinkingBlockVariant(value);

    public static implicit operator ContentBlock(BetaRedactedThinkingBlock value) =>
        new ContentBlockVariants::BetaRedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock(BetaToolUseBlock value) =>
        new ContentBlockVariants::BetaToolUseBlockVariant(value);

    public static implicit operator ContentBlock(BetaServerToolUseBlock value) =>
        new ContentBlockVariants::BetaServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock(BetaWebSearchToolResultBlock value) =>
        new ContentBlockVariants::BetaWebSearchToolResultBlockVariant(value);

    public static implicit operator ContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new ContentBlockVariants::BetaCodeExecutionToolResultBlockVariant(value);

    public static implicit operator ContentBlock(BetaMCPToolUseBlock value) =>
        new ContentBlockVariants::BetaMCPToolUseBlockVariant(value);

    public static implicit operator ContentBlock(BetaMCPToolResultBlock value) =>
        new ContentBlockVariants::BetaMCPToolResultBlockVariant(value);

    public static implicit operator ContentBlock(BetaContainerUploadBlock value) =>
        new ContentBlockVariants::BetaContainerUploadBlockVariant(value);

    public abstract void Validate();
}
