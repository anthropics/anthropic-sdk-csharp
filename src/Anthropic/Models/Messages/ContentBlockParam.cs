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

    public static ContentBlockParamVariants::TextBlockParam Create(TextBlockParam value) =>
        new(value);

    public static ContentBlockParamVariants::ImageBlockParam Create(ImageBlockParam value) =>
        new(value);

    public static ContentBlockParamVariants::DocumentBlockParam Create(DocumentBlockParam value) =>
        new(value);

    public static ContentBlockParamVariants::ThinkingBlockParam Create(ThinkingBlockParam value) =>
        new(value);

    public static ContentBlockParamVariants::RedactedThinkingBlockParam Create(
        RedactedThinkingBlockParam value
    ) => new(value);

    public static ContentBlockParamVariants::ToolUseBlockParam Create(ToolUseBlockParam value) =>
        new(value);

    public static ContentBlockParamVariants::ToolResultBlockParam Create(
        ToolResultBlockParam value
    ) => new(value);

    public static ContentBlockParamVariants::ServerToolUseBlockParam Create(
        ServerToolUseBlockParam value
    ) => new(value);

    public static ContentBlockParamVariants::WebSearchToolResultBlockParam Create(
        WebSearchToolResultBlockParam value
    ) => new(value);

    public abstract void Validate();
}
