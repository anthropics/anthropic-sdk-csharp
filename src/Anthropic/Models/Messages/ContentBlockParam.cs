using Anthropic = Anthropic;
using ContentBlockParamVariants = Anthropic.Models.Messages.ContentBlockParamVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlockParam>))]
public abstract record class ContentBlockParam
{
    internal ContentBlockParam() { }

    public static implicit operator ContentBlockParam(TextBlockParam value) =>
        new ContentBlockParamVariants::TextBlockParam(value);

    public static implicit operator ContentBlockParam(ImageBlockParam value) =>
        new ContentBlockParamVariants::ImageBlockParam(value);

    public static implicit operator ContentBlockParam(DocumentBlockParam value) =>
        new ContentBlockParamVariants::DocumentBlockParam(value);

    public static implicit operator ContentBlockParam(ThinkingBlockParam value) =>
        new ContentBlockParamVariants::ThinkingBlockParam(value);

    public static implicit operator ContentBlockParam(RedactedThinkingBlockParam value) =>
        new ContentBlockParamVariants::RedactedThinkingBlockParam(value);

    public static implicit operator ContentBlockParam(ToolUseBlockParam value) =>
        new ContentBlockParamVariants::ToolUseBlockParam(value);

    public static implicit operator ContentBlockParam(ToolResultBlockParam value) =>
        new ContentBlockParamVariants::ToolResultBlockParam(value);

    public static implicit operator ContentBlockParam(ServerToolUseBlockParam value) =>
        new ContentBlockParamVariants::ServerToolUseBlockParam(value);

    public static implicit operator ContentBlockParam(WebSearchToolResultBlockParam value) =>
        new ContentBlockParamVariants::WebSearchToolResultBlockParam(value);

    public abstract void Validate();
}
