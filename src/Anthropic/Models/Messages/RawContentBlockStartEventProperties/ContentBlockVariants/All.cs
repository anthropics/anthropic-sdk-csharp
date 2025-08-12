using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;

public sealed record class TextBlockVariant(Messages::TextBlock Value)
    : ContentBlock1,
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
    : ContentBlock1,
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
    : ContentBlock1,
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
    : ContentBlock1,
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
    : ContentBlock1,
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
    : ContentBlock1,
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
