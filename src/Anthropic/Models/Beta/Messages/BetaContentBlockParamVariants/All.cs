using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
public sealed record class BetaTextBlockParamVariant(Messages::BetaTextBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaTextBlockParamVariant, Messages::BetaTextBlockParam>
{
    public static BetaTextBlockParamVariant From(Messages::BetaTextBlockParam value)
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
public sealed record class BetaImageBlockParamVariant(Messages::BetaImageBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaImageBlockParamVariant, Messages::BetaImageBlockParam>
{
    public static BetaImageBlockParamVariant From(Messages::BetaImageBlockParam value)
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
public sealed record class BetaRequestDocumentBlockVariant(Messages::BetaRequestDocumentBlock Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaRequestDocumentBlockVariant, Messages::BetaRequestDocumentBlock>
{
    public static BetaRequestDocumentBlockVariant From(Messages::BetaRequestDocumentBlock value)
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
public sealed record class BetaSearchResultBlockParamVariant(
    Messages::BetaSearchResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaSearchResultBlockParamVariant, Messages::BetaSearchResultBlockParam>
{
    public static BetaSearchResultBlockParamVariant From(Messages::BetaSearchResultBlockParam value)
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
public sealed record class BetaThinkingBlockParamVariant(Messages::BetaThinkingBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaThinkingBlockParamVariant, Messages::BetaThinkingBlockParam>
{
    public static BetaThinkingBlockParamVariant From(Messages::BetaThinkingBlockParam value)
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
public sealed record class BetaRedactedThinkingBlockParamVariant(
    Messages::BetaRedactedThinkingBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaRedactedThinkingBlockParamVariant, Messages::BetaRedactedThinkingBlockParam>
{
    public static BetaRedactedThinkingBlockParamVariant From(
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
public sealed record class BetaToolUseBlockParamVariant(Messages::BetaToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaToolUseBlockParamVariant, Messages::BetaToolUseBlockParam>
{
    public static BetaToolUseBlockParamVariant From(Messages::BetaToolUseBlockParam value)
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
public sealed record class BetaToolResultBlockParamVariant(Messages::BetaToolResultBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaToolResultBlockParamVariant, Messages::BetaToolResultBlockParam>
{
    public static BetaToolResultBlockParamVariant From(Messages::BetaToolResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaServerToolUseBlockParamVariant(
    Messages::BetaServerToolUseBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaServerToolUseBlockParamVariant, Messages::BetaServerToolUseBlockParam>
{
    public static BetaServerToolUseBlockParamVariant From(
        Messages::BetaServerToolUseBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchToolResultBlockParamVariant(
    Messages::BetaWebSearchToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<
            BetaWebSearchToolResultBlockParamVariant,
            Messages::BetaWebSearchToolResultBlockParam
        >
{
    public static BetaWebSearchToolResultBlockParamVariant From(
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

public sealed record class BetaCodeExecutionToolResultBlockParamVariant(
    Messages::BetaCodeExecutionToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<
            BetaCodeExecutionToolResultBlockParamVariant,
            Messages::BetaCodeExecutionToolResultBlockParam
        >
{
    public static BetaCodeExecutionToolResultBlockParamVariant From(
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

public sealed record class BetaMCPToolUseBlockParamVariant(Messages::BetaMCPToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaMCPToolUseBlockParamVariant, Messages::BetaMCPToolUseBlockParam>
{
    public static BetaMCPToolUseBlockParamVariant From(Messages::BetaMCPToolUseBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRequestMCPToolResultBlockParamVariant(
    Messages::BetaRequestMCPToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<
            BetaRequestMCPToolResultBlockParamVariant,
            Messages::BetaRequestMCPToolResultBlockParam
        >
{
    public static BetaRequestMCPToolResultBlockParamVariant From(
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
public sealed record class BetaContainerUploadBlockParamVariant(
    Messages::BetaContainerUploadBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaContainerUploadBlockParamVariant, Messages::BetaContainerUploadBlockParam>
{
    public static BetaContainerUploadBlockParamVariant From(
        Messages::BetaContainerUploadBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
