using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.ContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
public sealed record class TextBlockParam(Messages::TextBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<TextBlockParam, Messages::TextBlockParam>
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
public sealed record class ImageBlockParam(Messages::ImageBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ImageBlockParam, Messages::ImageBlockParam>
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
public sealed record class DocumentBlockParam(Messages::DocumentBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<DocumentBlockParam, Messages::DocumentBlockParam>
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
/// A search result block containing source, title, and content from search operations.
/// </summary>
public sealed record class SearchResultBlockParam(Messages::SearchResultBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<SearchResultBlockParam, Messages::SearchResultBlockParam>
{
    public static SearchResultBlockParam From(Messages::SearchResultBlockParam value)
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
public sealed record class ThinkingBlockParam(Messages::ThinkingBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ThinkingBlockParam, Messages::ThinkingBlockParam>
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
public sealed record class RedactedThinkingBlockParam(Messages::RedactedThinkingBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<RedactedThinkingBlockParam, Messages::RedactedThinkingBlockParam>
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
public sealed record class ToolUseBlockParam(Messages::ToolUseBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ToolUseBlockParam, Messages::ToolUseBlockParam>
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
public sealed record class ToolResultBlockParam(Messages::ToolResultBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ToolResultBlockParam, Messages::ToolResultBlockParam>
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

public sealed record class ServerToolUseBlockParam(Messages::ServerToolUseBlockParam Value)
    : Messages::ContentBlockParam,
        IVariant<ServerToolUseBlockParam, Messages::ServerToolUseBlockParam>
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

public sealed record class WebSearchToolResultBlockParam(
    Messages::WebSearchToolResultBlockParam Value
)
    : Messages::ContentBlockParam,
        IVariant<WebSearchToolResultBlockParam, Messages::WebSearchToolResultBlockParam>
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
