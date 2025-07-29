using Anthropic = Anthropic;
using ContentBlockVariants = Anthropic.Models.Messages.ContentBlockVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(TextBlock value) =>
        new ContentBlockVariants::TextBlock(value);

    public static implicit operator ContentBlock(ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlock(value);

    public static implicit operator ContentBlock(RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlock(value);

    public static implicit operator ContentBlock(ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlock(value);

    public static implicit operator ContentBlock(ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlock(value);

    public static implicit operator ContentBlock(WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlock(value);

    public abstract void Validate();
}
