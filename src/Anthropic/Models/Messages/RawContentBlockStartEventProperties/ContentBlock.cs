using Anthropic = Anthropic;
using ContentBlockVariants = Anthropic.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.RawContentBlockStartEventProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static ContentBlockVariants::TextBlock Create(Messages::TextBlock value) => new(value);

    public static ContentBlockVariants::ThinkingBlock Create(Messages::ThinkingBlock value) =>
        new(value);

    public static ContentBlockVariants::RedactedThinkingBlock Create(
        Messages::RedactedThinkingBlock value
    ) => new(value);

    public static ContentBlockVariants::ToolUseBlock Create(Messages::ToolUseBlock value) =>
        new(value);

    public static ContentBlockVariants::ServerToolUseBlock Create(
        Messages::ServerToolUseBlock value
    ) => new(value);

    public static ContentBlockVariants::WebSearchToolResultBlock Create(
        Messages::WebSearchToolResultBlock value
    ) => new(value);

    public abstract void Validate();
}
