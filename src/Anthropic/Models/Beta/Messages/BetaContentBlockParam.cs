using System.Text.Json.Serialization;
using BetaContentBlockParamVariants = Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(UnionConverter<BetaContentBlockParam>))]
public abstract record class BetaContentBlockParam
{
    internal BetaContentBlockParam() { }

    public static implicit operator BetaContentBlockParam(BetaTextBlockParam value) =>
        new BetaContentBlockParamVariants::BetaTextBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaImageBlockParam value) =>
        new BetaContentBlockParamVariants::BetaImageBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaRequestDocumentBlock value) =>
        new BetaContentBlockParamVariants::BetaRequestDocumentBlockVariant(value);

    public static implicit operator BetaContentBlockParam(BetaSearchResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaSearchResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaThinkingBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaRedactedThinkingBlockParam value) =>
        new BetaContentBlockParamVariants::BetaRedactedThinkingBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaToolResultBlockParam value) =>
        new BetaContentBlockParamVariants::BetaToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaServerToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaServerToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaWebSearchToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaWebSearchToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaCodeExecutionToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaCodeExecutionToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaMCPToolUseBlockParam value) =>
        new BetaContentBlockParamVariants::BetaMCPToolUseBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(
        BetaRequestMCPToolResultBlockParam value
    ) => new BetaContentBlockParamVariants::BetaRequestMCPToolResultBlockParamVariant(value);

    public static implicit operator BetaContentBlockParam(BetaContainerUploadBlockParam value) =>
        new BetaContentBlockParamVariants::BetaContainerUploadBlockParamVariant(value);

    public abstract void Validate();
}
