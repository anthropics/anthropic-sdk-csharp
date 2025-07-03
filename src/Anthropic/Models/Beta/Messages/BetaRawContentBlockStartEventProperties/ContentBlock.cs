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

    public static ContentBlockVariants::BetaTextBlock Create(Messages::BetaTextBlock value) =>
        new(value);

    public static ContentBlockVariants::BetaThinkingBlock Create(
        Messages::BetaThinkingBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaRedactedThinkingBlock Create(
        Messages::BetaRedactedThinkingBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaToolUseBlock Create(Messages::BetaToolUseBlock value) =>
        new(value);

    public static ContentBlockVariants::BetaServerToolUseBlock Create(
        Messages::BetaServerToolUseBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaWebSearchToolResultBlock Create(
        Messages::BetaWebSearchToolResultBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaCodeExecutionToolResultBlock Create(
        Messages::BetaCodeExecutionToolResultBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaMCPToolUseBlock Create(
        Messages::BetaMCPToolUseBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaMCPToolResultBlock Create(
        Messages::BetaMCPToolResultBlock value
    ) => new(value);

    public static ContentBlockVariants::BetaContainerUploadBlock Create(
        Messages::BetaContainerUploadBlock value
    ) => new(value);

    public abstract void Validate();
}
