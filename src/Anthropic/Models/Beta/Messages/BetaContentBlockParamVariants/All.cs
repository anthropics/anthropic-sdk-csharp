using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(VariantConverter<BetaTextBlockParamVariant, BetaTextBlockParam>))]
public sealed record class BetaTextBlockParamVariant(BetaTextBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaTextBlockParamVariant, BetaTextBlockParam>
{
    public static BetaTextBlockParamVariant From(BetaTextBlockParam value)
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
[JsonConverter(typeof(VariantConverter<BetaImageBlockParamVariant, BetaImageBlockParam>))]
public sealed record class BetaImageBlockParamVariant(BetaImageBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaImageBlockParamVariant, BetaImageBlockParam>
{
    public static BetaImageBlockParamVariant From(BetaImageBlockParam value)
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
[JsonConverter(typeof(VariantConverter<BetaRequestDocumentBlockVariant, BetaRequestDocumentBlock>))]
public sealed record class BetaRequestDocumentBlockVariant(BetaRequestDocumentBlock Value)
    : BetaContentBlockParam,
        IVariant<BetaRequestDocumentBlockVariant, BetaRequestDocumentBlock>
{
    public static BetaRequestDocumentBlockVariant From(BetaRequestDocumentBlock value)
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
[JsonConverter(
    typeof(VariantConverter<BetaSearchResultBlockParamVariant, BetaSearchResultBlockParam>)
)]
public sealed record class BetaSearchResultBlockParamVariant(BetaSearchResultBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaSearchResultBlockParamVariant, BetaSearchResultBlockParam>
{
    public static BetaSearchResultBlockParamVariant From(BetaSearchResultBlockParam value)
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
[JsonConverter(typeof(VariantConverter<BetaThinkingBlockParamVariant, BetaThinkingBlockParam>))]
public sealed record class BetaThinkingBlockParamVariant(BetaThinkingBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaThinkingBlockParamVariant, BetaThinkingBlockParam>
{
    public static BetaThinkingBlockParamVariant From(BetaThinkingBlockParam value)
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
    typeof(VariantConverter<BetaRedactedThinkingBlockParamVariant, BetaRedactedThinkingBlockParam>)
)]
public sealed record class BetaRedactedThinkingBlockParamVariant(
    BetaRedactedThinkingBlockParam Value
)
    : BetaContentBlockParam,
        IVariant<BetaRedactedThinkingBlockParamVariant, BetaRedactedThinkingBlockParam>
{
    public static BetaRedactedThinkingBlockParamVariant From(BetaRedactedThinkingBlockParam value)
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
[JsonConverter(typeof(VariantConverter<BetaToolUseBlockParamVariant, BetaToolUseBlockParam>))]
public sealed record class BetaToolUseBlockParamVariant(BetaToolUseBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaToolUseBlockParamVariant, BetaToolUseBlockParam>
{
    public static BetaToolUseBlockParamVariant From(BetaToolUseBlockParam value)
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
[JsonConverter(typeof(VariantConverter<BetaToolResultBlockParamVariant, BetaToolResultBlockParam>))]
public sealed record class BetaToolResultBlockParamVariant(BetaToolResultBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaToolResultBlockParamVariant, BetaToolResultBlockParam>
{
    public static BetaToolResultBlockParamVariant From(BetaToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaServerToolUseBlockParamVariant, BetaServerToolUseBlockParam>)
)]
public sealed record class BetaServerToolUseBlockParamVariant(BetaServerToolUseBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaServerToolUseBlockParamVariant, BetaServerToolUseBlockParam>
{
    public static BetaServerToolUseBlockParamVariant From(BetaServerToolUseBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        BetaWebSearchToolResultBlockParamVariant,
        BetaWebSearchToolResultBlockParam
    >)
)]
public sealed record class BetaWebSearchToolResultBlockParamVariant(
    BetaWebSearchToolResultBlockParam Value
)
    : BetaContentBlockParam,
        IVariant<BetaWebSearchToolResultBlockParamVariant, BetaWebSearchToolResultBlockParam>
{
    public static BetaWebSearchToolResultBlockParamVariant From(
        BetaWebSearchToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        BetaCodeExecutionToolResultBlockParamVariant,
        BetaCodeExecutionToolResultBlockParam
    >)
)]
public sealed record class BetaCodeExecutionToolResultBlockParamVariant(
    BetaCodeExecutionToolResultBlockParam Value
)
    : BetaContentBlockParam,
        IVariant<
            BetaCodeExecutionToolResultBlockParamVariant,
            BetaCodeExecutionToolResultBlockParam
        >
{
    public static BetaCodeExecutionToolResultBlockParamVariant From(
        BetaCodeExecutionToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaMCPToolUseBlockParamVariant, BetaMCPToolUseBlockParam>))]
public sealed record class BetaMCPToolUseBlockParamVariant(BetaMCPToolUseBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaMCPToolUseBlockParamVariant, BetaMCPToolUseBlockParam>
{
    public static BetaMCPToolUseBlockParamVariant From(BetaMCPToolUseBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        BetaRequestMCPToolResultBlockParamVariant,
        BetaRequestMCPToolResultBlockParam
    >)
)]
public sealed record class BetaRequestMCPToolResultBlockParamVariant(
    BetaRequestMCPToolResultBlockParam Value
)
    : BetaContentBlockParam,
        IVariant<BetaRequestMCPToolResultBlockParamVariant, BetaRequestMCPToolResultBlockParam>
{
    public static BetaRequestMCPToolResultBlockParamVariant From(
        BetaRequestMCPToolResultBlockParam value
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
[JsonConverter(
    typeof(VariantConverter<BetaContainerUploadBlockParamVariant, BetaContainerUploadBlockParam>)
)]
public sealed record class BetaContainerUploadBlockParamVariant(BetaContainerUploadBlockParam Value)
    : BetaContentBlockParam,
        IVariant<BetaContainerUploadBlockParamVariant, BetaContainerUploadBlockParam>
{
    public static BetaContainerUploadBlockParamVariant From(BetaContainerUploadBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
