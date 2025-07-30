using System.Text.Json.Serialization;
using MessageCountTokensToolVariants = Anthropic.Models.Messages.MessageCountTokensToolVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<MessageCountTokensTool>))]
public abstract record class MessageCountTokensTool
{
    internal MessageCountTokensTool() { }

    public static implicit operator MessageCountTokensTool(Tool value) =>
        new MessageCountTokensToolVariants::ToolVariant(value);

    public static implicit operator MessageCountTokensTool(ToolBash20250124 value) =>
        new MessageCountTokensToolVariants::ToolBash20250124Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250124 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250124Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250429 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250429Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250728 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250728Variant(value);

    public static implicit operator MessageCountTokensTool(WebSearchTool20250305 value) =>
        new MessageCountTokensToolVariants::WebSearchTool20250305Variant(value);

    public abstract void Validate();
}
