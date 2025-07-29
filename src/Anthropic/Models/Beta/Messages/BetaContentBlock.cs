using Anthropic = Anthropic;
using BetaContentBlockVariants = Anthropic.Models.Beta.Messages.BetaContentBlockVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaContentBlock>))]
public abstract record class BetaContentBlock
{
    internal BetaContentBlock() { }

    public static implicit operator BetaContentBlock(BetaTextBlock value) =>
        new BetaContentBlockVariants::BetaTextBlock(value);

    public static implicit operator BetaContentBlock(BetaThinkingBlock value) =>
        new BetaContentBlockVariants::BetaThinkingBlock(value);

    public static implicit operator BetaContentBlock(BetaRedactedThinkingBlock value) =>
        new BetaContentBlockVariants::BetaRedactedThinkingBlock(value);

    public static implicit operator BetaContentBlock(BetaToolUseBlock value) =>
        new BetaContentBlockVariants::BetaToolUseBlock(value);

    public static implicit operator BetaContentBlock(BetaServerToolUseBlock value) =>
        new BetaContentBlockVariants::BetaServerToolUseBlock(value);

    public static implicit operator BetaContentBlock(BetaWebSearchToolResultBlock value) =>
        new BetaContentBlockVariants::BetaWebSearchToolResultBlock(value);

    public static implicit operator BetaContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new BetaContentBlockVariants::BetaCodeExecutionToolResultBlock(value);

    public static implicit operator BetaContentBlock(BetaMCPToolUseBlock value) =>
        new BetaContentBlockVariants::BetaMCPToolUseBlock(value);

    public static implicit operator BetaContentBlock(BetaMCPToolResultBlock value) =>
        new BetaContentBlockVariants::BetaMCPToolResultBlock(value);

    public static implicit operator BetaContentBlock(BetaContainerUploadBlock value) =>
        new BetaContentBlockVariants::BetaContainerUploadBlock(value);

    public abstract void Validate();
}
