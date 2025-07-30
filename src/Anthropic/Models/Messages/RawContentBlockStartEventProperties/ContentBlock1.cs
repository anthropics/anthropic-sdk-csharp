using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;

namespace Anthropic.Models.Messages.RawContentBlockStartEventProperties;

[JsonConverter(typeof(UnionConverter<ContentBlock1>))]
public abstract record class ContentBlock1
{
    internal ContentBlock1() { }

    public static implicit operator ContentBlock1(TextBlock value) =>
        new ContentBlockVariants::TextBlockVariant(value);

    public static implicit operator ContentBlock1(ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlockVariant(value);

    public static implicit operator ContentBlock1(RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock1(ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlockVariant(value);

    public static implicit operator ContentBlock1(ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock1(WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlockVariant(value);

    public abstract void Validate();
}
