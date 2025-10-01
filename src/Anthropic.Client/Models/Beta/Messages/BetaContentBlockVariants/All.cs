using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaContentBlockVariants;

public sealed record class BetaTextBlock(Messages::BetaTextBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaTextBlock, Messages::BetaTextBlock>
{
    public static BetaTextBlock From(Messages::BetaTextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingBlock(Messages::BetaThinkingBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaThinkingBlock, Messages::BetaThinkingBlock>
{
    public static BetaThinkingBlock From(Messages::BetaThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRedactedThinkingBlock(Messages::BetaRedactedThinkingBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaRedactedThinkingBlock, Messages::BetaRedactedThinkingBlock>
{
    public static BetaRedactedThinkingBlock From(Messages::BetaRedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolUseBlock(Messages::BetaToolUseBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaToolUseBlock, Messages::BetaToolUseBlock>
{
    public static BetaToolUseBlock From(Messages::BetaToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaServerToolUseBlock(Messages::BetaServerToolUseBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaServerToolUseBlock, Messages::BetaServerToolUseBlock>
{
    public static BetaServerToolUseBlock From(Messages::BetaServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchToolResultBlock(
    Messages::BetaWebSearchToolResultBlock Value
)
    : Messages::BetaContentBlock,
        IVariant<BetaWebSearchToolResultBlock, Messages::BetaWebSearchToolResultBlock>
{
    public static BetaWebSearchToolResultBlock From(Messages::BetaWebSearchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebFetchToolResultBlock(Messages::BetaWebFetchToolResultBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaWebFetchToolResultBlock, Messages::BetaWebFetchToolResultBlock>
{
    public static BetaWebFetchToolResultBlock From(Messages::BetaWebFetchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionToolResultBlock(
    Messages::BetaCodeExecutionToolResultBlock Value
)
    : Messages::BetaContentBlock,
        IVariant<BetaCodeExecutionToolResultBlock, Messages::BetaCodeExecutionToolResultBlock>
{
    public static BetaCodeExecutionToolResultBlock From(
        Messages::BetaCodeExecutionToolResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaBashCodeExecutionToolResultBlock(
    Messages::BetaBashCodeExecutionToolResultBlock Value
)
    : Messages::BetaContentBlock,
        IVariant<
            BetaBashCodeExecutionToolResultBlock,
            Messages::BetaBashCodeExecutionToolResultBlock
        >
{
    public static BetaBashCodeExecutionToolResultBlock From(
        Messages::BetaBashCodeExecutionToolResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionToolResultBlock(
    Messages::BetaTextEditorCodeExecutionToolResultBlock Value
)
    : Messages::BetaContentBlock,
        IVariant<
            BetaTextEditorCodeExecutionToolResultBlock,
            Messages::BetaTextEditorCodeExecutionToolResultBlock
        >
{
    public static BetaTextEditorCodeExecutionToolResultBlock From(
        Messages::BetaTextEditorCodeExecutionToolResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMCPToolUseBlock(Messages::BetaMCPToolUseBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaMCPToolUseBlock, Messages::BetaMCPToolUseBlock>
{
    public static BetaMCPToolUseBlock From(Messages::BetaMCPToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMCPToolResultBlock(Messages::BetaMCPToolResultBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaMCPToolResultBlock, Messages::BetaMCPToolResultBlock>
{
    public static BetaMCPToolResultBlock From(Messages::BetaMCPToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
public sealed record class BetaContainerUploadBlock(Messages::BetaContainerUploadBlock Value)
    : Messages::BetaContentBlock,
        IVariant<BetaContainerUploadBlock, Messages::BetaContainerUploadBlock>
{
    public static BetaContainerUploadBlock From(Messages::BetaContainerUploadBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
