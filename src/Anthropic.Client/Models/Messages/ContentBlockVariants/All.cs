using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.ContentBlockVariants;

public sealed record class TextBlock(Messages::TextBlock Value)
    : Messages::ContentBlock,
        IVariant<TextBlock, Messages::TextBlock>
{
    public static TextBlock From(Messages::TextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThinkingBlock(Messages::ThinkingBlock Value)
    : Messages::ContentBlock,
        IVariant<ThinkingBlock, Messages::ThinkingBlock>
{
    public static ThinkingBlock From(Messages::ThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RedactedThinkingBlock(Messages::RedactedThinkingBlock Value)
    : Messages::ContentBlock,
        IVariant<RedactedThinkingBlock, Messages::RedactedThinkingBlock>
{
    public static RedactedThinkingBlock From(Messages::RedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ToolUseBlock(Messages::ToolUseBlock Value)
    : Messages::ContentBlock,
        IVariant<ToolUseBlock, Messages::ToolUseBlock>
{
    public static ToolUseBlock From(Messages::ToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ServerToolUseBlock(Messages::ServerToolUseBlock Value)
    : Messages::ContentBlock,
        IVariant<ServerToolUseBlock, Messages::ServerToolUseBlock>
{
    public static ServerToolUseBlock From(Messages::ServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebSearchToolResultBlock(Messages::WebSearchToolResultBlock Value)
    : Messages::ContentBlock,
        IVariant<WebSearchToolResultBlock, Messages::WebSearchToolResultBlock>
{
    public static WebSearchToolResultBlock From(Messages::WebSearchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
