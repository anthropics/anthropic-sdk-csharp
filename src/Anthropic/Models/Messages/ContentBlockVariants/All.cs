using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ContentBlockVariants;

[JsonConverter(typeof(VariantConverter<TextBlockVariant, TextBlock>))]
public sealed record class TextBlockVariant(TextBlock Value)
    : ContentBlock,
        IVariant<TextBlockVariant, TextBlock>
{
    public static TextBlockVariant From(TextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ThinkingBlockVariant, ThinkingBlock>))]
public sealed record class ThinkingBlockVariant(ThinkingBlock Value)
    : ContentBlock,
        IVariant<ThinkingBlockVariant, ThinkingBlock>
{
    public static ThinkingBlockVariant From(ThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<RedactedThinkingBlockVariant, RedactedThinkingBlock>))]
public sealed record class RedactedThinkingBlockVariant(RedactedThinkingBlock Value)
    : ContentBlock,
        IVariant<RedactedThinkingBlockVariant, RedactedThinkingBlock>
{
    public static RedactedThinkingBlockVariant From(RedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ToolUseBlockVariant, ToolUseBlock>))]
public sealed record class ToolUseBlockVariant(ToolUseBlock Value)
    : ContentBlock,
        IVariant<ToolUseBlockVariant, ToolUseBlock>
{
    public static ToolUseBlockVariant From(ToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ServerToolUseBlockVariant, ServerToolUseBlock>))]
public sealed record class ServerToolUseBlockVariant(ServerToolUseBlock Value)
    : ContentBlock,
        IVariant<ServerToolUseBlockVariant, ServerToolUseBlock>
{
    public static ServerToolUseBlockVariant From(ServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<WebSearchToolResultBlockVariant, WebSearchToolResultBlock>))]
public sealed record class WebSearchToolResultBlockVariant(WebSearchToolResultBlock Value)
    : ContentBlock,
        IVariant<WebSearchToolResultBlockVariant, WebSearchToolResultBlock>
{
    public static WebSearchToolResultBlockVariant From(WebSearchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
