using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.MessageCountTokensToolVariants;

public sealed record class Tool(Messages::Tool Value)
    : Messages::MessageCountTokensTool,
        IVariant<Tool, Messages::Tool>
{
    public static Tool From(Messages::Tool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolBash20250124(Messages::ToolBash20250124 Value)
    : Messages::MessageCountTokensTool,
        IVariant<ToolBash20250124, Messages::ToolBash20250124>
{
    public static ToolBash20250124 From(Messages::ToolBash20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolTextEditor20250124(Messages::ToolTextEditor20250124 Value)
    : Messages::MessageCountTokensTool,
        IVariant<ToolTextEditor20250124, Messages::ToolTextEditor20250124>
{
    public static ToolTextEditor20250124 From(Messages::ToolTextEditor20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolTextEditor20250429(Messages::ToolTextEditor20250429 Value)
    : Messages::MessageCountTokensTool,
        IVariant<ToolTextEditor20250429, Messages::ToolTextEditor20250429>
{
    public static ToolTextEditor20250429 From(Messages::ToolTextEditor20250429 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolTextEditor20250728(Messages::ToolTextEditor20250728 Value)
    : Messages::MessageCountTokensTool,
        IVariant<ToolTextEditor20250728, Messages::ToolTextEditor20250728>
{
    public static ToolTextEditor20250728 From(Messages::ToolTextEditor20250728 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebSearchTool20250305(Messages::WebSearchTool20250305 Value)
    : Messages::MessageCountTokensTool,
        IVariant<WebSearchTool20250305, Messages::WebSearchTool20250305>
{
    public static WebSearchTool20250305 From(Messages::WebSearchTool20250305 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
