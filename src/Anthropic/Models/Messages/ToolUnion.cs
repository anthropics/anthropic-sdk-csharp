using Anthropic = Anthropic;
using Serialization = System.Text.Json.Serialization;
using ToolUnionProperties = Anthropic.Models.Messages.ToolUnionProperties;
using ToolUnionVariants = Anthropic.Models.Messages.ToolUnionVariants;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ToolUnion>))]
public abstract record class ToolUnion
{
    internal ToolUnion() { }

    public static implicit operator ToolUnion(Tool value) => new ToolUnionVariants::Tool(value);

    public static implicit operator ToolUnion(ToolBash20250124 value) =>
        new ToolUnionVariants::ToolBash20250124(value);

    public static implicit operator ToolUnion(ToolTextEditor20250124 value) =>
        new ToolUnionVariants::ToolTextEditor20250124(value);

    public static implicit operator ToolUnion(ToolUnionProperties::TextEditor20250429 value) =>
        new ToolUnionVariants::TextEditor20250429(value);

    public static implicit operator ToolUnion(WebSearchTool20250305 value) =>
        new ToolUnionVariants::WebSearchTool20250305(value);

    public abstract void Validate();
}
