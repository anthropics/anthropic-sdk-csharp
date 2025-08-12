using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ToolUnionVariants;

public sealed record class ToolVariant(Messages::Tool Value)
    : Messages::ToolUnion,
        IVariant<ToolVariant, Messages::Tool>
{
    public static ToolVariant From(Messages::Tool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolBash20250124Variant(Messages::ToolBash20250124 Value)
    : Messages::ToolUnion,
        IVariant<ToolBash20250124Variant, Messages::ToolBash20250124>
{
    public static ToolBash20250124Variant From(Messages::ToolBash20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolTextEditor20250124Variant(Messages::ToolTextEditor20250124 Value)
    : Messages::ToolUnion,
        IVariant<ToolTextEditor20250124Variant, Messages::ToolTextEditor20250124>
{
    public static ToolTextEditor20250124Variant From(Messages::ToolTextEditor20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolTextEditor20250429Variant(Messages::ToolTextEditor20250429 Value)
    : Messages::ToolUnion,
        IVariant<ToolTextEditor20250429Variant, Messages::ToolTextEditor20250429>
{
    public static ToolTextEditor20250429Variant From(Messages::ToolTextEditor20250429 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolTextEditor20250728Variant(Messages::ToolTextEditor20250728 Value)
    : Messages::ToolUnion,
        IVariant<ToolTextEditor20250728Variant, Messages::ToolTextEditor20250728>
{
    public static ToolTextEditor20250728Variant From(Messages::ToolTextEditor20250728 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebSearchTool20250305Variant(Messages::WebSearchTool20250305 Value)
    : Messages::ToolUnion,
        IVariant<WebSearchTool20250305Variant, Messages::WebSearchTool20250305>
{
    public static WebSearchTool20250305Variant From(Messages::WebSearchTool20250305 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
