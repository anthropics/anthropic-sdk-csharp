using Anthropic = Anthropic;
using ContentBlockVariants = Anthropic.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.RawContentBlockStartEventProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(Messages::TextBlock value) =>
        new ContentBlockVariants::TextBlock(value);

    public static implicit operator ContentBlock(Messages::ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlock(value);

    public static implicit operator ContentBlock(Messages::RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlock(value);

    public static implicit operator ContentBlock(Messages::ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlock(value);

    public abstract void Validate();
}
