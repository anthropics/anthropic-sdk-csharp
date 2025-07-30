using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Models.Messages.ContentBlockVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(TextBlock value) =>
        new ContentBlockVariants::TextBlockVariant(value);

    public static implicit operator ContentBlock(ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlockVariant(value);

    public static implicit operator ContentBlock(RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock(ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlockVariant(value);

    public static implicit operator ContentBlock(ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock(WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlockVariant(value);

    public abstract void Validate();
}
