using System.Text.Json.Serialization;
using MessageCountTokensToolProperties = Anthropic.Models.Messages.MessageCountTokensToolProperties;

namespace Anthropic.Models.Messages.MessageCountTokensToolVariants;

[JsonConverter(typeof(VariantConverter<ToolVariant, Tool>))]
public sealed record class ToolVariant(Tool Value)
    : MessageCountTokensTool,
        IVariant<ToolVariant, Tool>
{
    public static ToolVariant From(Tool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ToolBash20250124Variant, ToolBash20250124>))]
public sealed record class ToolBash20250124Variant(ToolBash20250124 Value)
    : MessageCountTokensTool,
        IVariant<ToolBash20250124Variant, ToolBash20250124>
{
    public static ToolBash20250124Variant From(ToolBash20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ToolTextEditor20250124Variant, ToolTextEditor20250124>))]
public sealed record class ToolTextEditor20250124Variant(ToolTextEditor20250124 Value)
    : MessageCountTokensTool,
        IVariant<ToolTextEditor20250124Variant, ToolTextEditor20250124>
{
    public static ToolTextEditor20250124Variant From(ToolTextEditor20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        TextEditor20250429,
        MessageCountTokensToolProperties::TextEditor20250429
    >)
)]
public sealed record class TextEditor20250429(
    MessageCountTokensToolProperties::TextEditor20250429 Value
)
    : MessageCountTokensTool,
        IVariant<TextEditor20250429, MessageCountTokensToolProperties::TextEditor20250429>
{
    public static TextEditor20250429 From(
        MessageCountTokensToolProperties::TextEditor20250429 value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ToolTextEditor20250728Variant, ToolTextEditor20250728>))]
public sealed record class ToolTextEditor20250728Variant(ToolTextEditor20250728 Value)
    : MessageCountTokensTool,
        IVariant<ToolTextEditor20250728Variant, ToolTextEditor20250728>
{
    public static ToolTextEditor20250728Variant From(ToolTextEditor20250728 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<WebSearchTool20250305Variant, WebSearchTool20250305>))]
public sealed record class WebSearchTool20250305Variant(WebSearchTool20250305 Value)
    : MessageCountTokensTool,
        IVariant<WebSearchTool20250305Variant, WebSearchTool20250305>
{
    public static WebSearchTool20250305Variant From(WebSearchTool20250305 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
