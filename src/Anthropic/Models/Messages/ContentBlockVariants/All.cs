using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ContentBlockVariants;

public sealed record class TextBlockVariant(Messages::TextBlock Value)
    : Messages::ContentBlock,
        IVariant<TextBlockVariant, Messages::TextBlock>
{
    public static TextBlockVariant From(Messages::TextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThinkingBlockVariant(Messages::ThinkingBlock Value)
    : Messages::ContentBlock,
        IVariant<ThinkingBlockVariant, Messages::ThinkingBlock>
{
    public static ThinkingBlockVariant From(Messages::ThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RedactedThinkingBlockVariant(Messages::RedactedThinkingBlock Value)
    : Messages::ContentBlock,
        IVariant<RedactedThinkingBlockVariant, Messages::RedactedThinkingBlock>
{
    public static RedactedThinkingBlockVariant From(Messages::RedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolUseBlockVariant(Messages::ToolUseBlock Value)
    : Messages::ContentBlock,
        IVariant<ToolUseBlockVariant, Messages::ToolUseBlock>
{
    public static ToolUseBlockVariant From(Messages::ToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ServerToolUseBlockVariant(Messages::ServerToolUseBlock Value)
    : Messages::ContentBlock,
        IVariant<ServerToolUseBlockVariant, Messages::ServerToolUseBlock>
{
    public static ServerToolUseBlockVariant From(Messages::ServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebSearchToolResultBlockVariant(Messages::WebSearchToolResultBlock Value)
    : Messages::ContentBlock,
        IVariant<WebSearchToolResultBlockVariant, Messages::WebSearchToolResultBlock>
{
    public static WebSearchToolResultBlockVariant From(Messages::WebSearchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
