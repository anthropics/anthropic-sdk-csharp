using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaTextBlockParam, Messages::BetaTextBlockParam>)
)]
public sealed record class BetaTextBlockParam(Messages::BetaTextBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaTextBlockParam, Messages::BetaTextBlockParam>
{
    public static BetaTextBlockParam From(Messages::BetaTextBlockParam value)
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
    typeof(Anthropic::VariantConverter<BetaImageBlockParam, Messages::BetaImageBlockParam>)
)]
public sealed record class BetaImageBlockParam(Messages::BetaImageBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaImageBlockParam, Messages::BetaImageBlockParam>
{
    public static BetaImageBlockParam From(Messages::BetaImageBlockParam value)
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
    typeof(Anthropic::VariantConverter<
        BetaRequestDocumentBlock,
        Messages::BetaRequestDocumentBlock
    >)
)]
public sealed record class BetaRequestDocumentBlock(Messages::BetaRequestDocumentBlock Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaRequestDocumentBlock, Messages::BetaRequestDocumentBlock>
{
    public static BetaRequestDocumentBlock From(Messages::BetaRequestDocumentBlock value)
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
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaSearchResultBlockParam,
        Messages::BetaSearchResultBlockParam
    >)
)]
public sealed record class BetaSearchResultBlockParam(Messages::BetaSearchResultBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaSearchResultBlockParam, Messages::BetaSearchResultBlockParam>
{
    public static BetaSearchResultBlockParam From(Messages::BetaSearchResultBlockParam value)
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
    typeof(Anthropic::VariantConverter<BetaThinkingBlockParam, Messages::BetaThinkingBlockParam>)
)]
public sealed record class BetaThinkingBlockParam(Messages::BetaThinkingBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaThinkingBlockParam, Messages::BetaThinkingBlockParam>
{
    public static BetaThinkingBlockParam From(Messages::BetaThinkingBlockParam value)
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
        BetaRedactedThinkingBlockParam,
        Messages::BetaRedactedThinkingBlockParam
    >)
)]
public sealed record class BetaRedactedThinkingBlockParam(
    Messages::BetaRedactedThinkingBlockParam Value
)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<
            BetaRedactedThinkingBlockParam,
            Messages::BetaRedactedThinkingBlockParam
        >
{
    public static BetaRedactedThinkingBlockParam From(
        Messages::BetaRedactedThinkingBlockParam value
    )
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
    typeof(Anthropic::VariantConverter<BetaToolUseBlockParam, Messages::BetaToolUseBlockParam>)
)]
public sealed record class BetaToolUseBlockParam(Messages::BetaToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaToolUseBlockParam, Messages::BetaToolUseBlockParam>
{
    public static BetaToolUseBlockParam From(Messages::BetaToolUseBlockParam value)
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
    typeof(Anthropic::VariantConverter<
        BetaToolResultBlockParam,
        Messages::BetaToolResultBlockParam
    >)
)]
public sealed record class BetaToolResultBlockParam(Messages::BetaToolResultBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaToolResultBlockParam, Messages::BetaToolResultBlockParam>
{
    public static BetaToolResultBlockParam From(Messages::BetaToolResultBlockParam value)
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
        BetaServerToolUseBlockParam,
        Messages::BetaServerToolUseBlockParam
    >)
)]
public sealed record class BetaServerToolUseBlockParam(Messages::BetaServerToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaServerToolUseBlockParam, Messages::BetaServerToolUseBlockParam>
{
    public static BetaServerToolUseBlockParam From(Messages::BetaServerToolUseBlockParam value)
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
        BetaWebSearchToolResultBlockParam,
        Messages::BetaWebSearchToolResultBlockParam
    >)
)]
public sealed record class BetaWebSearchToolResultBlockParam(
    Messages::BetaWebSearchToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<
            BetaWebSearchToolResultBlockParam,
            Messages::BetaWebSearchToolResultBlockParam
        >
{
    public static BetaWebSearchToolResultBlockParam From(
        Messages::BetaWebSearchToolResultBlockParam value
    )
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
        BetaCodeExecutionToolResultBlockParam,
        Messages::BetaCodeExecutionToolResultBlockParam
    >)
)]
public sealed record class BetaCodeExecutionToolResultBlockParam(
    Messages::BetaCodeExecutionToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<
            BetaCodeExecutionToolResultBlockParam,
            Messages::BetaCodeExecutionToolResultBlockParam
        >
{
    public static BetaCodeExecutionToolResultBlockParam From(
        Messages::BetaCodeExecutionToolResultBlockParam value
    )
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
        BetaMCPToolUseBlockParam,
        Messages::BetaMCPToolUseBlockParam
    >)
)]
public sealed record class BetaMCPToolUseBlockParam(Messages::BetaMCPToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaMCPToolUseBlockParam, Messages::BetaMCPToolUseBlockParam>
{
    public static BetaMCPToolUseBlockParam From(Messages::BetaMCPToolUseBlockParam value)
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
        BetaRequestMCPToolResultBlockParam,
        Messages::BetaRequestMCPToolResultBlockParam
    >)
)]
public sealed record class BetaRequestMCPToolResultBlockParam(
    Messages::BetaRequestMCPToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<
            BetaRequestMCPToolResultBlockParam,
            Messages::BetaRequestMCPToolResultBlockParam
        >
{
    public static BetaRequestMCPToolResultBlockParam From(
        Messages::BetaRequestMCPToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A content block that represents a file to be uploaded to the container Files uploaded
/// via this block will be available in the container's input directory.
/// </summary>
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaContainerUploadBlockParam,
        Messages::BetaContainerUploadBlockParam
    >)
)]
public sealed record class BetaContainerUploadBlockParam(
    Messages::BetaContainerUploadBlockParam Value
)
    : Messages::BetaContentBlockParam,
        Anthropic::IVariant<BetaContainerUploadBlockParam, Messages::BetaContainerUploadBlockParam>
{
    public static BetaContainerUploadBlockParam From(Messages::BetaContainerUploadBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
