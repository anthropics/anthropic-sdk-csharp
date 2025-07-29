using Anthropic = Anthropic;
using ContentBlockVariants = Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(Messages::BetaTextBlock value) =>
        new ContentBlockVariants::BetaTextBlock(value);

    public static implicit operator ContentBlock(Messages::BetaThinkingBlock value) =>
        new ContentBlockVariants::BetaThinkingBlock(value);

    public static implicit operator ContentBlock(Messages::BetaRedactedThinkingBlock value) =>
        new ContentBlockVariants::BetaRedactedThinkingBlock(value);

    public static implicit operator ContentBlock(Messages::BetaToolUseBlock value) =>
        new ContentBlockVariants::BetaToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::BetaServerToolUseBlock value) =>
        new ContentBlockVariants::BetaServerToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::BetaWebSearchToolResultBlock value) =>
        new ContentBlockVariants::BetaWebSearchToolResultBlock(value);

    public static implicit operator ContentBlock(
        Messages::BetaCodeExecutionToolResultBlock value
    ) => new ContentBlockVariants::BetaCodeExecutionToolResultBlock(value);

    public static implicit operator ContentBlock(Messages::BetaMCPToolUseBlock value) =>
        new ContentBlockVariants::BetaMCPToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::BetaMCPToolResultBlock value) =>
        new ContentBlockVariants::BetaMCPToolResultBlock(value);

    public static implicit operator ContentBlock(Messages::BetaContainerUploadBlock value) =>
        new ContentBlockVariants::BetaContainerUploadBlock(value);

    public abstract void Validate();
}
