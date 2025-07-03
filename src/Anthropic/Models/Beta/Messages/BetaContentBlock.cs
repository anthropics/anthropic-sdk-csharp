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

    public static BetaContentBlockVariants::BetaTextBlock Create(BetaTextBlock value) => new(value);

    public static BetaContentBlockVariants::BetaThinkingBlock Create(BetaThinkingBlock value) =>
        new(value);

    public static BetaContentBlockVariants::BetaRedactedThinkingBlock Create(
        BetaRedactedThinkingBlock value
    ) => new(value);

    public static BetaContentBlockVariants::BetaToolUseBlock Create(BetaToolUseBlock value) =>
        new(value);

    public static BetaContentBlockVariants::BetaServerToolUseBlock Create(
        BetaServerToolUseBlock value
    ) => new(value);

    public static BetaContentBlockVariants::BetaWebSearchToolResultBlock Create(
        BetaWebSearchToolResultBlock value
    ) => new(value);

    public static BetaContentBlockVariants::BetaCodeExecutionToolResultBlock Create(
        BetaCodeExecutionToolResultBlock value
    ) => new(value);

    public static BetaContentBlockVariants::BetaMCPToolUseBlock Create(BetaMCPToolUseBlock value) =>
        new(value);

    public static BetaContentBlockVariants::BetaMCPToolResultBlock Create(
        BetaMCPToolResultBlock value
    ) => new(value);

    public static BetaContentBlockVariants::BetaContainerUploadBlock Create(
        BetaContainerUploadBlock value
    ) => new(value);

    public abstract void Validate();
}
