using Anthropic = Anthropic;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<TextBlockParam, Messages::TextBlockParam>)
)]
public sealed record class TextBlockParam(Messages::TextBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<TextBlockParam, Messages::TextBlockParam>
{
    public static TextBlockParam From(Messages::TextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Image content specified directly as base64 data or as a reference via a URL.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ImageBlockParam, Messages::ImageBlockParam>)
)]
public sealed record class ImageBlockParam(Messages::ImageBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<ImageBlockParam, Messages::ImageBlockParam>
{
    public static ImageBlockParam From(Messages::ImageBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Document content, either specified directly as base64 data, as text, or as a
/// reference via a URL.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<DocumentBlockParam, Messages::DocumentBlockParam>)
)]
public sealed record class DocumentBlockParam(Messages::DocumentBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<DocumentBlockParam, Messages::DocumentBlockParam>
{
    public static DocumentBlockParam From(Messages::DocumentBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A block specifying internal thinking by the model.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ThinkingBlockParam, Messages::ThinkingBlockParam>)
)]
public sealed record class ThinkingBlockParam(Messages::ThinkingBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<ThinkingBlockParam, Messages::ThinkingBlockParam>
{
    public static ThinkingBlockParam From(Messages::ThinkingBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A block specifying internal, redacted thinking by the model.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        RedactedThinkingBlockParam,
        Messages::RedactedThinkingBlockParam
    >)
)]
public sealed record class RedactedThinkingBlockParam(Messages::RedactedThinkingBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<RedactedThinkingBlockParam, Messages::RedactedThinkingBlockParam>
{
    public static RedactedThinkingBlockParam From(Messages::RedactedThinkingBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A block indicating a tool use by the model.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ToolUseBlockParam, Messages::ToolUseBlockParam>)
)]
public sealed record class ToolUseBlockParam(Messages::ToolUseBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<ToolUseBlockParam, Messages::ToolUseBlockParam>
{
    public static ToolUseBlockParam From(Messages::ToolUseBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A block specifying the results of a tool use by the model.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ToolResultBlockParam, Messages::ToolResultBlockParam>)
)]
public sealed record class ToolResultBlockParam(Messages::ToolResultBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<ToolResultBlockParam, Messages::ToolResultBlockParam>
{
    public static ToolResultBlockParam From(Messages::ToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<ServerToolUseBlockParam, Messages::ServerToolUseBlockParam>)
)]
public sealed record class ServerToolUseBlockParam(Messages::ServerToolUseBlockParam Value)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<ServerToolUseBlockParam, Messages::ServerToolUseBlockParam>
{
    public static ServerToolUseBlockParam From(Messages::ServerToolUseBlockParam value)
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
        WebSearchToolResultBlockParam,
        Messages::WebSearchToolResultBlockParam
    >)
)]
public sealed record class WebSearchToolResultBlockParam(
    Messages::WebSearchToolResultBlockParam Value
)
    : Messages::ContentBlockParam,
        Anthropic::IVariant<WebSearchToolResultBlockParam, Messages::WebSearchToolResultBlockParam>
{
    public static WebSearchToolResultBlockParam From(Messages::WebSearchToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
