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

    public static implicit operator BetaContentBlockParam(BetaTextBlockParam value) =>
        new BetaContentBlockParamVariants::BetaTextBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaImageBlockParam value) =>
        new BetaContentBlockParamVariants::BetaImageBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaRequestDocumentBlock value) =>
        new BetaContentBlockParamVariants::BetaRequestDocumentBlock(value);

    public static implicit operator BetaContentBlockParam(BetaSearchResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaSearchResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaThinkingBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaRedactedThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaRedactedThinkingBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolUseBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaToolResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaServerToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaServerToolUseBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaWebSearchToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaMCPToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaMCPToolUseBlockParam(value);

    public static implicit operator BetaContentBlockParam(
        BetaRequestMCPToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParam(value);

    public static implicit operator BetaContentBlockParam(BetaContainerUploadBlockParam value) =>
        new BetaContentBlockParamVariants::BetaContainerUploadBlockParam(value);

    public abstract void Validate();
}
