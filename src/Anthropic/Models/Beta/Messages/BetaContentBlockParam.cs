using Anthropic = Anthropic;
using BetaContentBlockParamVariants = Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaContentBlockParam>))]
public abstract record class BetaContentBlockParam
{
    internal BetaContentBlockParam() { }

    public static BetaContentBlockParamVariants::BetaTextBlockParam Create(
        BetaTextBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaImageBlockParam Create(
        BetaImageBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaRequestDocumentBlock Create(
        BetaRequestDocumentBlock value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaSearchResultBlockParam Create(
        BetaSearchResultBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaThinkingBlockParam Create(
        BetaThinkingBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam Create(
        BetaRedactedThinkingBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaToolUseBlockParam Create(
        BetaToolUseBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaToolResultBlockParam Create(
        BetaToolResultBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaServerToolUseBlockParam Create(
        BetaServerToolUseBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam Create(
        BetaWebSearchToolResultBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam Create(
        BetaCodeExecutionToolResultBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaMCPToolUseBlockParam Create(
        BetaMCPToolUseBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam Create(
        BetaRequestMCPToolResultBlockParam value
    ) => new(value);

    public static BetaContentBlockParamVariants::BetaContainerUploadBlockParam Create(
        BetaContainerUploadBlockParam value
    ) => new(value);

    public abstract void Validate();
}
