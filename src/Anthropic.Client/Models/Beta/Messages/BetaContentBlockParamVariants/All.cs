using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaContentBlockParamVariants;

/// <summary>
/// Regular text content.
/// </summary>
public sealed record class BetaTextBlockParam(Messages::BetaTextBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaTextBlockParam, Messages::BetaTextBlockParam>
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
public sealed record class BetaImageBlockParam(Messages::BetaImageBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaImageBlockParam, Messages::BetaImageBlockParam>
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
public sealed record class BetaRequestDocumentBlock(Messages::BetaRequestDocumentBlock Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaRequestDocumentBlock, Messages::BetaRequestDocumentBlock>
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
public sealed record class BetaSearchResultBlockParam(Messages::BetaSearchResultBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaSearchResultBlockParam, Messages::BetaSearchResultBlockParam>
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
public sealed record class BetaThinkingBlockParam(Messages::BetaThinkingBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaThinkingBlockParam, Messages::BetaThinkingBlockParam>
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
public sealed record class BetaRedactedThinkingBlockParam(
    Messages::BetaRedactedThinkingBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaRedactedThinkingBlockParam, Messages::BetaRedactedThinkingBlockParam>
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
public sealed record class BetaToolUseBlockParam(Messages::BetaToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaToolUseBlockParam, Messages::BetaToolUseBlockParam>
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
public sealed record class BetaToolResultBlockParam(Messages::BetaToolResultBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaToolResultBlockParam, Messages::BetaToolResultBlockParam>
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

public sealed record class BetaServerToolUseBlockParam(Messages::BetaServerToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaServerToolUseBlockParam, Messages::BetaServerToolUseBlockParam>
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

public sealed record class BetaWebSearchToolResultBlockParam(
    Messages::BetaWebSearchToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaWebSearchToolResultBlockParam, Messages::BetaWebSearchToolResultBlockParam>
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

public sealed record class BetaWebFetchToolResultBlockParam(
    Messages::BetaWebFetchToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaWebFetchToolResultBlockParam, Messages::BetaWebFetchToolResultBlockParam>
{
    public static BetaWebFetchToolResultBlockParam From(
        Messages::BetaWebFetchToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionToolResultBlockParam(
    Messages::BetaCodeExecutionToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<
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

public sealed record class BetaBashCodeExecutionToolResultBlockParam(
    Messages::BetaBashCodeExecutionToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<
            BetaBashCodeExecutionToolResultBlockParam,
            Messages::BetaBashCodeExecutionToolResultBlockParam
        >
{
    public static BetaBashCodeExecutionToolResultBlockParam From(
        Messages::BetaBashCodeExecutionToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionToolResultBlockParam(
    Messages::BetaTextEditorCodeExecutionToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<
            BetaTextEditorCodeExecutionToolResultBlockParam,
            Messages::BetaTextEditorCodeExecutionToolResultBlockParam
        >
{
    public static BetaTextEditorCodeExecutionToolResultBlockParam From(
        Messages::BetaTextEditorCodeExecutionToolResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMCPToolUseBlockParam(Messages::BetaMCPToolUseBlockParam Value)
    : Messages::BetaContentBlockParam,
        IVariant<BetaMCPToolUseBlockParam, Messages::BetaMCPToolUseBlockParam>
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

public sealed record class BetaRequestMCPToolResultBlockParam(
    Messages::BetaRequestMCPToolResultBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaRequestMCPToolResultBlockParam, Messages::BetaRequestMCPToolResultBlockParam>
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
public sealed record class BetaContainerUploadBlockParam(
    Messages::BetaContainerUploadBlockParam Value
)
    : Messages::BetaContentBlockParam,
        IVariant<BetaContainerUploadBlockParam, Messages::BetaContainerUploadBlockParam>
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
