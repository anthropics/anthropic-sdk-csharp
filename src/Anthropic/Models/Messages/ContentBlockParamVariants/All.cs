using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(VariantConverter<TextBlockParamVariant, TextBlockParam>))]
public sealed record class TextBlockParamVariant(TextBlockParam Value)
    : ContentBlockParam,
        IVariant<TextBlockParamVariant, TextBlockParam>
{
    public static TextBlockParamVariant From(TextBlockParam value)
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
[JsonConverter(typeof(VariantConverter<ImageBlockParamVariant, ImageBlockParam>))]
public sealed record class ImageBlockParamVariant(ImageBlockParam Value)
    : ContentBlockParam,
        IVariant<ImageBlockParamVariant, ImageBlockParam>
{
    public static ImageBlockParamVariant From(ImageBlockParam value)
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
[JsonConverter(typeof(VariantConverter<DocumentBlockParamVariant, DocumentBlockParam>))]
public sealed record class DocumentBlockParamVariant(DocumentBlockParam Value)
    : ContentBlockParam,
        IVariant<DocumentBlockParamVariant, DocumentBlockParam>
{
    public static DocumentBlockParamVariant From(DocumentBlockParam value)
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
[JsonConverter(typeof(VariantConverter<ThinkingBlockParamVariant, ThinkingBlockParam>))]
public sealed record class ThinkingBlockParamVariant(ThinkingBlockParam Value)
    : ContentBlockParam,
        IVariant<ThinkingBlockParamVariant, ThinkingBlockParam>
{
    public static ThinkingBlockParamVariant From(ThinkingBlockParam value)
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
[JsonConverter(
    typeof(VariantConverter<RedactedThinkingBlockParamVariant, RedactedThinkingBlockParam>)
)]
public sealed record class RedactedThinkingBlockParamVariant(RedactedThinkingBlockParam Value)
    : ContentBlockParam,
        IVariant<RedactedThinkingBlockParamVariant, RedactedThinkingBlockParam>
{
    public static RedactedThinkingBlockParamVariant From(RedactedThinkingBlockParam value)
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
[JsonConverter(typeof(VariantConverter<ToolUseBlockParamVariant, ToolUseBlockParam>))]
public sealed record class ToolUseBlockParamVariant(ToolUseBlockParam Value)
    : ContentBlockParam,
        IVariant<ToolUseBlockParamVariant, ToolUseBlockParam>
{
    public static ToolUseBlockParamVariant From(ToolUseBlockParam value)
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
[JsonConverter(typeof(VariantConverter<ToolResultBlockParamVariant, ToolResultBlockParam>))]
public sealed record class ToolResultBlockParamVariant(ToolResultBlockParam Value)
    : ContentBlockParam,
        IVariant<ToolResultBlockParamVariant, ToolResultBlockParam>
{
    public static ToolResultBlockParamVariant From(ToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ServerToolUseBlockParamVariant, ServerToolUseBlockParam>))]
public sealed record class ServerToolUseBlockParamVariant(ServerToolUseBlockParam Value)
    : ContentBlockParam,
        IVariant<ServerToolUseBlockParamVariant, ServerToolUseBlockParam>
{
    public static ServerToolUseBlockParamVariant From(ServerToolUseBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<WebSearchToolResultBlockParamVariant, WebSearchToolResultBlockParam>)
)]
public sealed record class WebSearchToolResultBlockParamVariant(WebSearchToolResultBlockParam Value)
    : ContentBlockParam,
        IVariant<WebSearchToolResultBlockParamVariant, WebSearchToolResultBlockParam>
{
    public static WebSearchToolResultBlockParamVariant From(WebSearchToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
