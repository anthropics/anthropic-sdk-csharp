using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
public sealed record class TextBlockParamVariant(Messages::TextBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<TextBlockParamVariant, Messages::TextBlockParam>
{
    public static TextBlockParamVariant From(Messages::TextBlockParam value)
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
public sealed record class ImageBlockParamVariant(Messages::ImageBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ImageBlockParamVariant, Messages::ImageBlockParam>
{
    public static ImageBlockParamVariant From(Messages::ImageBlockParam value)
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
public sealed record class DocumentBlockParamVariant(Messages::DocumentBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<DocumentBlockParamVariant, Messages::DocumentBlockParam>
{
    public static DocumentBlockParamVariant From(Messages::DocumentBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A search result block containing source, title, and content from search operations.
/// </summary>
public sealed record class SearchResultBlockParamVariant(Messages::SearchResultBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<SearchResultBlockParamVariant, Messages::SearchResultBlockParam>
{
    public static SearchResultBlockParamVariant From(Messages::SearchResultBlockParam value)
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
public sealed record class ThinkingBlockParamVariant(Messages::ThinkingBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ThinkingBlockParamVariant, Messages::ThinkingBlockParam>
{
    public static ThinkingBlockParamVariant From(Messages::ThinkingBlockParam value)
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
public sealed record class RedactedThinkingBlockParamVariant(
    Messages::RedactedThinkingBlockParam Value
)
    : Messages::ContentBlockParam,
        IVariant<RedactedThinkingBlockParamVariant, Messages::RedactedThinkingBlockParam>
{
    public static RedactedThinkingBlockParamVariant From(Messages::RedactedThinkingBlockParam value)
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
public sealed record class ToolUseBlockParamVariant(Messages::ToolUseBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ToolUseBlockParamVariant, Messages::ToolUseBlockParam>
{
    public static ToolUseBlockParamVariant From(Messages::ToolUseBlockParam value)
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
public sealed record class ToolResultBlockParamVariant(Messages::ToolResultBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ToolResultBlockParamVariant, Messages::ToolResultBlockParam>
{
    public static ToolResultBlockParamVariant From(Messages::ToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ServerToolUseBlockParamVariant(Messages::ServerToolUseBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ServerToolUseBlockParamVariant, Messages::ServerToolUseBlockParam>
{
    public static ServerToolUseBlockParamVariant From(Messages::ServerToolUseBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebSearchToolResultBlockParamVariant(
    Messages::WebSearchToolResultBlockParam Value
)
    : Messages::ContentBlockParam,
        IVariant<WebSearchToolResultBlockParamVariant, Messages::WebSearchToolResultBlockParam>
{
    public static WebSearchToolResultBlockParamVariant From(
        Messages::WebSearchToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
