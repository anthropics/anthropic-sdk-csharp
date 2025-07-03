using Anthropic = Anthropic;
using Messages = Anthropic.Models.Messages;
using RawContentBlockStartEventProperties = Anthropic.Models.Messages.RawContentBlockStartEventProperties;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;

[Serialization::JsonConverter(typeof(Anthropic::VariantConverter<TextBlock, Messages::TextBlock>))]
public sealed record class TextBlock(Messages::TextBlock Value)
    : RawContentBlockStartEventProperties::ContentBlock,
        Anthropic::IVariant<TextBlock, Messages::TextBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ThinkingBlock, Messages::ThinkingBlock>)
)]
public sealed record class ThinkingBlock(Messages::ThinkingBlock Value)
    : RawContentBlockStartEventProperties::ContentBlock,
        Anthropic::IVariant<ThinkingBlock, Messages::ThinkingBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<RedactedThinkingBlock, Messages::RedactedThinkingBlock>)
)]
public sealed record class RedactedThinkingBlock(Messages::RedactedThinkingBlock Value)
    : RawContentBlockStartEventProperties::ContentBlock,
        Anthropic::IVariant<RedactedThinkingBlock, Messages::RedactedThinkingBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ToolUseBlock, Messages::ToolUseBlock>)
)]
public sealed record class ToolUseBlock(Messages::ToolUseBlock Value)
    : RawContentBlockStartEventProperties::ContentBlock,
        Anthropic::IVariant<ToolUseBlock, Messages::ToolUseBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ServerToolUseBlock, Messages::ServerToolUseBlock>)
)]
public sealed record class ServerToolUseBlock(Messages::ServerToolUseBlock Value)
    : RawContentBlockStartEventProperties::ContentBlock,
        Anthropic::IVariant<ServerToolUseBlock, Messages::ServerToolUseBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        WebSearchToolResultBlock,
        Messages::WebSearchToolResultBlock
    >)
)]
public sealed record class WebSearchToolResultBlock(Messages::WebSearchToolResultBlock Value)
    : RawContentBlockStartEventProperties::ContentBlock,
        Anthropic::IVariant<WebSearchToolResultBlock, Messages::WebSearchToolResultBlock>
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
