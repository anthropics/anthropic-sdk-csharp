using Anthropic = Anthropic;
using ContentBlockVariants = Anthropic.Models.Messages.ContentBlockVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlock>))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static ContentBlockVariants::TextBlock Create(TextBlock value) => new(value);

    public static ContentBlockVariants::ThinkingBlock Create(ThinkingBlock value) => new(value);

    public static ContentBlockVariants::RedactedThinkingBlock Create(RedactedThinkingBlock value) =>
        new(value);

    public static ContentBlockVariants::ToolUseBlock Create(ToolUseBlock value) => new(value);

    public static ContentBlockVariants::ServerToolUseBlock Create(ServerToolUseBlock value) =>
        new(value);

    public static ContentBlockVariants::WebSearchToolResultBlock Create(
        WebSearchToolResultBlock value
    ) => new(value);

    public abstract void Validate();
}
